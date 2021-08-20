Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel
Imports CBLabelPrinterBLL.CB.Bartender.Utilities
Imports CBLabelPrinterBLL.CB.Bartender.Logic.Tasks
Imports CBLabelPrinterBLL.CB.Bartender.Logic
Imports CBLabelPrinterBLL.CB.Bartender
Imports System.IO
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework.KioskException
Imports System.Web.Configuration

Public Class LabelPrint
    Inherits System.Web.UI.Page
    'Public Property viewModel As PrintDocumentsViewModel = New PrintDocumentsViewModel
    Private Const tstFilePath = ""
    Private Const tstPrinter = "1note"

    'Private PictureBoxes As List(Of PictureBox) = New List(Of PictureBox)()
    Private Const ThumbWidth As Integer = 100
    Private Const ThumbHeight As Integer = 100
    Private _FormatName As String
    Private _PackDesc As String
    Private _ProdOrderNumber As String
    Private _BasketNumber As Integer
    Private _ProductionOrder As DataSet
    Private _PrinterSelected As String
    Private _KioskSelected As String
    Private _LineSelected As String
    Private _PrinterName As String
    Private _gtin As String
    Private _productDesc As String
    Private _qty As String
    Private _cert As String


    Private _selectionindex As Integer
    Private _documentFileName As String
    'Dim var2 = lstLabelBrowser.SelectedIndex
    Public LabelFullPath As String
    Public Property isOk As Boolean
    Public viewModel As New PrintDocumentsViewModel()
    Private _Shift As String
    Private _Basket As String
    Private _PrinterType As String
    Private _OrderLot As String

#Region "Variables"

    Public Property Cert As String
        Get
            Return _cert
        End Get
        Set
            _cert = Value
        End Set
    End Property
    Public Property PrinterType As String
        Get
            Return _PrinterType
        End Get
        Set
            _PrinterType = Value
        End Set
    End Property

    Public Property Qty As String
        Get
            Return _qty
        End Get
        Set
            _qty = Value
        End Set
    End Property

    Public Property ProdDesc As String
        Get
            Return _productDesc
        End Get
        Set
            _productDesc = Value
        End Set
    End Property

    Public Property selectionindex As Integer
        Get
            Return _selectionindex
        End Get
        Set
            _selectionindex = Value
        End Set
    End Property
    'Dim seletedItem As GridView = lstLabelBrowser.Items(selectionindex)
    Public Property documentFileName As String
        Get
            Return _documentFileName
        End Get
        Set
            _documentFileName = Value
        End Set
    End Property
    Public Property PrinterName() As String ' = CType(Session.Item("PrinterName"), String)
        Get
            Return _PrinterName
        End Get
        Set
            _PrinterName = Value
        End Set
    End Property

    Public Property LineSelected() As String '= CType(Session.Item("Line"), String)
        Get
            Return _LineSelected
        End Get
        Set
            _LineSelected = Value
        End Set
    End Property

    Public Property KioskSelected() As String '= CType(Session.Item("Kiosk"), String)
        Get
            Return _KioskSelected
        End Get
        Set
            _KioskSelected = Value
        End Set
    End Property

    Public Property PrinterSelected() As String '= CType(Session.Item("PrinterId"), String)
        Get
            Return _PrinterSelected
        End Get
        Set
            _PrinterSelected = Value
        End Set
    End Property

    Public Property ProductionOrder() As DataSet
        Get
            Return _ProductionOrder
        End Get
        Set
            _ProductionOrder = Value
        End Set
    End Property

    Public Property BasketNumber() As Integer
        Get
            Return _BasketNumber
        End Get
        Set
            _BasketNumber = Value
        End Set
    End Property

    Public Property ProdOrderNumber() As String
        Get
            Return _ProdOrderNumber
        End Get
        Set
            _ProdOrderNumber = Value
        End Set
    End Property

    Public Property PackDesc() As String
        Get
            Return _PackDesc
        End Get
        Set
            _PackDesc = Value
        End Set
    End Property

    Public Property FormatName() As String
        Get
            Return _FormatName
        End Get
        Set
            _FormatName = Value
        End Set
    End Property

    Public Property GTIN() As String
        Get
            Return _gtin
        End Get
        Set
            _gtin = Value
        End Set
    End Property

    Public Property Shift As String
        Get
            Return _Shift
        End Get
        Set
            _Shift = Value
        End Set
    End Property

    Public Property Basket As String
        Get
            Return _Basket
        End Get
        Set
            _Basket = Value
        End Set
    End Property

    Public Property OrderLot As String
        Get
            Return _OrderLot
        End Get
        Set
            _OrderLot = Value
        End Set
    End Property



