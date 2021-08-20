Imports System.ComponentModel
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework.KioskException
Imports CBLabelPrinterBLL.CB.Bartender.Logic
Imports CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.PrintServer
Imports Seagull.BarTender.PrintServer.Tasks
Imports Seagull.Services.PrintScheduler

Namespace CB.Bartender.Models

    ''' <summary>
    ''' Label Print Controller Class
    ''' Author: Brian Kinser
    ''' Date: 8/13/2020
    ''' Purpose: This allows the user to open a format, select a printer, set substrings, and print.
    '''
    ''' This is intended to:
    '''  -Generate quick thumbnails without first opening a format in BarTender.
    '''  -Open a Format in BarTender.
    '''  -Get a list of printers and set the printer on a format.
    '''  -Set a DataGridView to use the SubStrings collection as a DataSource.
    '''  -Get and Set the number of serialized copies and the number of identical copies.
    '''  -Start and Stop a BarTender engine.
    ''' </summary>
    Public Class LabelPrint

#Region "Fields"
        ' Common strings.
        Private Const appName As String = "CB Warehouse Label Print"
        Private Const dataSourced As String = "Data Sourced"

        Private engine As Engine = Nothing ' The BarTender Print Engine
        Private format As LabelFormatDocument = Nothing ' The currently open Format
        Private isClosing As Boolean = False ' Set to true if we are closing. This helps discontinue thumbnail loading.

        ' Label browser
        Private browsingFormats() As String ' The list of filenames in the current folder
        Private listItems As Hashtable ' A hash table containing ListViewItems and indexed by format name.
        Private subStringDataset As DataSet
        ' It keeps track of what formats have had their image loaded.
        Private generationQueue As Queue(Of Integer) ' A queue containing indexes into browsingFormats
        ' to facilitate the generation of thumbnails

        ' Label browser indexes.
        Private topIndex As Integer ' The top visible index in the lstLabelBrowser
        Private selectedIndex As Integer ' The selected index in the lstLabelBrowser
        Private printerName As String ' Name of the printer
        Private docFileName As String ' full path of the doc
        Private messageList As List(Of String) = Nothing
#End Region

