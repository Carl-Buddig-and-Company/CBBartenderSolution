Imports System.Web.Script.Serialization
Imports CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CB.WebLabel.Framework.CB.WebLabel.Framework.KioskException
Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBLabelPrinterBLL.CB.Bartender.Models.PrintDocumentViewsModel
Imports CBWarehouseLabelPrint

Public Class WebUtilities

    Public Property isKioskFound As Boolean

    ''' <summary>
    ''' Gets the name of the label format file to be used 
    ''' by calling the dataset and passing in query parm for printer type
    ''' </summary>
    ''' <param name="_printType"></param>
    ''' <returns>Type of printer</returns>
    Public Function GetPrinterLabelFormat(_printType As String) As String
        Dim ret As String = ""
        Dim printTypeAdapter As New DataSetPrinterTypesTableAdapters.PrinterTypeTableAdapter
        Dim ptDataTable As New DataSetPrinterTypes.PrinterTypeDataTable
        Dim printDS As DataSetPrinterTypes = New DataSetPrinterTypes
        Dim printRow As DataRow

        'ptDataTable = printTypeAdapter.GetDataByPrinterType(_printType)
        ptDataTable = printTypeAdapter.GetDataByPrinterType(Integer.Parse(_printType))

        If ptDataTable.Count >= 1 Then
            ' printRow = ptDataTable.Rows()

            For Each pr As DataRow In ptDataTable.Rows
                ret = pr.Item(4)
                Return $"{ret}BUDDIG.FMT.btw"
            Next

            'printRow = printDS.c("strLabelTypeColumn")
            'If Not IsDBNull(ptDataTable.strLabelTypeColumn) Then
            '    Dim dc As DataColumn = ptDataTable.strLabelTypeColumn
            '    ret = dc.DefaultValue
            '    If ret IsNot Nothing Then
            '        Return $"{ret}BUDDIG.FMT.btw"
            '    End If
            'Else

            'End If
            ret = "Failed"
        End If

        Return ret
    End Function


    ''' <summary>
    ''' Gets the substrings data needed
    ''' </summary>
    ''' <param name="_order">797123</param>
    ''' <returns>PrintDocumentsViewModel</returns>
    Public Function GetPrinterLabelSubstrings(_order As String) As PrintDocumentsViewModel
        Dim printViewDoc As New PrintDocumentsViewModel
        Dim prodTickAdapter As New DataSetProdTickTableAdapters.vwProdTickTableAdapter
        Dim prodTickDataTable As New DataSetProdTick.vwProdTickDataTable

        prodTickDataTable = prodTickAdapter.GetDataByOrder(_order)

        If prodTickDataTable.Count >= 1 Then
            Dim dr As DataRow
            dr = prodTickDataTable.Rows(0)
            Dim obj = dr.Item(prodTickDataTable.ProdDescColumn)

            'set prod tick values
            printViewDoc.ProdDesc = dr.Item(prodTickDataTable.ProdDescColumn).ToString
            printViewDoc.PackDesc = $"{dr.Item(prodTickDataTable.PackQtyColumn)} - {dr.Item(prodTickDataTable.ProdSizeColumn)}"
            printViewDoc.PriceCode = dr.Item(prodTickDataTable.PriceCodeColumn).ToString
            printViewDoc.Qty = dr.Item(prodTickDataTable.PackQtyColumn).ToString
            printViewDoc.Version = dr.Item(prodTickDataTable.VersionColumn).ToString
            printViewDoc.Gtin = dr.Item(prodTickDataTable.GTINColumn).ToString
            printViewDoc.CodeDate = dr.Item(prodTickDataTable.DateProdColumn).ToString
            printViewDoc.NewCodeDate = dr.Item(prodTickDataTable.DateProdColumn).ToString
        End If



        Return printViewDoc


    End Function

    Public Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next

    End Function

    Public Function GetComputerName() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()

        GetComputerName = strHostName
    End Function


    Public Function getKioskId() As String
        Dim hostName = GetComputerName()
        Dim ipAddress = GetIPv4Address()

        Dim fullDSTableAdapter As New LineFullTableAdapters.FullDataSetTableAdapter
        Dim fullDataTable As New LineFull.FullDataSetDataTable
        Dim ds As New DataSet()

        fullDSTableAdapter.FillByComputerName(fullDataTable, hostName) '.FillByNpid(NewBenefitsDataSet.FO_HealthcateHighways_Control, "HCHRXMEDTIP")

        If fullDataTable.Count >= 1 Then

            getKioskId = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue
            isKioskFound = True

        Else
            isKioskFound = False
            getKioskId = 0
        End If
    End Function


    ''' <summary>
    ''' Displays available documents with thumbnails and allows printing to printers, client printers, and client ports.
    ''' </summary>
    Public Function PrintDocuments(_printerName As String) As String
        Dim documentsList As List(Of WebLabelPrintDocument) = WebLabelPrintDocument.GenerateDocumentsList()
        Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()

        ' Set default view model options
        Dim viewModel As New PrintDocumentsViewModel()
        viewModel.DocumentsList = documentsList
        viewModel.ServerPrintersList = serverPrintersList
        viewModel.SelectedDocumentIndex = 0
        viewModel.PrintType = "Server"

        If _printerName.Length >= 1 Then
            viewModel.SelectedClientPrinterName = _printerName

        Else viewModel.SelectedClientPrinterName = String.Empty
        End If
        ' Set the default server printer to the Windows default printer if one is available. Oftentimes, when a web application is hosted
        ' as an AppPool account that is different than the current user, we may not be able to get a default printer. In that case, select
        ' the first available printer.
        Dim hasDefault As Boolean = False
        For Each printerInfo As ServerPrinterInfo In serverPrintersList
            If printerInfo.IsDefault Then
                viewModel.SelectedServerPrinterName = printerInfo.PrinterName
                hasDefault = True
                Exit For
            End If
        Next
        If Not hasDefault AndAlso serverPrintersList.Count > 0 Then
            viewModel.SelectedServerPrinterName = serverPrintersList(0).PrinterName
        End If

        'ViewBag.CurrentPage = "PrintDocuments"
        Return "Doc printed" ' View(viewModel)
    End Function

    ''' <summary>
    ''' Prints the specified document
    ''' </summary>
    Public Function PrintDocument(viewModel As PrintDocumentsViewModel) As String
        Dim documentsList As List(Of WebLabelPrintDocument) = WebLabelPrintDocument.GenerateDocumentsList()
        Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()

        ' The selected server printer actually comes back with the clientside JSON value. Parse that back
        ' into a PrinterInfo so that we can get the actual printer name back.
        If Not String.IsNullOrEmpty(viewModel.SelectedServerPrinterName) Then
            Dim printerInfo As ServerPrinterInfo = New JavaScriptSerializer().Deserialize(Of ServerPrinterInfo)(viewModel.SelectedServerPrinterName)
            viewModel.SelectedServerPrinterName = printerInfo.PrinterName
        End If

        viewModel.DocumentsList = documentsList
        viewModel.ServerPrintersList = serverPrintersList

        Dim documentFileName As String = documentsList(viewModel.SelectedDocumentIndex).FullPath

        ' Perform the print job. Client and Direct Port print jobs are treated the same on the server.
        If viewModel.PrintType = "Server" Then
            viewModel.PrintMessages = PrintSchedulerServiceSupport.PrintToServerPrinter(documentFileName, viewModel.SelectedServerPrinterName)
        Else
            Dim printCode As String = String.Empty
            viewModel.PrintMessages = PrintSchedulerServiceSupport.PrintToClientPrinter(documentFileName, viewModel.SelectedServerPrinterName, viewModel.ClientPrintLicense, printCode)

            If Not String.IsNullOrEmpty(printCode) Then
                viewModel.ClientPrintCode = printCode
            End If
        End If

        'ViewBag.CurrentPage = "PrintDocuments"
        Return "Printed" ' View("PrintDocuments", viewModel)
    End Function

    Public Function IsKioskThere(kioskName As String) As String
        Dim fullDSTableAdapter As New LineFullTableAdapters.FullDataSetTableAdapter
        Dim fullDataTable As New LineFull.FullDataSetDataTable
        Dim ds As New DataSet()

        fullDSTableAdapter.FillByComputerName(fullDataTable, kioskName) '.FillByNpid(NewBenefitsDataSet.FO_HealthcateHighways_Control, "HCHRXMEDTIP")

        If fullDataTable.Count >= 1 Then

            IsKioskThere = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue

        Else
            IsKioskThere = 0

        End If
    End Function

    Public Shared Sub CreateWebViewModelError(viewModel As PrintDocumentsViewModel,
                                              _source As String,
                                              _message As String,
                                              _type As KioskExceptionType)
        Dim docModel As PrintDocumentsViewModel = New PrintDocumentsViewModel()
        docModel = viewModel
        Dim errorModel As ErrorModel = New ErrorModel With {
                .ProdOrderNumber = docModel.ProdOrderNumber,
                .SelectedServerPrinterName = docModel.SelectedServerPrinterName,
                .BasketNumber = docModel.BasketNumber,
                .FormatName = docModel.FormatName,
                .Gtin = docModel.Gtin,
                .Line = docModel.Line,
                .Shift = docModel.Shift,
                .FullPath = docModel.FullPath,
                .PrintMessages = viewModel.PrintMessages,
                .Source = viewModel.Source
            }


        Dim ks As KioskException = New KioskException(_type, _message, _source, errorModel)

    End Sub


    ''' <summary>
    ''' This creates the error model.
    ''' Allows for passing of single object with all error information
    ''' </summary>
    ''' <param name="viewModel"></param>
    Public Shared Sub CreateWebViewModelError(viewModel As PrintDocumentsViewModel)
        Dim docModel As PrintDocumentsViewModel = New PrintDocumentsViewModel()
        docModel = viewModel
        Dim errorModel As ErrorModel = New ErrorModel With {
                .ProdOrderNumber = docModel.ProdOrderNumber,
                .SelectedServerPrinterName = docModel.SelectedServerPrinterName,
                .BasketNumber = docModel.BasketNumber,
                .FormatName = docModel.FormatName,
                .Gtin = docModel.Gtin,
                .Line = docModel.Line,
                .Shift = docModel.Shift,
                .FullPath = docModel.FullPath,
                .PrintMessages = viewModel.PrintMessages,
                .Source = viewModel.Source
            }

        'Dim msg As String = message

        'For Each mg As String In viewModel.PrintMessages
        '    msg += mg
        'Next

        Dim ks As KioskException = New KioskException(errorModel)

    End Sub
    Public Sub DocumentModelError(docModel As WebLabelPrintDocument)

    End Sub

End Class
