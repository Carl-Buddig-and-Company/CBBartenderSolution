Imports System.IO
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework.KioskException
Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.PrintServer


Namespace CB.Bartender.Utilities



    Public Class Utilities

        Private ke As KioskException

        Private subStringDataset As DataSet

        Public Function DisplayPrinterNames() As List(Of String)
            Dim serverPrintersList As List(Of ServerPrinterInfo)
            Dim printNameList As List(Of String) = New List(Of String)

            serverPrintersList = New List(Of ServerPrinterInfo)

            For Each srvPrint As ServerPrinterInfo In serverPrintersList
                printNameList.Add(srvPrint.PrinterName)
            Next
            '= New ServerPrinterInfo.GetServerPrinters()

            'ViewBag.CurrentPage = "DisplayPrinters"
            Return printNameList
        End Function

        Public Function DisplayPrinters() As List(Of ServerPrinterInfo)
            Dim serverPrintersList As List(Of ServerPrinterInfo)

            serverPrintersList = New List(Of ServerPrinterInfo)
            '= New ServerPrinterInfo.GetServerPrinters()

            'ViewBag.CurrentPage = "DisplayPrinters"
            Return serverPrintersList
        End Function

        Public Shared Function PrintLabels(_viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel, _fileName As String, _printerName As String) As List(Of String)
            'Dim currentTask As Logic.PrintTask = New Logic.PrintTask(fileName, printerName)
            Dim vwModel As PrintDocumentViewsModel.PrintDocumentsViewModel = New PrintDocumentViewsModel.PrintDocumentsViewModel()
            Dim v As List(Of String) ' = currentTask.Status
            Dim lblPrint As LabelPrint = New LabelPrint()

            vwModel = _viewModel

            'v = lblPrint.PrintLabelNewest(_fileName, vwModel)

            Return v
        End Function

        Public Function PrintLabels(_filePath As String, _printerName As String, _documentModel As WebLabelPrintDocument) As List(Of String)
            Dim msgs As List(Of String) = New List(Of String)
            Dim msg As String
            ' Initialize and start a new engine 
            Using btEngine As New Engine()

                btEngine.Start()

                ' Open a label format that specifies the default printer 
                Dim btFormat As LabelFormatDocument = btEngine.Documents.Open(_filePath, _printerName)

                ' Print the label 
                Dim result As Result = btFormat.Print("PrintJob1")
                Dim messages As Messages = Nothing
                If result = Result.Failure Then
                    msg = "Print Failed"
                Else
                    msg = "Label was successfully sent to printer."
                End If

                msgs.Add(msg)

                For Each message As Message In messages
                    msg = message.Text + " Severity: " + message.Severity.ToString() + "Category: " + message.Category ' messageString &= Constants.vbLf + Constants.vbLf + message.Text
                    msgs.Add(msg)
                Next message

            End Using

            Return msgs
        End Function


        Public Function PrintPreview(_newPreviewfileName As String, _previewFolder As String,
                                     _docFilePath As String, _documentModel As WebLabelPrintDocument) As String

            Dim dt As DateTime = DateTime.UtcNow
            Dim previewFolder As String = "Previews/"

            Dim fileName As String = _newPreviewfileName & dt.Month & dt.Day & dt.Hour & dt.Minute  ' "yes.png"
            Dim paths As String() = New String() {previewFolder, fileName & ".png"}
            Dim fullPath As String = Path.Combine(paths)

            Dim strBld As String = Nothing

            Dim strRet As String = "Failed"
            Dim folder As String = _previewFolder
            Dim btFormat As LabelFormatDocument
            Dim messages As Messages = Nothing

            Try
                Dim btEngine As New Engine()

                ' Start the BarTender print engine. 
                btEngine.Start()

                ' Open the specified format. 
                btFormat = btEngine.Documents.Open(_docFilePath) '"c:\MyFormat.btw")

                ' Set the substrings grid.
                If btFormat.SubStrings.Count > 0 Then
                    Dim bindingSource As New DataSet() ' BindingSource()

                    bindingSource = btFormat.SubStrings
                    subStringDataset = bindingSource

                    btFormat.SubStrings("ProdOrder").Value = _documentModel.ProdOrderNumber
                    btFormat.SubStrings("GTIN").Value = _documentModel.Gtin
                    btFormat.SubStrings("PackDesc").Value = _documentModel.PackDesc
                    btFormat.SubStrings("ProdDesc").Value = _documentModel.ProdDesc
                    'btFormat.SubStrings("Qty").Value = _documentModel.Qty

                End If

                ' Export the label format's print preview image(s) to a file. 
                Dim results As Result = btFormat.ExportPrintPreviewToFile(folder, fileName & ".png", ImageType.JPEG, ColorDepth.ColorDepth256, New Resolution(96), Drawing.Color.Green, OverwriteOptions.Overwrite, True, True, messages)

                If results = Result.Failure Then
                    strBld = "Error creating the print preview in " + fileName
                    My.Application.Log.WriteEntry(strBld, TraceEventType.Error)

                    If messages.Count >= 1 Then
                        For Each message As Message In messages
                            My.Application.Log.WriteEntry(message.Text, TraceEventType.Error)
                            'strBld += message.Text + " "
                        Next

                    End If
                Else
                    strRet = fileName ' & "1" ' folder + "\" + filename
                    ke = New KioskException(KioskExceptionType.kioskWarning, "Successful print preview", "Utilities") ', , KioskException.KioskExceptionType.kioskWarning)

                    My.Application.Log.WriteEntry("success, print preview", TraceEventType.Information)
                    If messages.Count >= 1 Then
                        For Each message As Message In messages
                            My.Application.Log.WriteEntry(message.Text, TraceEventType.Information)
                            'strBld += message.Text + " "
                        Next

                    End If
                End If


                ' Stop the BarTender print engine. 
                btEngine.Stop()


            Catch exception As PrintEngineException
                My.Application.Log.WriteException(exception,
                TraceEventType.Error,
                "Bartender PrintEngineException in print preview " &
                "Error creating the print preview for " & fileName &
                " for format " & _docFilePath)
            Catch comException As System.Runtime.InteropServices.COMException
                My.Application.Log.WriteException(comException,
                TraceEventType.Error,
                "Error creating the label format print preivew " + fileName +
                 " for format " & _docFilePath)

            Catch ex As Exception
                My.Application.Log.WriteException(ex,
                TraceEventType.Error,
                 "Error creating the label format print preivew " + fileName +
                " for format " & _docFilePath)

            End Try


            Return strRet

        End Function

        Public Function CheckLogs() As List(Of String)
            'Dim otherPath As TraceListener  = New System.Diagnostics.TraceListener().TraceEvent()
            Dim path As String = My.Application.Log.DefaultFileLogWriter.FullLogFileName
            Dim lstReturn As List(Of String) = New List(Of String)
            My.Application.Log.DefaultFileLogWriter.Close()
            'Dim lines() As String = System.IO.File.ReadAllLines(path)

            'Dim fs1 As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read)
            'Dim rd1 As StreamReader = New StreamReader(fs1)

            'While rd1.Peek() >= 0
            '    lstReturn.Add(rd1.ReadLine())
            'End While

            'For Each str As String In rd1.ReadLine
            '    lstReturn.Add(str)
            'Next



            Return lstReturn
        End Function

        Public Shared Sub CreatedViewModelError(viewModel As PrintDocumentsViewModel, source As String, message As String, type As KioskExceptionType)

            Dim errorModel As ErrorModel = New ErrorModel With {
                .ProdOrderNumber = viewModel.ProdOrderNumber,
                .SelectedServerPrinterName = viewModel.SelectedServerPrinterName,
                .BasketNumber = viewModel.BasketNumber,
                .FormatName = viewModel.FormatName,
                .Gtin = viewModel.Gtin,
                .Line = viewModel.Line,
                .Shift = viewModel.Shift,
                .FullPath = viewModel.FullPath
            }
            Dim msg As String = message

            For Each mg As String In viewModel.PrintMessages
                msg += $" {mg}"
            Next

            Dim ks As KioskException = New KioskException(type, msg, source, errorModel)

        End Sub





    End Class

End Namespace