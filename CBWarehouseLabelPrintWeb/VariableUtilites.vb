Public Class VariableUtilites

    Private isPrinterReady As Boolean = False
    Private isDataReady As Boolean = False
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
End Class
