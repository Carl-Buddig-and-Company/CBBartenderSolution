Imports System.Web.Script.Serialization

Namespace CB.WebLabel.Framework


    ''' <summary>
    ''' Error Model class
    ''' Purpose: Holds data for error fields
    ''' </summary>
    Public Class ErrorModel


        ''' <summary>
        ''' The index of the currently selected document.
        ''' </summary>
        Public Property SelectedDocumentIndex() As Integer
            Get
                Return m_SelectedDocumentIndex
            End Get
            Set(value As Integer)
                m_SelectedDocumentIndex = value
            End Set
        End Property
        Private m_SelectedDocumentIndex As Integer

        ''' <summary>
        ''' Determines if we're printing to a server or client printer. Values are "Server" or "Client" or "DirectPort".
        ''' </summary>
        Public Property PrintType() As String
            Get
                Return m_PrintType
            End Get
            Set(value As String)
                m_PrintType = value
            End Set
        End Property
        Private m_PrintType As String

        ''' <summary>
        ''' The name of the selected server printer. This is the printer that BarTender will print directly to if
        ''' PrintType is set to "Server". If PrintType is set to "Client", this is the printer that BarTender will
        ''' use to generate the print code that is ultimately sent to the client printer.
        ''' </summary>
        Public Property SelectedServerPrinterName() As String
            Get
                Return m_SelectedServerPrinterName
            End Get
            Set(value As String)
                m_SelectedServerPrinterName = value
            End Set
        End Property
        Private m_SelectedServerPrinterName As String

        ''' <summary>
        ''' The name of the selected client printer. If PrintType is set to "Client", the client print module will
        ''' print to this printer after the job has been processed by BarTender.
        ''' </summary>
        Public Property SelectedClientPrinterName() As String
            Get
                Return m_SelectedClientPrinterName
            End Get
            Set(value As String)
                m_SelectedClientPrinterName = value
            End Set
        End Property
        Private m_SelectedClientPrinterName As String

        ''' <summary>
        ''' The port value used when PrintType is set to "DirectPort".
        ''' </summary>
        Public Property SelectedDirectPort() As String
            Get
                Return m_SelectedDirectPort
            End Get
            Set(value As String)
                m_SelectedDirectPort = value
            End Set
        End Property
        Private m_SelectedDirectPort As String

        ''' <summary>
        ''' The IPv4 or IPv6 address used when printing directly to an IP port.
        ''' </summary>
        Public Property DirectPortIPAddress() As String
            Get
                Return m_DirectPortIPAddress
            End Get
            Set(value As String)
                m_DirectPortIPAddress = value
            End Set
        End Property
        Private m_DirectPortIPAddress As String

        ''' <summary>
        ''' The port number used when printing directly to an IP port.
        ''' </summary>
        Public Property DirectPortPortNumber() As String
            Get
                Return m_DirectPortPortNumber
            End Get
            Set(value As String)
                m_DirectPortPortNumber = value
            End Set
        End Property
        Private m_DirectPortPortNumber As String

        ''' <summary>
        ''' This contains the print license to use for the selected client printer. Any time you print to a client printer,
        ''' a valid license must be generated. When the list is initially loaded, and when the selection changes,
        ''' the client print module will generate a new print license.
        ''' </summary>
        Public Property ClientPrintLicense() As String
            Get
                Return m_ClientPrintLicense
            End Get
            Set(value As String)
                m_ClientPrintLicense = value
            End Set
        End Property
        Private m_ClientPrintLicense As String

        ''' <summary>
        ''' Contains a list of messages generated after printing. These are written out to the page after printing.
        ''' </summary>
        Public Property PrintMessages() As List(Of String)
            Get
                Return m_PrintMessages
            End Get
            Set(value As List(Of String))
                m_PrintMessages = value
            End Set
        End Property
        Private m_PrintMessages As List(Of String)

        ''' <summary>
        ''' This contains the raw print code to send to the client printer if there was a successful client print job.
        ''' </summary>
        Public Property ClientPrintCode() As String
            Get
                Return m_ClientPrintCode
            End Get
            Set(value As String)
                m_ClientPrintCode = value
            End Set
        End Property
        Private m_ClientPrintCode As String

        Public Property ProdOrderNumber() As String
            Get
                Return m_ProdOrderNumber
            End Get
            Set(value As String)
                m_ProdOrderNumber = value
            End Set
        End Property
        Private m_ProdOrderNumber As String
        Public Property BasketNumber As String
            Get
                Return m_basketNumber
            End Get
            Set(value As String)
                m_basketNumber = value
            End Set
        End Property
        Private m_basketNumber As String

        Public Property PackDesc As String
            Get
                Return m_packDesc
            End Get
            Set(value As String)
                m_packDesc = value
            End Set
        End Property
        Private m_packDesc As String

        Public Property Gtin As String
            Get
                Return m_gtin
            End Get
            Set(value As String)
                m_gtin = value
            End Set
        End Property
        Private m_gtin As String

        Public Property FullPath As String
            Get
                Return m_fullPath
            End Get
            Set(value As String)
                m_fullPath = value
            End Set
        End Property
        Private m_fullPath As String

        Public Property PreviewPath As String
            Get
                Return m_previewPath
            End Get
            Set(value As String)
                m_previewPath = value
            End Set
        End Property
        Private m_previewPath As String

        Public Property Qty As String
            Get
                Return m_qty
            End Get
            Set(value As String)
                m_qty = value
            End Set
        End Property
        Private m_qty As String

        Public Property ProdDesc As String
            Get
                Return m_prodDesc
            End Get
            Set(value As String)
                m_prodDesc = value
            End Set
        End Property
        Private m_prodDesc As String

        Public Property Line As String
            Get
                Return m_line
            End Get
            Set(value As String)
                m_line = value
            End Set
        End Property
        Private m_line As String

        Public Property Shift As String
            Get
                Return m_shift
            End Get
            Set(value As String)
                m_shift = value
            End Set
        End Property
        Private m_shift As String

        Public Property FormatName As String
            Get
                Return m_formatName
            End Get
            Set(value As String)
                m_formatName = value
            End Set
        End Property
        Private m_formatName As String

        Public Property UserId As String
            Get
                Return m_userId
            End Get
            Set(value As String)
                m_userId = value
            End Set
        End Property
        Private m_userId As String

        Public Property Source As String
            Get
                Return m_source
            End Get
            Set(value As String)
                m_source = value
            End Set
        End Property
        Private m_source As String

        Public Property Message As String
            Get
                Return m_message
            End Get
            Set(value As String)
                m_message = value
            End Set
        End Property
        Private m_message As String


        ''' <summary>
        ''' Default constructor for creating new error datasets
        ''' </summary>
        Public Sub New()

            ProdOrderNumber = String.Empty
            BasketNumber = String.Empty
            PackDesc = String.Empty
            ProdDesc = String.Empty
            Qty = String.Empty
            FullPath = String.Empty
            PreviewPath = String.Empty
            Gtin = String.Empty
            FormatName = String.Empty
            Line = String.Empty
            Shift = String.Empty
            UserId = String.Empty
            Source = String.Empty
            Message = String.Empty
        End Sub


    End Class
End Namespace

