Namespace CB.WebLabel.Framework
    Public Class AuditModel


        Private m_ProdOrderNumber As String
        Private m_basketNumber As Integer
        Private m_fullPath As String
        Private m_line As Integer
        Private m_shift As Integer
        Private m_qty As Integer
        Private m_formatName As String
        Private m_message As String
        Private _Location As String
        Private _prc As String
        Private _Cert As String
        Private _CodeDate As String
        Private _MeatCode As String
        Private _PriceCode As String
        Private _Version As String
        Private _PrivLabel As String
        Private _OrderLineNo As String
        Private _OrderId As String
        Private _MOQ As String
        Private _GTIN As String
        Private _Comment As String
        Private _ProductNo As String
        Private _ProdDesc As String
        Private _SpecPack As String
        Private _PackQty As String
        Private _MfgOrder As String

        Public Property ProdOrderNumber() As String
            Get
                Return m_ProdOrderNumber
            End Get
            Set(value As String)
                m_ProdOrderNumber = value
            End Set
        End Property

        Public Property BasketNumber As Integer
            Get
                Return m_basketNumber
            End Get
            Set(value As Integer)
                m_basketNumber = value
            End Set
        End Property


        Public Property FullPath As String
            Get
                Return m_fullPath
            End Get
            Set(value As String)
                m_fullPath = value
            End Set
        End Property


        Public Property Qty As Integer
            Get
                Return m_qty
            End Get
            Set(value As Integer)
                m_qty = value
            End Set
        End Property

        Public Property Line As Integer
            Get
                Return m_line
            End Get
            Set(value As Integer)
                m_line = value
            End Set
        End Property

        Public Property Shift As Integer
            Get
                Return m_shift
            End Get
            Set(value As Integer)
                m_shift = value
            End Set
        End Property

        Public Property FormatName As String
            Get
                Return m_formatName
            End Get
            Set(value As String)
                m_formatName = value
            End Set
        End Property

        Public Property Message As String
            Get
                Return m_message
            End Get
            Set(value As String)
                m_message = value
            End Set
        End Property

        Public Property Location As String
            Get
                Return _Location
            End Get
            Set
                _Location = Value
            End Set
        End Property

        Public Property ProdRecallChar As String
            Get
                Return _prc
            End Get
            Set
                _prc = Value
            End Set
        End Property

        Public Property Cert As String
            Get
                Return _Cert
            End Get
            Set
                _Cert = Value
            End Set
        End Property

        Public Property CodeDate As String
            Get
                Return _CodeDate
            End Get
            Set
                _CodeDate = Value
            End Set
        End Property

        Public Property MeatCode As String
            Get
                Return _MeatCode
            End Get
            Set
                _MeatCode = Value
            End Set
        End Property

        Public Property PriceCode As String
            Get
                Return _PriceCode
            End Get
            Set
                _PriceCode = Value
            End Set
        End Property

        Public Property Version As String
            Get
                Return _Version
            End Get
            Set
                _Version = Value
            End Set
        End Property

        Public Property PrivLabel As String
            Get
                Return _PrivLabel
            End Get
            Set
                _PrivLabel = Value
            End Set
        End Property

        Public Property OrderLineNo As String
            Get
                Return _OrderLineNo
            End Get
            Set
                _OrderLineNo = Value
            End Set
        End Property

        Public Property OrderId As String
            Get
                Return _OrderId
            End Get
            Set
                _OrderId = Value
            End Set
        End Property

        Public Property MOQ As String
            Get
                Return _MOQ
            End Get
            Set
                _MOQ = Value
            End Set
        End Property

        Public Property Comment As String
            Get
                Return _Comment
            End Get
            Set
                _Comment = Value
            End Set
        End Property

        Public Property MfgOrder As String
            Get
                Return _MfgOrder
            End Get
            Set
                _MfgOrder = Value
            End Set
        End Property

        Public Property PackQty As String
            Get
                Return _PackQty
            End Get
            Set
                _PackQty = Value
            End Set
        End Property

        Public Property SpecPack As String
            Get
                Return _SpecPack
            End Get
            Set
                _SpecPack = Value
            End Set
        End Property

        Public Property ProdDesc As String
            Get
                Return _ProdDesc
            End Get
            Set
                _ProdDesc = Value
            End Set
        End Property

        Public Property ProductNo As String
            Get
                Return _ProductNo
            End Get
            Set
                _ProductNo = Value
            End Set
        End Property

        Public Property GTIN As String
            Get
                Return _GTIN
            End Get
            Set
                _GTIN = Value
            End Set
        End Property

        ''' <summary>
        ''' Default constructor
        ''' </summary>
        Public Sub New()

            ProdOrderNumber = String.Empty
            BasketNumber = 99 ' String.Empty
            Qty = 99 ' String.Empty
            FullPath = String.Empty
            FormatName = String.Empty
            Line = 99 'String.Empty
            Shift = 99 ' String.Empty
            Message = String.Empty
            Location = String.Empty
            ProdRecallChar = "P"
            SpecPack = String.Empty
        End Sub
    End Class

End Namespace

