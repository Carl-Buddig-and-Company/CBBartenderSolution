Imports System.IO
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework.KioskException
Imports CBLabelPrinterBLL.CB.Bartender
Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBWarehouseLabelPrint

''' <summary>
''' Keypad Form webpage
''' This page is the main process monitor fundction
''' </summary>
Public Class KeypadForm
    Inherits System.Web.UI.Page

    Public lblInfo As Models.LabelInfo = New Models.LabelInfo()
    Public Property viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel = New PrintDocumentViewsModel.PrintDocumentsViewModel
    Private isPrinterReady As Boolean
    Private isDataReady As Boolean
    Public Property kioskId As String
    'Private varUt As VariableUtilites = New VariableUtilites()
    Private _isFormatOk As Boolean
    Private _isPackOk As Boolean
    Private _isGTINOk As Boolean
    Private _isPrinterOk As Boolean
    Private _isOrderOk As Boolean
    Private _isLineOk As Boolean
    Private _isAllOk As Boolean
    Private _GTIN As String
    Private _FormatName As String
    Private _PackDesc As String
    Private _ProdOrderNumber As String
    Private _BasketNumber As Integer
    Private _ProductionOrder As DataSet
    Private _PrinterSelected As String
    Private _KioskSelected As String
    Private _LineSelected As String
    Private _PrinterName As String
    Private _ProductDesc As String
    Private _Qty As String
    Private _PrinterType As String
    Private _CanadaCert As String
    Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents txtValue1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnShowKeypad1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnShowKeypad2 As System.Web.UI.WebControls.Button
    Protected WithEvents txtValue2 As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object


    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'Keypad1.Hide()
            'Session("Shift") = SelectShift()
            'retrieve cookies to see if kiosk is set
            If Request.Cookies("ProcessMonitorKiosk") IsNot Nothing Then
                kioskId = Request.Cookies("ProcessMonitorKiosk")("kioskId")
            End If

            Dim fldKiosk As String = kioskId

            If fldKiosk Is Nothing Then fldKiosk = CType(Session.Item("Kiosk"), String)

            'if kiosk number has been set, filter the lines for only that kiosk
            If fldKiosk IsNot Nothing Then
                Session("Kiosk") = fldKiosk
                ButtonKiosk.CssClass = "btn btn-success btn-lg"
                lblInfo.KioskSelected = fldKiosk
                LabelKiosk.Text = fldKiosk

                KioskSelected = fldKiosk
                MultiView1.ActiveViewIndex = 0

            Else
                Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, "Kiosk doesnt exist, new computer detected", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

                Response.Redirect("Default.aspx")
            End If

            'If validateData() Then
            '    MultiView1.ActiveViewIndex = 1
            '    ButtonLineMaster.CssClass = "btn-success active focus"
            '    ButtonKiosk.CssClass = "btn-success active focus"
            '    'Else MultiView1.ActiveViewIndex = 4
            'End If
        End If

    End Sub

#Region "Variables"
    Public Property PrinterType As String
        Get
            Return _PrinterType
        End Get
        Set
            _PrinterType = Value
        End Set
    End Property

    Public Property Qty() As String ' = CType(Session.Item("PrinterName"), String)
        Get
            Return _Qty
        End Get
        Set
            _Qty = Value
        End Set
    End Property

    Public Property ProdDesc() As String ' = CType(Session.Item("PrinterName"), String)
        Get
            Return _ProductDesc
        End Get
        Set
            _ProductDesc = Value
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
            Return _GTIN
        End Get
        Set
            _GTIN = Value
        End Set
    End Property

    Public Property isAllOk() As Boolean
        Get
            Return _isAllOk
        End Get
        Set
            _isAllOk = Value
        End Set
    End Property

    Public Property isLineOk() As Boolean
        Get
            Return _isLineOk
        End Get
        Set
            _isLineOk = Value
        End Set
    End Property

    Public Property isOrderOk() As Boolean
        Get
            Return _isOrderOk
        End Get
        Set
            _isOrderOk = Value
        End Set
    End Property

    Public Property isPrinterOk() As Boolean
        Get
            Return _isPrinterOk
        End Get
        Set
            _isPrinterOk = Value
        End Set
    End Property

    Public Property isGTINOk() As Boolean
        Get
            Return _isGTINOk
        End Get
        Set
            _isGTINOk = Value
        End Set
    End Property

    Public Property isPackOk() As Boolean
        Get
            Return _isPackOk
        End Get
        Set
            _isPackOk = Value
        End Set
    End Property

    Public Property isFormatOk() As Boolean
        Get
            Return _isFormatOk
        End Get
        Set
            _isFormatOk = Value
        End Set
    End Property

    Public Property CanadaCert() As String
        Get
            Return _CanadaCert
        End Get
        Set
            _CanadaCert = Value
        End Set
    End Property


