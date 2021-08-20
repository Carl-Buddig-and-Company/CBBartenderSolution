Namespace CB.WebLabel.Framework


    Public Class PreviewCleaner
        Private m_FolderPath As String

        Public Property FolderPath As String
            Get
                Return m_FolderPath
            End Get
            Set
                m_FolderPath = Value
            End Set
        End Property

        Public Function DeleteLabelPreviews() As List(Of String)

        End Function

        Private Function DeleteLabelPreviews(_folderName As String, _ext As String) As List(Of String)
            Dim msgs As List(Of String) = New List(Of String)
            Dim msg As String = Nothing
            Dim previewFolder As String = _folderName

            'Dim paths As String() = New String() {previewFolder, fileName & _ext}
            'Dim fullPath As String = Path.Combine(paths)


            Return msgs
        End Function
    End Class
End Namespace