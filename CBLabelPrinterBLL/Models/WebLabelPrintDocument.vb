Imports System.Collections.Generic
Imports System.Linq
Imports System.IO
Imports System.Web

Imports Seagull.BarTender.Print
Imports CB.WebLabel.Framework.CB.WebLabel.Framework

Namespace CB.Bartender.Models



    Public Class WebLabelPrintDocument
        Public Property FullPath() As String
            Get
                Return m_FullPath
            End Get
            Set(value As String)
                m_FullPath = value
            End Set
        End Property
        Private m_FullPath As String
        Public Property ThumbnailRelativePath() As String
            Get
                Return m_ThumbnailRelativePath
            End Get
            Set(value As String)
                m_ThumbnailRelativePath = value
            End Set
        End Property
        Private m_ThumbnailRelativePath As String
        Public Property DisplayName() As String
            Get
                Return m_DisplayName
            End Get
            Set(value As String)
                m_DisplayName = value
            End Set
        End Property
        Private m_DisplayName As String

        Public Property ProdOrderNumber() As String
            Get
                Return m_ProdOrderNumber
            End Get
            Set(value As String)
                m_ProdOrderNumber = value
            End Set
        End Property
        Private m_ProdOrderNumber As String
        Public Property BasketNumber() As String
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
        Public Property FormatName As String
            Get
                Return m_formatName
            End Get
            Set(value As String)
                m_formatName = value
            End Set
        End Property
        Private m_formatName As String


        ''' <summary>
        ''' Finds all BarTender documents in the server's Documents directory, generates thumbnails for them,
        ''' and returns a list of valid files. In a real application, we recommend implementing some form of caching.
        ''' Thumbnail generation can be slow, so this implementation keeps track of file modification times to
        ''' avoid re-generating thumbnails unnecessarily.
        ''' </summary>
        Public Shared Function GenerateDocumentsList() As List(Of WebLabelPrintDocument)
            Dim documentsList As New List(Of WebLabelPrintDocument)()

            Try

                Dim documentsFullPath As String = HttpContext.Current.Server.MapPath("~/Documents")
                If Not Directory.Exists(documentsFullPath) Then
                    Return documentsList
                End If

                For Each fileName As String In Directory.GetFiles(documentsFullPath)
                    ' Filter for BarTender documents (.btw files)
                    If Not fileName.ToLowerInvariant().EndsWith("btw") Then
                        Continue For
                    End If

                    Dim document As New WebLabelPrintDocument With {
                        .FullPath = fileName,
                        .DisplayName = Path.GetFileName(fileName)
                    }

                    documentsList.Add(document)

                Next

            Catch exception As PrintEngineException
                Dim ke As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, exception.Message, "WebLabelPrint-GenerateDocumentList")
            Catch comException As System.Runtime.InteropServices.COMException
                Dim ke As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, comException.Message, "WebLabelPrint-GenerateDocumentList")
            Catch ex As Exception
                Dim ke As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ex.Message, "WebLabelPrint-GenerateDocumentList")

            End Try



            Return documentsList
        End Function

        Public Shared Function getDocumentsListForFormatName(_formatName As String) As List(Of WebLabelPrintDocument)
            Dim documentsList As New List(Of WebLabelPrintDocument)()
            Dim document As New WebLabelPrintDocument()
            Dim documentsFullPath As String = HttpContext.Current.Server.MapPath("~/Documents")
            Dim file As File
            If Not Directory.Exists(documentsFullPath) Then
                Return documentsList
            End If

            If Not File.Exists(documentsFullPath) Then
                Return documentsList
            End If

            For Each fileName As String In Directory.GetFiles(documentsFullPath)
                ' Filter for BarTender documents (.btw files)
                If fileName.ToLowerInvariant().EndsWith("btw") Then
                    Dim fn = fileName.Remove(fileName.Length, -4)
                    If fn Is _formatName Then
                        document.FullPath = fileName
                        document.DisplayName = Path.GetFileName(fileName)
                        document.ThumbnailRelativePath = "~/Documents/" + document.DisplayName.Substring(0, document.DisplayName.Length - 3) + "png"
                        document.PreviewPath = "c:\PreviewFolder\"
                        documentsList.Add(document)
                    End If



                    'Continue For
                End If


            Next

            Return documentsList
        End Function
    End Class

End Namespace