#End Region

#Region "Keypad"

    ''' <summary>
    ''' Keypad control on clicked method, detect which view is 
    ''' open when the keypad is clicked
    ''' view 0 - line
    ''' view 1 - product order
    ''' view 2 - basket
    ''' view 3 - canada cert
    ''' </summary>
    Private Sub Keypad1_OnOKClicked() Handles Keypad1.OnOKClicked
        Select Case MultiView1.ActiveViewIndex
            Case 0
                'Line view
                LineSelected = Keypad1.Value

                If CheckLineSelection() Then SetLineSelection()

            Case 1
                'Production View
                ProdOrderNumber = Keypad1.Value

                SetProdOrderSelection()

            Case 2
                'Basket View
                BasketNumber = Keypad1.Value

                Dim ln As Integer = Keypad1.Value.Length
                If ln = 6 Then
                    Dim usr As UserControl = Keypad1
                    usr.Visible = False

                    LabelBasketNumber.Text = Keypad1.Value
                    LabelMessage.Visible = True
                    LabelMessage.Text = "Loading preview"
                    SetBasketSelection()
                Else
                    LabelMessage.Visible = True
                    LabelMessage.Text = "Basket number must be exactly 6 digits"
                End If
            Case 3
                'Canada Cert required
                CanadaCert = Keypad1.Value
                SetCanadaSelection()


        End Select


    End Sub

    Private Sub Keypad1_OnCancelClicked() Handles Keypad1.OnCancelClicked
        Me.Keypad1.Hide()
        Me.LabelMessage.Text = "Canceled"

    End Sub


#End Region

#Region "Grid Selections"

    ''' <summary>
    ''' Line selection, set session variables
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        LineSelected = GridView1.SelectedRow.Cells.Item(1).Text
        PrinterName = GridView1.SelectedRow.Cells.Item(3).Text
        PrinterSelected = GridView1.SelectedRow.Cells.Item(2).Text

        If CheckLineSelection() Then SetLineSelection()




    End Sub

    ''' <summary>
    ''' The line show all grid selection, same as line selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub GridViewKiosk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewKiosk.SelectedIndexChanged
        LineSelected = GridViewKiosk.SelectedRow.Cells.Item(1).Text
        PrinterName = GridViewKiosk.SelectedRow.Cells.Item(3).Text
        PrinterSelected = GridViewKiosk.SelectedRow.Cells.Item(2).Text

        If CheckLineSelection() Then SetLineSelection()


    End Sub

    ''' <summary>
    ''' Production Orders grid selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub GridViewProductionOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewProductionOrders.SelectedIndexChanged
        ProdOrderNumber = GridViewProductionOrders.SelectedRow.Cells.Item(1).Text

        SetProdOrderSelection()

    End Sub


    Protected Sub DataList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataList2.SelectedIndexChanged

    End Sub

    ''' <summary>
    ''' Line data list selection, gets the line and printer name set from the data list seleciton
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    Protected Sub DataList2_ItemCommand(source As Object, e As DataListCommandEventArgs)

        Dim idx As Integer = e.Item.ItemIndex
        Dim lblLine As Label = DataList2.Items(idx).FindControl("LabelLineNumberItem")
        Dim lblPrint As Label = DataList2.Items(idx).FindControl("LabelDLPrinterName")
        Dim lblPrintId As Label = DataList2.Items(idx).FindControl("fk_nPrinterTypeIdLabel")
        Dim text As String = lblLine.Text

        LineSelected = lblLine.Text
        PrinterName = lblPrint.Text
        PrinterSelected = lblPrintId.Text

        If CheckLineSelection() Then SetLineSelection()
    End Sub

    ''' <summary>
    ''' Prod order selectio, gets the order formt he data list seleciton then calls setProdORderSelection
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    Protected Sub DataList1_ItemCommand(source As Object, e As DataListCommandEventArgs)
        Dim idx As Integer = e.Item.ItemIndex
        Dim label As Label = DataList1.Items(e.Item.ItemIndex).FindControl("lblProdDL")
        Dim text As String = label.Text
        ProdOrderNumber = label.Text

        SetProdOrderSelection()
    End Sub



