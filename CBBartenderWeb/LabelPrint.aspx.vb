Imports CBLabelPrinterBLL.CB.Bartender.Models
Public Class Contact
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        PrinterList_Load()
    End Sub

    Private Sub PrinterList_Load()


        'Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()

        '' Set the default server printer to the Windows default printer if one is available. Oftentimes, when a web application is hosted
        '' as an AppPool account that is different than the current user, we may not be able to get a default printer. In that case, select
        '' the first available printer.
        'Dim hasDefault As Boolean = False
        'For Each printerInfo As ServerPrinterInfo In serverPrintersList
        '    DropDownListPrinters.Items.Add(printerInfo.PrinterName)
        '    If printerInfo.IsDefault Then
        '        DropDownListPrinters.SelectedValue = printerInfo.PrinterName
        '        hasDefault = True
        '        Exit For
        '    End If
        'Next
        'If Not hasDefault AndAlso serverPrintersList.Count > 0 Then
        '    DropDownListPrinters.SelectedValue = serverPrintersList(0).PrinterName
        '    'viewModel.SelectedServerPrinterName = serverPrintersList(0).PrinterName
        'End If
    End Sub
End Class