#Region "Constructor"
        ''' <summary>
        ''' Constructor
        ''' </summary>
        Public Sub New()
            'InitializeComponent()
        End Sub
#End Region

#Region "Enumerations"
        ' Indexes into our image list for the label browser.
        Private Enum ImageIndex
            LoadingFormatImage = 0
            FailureToLoadFormatImage = 1
        End Enum
#End Region

#Region "Methods"

        ''' <summary>
        ''' Creates a print preview by saving an image of the label to /Previews folder
        ''' </summary>
        ''' <param name="_newPreviewfileName"></param>
        ''' <param name="_previewFolder"></param>
        ''' <param name="_docFilePath"></param>
        ''' <param name="_documentModel"></param>
        ''' <returns></returns>
        Public Function PrintPreview(_newPreviewfileName As String, _previewFolder As String,
                                     _docFilePath As String, _documentModel As PrintDocumentsViewModel) As PrintDocumentsViewModel

            Dim docModel As PrintDocumentsViewModel = New PrintDocumentsViewModel()
            Dim dt As DateTime = DateTime.Now
            Dim previewFolder As String = "/Previews/" '_previewFolder

            Dim fileName As String = $"{_newPreviewfileName}.png" ' & dt.Month & dt.Day & dt.Hour & dt.Minute  ' "yes.png"
            Dim paths As String() = New String() {previewFolder, fileName & ".png"}
            Dim fullPath As String = System.IO.Path.Combine(paths)

            Dim strBld As String = Nothing

            Dim strRet As String = "Failed"
            Dim folder As String = _previewFolder
            Dim btFormat As LabelFormatDocument
            Dim messages As Messages = Nothing

            Try
                Dim btEngine As New Engine()
                docModel = _documentModel
                ' Start the BarTender print engine. 
                btEngine.Start()

                ' Open the specified format. 
                btFormat = btEngine.Documents.Open(_docFilePath) '"c:\MyFormat.btw")

                ' Set the substrings grid.
                If btFormat.SubStrings.Count > 0 Then
                    Dim bindingSource As New DataSet() ' BindingSource()


                    bindingSource = btFormat.SubStrings
                    subStringDataset = bindingSource

                    'btFormat.SubStrings("ProdOrder").Value = _documentModel.ProdOrderNumber
                    btFormat.SubStrings("GTIN").Value = _documentModel.Gtin
                    btFormat.SubStrings("ProdDesc").Value = _documentModel.ProdDesc
                    btFormat.SubStrings("PriceCode").Value = _documentModel.PriceCode
                    btFormat.SubStrings("Pack_Size").Value = _documentModel.PackDesc
                    btFormat.SubStrings("Lot").Value = $"{_documentModel.ProdOrderNumber}{_documentModel.Lot}"
                    'btFormat.SubStrings("Lot").Value = _documentModel.Lot
                    btFormat.SubStrings("LineNo").Value = _documentModel.Line
                    btFormat.SubStrings("CodeDate").Value = _documentModel.CodeDate
                    btFormat.SubStrings("NewCodeDate").Value = _documentModel.CodeDate
                    btFormat.SubStrings("Version").Value = _documentModel.Version

                    '•	CodeDate
                    '•	GTIN
                    '•	LineNo
                    '•	Lot
                    '•	NewCodeDate
                    '•	Pack_Size
                    '•	PriceCode
                    '•	ProdDesc
                    '•	Version

                End If

                ' Export the label format's print preview image(s) to a file. 
                Dim results As Result = btFormat.ExportPrintPreviewToFile(folder, fileName, ImageType.JPEG, ColorDepth.ColorDepth256, New Resolution(96), Drawing.Color.Green, Seagull.BarTender.Print.OverwriteOptions.Overwrite, True, True, messages)

                If results = Result.Failure Then
                    docModel.Source = "Failed"
                    'strBld = $"Error creating the print preview in {folder} {fileName}"
                    'docModel.PrintMessages.Add($"Error creating the print preview file {fileName} in folder {folder} ")

                    If messages.Count >= 1 Then

                        'docModel.PrintMessages.Add(Message.Text)
                        For Each message As Message In messages
                            'My.Application.Log.WriteEntry(message.Text, TraceEventType.Error)
                            'strBld += message.Text + " "

                            docModel.PrintMessages.Add(message.Text)
                        Next

                    End If

                    'CreatedViewModelError(docModel, "LabelPrintClass-PrintPreview",
                    '                       $"Bartender PrintEngineException",
                    '                       KioskExceptionType.kioskError)
                Else
                    docModel.Source = $"{_newPreviewfileName}"
                    docModel.PrintMessages.Add("Preview Saved")
                    If messages.Count >= 1 Then

                        For Each message As Message In messages
                            docModel.PrintMessages.Add(message.Text)
                        Next

                    End If

                    'TODO delete after testing
                    'CreatedViewModelError(docModel, "LabelPrintClass-PrintPreview",
                    '                     "Preview message",
                    '                     KioskExceptionType.kioskInformation)

                End If

                ' Stop the BarTender print engine. 
                btEngine.Stop()


            Catch exception As PrintEngineException
                CreatedViewModelError(docModel, "LabelPrintClass-PrintPreview",
                                           $"Bartender PrintEngineException {exception.Message}",
                                           KioskExceptionType.kioskError)

            Catch comException As System.Runtime.InteropServices.COMException
                CreatedViewModelError(docModel, "LabelPrintClass-PrintPreview",
                                           $"Error in print preview: {comException.Message}",
                                           KioskExceptionType.kioskError)

            Catch ex As Exception
                CreatedViewModelError(docModel, "LabelPrintClass-PrintPreview",
                                           $"Error in print preview: {ex.Message}",
                                           KioskExceptionType.kioskError)

            End Try


            Return docModel

        End Function


        ''' <summary>
        ''' Called when the user prints the actual label.
        ''' Prints the loaded format using the selected printer.
        ''' </summary>
        Public Function PrintLabelNewest(ByVal _fileName As String,
                                         ByVal _viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel,
                                         ByVal _documentModel As WebLabelPrintDocument,
                                         ByVal _printerName As String) As PrintDocumentsViewModel

            Dim viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel = New PrintDocumentViewsModel.PrintDocumentsViewModel
            Dim msg As String = ""
            Dim msgs As List(Of String) = New List(Of String)
            Dim results = ""
            viewModel = _viewModel

            Try
                engine = New Engine(True)

                'set local variables
                printerName = _viewModel.SelectedServerPrinterName ' _printerName
                docFileName = _fileName

                SyncLock engine
                    Dim success As Boolean = True

                    If format IsNot Nothing Then
                        format.Close(SaveOptions.DoNotSaveChanges)
                        'TODO This would be bad, do throw error or something or return

                        msg = "Format was already open"
                        msgs.Add(msg)
                        viewModel.Source = "Failed"
                        viewModel.PrintMessages.Add(msg)
                        Return viewModel
                    ElseIf format Is Nothing Then
                        format = engine.Documents.Open(docFileName, printerName)
                        viewModel.FullPath = docFileName
                    End If


                    ' Assign number of identical copies if it is not datasourced.
                    If format.PrintSetup.SupportsIdenticalCopies = True Then
                        'TODO add variable for number of copies
                        Dim copies As Integer = viewModel.Copies
                        success = copies >= 1 ' Int32.TryParse(noCopies, copies) AndAlso (copies >= 1)
                        If (Not success) Then
                            results = "Identical Copies must be an integer greater than or equal to 1."
                            msgs.Add(results)
                            viewModel.Source = "Failed"
                            viewModel.PrintMessages.Add(results)
                            Return viewModel
                        Else
                            format.PrintSetup.IdenticalCopiesOfLabel = copies
                        End If
                    End If

                    ' Assign number of serialized copies if it is not datasourced.
                    If success AndAlso (format.PrintSetup.SupportsSerializedLabels = True) Then
                        Dim copies As Integer = 1
                        success = copies >= 1 ' Int32.TryParse(noCopies, copies) AndAlso (copies >= 1)
                        If (Not success) Then
                            results = "Serialized Copies must be an integer greater than or equal to 1."
                            msgs.Add(results)
                            viewModel.Source = "Failed"
                            viewModel.PrintMessages.Add(results)
                            Return viewModel
                        Else
                            format.PrintSetup.NumberOfSerializedLabels = copies
                        End If
                    End If

                    ' If there are no incorrect values in the copies boxes then print.
                    If success Then

                        format.PrintSetup.PrinterName = printerName ' cboPrinters.SelectedItem.ToString()
                        format.PrintSetup.PrintToFile = False

                        'update format values
                        ' Set the substrings grid.
                        If format.SubStrings.Count > 0 Then
                            Dim bindingSource As New DataSet() ' BindingSource()

                            bindingSource = format.SubStrings
                            subStringDataset = bindingSource

                            'vwProdTick for more data to fill these substrings

                            format.SubStrings("GTIN").Value = viewModel.Gtin
                            format.SubStrings("ProdDesc").Value = viewModel.ProdDesc
                            format.SubStrings("PriceCode").Value = viewModel.PriceCode
                            format.SubStrings("Pack_Size").Value = viewModel.PackDesc
                            format.SubStrings("Lot").Value = $"{viewModel.ProdOrderNumber}{viewModel.Lot}"
                            format.SubStrings("LineNo").Value = viewModel.Line
                            format.SubStrings("CodeDate").Value = viewModel.CodeDate
                            format.SubStrings("NewCodeDate").Value = viewModel.CodeDate
                            format.SubStrings("Version").Value = viewModel.Version

                        End If

                        Dim messages As Messages = Nothing
                        Dim waitForCompletionTimeout As Integer = 10000 ' 10 seconds
                        Dim result As Result = format.Print(appName, waitForCompletionTimeout, messages)

                        For Each message As Message In messages
                            viewModel.PrintMessages.Add(message.Text)
                        Next message

                        If result = Result.Failure Then
                            viewModel.Source = "Failed"
                        Else
                            viewModel.Source = "Success"
                        End If

                    End If
                End SyncLock
            Catch exception As PrintEngineException
                CreatedViewModelError(viewModel, "LabelPrintClass-PrintLabelNewest",
                                           $"Bartender PrintEngineException {exception.Message}",
                                           KioskExceptionType.kioskError)

            Catch comException As System.Runtime.InteropServices.COMException
                CreatedViewModelError(viewModel, "LabelPrintClass-PrintLabelNewest COM excpetion", $"{comException.Message }", KioskExceptionType.kioskError)
            Catch ex As Exception
                CreatedViewModelError(viewModel, "LabelPrintClass-PrintLabelNewest excpetion", $"{ex.Message }", KioskExceptionType.kioskError)
            End Try

            ' Quit the BarTender Print Engine, but do not save changes to any open formats.
            If engine IsNot Nothing Then
                engine.Stop(SaveOptions.DoNotSaveChanges)
            End If

            Return viewModel
        End Function

        'TODO not in use, remove
        Public Function exportPreview() As String
            ' Initialize a new TaskManager object.
            Using btTaskManager As New TaskManager()
                ' Start a task engine.
                btTaskManager.Start(1)

                ' Create a new ExportPrintPreviewToImageTask.
                Dim task As New ExportPrintPreviewToFileTask(docFileName, "C:\Previewfolder\", "Format1 (Page %PageNumber%).png") ' " "C:\Format1.btw", "C:\", "Format1 (Page %PageNumber%).bmp")

                ' Specify the properties of the output image.
                task.ImageType = Seagull.BarTender.Print.ImageType.PNG
                task.Colors = Seagull.BarTender.Print.ColorDepth.Mono
                task.Resolution = New Seagull.BarTender.Print.Resolution(50)

                'task.  btTaskManager.TaskQueue.QueueTask(task)
                Dim taskStatus As TaskStatus = btTaskManager.TaskQueue.QueueTaskAndWait(task, 10000)
                ' Execute the task asynchronously for performance.
                'btTaskManager.TaskQueue.QueueTask(task)
                Dim msg As String = Nothing
                Dim msgs As List(Of String)
                Dim messages As Messages

                'taskStatus.
                Select Case taskStatus
                    Case TaskStatus.Success
                        Return "Exported"
                    Case TaskStatus.Error
                        For Each message As Message In task.Messages
                            msg += message.Text
                            'msgs.Add(msg)
                        Next
                        Return msg

                    Case Else

                End Select

                If btTaskManager.TaskQueue.Count >= 1 Then
                    Dim currentTask As Task = task

                    If currentTask.IsComplete = False Then
                        'btTaskManager.TaskQueue.q
                    End If
                    If currentTask.Status = TaskStatus.Success Then
                        btTaskManager.Stop(100, True)
                    ElseIf currentTask.Status = TaskStatus.Error Then
                        btTaskManager.Stop(100, True)
                    ElseIf currentTask.Status = TaskStatus.Queued Then
                        btTaskManager.Stop(10000, True)
                    End If
                End If

                ' Stop the task engine.
                ' Ten second timeout gives tasks time to finish.
                btTaskManager.Stop(10000, True)
            End Using
        End Function

        ''' <summary>
        ''' This creates the error model.
        ''' Allows for passing of single object with all error information
        ''' </summary>
        ''' <param name="viewModel"></param>
        ''' <param name="source"></param>
        ''' <param name="message"></param>
        ''' <param name="type"></param>
        Public Sub CreatedViewModelError(viewModel As PrintDocumentsViewModel, source As String, message As String, type As KioskExceptionType)

            Dim errorModel As ErrorModel = New ErrorModel With {
                .ProdOrderNumber = viewModel.ProdOrderNumber,
                .SelectedServerPrinterName = viewModel.SelectedServerPrinterName,
                .BasketNumber = viewModel.Lot,
                .FormatName = viewModel.FormatName,
                .Gtin = viewModel.Gtin,
                .Line = viewModel.Line,
                .Shift = viewModel.Shift,
                .FullPath = viewModel.FullPath,
                .PrintMessages = viewModel.PrintMessages
            }
            Dim msg As String = "" ' message

            'For Each mg As String In viewModel.PrintMessages
            '    If msg.Length <= 4000 Then
            '        msg += $"{mg}"
            '    End If

            'Next

            'If message.Length <= 500 And msg.Length <= 4000 Then
            '    message += msg
            'End If

            Dim ks As KioskException = New KioskException(type, message, source, errorModel)

        End Sub


        'Public Shared Sub CreateAudit(_viewmodel As PrintDocumentViewsModel.PrintDocumentsViewModel)
        '    Dim am As AuditModel = New AuditModel()
        '    Dim strCombine As String = "Completed "
        '    Dim viewModel As New CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel.PrintDocumentsViewModel

        '    am.Location = "Process Monitor"
        '    am.Message = "Completed printing"

        '    If Not String.IsNullOrEmpty(_viewmodel.FormatName) Then am.FormatName = _viewmodel.FormatName
        '    If Not String.IsNullOrEmpty(_viewmodel.ProdOrderNumber) Then am.ProdOrderNumber = _viewmodel.ProdOrderNumber
        '    If Not String.IsNullOrEmpty(_viewmodel.Shift) Then am.Shift = Integer.Parse(_viewmodel.Shift)
        '    If Not String.IsNullOrEmpty(_viewmodel.Line) Then am.Line = Integer.Parse(_viewmodel.Line)
        '    If Not String.IsNullOrEmpty(_viewmodel.Qty) Then am.Qty = Integer.Parse(_viewmodel.Qty)
        '    If Not String.IsNullOrEmpty(_viewmodel.BasketNumber) Then am.BasketNumber = Integer.Parse(_viewmodel.BasketNumber)
        '    If Not String.IsNullOrEmpty(_viewmodel.Lot) Then am.BasketNumber = CInt(_viewmodel.Lot)
        '    If Not String.IsNullOrEmpty(_viewmodel.ProdDesc) Then am.ProdDesc = _viewmodel.ProdDesc
        '    If Not String.IsNullOrEmpty(_viewmodel.PriceCode) Then am.PriceCode = _viewmodel.PriceCode
        '    If Not String.IsNullOrEmpty(_viewmodel.Cert) Then am.Cert = _viewmodel.Cert
        '    If Not String.IsNullOrEmpty(_viewmodel.CodeDate) Then am.CodeDate = _viewmodel.CodeDate
        '    If Not String.IsNullOrEmpty(_viewmodel.SelectedServerPrinterName) Then am.Comment = _viewmodel.SelectedServerPrinterName


        '    If _viewmodel.PrintMessages.Count > 0 Then
        '        For Each msg As String In _viewmodel.PrintMessages
        '            strCombine += $"{msg} "
        '        Next
        '        am.Message = strCombine
        '    End If

        '    Dim al As AuditLogger = New AuditLogger(am)

        '    If Not String.IsNullOrEmpty(_viewmodel.Cert) Then DataUtility.UpdateCanadaCert(_viewmodel.ProdOrderNumber, _viewmodel.Cert)


        'End Sub


#End Region


    End Class

End Namespace