#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If isAllOk() Then
                Dim pp As String = PrintPreview()

                If String.IsNullOrEmpty(pp) Or pp = "Success" Then


                    isOk = True
                Else
                    isOk = False
                End If


            Else

                Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Label printing data is missing", "LabelPrint Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

            End If
        Else


        End If


    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'LabelJS.Text = "<script type='text/javascript'>showModalImage();</script>"
    End Sub

#Region "ButtonsAndMethods"
    Public Function isAllOk() As Boolean
        isOk = True
        Dim isPrinterOk = True
        Dim isPrintType = True
        Dim isFormatOk = True
        Dim isProdOrder = True

        ' set page variables
        PrinterName = CType(Session.Item("PrinterName"), String)
        Shift = CType(Session.Item("Shift"), String)
        LineSelected = CType(Session.Item("Line"), String)
        KioskSelected = CType(Session.Item("Kiosk"), String)
        PrinterSelected = CType(Session.Item("PrinterId"), String)
        ProdDesc = CType(Session.Item("ProdDesc"), String)
        ProdOrderNumber = CType(Session.Item("ProdOrderNumber"), String)
        PackDesc = CType(Session.Item("PackDesc"), String)
        FormatName = CType(Session.Item("FormatName"), String)
        GTIN = CType(Session.Item("GTIN"), String)
        Qty = CType(Session.Item("Qty"), String)
        Basket = CType(Session.Item("Basket"), String)
        PrinterType = CType(Session.Item("PrinterType"), String)
        'OrderLot = CType(ses)
        OrderLot = $"{ProdOrderNumber}{Basket}"

        viewModel = CType(Session.Item("ViewModel"), PrintDocumentsViewModel)

        'Validate important substrings
        If PrinterName Is Nothing Or String.IsNullOrEmpty(PrinterName) Then isPrinterOk = False
        If ProdOrderNumber Is Nothing Or String.IsNullOrEmpty(ProdOrderNumber) Then isProdOrder = False
        If PrinterType Is Nothing Or String.IsNullOrEmpty(PrinterType) Then isPrintType = False
        If FormatName Is Nothing Or String.IsNullOrEmpty(FormatName) Then isFormatOk = False

        If isPrinterOk And isProdOrder And isPrintType Then
            Dim wu As New WebUtilities


            viewModel = wu.GetPrinterLabelSubstrings(ProdOrderNumber)

            viewModel.Shift = Shift
            viewModel.Lot = Basket
            If viewModel.Qty Is Nothing Then viewModel.Qty = Qty
            'viewModel.Gtin = GTIN
            'viewModel.PackDesc = PackDesc
            viewModel.Line = LineSelected
            viewModel.FormatName = FormatName
            viewModel.SelectedServerPrinterName = PrinterName
            viewModel.ProdOrderNumber = ProdOrderNumber

            LabelProdOrder.Text = ProdOrderNumber
            LabelProdDesc.Text = viewModel.ProdDesc
            LabelPrinterName.Text = PrinterName
            LabelPrinterId.Text = PrinterSelected
            LabelPack.Text = viewModel.PackDesc
            LabelQty.Text = Qty
            LabelGTIN.Text = viewModel.Gtin
            LabelFormat.Text = FormatName

            Return True
        Else
            isOk = False
            Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, $"Printer name: {PrinterName} Order: {ProdOrderNumber} and Format: {FormatName} are required", "LabelPrint Web Page-235") ', , KioskException.KioskExceptionType.kioskWarning)

        End If

        Return isOk
    End Function

    Public Function LoadSessionDetails(setValues As Boolean) As Boolean
        PrinterName = CType(Session.Item("PrinterName"), String)

        If PrinterName Is String.Empty Then
            LoadSessionDetails = False
        Else
            PrinterName = CType(Session.Item("PrinterName"), String)
            LineSelected = CType(Session.Item("Line"), String)
            KioskSelected = CType(Session.Item("Kiosk"), String)
            PrinterSelected = CType(Session.Item("PrinterId"), String)
            ProdDesc = CType(Session.Item("ProdDesc"), String)
            ProdOrderNumber = CType(Session.Item("ProdOrderNumber"), String)
            PackDesc = CType(Session.Item("PackDesc"), String)
            FormatName = CType(Session.Item("FormatName"), String)
            GTIN = CType(Session.Item("GTIN"), String)
            Qty = CType(Session.Item("Qty"), String)
            PrinterType = CType(Session.Item("PrinterType"), String)


            LabelProdOrder.Text = ProdOrderNumber
            LabelProdDesc.Text = _productDesc
            LabelPrinterName.Text = PrinterName
            LabelPrinterId.Text = PrinterSelected
            LabelPack.Text = PackDesc
            LabelQty.Text = Qty
            LabelGTIN.Text = GTIN
            LabelFormat.Text = FormatName
            LabelCert.Text = CType(Session.Item("Cert"), String)
        End If

        If Request.Cookies("ProcessMonitorKiosk") IsNot Nothing Then KioskSelected = Request.Cookies("ProcessMonitorKiosk")("kioskId")


        If setValues And LoadSessionDetails Then
            'TODO Create cookie here

        End If
        Return True
    End Function
    Public Function PrintLabelFormat()
        Dim printModel As PrintDocumentsViewModel = New PrintDocumentsViewModel

        printModel.SelectedClientPrinterName = PrinterName
        printModel.SelectedDocumentIndex = 1
        printModel.PrintType = "Server"
    End Function

    ''' <summary>
    ''' Displays available documents with thumbnails and allows printing to printers, client printers, and client ports.
    ''' </summary>
    Public Function PrintDocuments(_printerName As String) As String
        Dim documentsList As List(Of WebLabelPrintDocument) = WebLabelPrintDocument.GenerateDocumentsList()
        Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()

        ' Set default view model options
        Dim viewModel As New PrintDocumentsViewModel()
        viewModel.DocumentsList = documentsList
        viewModel.ServerPrintersList = serverPrintersList
        viewModel.SelectedDocumentIndex = 0
        viewModel.PrintType = "Server"

        If _printerName.Length >= 1 Then
            viewModel.SelectedClientPrinterName = _printerName

        Else viewModel.SelectedClientPrinterName = String.Empty
        End If
        ' Set the default server printer to the Windows default printer if one is available. Oftentimes, when a web application is hosted
        ' as an AppPool account that is different than the current user, we may not be able to get a default printer. In that case, select
        ' the first available printer.
        Dim hasDefault As Boolean = False
        For Each printerInfo As ServerPrinterInfo In serverPrintersList
            If printerInfo.IsDefault Then
                viewModel.SelectedServerPrinterName = printerInfo.PrinterName
                hasDefault = True
                Exit For
            End If
        Next
        If Not hasDefault AndAlso serverPrintersList.Count > 0 Then
            viewModel.SelectedServerPrinterName = serverPrintersList(0).PrinterName
        End If

        'ViewBag.CurrentPage = "PrintDocuments"
        Return "Preview showing" ' View(viewModel)
    End Function

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim documentsList As List(Of WebLabelPrintDocument) = WebLabelPrintDocument.GenerateDocumentsList()
        Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()
        Dim util As CBLabelPrinterBLL.CB.Bartender.Utilities.Utilities = New Utilities()
        Dim viewModel As New PrintDocumentsViewModel()
        Dim lst As List(Of String) = New List(Of String)
        'Dim var2 = lstLabelBrowser.SelectedIndex
        Dim dr As GridViewRow
        dr = GridView1.SelectedRow()
        selectionindex = GridView1.SelectedIndex
        'Dim seletedItem As GridView = lstLabelBrowser.Items(selectionindex)

        LabelFullPath = dr.Cells(3).Text ' lstLabelBrowser.SelectedValue

        viewModel.DocumentsList = documentsList
        viewModel.ServerPrintersList = serverPrintersList
        viewModel.SelectedDocumentIndex = selectionindex
        viewModel.PrintType = "Server"

        viewModel.SelectedServerPrinterName = "1note"
        PrinterName = viewModel.SelectedServerPrinterName

        documentFileName = documentsList(viewModel.SelectedDocumentIndex).FullPath

        Dim previewPath ' = util.PrintPreview("PrintPreview.png", documentFileName) ', "BKINSER2020", LineSelected, "1", FormatName)
        ', , )

        If previewPath = "Failed" Then
            Label1.Text = "Preview Failed"
        Else
            Label1.Text = previewPath
            LabelPreview.Text = previewPath
            ImagePreview.ImageUrl = previewPath



        End If

        If viewModel.PrintType = "Server" Then
            Dim labelPrinter As CBLabelPrinterBLL.CB.Bartender.Models.LabelPrint = New CBLabelPrinterBLL.CB.Bartender.Models.LabelPrint()

            'viewModel.PrintMessages = Utilities.PrintLabels(documentFileName, PrinterName)
            'viewModel.PrintMessages = labelPrinter.PrintLabelNewest(documentFileName, viewModel, docu, GTIN, ProdOrderNumber, PackDesc, BasketNumber, ProdDesc, Qty) ' viewModel, 1, PrinterName, LabelFullPath, selectionindex) 'int.printLabel(documentFileName, PrinterName)

            'viewModel.PrintMessages = labelPrinter.printLabel(viewModel, 1, PrinterName, LabelFullPath, selectionindex) 'int.printLabel(documentFileName, PrinterName)
            'viewModel.PrintMessages = PrintSchedulerServiceSupport.PrintToServerPrinter(documentFileName, viewModel.SelectedServerPrinterName)

            For Each txt As String In viewModel.PrintMessages
                Label1.Text += txt
                'BulletedListMessages.Items.Add(txt)
            Next
        End If



    End Sub
    Protected Function CreatePrintDocument() As WebLabelPrintDocument

        Dim document As New WebLabelPrintDocument With {
            .SelectedServerPrinterName = LabelPrinterName.Text,
            .ProdOrderNumber = LabelProdOrder.Text,
            .PackDesc = LabelPack.Text,
            .FormatName = LabelFormat.Text,
            .Gtin = LabelGTIN.Text,
            .ProdDesc = LabelProdDesc.Text,
            .Qty = LabelQty.Text,
            .BasketNumber = LabelBasketNumber.Text
        }

        Return document

    End Function

    Protected Function CreateViewDocument() As PrintDocumentsViewModel

        Dim viewModel = New PrintDocumentViewsModel.PrintDocumentsViewModel With {
            .BasketNumber = CType(Session.Item("Basket"), String),
            .FormatName = CType(Session.Item("FormatName"), String),
            .SelectedServerPrinterName = CType(Session.Item("PrinterName"), String),
            .ProdOrderNumber = CType(Session.Item("ProdOrderNumber"), String),
            .PackDesc = CType(Session.Item("PackDesc"), String),
            .Qty = CType(Session.Item("Qty"), String),
            .Gtin = CType(Session.Item("GTIN"), String),
            .Line = CType(Session.Item("Line"), String),
            .Shift = CType(Session.Item("Shift"), String),
            .Cert = CType(Session.Item("Cert"), String)
                    }

        Return viewModel

    End Function

    Protected Function CallPrintSchedulerService() As List(Of String)
        If viewModel.PrintType = "Server" Then
            'viewModel.PrintMessages = Utilities.PrintLabels(documentFileName, PrinterName)
            'viewModel.PrintMessages = labelPrinter.printLabel(viewModel, 1, PrinterName, LabelFullPath, selectionindex) 'int.printLabel(documentFileName, PrinterName)
            viewModel.PrintMessages = PrintSchedulerServiceSupport.PrintToServerPrinter(documentFileName, viewModel.SelectedServerPrinterName)

            For Each txt As String In viewModel.PrintMessages
                Label1.Text += txt
                'BulletedListMessages.Items.Add(txt)
            Next
        Else
            Dim printCode As String = String.Empty
            'viewModel.PrintMessages = PrintSchedulerServiceSupport.PrintToServerPrinter(documentFileName, viewModel.SelectedServerPrinterName, viewModel.ClientPrintLicense, printCode)

            If Not String.IsNullOrEmpty(printCode) Then
                viewModel.ClientPrintCode = printCode
            End If
        End If
        Return viewModel.PrintMessages
    End Function

    Protected Function DeletePreview(_previewPath As String) As Boolean

        Return True
    End Function

    Protected Sub ButtonPrint_Click(sender As Object, e As EventArgs) Handles ButtonPrint.Click

        PrintLabelNow()

        'Response.Redirect("KeypadForm.aspx")

        'PrintLabelNow()
    End Sub

    Protected Sub ButtonPrintPreview_Click(sender As Object, e As EventArgs) Handles ButtonPrintPreview.Click

        PrintPreview()

        'Dim pPreview As String = PrintPreview()
        'Dim folder As String = "c:\PreviewFolder"
        'Dim fileVar As String = FormatName + "_" + ProdOrderNumber & ID
        'Dim filename As String = System.IO.Path.Combine(folder, fileVar & ".png")


        'If pPreview Is "Failed" Then

        'Else
        '    If FileIO.FileSystem.FileExists(LabelPreview.Text) Then
        '        ImagePreview.ImageUrl = filename
        '    End If

        'End If


        'ImagePreview.ImageUrl = "Previews/Preview1.jpg"
    End Sub


    Protected Sub Timer1_Tick1(sender As Object, e As EventArgs)
        Dim timeLeft As Int32 = Integer.Parse(LabelTime.Text) 'getting the last value (the one from the label)
        timeLeft -= 1 '; //subtracting 1
        LabelTime.Text = timeLeft.ToString() ';  //adding it back To the label.     
        If Integer.Parse(LabelTime.Text) = 0 Then
            ' // If the countdown reaches '0', we stop it
            LabelTime.Text = "Completed 30 seconds, ready to print"
            ' PrintLabelNow()
            Timer1.Enabled = False '.Stop()
            Response.Redirect("KeypadForm.aspx", False)

        End If
    End Sub

    Protected Sub ButtonStartOver_Click(sender As Object, e As EventArgs) Handles ButtonStartOver.Click
        Response.Redirect("KeypadForm.aspx")
    End Sub

#End Region

#Region "PrintFunctions"

    ''' <summary>
    ''' Createse the print preview and retrieves it for viewiing
    ''' </summary>
    ''' <returns></returns>
    Protected Function PrintPreview() As String
        Dim ks As KioskException
        Dim util As Utilities = New Utilities()
        Dim labelPrinter As Models.LabelPrint = New Models.LabelPrint()
        Dim dt As DateTime = DateTime.Now
        'Dim lst As List(Of String) = New List(Of String)
        ' Dim folder As String = "C:\Users\bkinser\source\repos\CBBartenderSolution\CBWarehouseLabelPrintWeb\Previews"
        Dim fileVar As String = dt.Month & dt.Day & dt.Hour & dt.Minute
        Dim filename As String = $"{viewModel.FormatName}_{viewModel.ProdOrderNumber}_{fileVar}" 'LabelFormat.Text + "_" + LabelProdOrder.Text & "_" ' System.IO.Path.Combine(folder, fileVar & ".png")
        Dim document As New WebLabelPrintDocument()
        Dim errMsg As String = ""
        Dim previewFolder As String = Server.MapPath("~/Previews")
        Dim formatFolder As String = Server.MapPath("~/Documents")

        document = CreatePrintDocument()

        Dim previewPaths As String() = New String() {previewFolder, filename}
        Dim paths As String() = New String() {formatFolder, viewModel.FormatName} ' document.FormatName}

        'Dim paths As String() = New String() {formatFolder, document.FormatName & ".btw"}
        Dim fullPath As String = Path.Combine(paths)
        Dim fullPreviewPath As String = Path.Combine(previewPaths)

        If Not FileIO.FileSystem.FileExists(fullPath) Then
            errMsg = $"Label Format {FormatName} at file path {fullPath} was not found, file is missing"
            'Dim ks As KioskException =
            ' New KioskException(KioskExceptionType.kioskError, $"Label preview not found for {FormatName} failed due to {errMsg}", "KeypadForm Web Page Label Preview") ', , KioskException.KioskExceptionType.kioskWarning)
            LabelMessage.Text = errMsg
            WebUtilities.CreateWebViewModelError(viewModel, "LabelPrint - PrintPreview", errMsg, KioskExceptionType.kioskError)

            Return errMsg
        End If

        documentFileName = fullPath
        Dim docModel As PrintDocumentsViewModel = New PrintDocumentsViewModel()

        'TODO delete after testing
        'ks = New KioskException(KioskExceptionType.kioskInformation, $"Creating {filename} at folder {previewFolder} for {viewModel.ProdOrderNumber} order and printr {viewModel.SelectedServerPrinterName}", "Starting Print Preview") ', , KioskException.KioskExceptionType.kioskWarning)


        docModel = labelPrinter.PrintPreview(filename, previewFolder, documentFileName, viewModel)
        ' Dim previewPath = labelPrinter.PrintPreview(filename, previewFolder, documentFileName, viewModel)
        Label1.Text = $"Preview Order: {docModel.ProdOrderNumber}"

        'TODO delete after testin
        If docModel.PrintMessages.Count >= 1 Then
            For Each msg As String In docModel.PrintMessages
                BulletedList2.Items.Add(msg)
            Next
        End If
        'ks = New KioskException(KioskExceptionType.kioskError, $"Model returned {docModel.Source} ", "Created Print Preview") ', , KioskException.KioskExceptionType.kioskWarning)
        'WebUtilities.CreateWebViewModelError(docModel, "LabelPrintForm-Created Preview", $"Model returned {docModel.Source}", KioskExceptionType.kioskInformation)

        If docModel.Source = "Failed" Or String.IsNullOrEmpty(docModel.Source) Then
            Label1.Text = $"Error creating the print preview file {filename} in folder {previewFolder}, label format file was found at{fullPath} but no preview was created"
            BulletedList2.Visible = True
            BulletedList2.ForeColor = Drawing.Color.Red

            If docModel.PrintMessages.Count >= 1 Then
                For Each msg As String In docModel.PrintMessages
                    BulletedList2.Items.Add(msg)
                Next
            End If

            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Label printing data is missing", "LabelPrint Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, $"Label preview failed {documentFileName} and {viewModel.pro ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(docModel, "LabelPrint-PrintPreview", "Label preview failed", KioskExceptionType.kioskError)

        Else
            'previewPath = "Previews/" & filename

            LabelPreview.Text = $"{docModel.Source}1.png" 'docModel.Source
            ImagePreview.ImageUrl = $"Previews/{docModel.Source}1.png" ' $"/Previews/{previewPath}1.png" '$"{previewFolder}\" & previewPath & "1" & ".png"
            errMsg = "Success"
            'If Not FileIO.FileSystem.FileExists(ImagePreview.ImageUrl) Then

            '    LabelMessage.Text = $"could not find preview path {ImagePreview.ImageUrl}"
            '    WebUtilities.CreateWebViewModelError(viewModel, "LabelPrint-PrintPreview", "Label preview path not found", KioskExceptionType.kioskError)
            '    'errMsg = "Failed"
            'Else
            '    errMsg = "Success"
            'End If

        End If

        Return errMsg

    End Function

    ''' <summary>
    ''' Prints the label
    ''' </summary>
    Protected Sub PrintLabelNow()
        Dim util As Utilities = New Utilities()
        Dim document As New WebLabelPrintDocument()
        Dim lst As List(Of String) = New List(Of String)
        Dim wu As New WebUtilities
        Dim formatFolder As String = Server.MapPath("~/Documents")
        Dim labelPrinter As Models.LabelPrint = New Models.LabelPrint()
        Dim paths As String()
        Dim fullPath As String

        document = CreatePrintDocument()
        Dim isPrintFailed = False

        If isAllOk() Then

            paths = New String() {formatFolder, viewModel.FormatName}
            fullPath = Path.Combine(paths)

            Dim copies As Integer = My.Settings.Copies

            'Set the number of copies
            viewModel.Copies = copies

            'Print the label and return all messages to the print model
            viewModel = labelPrinter.PrintLabelNewest(fullPath, viewModel, document, PrinterName) ' viewModel, 1, PrinterName, LabelFullPath, selectionindex) 'int.printLabel(documentFileName, PrinterName)

            LabelMessage.Text = viewModel.Source

            'Audit trail entry
            If String.IsNullOrEmpty(viewModel.Source) Or viewModel.Source = "Success" Then

                AuditTrail.CreateAudit(viewModel)
                Response.Redirect("KeypadForm.aspx", False)

            ElseIf viewModel.Source = "Failed" Then

                For Each msg As String In viewModel.PrintMessages
                    BulletedList2.Items.Add(msg)
                Next

                WebUtilities.CreateWebViewModelError(viewModel, "Label Print Form", $"Print Failed for printer:{viewModel.SelectedServerPrinterName}", KioskExceptionType.kioskError)

            End If


        Else
            Label1.Text = "All is not ok"
            isOk = False
            WebUtilities.CreateWebViewModelError(viewModel, "Label Print Form", "Label printing data is missing", KioskExceptionType.kioskError)
            LabelMessage.Text = "Fail"
            ' Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Label printing data is missing", "LabelPrint Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

        End If


    End Sub

#End Region





End Class