#End Region

#Region "Buttons"


    Protected Sub ImageButtonLine_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonLine.Click
        MultiView1.ActiveViewIndex = 0

    End Sub

    Protected Sub ImageButtonOrder_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonOrder.Click
        MultiView1.ActiveViewIndex = 1
        Keypad1.Show()
    End Sub

    Protected Sub ImageButtonBasket_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBasket.Click

    End Sub
    Protected Sub ButtonLineMaster_Click(sender As Object, e As EventArgs) Handles ButtonLineMaster.Click
        MultiView1.ActiveViewIndex = 0
        'ViewLineMaster.Visible = True
        'ViewProductionOrders.Visible = False
        'ViewBaskets.Visible = False
        'ViewPrinters.Visible = False

    End Sub

    Protected Sub ButtonProdOrder_Click(sender As Object, e As EventArgs) Handles ButtonProdOrder.Click
        MultiView1.ActiveViewIndex = 1
        Keypad1.Show()
    End Sub

    Protected Sub ButtonBasket_Click(sender As Object, e As EventArgs) Handles ButtonBasket.Click

    End Sub

    Protected Sub ButtonKiosk_Click(sender As Object, e As EventArgs) Handles ButtonKiosk.Click
        MultiView1.ActiveViewIndex = 4


    End Sub

    Protected Sub ButtonViewPrinters_Click(sender As Object, e As EventArgs) Handles ButtonViewPrinters.Click
        PanelPrinter.Visible = True
    End Sub

    Protected Sub ButtonBasketGo_Click(sender As Object, e As EventArgs) Handles ButtonBasketGo.Click

        'SetBasketSelection()
        'SetAllSessionVariables()
        Response.Redirect("LabelPrint.aspx")

        'TODO set session varialbe for label print

    End Sub

    Protected Sub ButtonAdmin_Click(sender As Object, e As EventArgs) Handles ButtonAdmin.Click
        Response.Redirect("Admin.aspx")
    End Sub

    Protected Sub RadioButtonListShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListShift.SelectedIndexChanged
        LabelShift.Text = RadioButtonListShift.SelectedValue
        ObjectDataSourceProductionOrders.DataBind()
        GridViewProductionOrders.DataBind()
    End Sub

    Protected Sub ButtonShiftChange_Click(sender As Object, e As EventArgs) Handles ButtonShiftChange.Click
        'LabelShift.Text = RadioButtonListShift.SelectedValue
        'ObjectDataSourceProductionOrders.DataBind()
        'GridViewProductionOrders.DataBind()
    End Sub

#End Region

