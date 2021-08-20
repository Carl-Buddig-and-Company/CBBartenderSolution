
Imports CB.WebLabel.Framework.CB.WebLabel.Framework

Public Class DataUtility

    Public Shared Sub UpdateCanadaCert(_order As String, _canadaCert As String)
        Dim dtsp As New DataSetProductionOrdersTableAdapters.Production_TicketsTableAdapter



        Try
            dtsp.UpdateQuery(_canadaCert, _order)
        Catch ox As Odbc.OdbcException
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ox.Message, $"Canada Cert Update-Datatuility")


        Catch ex As Exception
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ex.Message, $"Canada Cert Update-Datatuility")



        End Try
    End Sub
    Public Shared Function IsOrderCanadaCert(_order As String) As Boolean

        Dim dtsa As New DataSetCanadaCertTableAdapters.vwProdTick_CanadaCertTableAdapter
        Dim certTable As New DataSetCanadaCert.vwProdTick_CanadaCertDataTable
        Dim dt As DateTime = DateTime.UtcNow

        Try
            certTable = dtsa.GetDataByOrder(_order)
            If certTable Is Nothing Or IsDBNull(certTable) Or certTable.Count = 0 Then
                IsOrderCanadaCert = False
            Else
                IsOrderCanadaCert = True
            End If

        Catch ox As Odbc.OdbcException
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ox.Message, $"Canada Cert Lookup-Datatuility")


        Catch ex As Exception
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ex.Message, $"Canada Cert Lookup-Datatuility")


        End Try

        Return IsOrderCanadaCert

    End Function

End Class
