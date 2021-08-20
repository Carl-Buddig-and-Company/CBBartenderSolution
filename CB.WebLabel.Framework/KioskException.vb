Imports CBLabelPrinterBLL.CB.Bartender.Models

Namespace CB.WebLabel.Framework

    Public Class KioskException
        Inherits Exception

        Enum KioskExceptionType
            kioskError
            kioskWarning
            kioskInformation
        End Enum

        Private mType As KioskExceptionType

        Public Property Type() As KioskExceptionType
            Get
                Return mType
            End Get
            Set(ByVal Value As KioskExceptionType)
                mType = Value
            End Set
        End Property

        ''' <summary>
        ''' Standard generic error with type, message and source basic information
        ''' </summary>
        ''' <param name="type"></param>
        ''' <param name="message"></param>
        ''' <param name="source"></param>
        Public Sub New(ByVal type As KioskExceptionType, ByVal message As String, ByVal source As String)
            MyBase.New(message)
            MyBase.Source = source
            mType = type
            If mType = KioskExceptionType.kioskError Then
                Logger.LogError("KioskException:" & source, message)
            Else
                Logger.LogWarning("KioskException:" & source, message)
            End If
        End Sub

        ''' <summary>
        ''' Full Error - includes errormodel dataset, type, message and source
        ''' </summary>
        ''' <param name="type"></param>
        ''' <param name="message"></param>
        ''' <param name="source"></param>
        ''' <param name="errorModel"></param>
        Public Sub New(ByVal type As KioskExceptionType,
                       ByVal message As String,
                       ByVal source As String,
                       ByVal errorModel As ErrorModel)
            MyBase.New(message)
            MyBase.Source = source
            mType = type
            If errorModel IsNot Nothing Then
                Logger.LogProcess(errorModel, source, message)
            Else
                Logger.LogProcess("KioskInfo:" & source, message, "0", 99, 99, "", "") ' (, message)
            End If

        End Sub

        ''' <summary>
        ''' Exception Error - use for exceptions
        ''' </summary>
        ''' <param name="type"></param>
        ''' <param name="message"></param>
        ''' <param name="e"></param>
        ''' <param name="source"></param>
        Public Sub New(ByVal type As KioskExceptionType,
                       ByVal message As String,
                       ByVal e As Exception,
                       ByVal source As String)
            MyBase.New(message, e)
            MyBase.Source = source
            mType = type
            If mType = KioskExceptionType.kioskError Then
                Logger.LogError("KioskException:" & source, message)
            Else
                Logger.LogWarning("KioskInfo:" & source, message)
            End If

        End Sub

        Public Sub New(ByVal _errorModel As ErrorModel)

            If _errorModel IsNot Nothing Then
                Logger.LogProcess(_errorModel, _errorModel.Source, _errorModel.Message)
            Else
                'AuditLogger.LogAuditProcess("Audit recorded but had no info", "", "", "", "", "", "", "", "", "")
            End If

        End Sub

        ''' <summary>
        ''' No type errors
        ''' </summary>
        ''' <param name="_errorModel"></param>
        ''' <param name="_source"></param>
        ''' <param name="_message"></param>
        Public Sub New(ByVal _errorModel As ErrorModel,
                       _source As String,
                       _message As String)

            If _errorModel IsNot Nothing Then
                Logger.LogError(_errorModel, _source, _message)
            Else
                'AuditLogger.LogAuditProcess("Audit recorded but had no info", "", "", "", "", "", "", "", "", "")
            End If

        End Sub



        Public Function CreateLogEntry(ByVal _source As String, _message As String, _exType As KioskExceptionType) As KioskException

            Return New KioskException(_exType, _message, _source)

        End Function

        Public Function CreateLogExceptionEntry(ByVal _message As String, ByVal _source As String, _ex As Exception, _exType As KioskExceptionType) As KioskException

            Return New KioskException(_exType, _message, _ex, _source)

        End Function

        'Public Function ConvertToSoapException() As System.Web.Services.Protocols.SoapException
        '    Dim errorDoc As New Xml.XmlDocument
        '    Dim message As String = Me.Message
        '    If Not Me.InnerException Is Nothing Then
        '        message = ": " + Me.InnerException.Message
        '    End If

        '    Dim xmlDetailElement As Xml.XmlElement = errorDoc.AppendChild(errorDoc.CreateElement(SoapException.DetailElementName.Name, SoapException.DetailElementName.Namespace))

        '    xmlDetailElement.AppendChild(errorDoc.CreateElement("Type")).AppendChild(errorDoc.CreateTextNode(Convert.ToString(mType)))
        '    xmlDetailElement.AppendChild(errorDoc.CreateElement("Source")).AppendChild(errorDoc.CreateTextNode(Source))
        '    xmlDetailElement.AppendChild(errorDoc.CreateElement("Message")).AppendChild(errorDoc.CreateTextNode(message))

        '    Return New System.Web.Services.Protocols.SoapException("KioskException", SoapException.ClientFaultCode, Me.Source, xmlDetailElement)
        'End Function

    End Class

End Namespace