#Region "Methods"

    Protected Function PrepareLabelInfo() As LabelInfo
        lblInfo = New LabelInfo With {
            .BasketNumber = LabelBasket.Text,
            .Format = LabelFormat.Text,
            .Gtin = LabelGTIN.Text,
            .ProdOrderNumber = LabelProdOrder.Text,
            .PackDesc = LabelPack.Text,
            .Qty = Qty,
            .PrinterName = LabelPrinterName.Text,
            .PrinterSelected = LabelPrinterSelected.Text,
            .KioskSelected = LabelKiosk.Text,
            .ProductDesc = LabelProdDesc.Text,
            .LineNumber = LabelLineNumber.Text
                    }


        Return lblInfo

    End Function

    ''' <summary>
    ''' Creates the view model and inserts the data
    ''' </summary>
    ''' <returns>PrintDocumentsViewModel</returns>
    Protected Function CreateViewModel() As PrintDocumentViewsModel.PrintDocumentsViewModel
        viewModel = New PrintDocumentViewsModel.PrintDocumentsViewModel With {
            .BasketNumber = CType(Session.Item("Basket"), String),
            .FormatName = CType(Session.Item("FormatName"), String),
            .SelectedServerPrinterName = LabelPrinterName.Text,
            .ProdOrderNumber = LabelProdOrder.Text,
            .FullPath = LabelFilePath.Text,
            .PackDesc = LabelPack.Text,
            .Qty = LabelQty.Text,
            .Gtin = LabelGTIN.Text,
            .Line = LabelLine.Text,
            .Shift = LabelShift.Text,
            .PrintType = LabelPrintType.Text
                    }

        Return viewModel

    End Function

    ''' <summary>
    ''' build session variables from the label texts
    ''' </summary>
    Protected Sub SetAllSessionVariables()
        Session("PrinterName") = LabelPrinterName.Text
        Session("PrinterId") = LabelPrinterSelected.Text
        Session("Kiosk") = LabelKiosk.Text
        Session("Line") = LabelLineNumber.Text
        Session("Shift") = LabelShift.Text

        Session("ProdOrderNumber") = LabelProdOrder.Text
        Session("PackDesc") = LabelPack.Text
        Session("FormatName") = LabelFormat.Text
        Session("GTIN") = LabelGTIN.Text
        Session("ProdDesc") = LabelProdDesc.Text
        Session("Qty") = LabelQty.Text

        Session("Basket") = LabelBasketNumber.Text
        Session("Shift") = LabelShift.Text
        Session("PrinterType") = LabelPrintType.Text
        Session("Cert") = LabelCert.Text

        Dim vs As New PrintDocumentViewsModel.PrintDocumentsViewModel
        vs = CreateViewModel()
        Session("ViewModel") = vs

    End Sub

    ''' <summary>
    ''' Sets the selection for the production order, which has been saved from the keypad value
    ''' or from the data list selection
    ''' Sets the GTIN, ProdDesc and QTY selections fromt he Production Tickets table
    ''' </summary>
    Protected Sub SetProdOrderSelection()

        Dim orderDSTableAdapter As New DataSetProductionOrdersTableAdapters.Production_TicketsTableAdapter ' LineFullTableAdapters.FullDataSetTableAdapter
        Dim orderDataTable As New DataSetProductionOrders.Production_TicketsDataTable
        Dim ds As New DataSet()

        Try

            If PackDesc Is Nothing Then

                orderDataTable = orderDSTableAdapter.GetDataByProdOrder(ProdOrderNumber)
                If orderDataTable.Rows.Count >= 1 Then
                    ds.Tables.Add(orderDataTable)

                    Dim orderRow As DataRow = orderDataTable.Rows.Item(0)

                    GTIN = orderRow(orderDataTable.GTINColumn)
                    ProdDesc = orderRow(orderDataTable.Product_DescriptionColumn)
                    Qty = orderRow(orderDataTable.Package_QtyColumn)

                    LabelGTIN.Text = GTIN
                    LabelProdDesc.Text = ProdDesc
                    LabelProdOrder.Text = ProdOrderNumber
                    LabelQty.Text = Qty

                Else
                    LabelMessage.Text = $"Could not locate Production Order# {ProdOrderNumber} in Production Tickets Table"
                    Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, LabelMessage.Text, "KeypadForm-SetProdOrderSelection") ', , KioskException.KioskExceptionType.kioskWarning)

                    Return

                End If


            End If

            ImageButtonBasket.Visible = True
            LabelBasket.Visible = True
            PanelShiftChange.Visible = False

            LabelOrder.Text = "Production Order: " + ProdOrderNumber
            LabelOrder.ForeColor = System.Drawing.Color.Black

            Keypad1.Value = Nothing
            MultiView1.ActiveViewIndex = 2

            ButtonProdOrder.CssClass = "btn btn-success btn-lg"
            ButtonBasket.Visible = True
            Dim usr As UserControl = Keypad1
            Dim btn As Button = usr.Controls.Item(3)

            'find the button on the keypad control and set its on clientclick to processing javascript
            btn.OnClientClick = "ShowProgress();"

        Catch comException As System.Runtime.InteropServices.COMException
            Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Prod order failure  ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

        Catch ex As Exception
            Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, "Label preview failed ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)

        End Try

    End Sub

    ''' <summary>
    ''' Checks the line selection of keypad for validation, usies the value entered in keypad or using the data l
    ''' list selection in Line Master table
    ''' </summary>
    Protected Function CheckLineSelection() As Boolean
        Dim lineDSTableAdapter As New LineFullTableAdapters.FullDataSetTableAdapter '
        Dim lineDataTable As New LineFull.FullDataSetDataTable
        Dim ds As New DataSet()
        LabelMessage.Visible = False
        LabelMessage.Text = ""

        If String.IsNullOrEmpty(LineSelected) Or LineSelected Is Nothing Then
            LabelMessage.Visible = True
            LabelMessage.Text = "No line selected"
            Return False
        End If

        Try
            lineDataTable = lineDSTableAdapter.GetDataByLine(Integer.Parse(LineSelected)) ' .GetData(.GetDataByProdOrder(ProdOrderNumber)
            If lineDataTable.Rows.Count >= 1 Then
                ds.Tables.Add(lineDataTable)

                Dim orderRow As DataRow = lineDataTable.Rows.Item(0)

                PrinterName = orderRow(lineDataTable.strPrinterNameColumn)
                PrinterSelected = orderRow(lineDataTable.fk_nPrinterIdColumn)
                PrinterType = orderRow(lineDataTable.fk_nPrinterTypeIdColumn)

                CheckLineSelection = True
            Else
                LabelMessage.Text = $"Line {LineSelected} not found in Line Master Table"
                Dim kds As KioskException = New KioskException(KioskExceptionType.kioskError, LabelMessage.Text, "KeypadForm - CheckLineSelection")
                Return False
            End If

            If String.IsNullOrEmpty(PrinterName) Or PrinterName Is Nothing Then
                LabelMessage.Text = $"Printer {LabelPrinterName.Text} not found"
                Dim kds As KioskException = New KioskException(KioskExceptionType.kioskError, LabelMessage.Text, "KeypadForm - CheckLineSelection")
                Return False

            Else

                Dim printInfo As ServerPrinterInfo = ServerPrinterInfo.GetServerPrinters(PrinterName)
                isPrinterReady = True

                If printInfo.PrinterName Is Nothing Or String.IsNullOrEmpty(printInfo.PrinterName) Then
                    isPrinterReady = False
                    LabelMessage.Visible = True
                    LabelMessage.Text = $"Printer {PrinterName} is offline, please choose another printer"
                    Dim kds As KioskException = New KioskException(KioskExceptionType.kioskError, $"Printer {PrinterName} is offline, please choose another printer", "KeypadForm - CheckLineSelection")
                    Return False

                End If

            End If

        Catch ex As Exception
            Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, ex.Message, "KeypadForm-CheckLineSelection")
        End Try
        Return CheckLineSelection

    End Function

    ''' <summary>
    ''' Sets the selection for the line
    ''' </summary>
    Protected Sub SetLineSelection()

        Try
            LabelPrinterId.Text = PrinterSelected
            LabelPrinterName.Text = PrinterName
            LabelLineNumber.Text = LineSelected
            LabelKiosk.Text = KioskSelected
            LabelPrintType.Text = PrinterType
            LabelFormat.Text = GetLabelFormat(PrinterType)
            LabelShift.Text = SelectShift() ' SelectShift()
            RadioButtonListShift.SelectedValue = LabelShift.Text


            'set the text for line label to grid selection
            LabelLine.Text = "Line: " + LineSelected
            LabelLine.ForeColor = System.Drawing.Color.Black

            MultiView1.ActiveViewIndex = 1
            Keypad1.Show()
            PanelShiftChange.Visible = True
            ImageButtonOrder.Visible = True
            LabelOrder.Visible = True
            ' Session("PrinterType") = printInfo.
            ButtonProdOrder.Visible = True
            'change button color
            ButtonLineMaster.CssClass = "btn btn-success btn-lg"

        Catch comException As System.Runtime.InteropServices.COMException
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Prod order failure  ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Keypad Form Line Selection", comException.Message, KioskExceptionType.kioskError)
        Catch ex As Exception
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, "Label preview failed ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Keypad Form Line Selection", ex.Message, KioskExceptionType.kioskError)


        End Try


    End Sub

    ''' <summary>
    ''' Sets the canada cert for basket
    ''' </summary>
    Protected Sub SetCanadaSelection()

        Try

            'reset all session variables to current
            SetAllSessionVariables()

            'checks if all data is ready, otherwise sets error
            If readyForLabelPreview() Then Response.Redirect("LabelPrint.aspx")


        Catch comException As System.Runtime.InteropServices.COMException
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Prod order failure  ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Failed setting canada selection", comException.Message, KioskExceptionType.kioskError)

        Catch ex As Exception
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, "Label preview failed ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Failed setting canada selection", ex.Message, KioskExceptionType.kioskError)


        End Try



    End Sub

    ''' <summary>
    ''' Sets the selection for basket
    ''' </summary>
    Protected Sub SetBasketSelection()

        Try

            LabelBasket.Visible = True
            LabelBasket.Text = "Basket: " + BasketNumber.ToString()
            LabelBasket.ForeColor = Drawing.Color.Black
            ButtonBasket.CssClass = "btn btn-success btn-lg"

            'reset all session variables to current
            SetAllSessionVariables()

            'sets viewl model variables to current
            'CreateViewModel()


            'checks if all data is ready, otherwise sets error
            If readyForLabelPreview() Then

                'check if order is a canada certification
                If DataUtility.IsOrderCanadaCert(ProdOrderNumber) Then
                    Keypad1.Value = Nothing
                    MultiView1.ActiveViewIndex = 5
                Else

                    Response.Redirect("LabelPrint.aspx", False)
                End If

            End If

        Catch comException As System.Runtime.InteropServices.COMException
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, "Prod order failure  ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Failed setting basket selection", comException.Message, KioskExceptionType.kioskError)

        Catch ex As Exception
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskWarning, "Label preview failed ", "KeypadForm Web Page") ', , KioskException.KioskExceptionType.kioskWarning)
            WebUtilities.CreateWebViewModelError(viewModel, "Failed setting basket selection", ex.Message, KioskExceptionType.kioskError)


        End Try



    End Sub

    ''' <summary>
    ''' Gets the file name for the label format to be used from PrinterType
    ''' </summary>
    ''' <param name="_printType"></param>
    ''' <returns></returns>
    Protected Function GetLabelFormat(_printType As String) As String
        Dim wu As New WebUtilities()

        Return wu.GetPrinterLabelFormat(_printType)
    End Function

    ''' <summary>
    ''' Selects the proper shift based on the current time of day
    ''' </summary>
    ''' <returns>Shift 1 = 1
    ''' Shift 2 = 2</returns>
    Public Function SelectShift() As Integer
        Dim startTime, endTime, currentTime As TimeSpan
        Dim rightNow As DateTime = DateTime.Now

        Dim midnite As DateTime = New Date(rightNow.Year, rightNow.Month, rightNow.Day, 23, 59, 0)
        Dim shiftEnd As DateTime = New Date(rightNow.Year, rightNow.Month, rightNow.Day, 15, 0, 0)
        Dim shiftstart As DateTime = New Date(rightNow.Year, rightNow.Month, rightNow.Day, 3, 0, 0)
        Dim shift As Integer = 0

        startTime = shiftstart.TimeOfDay
        endTime = shiftEnd.TimeOfDay
        currentTime = Now.TimeOfDay

        If currentTime > startTime And currentTime < endTime Then
            shift = 1
        ElseIf currentTime >= endTime Or currentTime <= startTime Then
            shift = 2
        End If

        Return shift

        'make this use parms passed in to determine if spans midnite
        'If endTime < startTime Then
        '    'the times span midnight 
        '    If currentTime > startTime And currentTime <= endTime Then
        '        shift = 1
        '    ElseIf currentTime < startTime And currentTime >= endTime Then
        '        shift = 2
        '    End If
        '    Return shift '(currentTime <= endTime)
        'Else
        '    'the times do not span midnight
        '    If currentTime > startTime And currentTime <= endTime Then
        '        shift = 1
        '    ElseIf currentTime < startTime And currentTime >= endTime Then
        '        shift = 2
        '    End If
        '    Return shift ' (startTime <= currentTime AndAlso currentTime <= endTime)
        'End If

    End Function

    ''' <summary>
    ''' Check if the label format and data is ready for printing
    ''' </summary>
    ''' <returns>True or False</returns>
    Protected Function readyForLabelPreview() As Boolean
        Dim hv = True
        Dim chkSession As Boolean = True
        Dim msg = "Ready for Printing"
        Dim errMsg = "Need data entry for "
        isPrinterReady = True

        Try

            chkSession = True
            If Not validateDataEntry(chkSession) Then

                errMsg = $"Required - Format: {LabelFormat.Text} Order: {LabelProdOrder.Text} Printer: {LabelPrinterName.Text} Message: {LabelMessage.Text}"
                WebUtilities.CreateWebViewModelError(viewModel, "Ready for Label Printing Validate Entry Failted", errMsg, KioskExceptionType.kioskError)
                LabelMessage.Text = Visible
                LabelMessage.Text = errMsg
                hv = False
                readyForLabelPreview = False
            End If

            'is data complete
            If hv Then
                isDataReady = True
                MultiView1.ActiveViewIndex = 3
                readyForLabelPreview = True

            Else
                LabelMessage.Text = " You have not completed all data entry requirements"
                LabelMessage.ForeColor = Drawing.Color.Red
                LabelPrinterSelected.Text = errMsg
                LabelPrinterSelected.ForeColor = Drawing.Color.Red

                errMsg = $"Format: {LabelFormat.Text} Order: {LabelProdOrder.Text} Printer: {LabelPrinterName.Text} Message: {LabelMessage.Text} are required"
                Dim ks As KioskException =
                        New KioskException("Keypad web form data entry", errMsg, KioskException.KioskExceptionType.kioskError)
                WebUtilities.CreateWebViewModelError(viewModel, "Failed ready for label check", errMsg, KioskExceptionType.kioskError)

                readyForLabelPreview = False
            End If




        Catch comException As System.Runtime.InteropServices.COMException
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, $"Label preivew failed for{FormatName} and prod order {ProdOrderNumber} due to {comException.Message}  ", "KeypadForm Web Page Label Preview") ', , KioskException.KioskExceptionType.kioskWarning)
            'TODO Create viewmodel
            'CreatedViewModelError(viewmodel, "KepadForm-ReadyForLabel", $"Not ready for label preview",KioskExceptionType.kioskError)
            WebUtilities.CreateWebViewModelError(viewModel, "Com Exception setting basket selection", $"Label preview for {FormatName} failed due to {comException.Message}", KioskExceptionType.kioskError)


        Catch ex As Exception
            'Dim ks As KioskException = New KioskException(KioskExceptionType.kioskError, $"Label preview for {FormatName} failed due to {ex.Message}", "KeypadForm Web Page Label Preview") ', , KioskException.KioskExceptionType.kioskWarning)
            'TODO Create viewmodel
            'CreatedViewModelError(viewmodel, "KepadForm-ReadyForLabel", $"Not ready for label preview",KioskExceptionType.kioskError)
            WebUtilities.CreateWebViewModelError(viewModel, "General exception basket selection", $"Label preview for {FormatName} failed due to {ex.Message}", KioskExceptionType.kioskError)



        End Try


        Return hv
    End Function


    ''' <summary>
    ''' Validate the data is present that is needed for printing
    ''' </summary>
    ''' <param name="_checkSession"></param>
    ''' <returns></returns>
    Private Function validateDataEntry(_checkSession As Boolean) As Boolean

        isAllOk = True
        isLineOk = True
        isOrderOk = True
        isPrinterOk = True
        isGTINOk = True
        isPackOk = True
        isFormatOk = True
        Dim isPrintTypeOk = True

        Dim cbErr As KioskException
        Dim s As String = lblInfo.PrinterName
        Dim errMsg As String = "No errors"

        'Check class variables strings
        'If String.IsNullOrEmpty(PackDesc) Then isPackOk = False
        If String.IsNullOrEmpty(LabelLineNumber.Text) Then isLineOk = False
        If String.IsNullOrEmpty(LabelPrinterName.Text) Then isPrinterOk = False
        If String.IsNullOrEmpty(LabelPrintType.Text) Then isPrintTypeOk = False
        If String.IsNullOrEmpty(LabelProdOrder.Text) Then isOrderOk = False
        'If String.IsNullOrEmpty(FormatName) Then isFormatOk = False
        If String.IsNullOrEmpty(GTIN) Then isGTINOk = False


        If isLineOk And isPrinterOk And isOrderOk Then

            isAllOk = True

        Else
            isAllOk = False
            errMsg = "Data is not ready, "
            If Not isPrinterOk Then errMsg = +$" Printer Name was not specified, "
            If Not isPrintTypeOk Then errMsg = +$"Print Type was not specified, "
            If Not isOrderOk Then errMsg = +$"Prod Order was not specified, "
            'If Not isFormatOk Then errMsg = +$"Format Label {FormatName} is not available "

            WebUtilities.CreateWebViewModelError(viewModel, "KeypadForm Web Page Validate Data Entry", errMsg, KioskExceptionType.kioskError)

            'cbErr = New KioskException(KioskExceptionType.kioskError,             $"Label preview for {FormatName} failed due to {errMsg}", "KeypadForm Web Page Label Preview") ', , KioskException.KioskExceptionType.kioskWarning)

        End If

        Return isAllOk
    End Function

#End Region

End Class