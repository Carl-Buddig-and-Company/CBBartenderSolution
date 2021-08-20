Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBWarehouseLabelPrint

Public Class AuditTrail
    Protected Property viewModel As New CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel.PrintDocumentsViewModel

    Public Shared Sub CreateAudit(_viewmodel As PrintDocumentViewsModel.PrintDocumentsViewModel)
        Dim am As AuditModel = New AuditModel()
        Dim strCombine As String = "Completed "

        am.Location = "Process Monitor"
        am.Message = "Completed printing"

        If Not String.IsNullOrEmpty(_viewmodel.FormatName) Then am.FormatName = _viewmodel.FormatName
        If Not String.IsNullOrEmpty(_viewmodel.ProdOrderNumber) Then am.ProdOrderNumber = _viewmodel.ProdOrderNumber
        If Not String.IsNullOrEmpty(_viewmodel.Shift) Then am.Shift = Integer.Parse(_viewmodel.Shift)
        If Not String.IsNullOrEmpty(_viewmodel.Line) Then am.Line = Integer.Parse(_viewmodel.Line)
        If Not String.IsNullOrEmpty(_viewmodel.Qty) Then am.Qty = Integer.Parse(_viewmodel.Qty)
        If Not String.IsNullOrEmpty(_viewmodel.BasketNumber) Then am.BasketNumber = Integer.Parse(_viewmodel.BasketNumber)
        If Not String.IsNullOrEmpty(_viewmodel.Lot) Then am.BasketNumber = _viewmodel.Lot
        If Not String.IsNullOrEmpty(_viewmodel.ProdDesc) Then am.ProdDesc = _viewmodel.ProdDesc
        If Not String.IsNullOrEmpty(_viewmodel.PriceCode) Then am.PriceCode = _viewmodel.PriceCode
        If Not String.IsNullOrEmpty(_viewmodel.Cert) Then am.Cert = _viewmodel.Cert
        If Not String.IsNullOrEmpty(_viewmodel.CodeDate) Then am.CodeDate = _viewmodel.CodeDate
        If Not String.IsNullOrEmpty(_viewmodel.SelectedServerPrinterName) Then am.Comment = _viewmodel.SelectedServerPrinterName
        'If Not String.IsNullOrEmpty(_viewmodel.PackDesc) Then am.PackQty = _viewmodel.PackDesc

        If _viewmodel.PrintMessages.Count > 0 Then
            For Each msg As String In _viewmodel.PrintMessages
                strCombine += $"{msg} "
            Next
            am.Message = strCombine
        End If

        Dim al As AuditLogger = New AuditLogger(am)

        If Not String.IsNullOrEmpty(_viewmodel.Cert) Then DataUtility.UpdateCanadaCert(_viewmodel.ProdOrderNumber, _viewmodel.Cert)


    End Sub

End Class
