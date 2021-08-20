Namespace CB.Bartender.Models

    <Serializable()>
Public Class LabelInfo

        Private mFormat As String
        Private mPrinterName As String
        Private mLineNumber As Integer
        Private mOrderNumber As Integer
        Private mBasketNumber As String
        Private mPrinterCode As String
        Private mPrinterResetExpression As String

        Private mPackDesc As String
        Private mProdOrderNumber As String
        Private mProductionOrder As DataSet
        Private mPrinterSelected As String
        Private mKioskSelected As String
        Private mLineSelected As String

        Private mGtin As String
        Private mProductDesc As String
        Private mQty As String


        Public Property LineNumber() As Integer
            Get
                Return mLineNumber
            End Get
            Set(ByVal Value As Integer)
                mLineNumber = Value
            End Set
        End Property
        Public Property OrderNumber() As Integer
            Get
                Return mOrderNumber
            End Get
            Set(ByVal Value As Integer)
                mOrderNumber = Value
            End Set
        End Property

        Public Property BasketNumber() As String
            Get
                Return mBasketNumber
            End Get
            Set(ByVal Value As String)
                mBasketNumber = Value
            End Set
        End Property
        Public Property Format() As String
            Get
                Return mFormat
            End Get
            Set(ByVal Value As String)
                mFormat = Value
            End Set
        End Property

        Public Property PrinterName() As String
            Get
                Return mPrinterName
            End Get
            Set(ByVal Value As String)
                mPrinterName = Value
            End Set
        End Property

        Public Property PrinterCode() As String
            Get
                Return mPrinterCode
            End Get
            Set(ByVal Value As String)
                mPrinterCode = Value
            End Set
        End Property
        Public Property PrinterResetExpression() As String
            Get
                Return mPrinterResetExpression
            End Get
            Set(ByVal Value As String)
                mPrinterResetExpression = Value
            End Set
        End Property

        Public Property ProductDesc As String
            Get
                Return mProductDesc
            End Get
            Set(value As String)
                mProductDesc = value
            End Set
        End Property

        Public Property Qty As String
            Get
                Return mQty
            End Get
            Set(value As String)
                mQty = value
            End Set
        End Property

        Public Property Gtin As String
            Get
                Return mGtin
            End Get
            Set(value As String)
                mGtin = value
            End Set
        End Property

        Public Property LineSelected As String
            Get
                Return mLineSelected
            End Get
            Set(value As String)
                mLineSelected = value
            End Set
        End Property

        Public Property KioskSelected As String
            Get
                Return mKioskSelected
            End Get
            Set(value As String)
                mKioskSelected = value
            End Set
        End Property

        Public Property PrinterSelected As String
            Get
                Return mPrinterSelected
            End Get
            Set(value As String)
                mPrinterSelected = value
            End Set
        End Property

        Public Property ProductionOrder As DataSet
            Get
                Return mProductionOrder
            End Get
            Set(value As DataSet)
                mProductionOrder = value
            End Set
        End Property

        Public Property ProdOrderNumber As String
            Get
                Return mProdOrderNumber
            End Get
            Set(value As String)
                mProdOrderNumber = value
            End Set
        End Property

        Public Property PackDesc As String
            Get
                Return mPackDesc
            End Get
            Set(value As String)
                mPackDesc = value
            End Set
        End Property
    End Class


End Namespace