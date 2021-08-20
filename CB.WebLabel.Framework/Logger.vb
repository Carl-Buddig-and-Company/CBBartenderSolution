Imports CBWarehouseLabelPrint

Namespace CB.WebLabel.Framework


    Public Class Logger
        Private Shared mTraceSwitch As TraceSwitch



        Public Shared Sub Initialize(ByVal traceSwitch As System.Diagnostics.TraceSwitch)
            mTraceSwitch = traceSwitch
        End Sub

        Public Shared Sub LogError(ByVal _errorModel As ErrorModel, ByVal _source As String, _message As String)
            Dim dsTableAdapter_ProcessErrors As New DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter

            dsTableAdapter_ProcessErrors.Insert("HQ", "", "", "",
                                                Convert.ToInt32(_errorModel.Shift),
                                                Convert.ToInt32(_errorModel.Line),
                                                Date.Today,
                                                Date.Today, DateTime.Now, 5, 1,
                                                _errorModel.SelectedServerPrinterName, _message,
                                                _errorModel.ProdOrderNumber,
                                                _errorModel.FormatName,
                                                _source)


        End Sub

        Public Shared Sub LogError(ByVal application As String, ByVal message As String)
            Logger.LogError(application, message, Nothing)
        End Sub
        Public Shared Sub LogError(ByVal application As String, ByVal message As String, ByVal traceContext As System.Web.TraceContext)
            If Not traceContext Is Nothing Then
                If mTraceSwitch Is Nothing Or mTraceSwitch.TraceError Then
                    traceContext.Write("ERROR", LogString(application, message))

                End If
            End If
            If mTraceSwitch Is Nothing Then
                System.Diagnostics.Trace.WriteLine(LogString(application, message))
            Else
                System.Diagnostics.Trace.WriteLineIf(mTraceSwitch.TraceError, LogString(application, message))
            End If
            My.Application.Log.WriteEntry(LogString(application, message), TraceEventType.Error)
            'InsertError(application, message, "Error")
            InsertError(application, message, "Warning", "", 1, 17, "format name")
        End Sub

        Public Shared Sub LogWarning(ByVal application As String, ByVal message As String)
            Logger.LogWarning(application, message, Nothing)
        End Sub
        Public Shared Sub LogWarning(ByVal application As String, ByVal message As String, ByVal traceContext As System.Web.TraceContext)
            If Not traceContext Is Nothing Then
                If mTraceSwitch Is Nothing Or mTraceSwitch.TraceWarning Then
                    traceContext.Write("WARN", LogString(application, message))

                End If
            End If
            If mTraceSwitch Is Nothing Then
                System.Diagnostics.Trace.WriteLine(LogString(application, message))
            Else
                System.Diagnostics.Trace.WriteLineIf(mTraceSwitch.TraceWarning, LogString(application, message))
            End If
            My.Application.Log.WriteEntry(LogString(application, message), TraceEventType.Warning)
            'InsertError(application, message, "Warning")
            InsertError(application, message, "Warning", "", 1, 17, "format name")
        End Sub

        Public Shared Sub LogInfo(ByVal application As String, ByVal message As String)
            Logger.LogInfo(application, message, Nothing)
        End Sub
        Public Shared Sub LogInfo(ByVal application As String, ByVal message As String, ByVal traceContext As System.Web.TraceContext)
            If Not traceContext Is Nothing Then
                If mTraceSwitch Is Nothing Or mTraceSwitch.TraceInfo Then
                    traceContext.Write("INFO", LogString(application, message))

                End If
            End If
            If mTraceSwitch Is Nothing Then
                System.Diagnostics.Trace.WriteLine(LogString(application, message))
            Else
                System.Diagnostics.Trace.WriteLineIf(mTraceSwitch.TraceInfo, LogString(application, message))
            End If
            My.Application.Log.WriteEntry(LogString(application, message), TraceEventType.Information)
            InsertError(application, message, "Info", "", 1, 17, "format name")
            'application, message, "Information")
        End Sub



        Public Shared Sub LogProcess(_moreInfo As String, _prodOrder As String,
                                     _format As String,
                                     _host As String,
                                     _location As String,
                                     _line As String,
                                     _shift As String,
                                     ByVal application As String,
                                     ByVal message As String,
                                     ByVal type As KioskException.KioskExceptionType)

            Dim dsTableAdapter_ProcessErrors As New DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter
            Dim dt_ProcessErrors As New DataSetErrors.ProcessErrorLogDataTable
            'Dim ds As New DataSetErrors
            Dim dt As DateTime = DateTime.UtcNow

            dsTableAdapter_ProcessErrors.Insert(_location, _host, "",
                                                Date.Today,
                                                Convert.ToInt32(_shift),
                                                Convert.ToInt32(_line),
                                                Date.Today,
                                                Date.Today, dt, 5, 1,
                                                application, _moreInfo, _prodOrder,
                                                _format, type.ToString())


        End Sub

        Public Shared Sub LogProcess(ByVal _errorModel As ErrorModel, ByVal _source As String, ByVal _msg As String)
            Dim dsTableAdapter_ProcessErrors As New DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter
            Dim dt_ProcessErrors As New DataSetErrors.ProcessErrorLogDataTable
            Dim dt As DateTime = DateTime.UtcNow
            'Dim dsKiosk As DataSet() = New DataSet("DatasetKiosk")
            Dim strBld As String = ""
            Dim shift, line As Int32

            If _errorModel.PrintMessages.Count >= 1 Then

                Dim i As Integer = 1

                For Each printMsg As String In _errorModel.PrintMessages
                    If i < 4 Then
                        strBld += $"{printMsg}"
                        i += 1
                    End If
                Next
            End If

            If String.IsNullOrEmpty(_errorModel.Shift) Then
                shift = 1
            Else
                shift = Convert.ToInt32(_errorModel.Shift)
            End If

            If String.IsNullOrEmpty(_errorModel.Line) Then
                line = 99
            Else
                line = Convert.ToInt32(_errorModel.Line)
            End If

            dsTableAdapter_ProcessErrors.InsertError(_errorModel.SelectedServerPrinterName,
                                                     _errorModel.UserId,
                                                     shift,
                                                     line,
                                                     dt,
                                                    _msg,
                                                     strBld,
                                                     _errorModel.ProdOrderNumber,
                                                     _errorModel.FormatName, _errorModel.Source)
            '(.Insert("HQ", "BK", "", Date.Today, Convert.ToInt32(_shift), Convert.ToInt32(_line), Date.Today, Date.Today, dt, 3, 1, _message, "", _order, _format, _source)

        End Sub
        Public Shared Sub LogProcess(ByVal _source As String,
                                       ByVal _message As String,
                                       ByVal _order As String,
                                       ByVal _shift As String,
                                       ByVal _line As String,
                                       ByVal _format As String,
                                       ByVal _type As String)

            Dim dsTableAdapter_ProcessErrors As New DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter
            Dim dt_ProcessErrors As New DataSetErrors.ProcessErrorLogDataTable
            Dim dt As DateTime = DateTime.Now

            '_shift = "1"
            '_line = "998"

            If _shift IsNot Nothing Then dt_ProcessErrors.ShiftColumn.DefaultValue = Convert.ToInt32(_shift)
            If _format IsNot Nothing Then dt_ProcessErrors.FormatColumn.DefaultValue = _format
            If _line IsNot Nothing Then dt_ProcessErrors.LineColumn.DefaultValue = Convert.ToInt32(_line)
            If _order IsNot Nothing Then dt_ProcessErrors.ProdOrderColumn.DefaultValue = _order
            If _source IsNot Nothing Then dt_ProcessErrors.SourceColumn.DefaultValue = _source
            If _message IsNot Nothing Then dt_ProcessErrors.MoreInfoColumn.DefaultValue = _message


            'dt_ProcessErrors.LocationColumn.DefaultValue = "ProcessMonitor"
            'dt_ProcessErrors.UserIdColumn.DefaultValue = "BK"
            'dt_ProcessErrors.ShiftColumn.DefaultValue = _shift
            'dt_ProcessErrors.FormatColumn.DefaultValue = _format
            'dt_ProcessErrors.LineColumn.DefaultValue = _line
            'dt_ProcessErrors.ProdOrderColumn.DefaultValue = _order
            'dt_ProcessErrors.SourceColumn.DefaultValue = _source
            'dt_ProcessErrors.MoreInfoColumn.DefaultValue = _message
            dt_ProcessErrors.EntryDateTimeColumn.DefaultValue = dt
            dt_ProcessErrors.StartTimeColumn.DefaultValue = dt




            ' Dim v1 = dsTableAdapter_ProcessErrors.Insert("HQ", "BK", "", Date.Today, Convert.ToInt32(_shift), Convert.ToInt32(_line), Date.Today, Date.Today, dt, 3, 1, _message, "", _order, _format, _source)
            Dim v = dsTableAdapter_ProcessErrors.Fill(dt_ProcessErrors) ' .Insert("HQ", "BK", "", Date.Today, Convert.ToInt32(_shift), Convert.ToInt32(_line), Date.Today, Date.Today, dt, 3, 1, _message, "", _order, _format, _source)


        End Sub

        'Private Shared Sub LogProcess(_viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel)
        '    Dim dsTableAdapter_ProcessErrors As New DataSetProcessLogTableAdapters.ProcessErrorLogTableAdapter ' New DataSetProcessErrorsTableAdapters.ProcessErrorsTableAdapter
        '    Dim dt_ProcessErrors As New DataSetProcessLog.ProcessErrorLogDataTable ' DataSetProcessErrors.ProcessErrorsDataTable ' .FullDataSetDataTable
        '    Dim dt As DateTime = DateTime.UtcNow
        '    Dim location, packDesc, userId, line, shift, order, printer, path, ppath, message, errType, format, source As String

        '    userId = "BTK"
        '    location = "HQ"
        '    shift = "4"
        '    line = "999"
        '    message = "No message"
        '    order = "No order"
        '    path = "No format path"
        '    ppath = "No preview path"
        '    format = "No format"
        '    source = "No source"

        '    If _viewModel.Line IsNot Nothing Then line = _viewModel.Line
        '    If _viewModel.Shift IsNot Nothing Then shift = _viewModel.Shift
        '    If _viewModel.PackDesc IsNot Nothing Then packDesc = _viewModel.PackDesc
        '    If _viewModel.SelectedServerPrinterName IsNot Nothing Then printer = _viewModel.SelectedServerPrinterName
        '    If _viewModel.ProdOrderNumber IsNot Nothing Then order = _viewModel.ProdOrderNumber
        '    If _viewModel.FormatName IsNot Nothing Then format = _viewModel.FormatName
        '    If _viewModel.FullPath IsNot Nothing Then path = _viewModel.FullPath
        '    If _viewModel.PreviewPath IsNot Nothing Then ppath = _viewModel.PreviewPath
        '    If _viewModel.UserId IsNot Nothing Then userId = _viewModel.UserId
        '    If _viewModel.Source IsNot Nothing Then source = _viewModel.Source

        '    If _viewModel.PrintMessages IsNot Nothing Then
        '        For Each m As String In _viewModel.PrintMessages
        '            message &= m & " " ' Append message
        '        Next

        '    End If

        '    dsTableAdapter_ProcessErrors.InsertQuery(location, userId, "Warehouse Label Print", Date.Today, Convert.ToInt32(shift), Convert.ToInt32(line), Date.Today, Date.Today, dt, 3, 1, message, message, order, format, source)


        'End Sub


        Private Shared Function LogString(ByVal application As String, ByVal message As String) As String
            Return System.DateTime.Now & ":" & application & ":" & message
        End Function

        'Private Shared Sub InsertError(_viewModel As PrintDocumentViewsModel.PrintDocumentsViewModel)
        '    Dim dsTableAdapter_ProcessErrors As New DataSetProcessLogTableAdapters.ProcessErrorLogTableAdapter ' New DataSetProcessErrorsTableAdapters.ProcessErrorsTableAdapter
        '    Dim dt_ProcessErrors As New DataSetProcessLog.ProcessErrorLogDataTable ' DataSetProcessErrors.ProcessErrorsDataTable ' .FullDataSetDataTable
        '    Dim dt As DateTime = DateTime.UtcNow
        '    Dim location, packDesc, userId, line, shift, order, printer, path, ppath, message, errType, format, source As String

        '    userId = "BTK"
        '    location = "HQ"
        '    shift = "4"
        '    line = "999"
        '    message = "No message"
        '    order = "No order"
        '    path = "No format path"
        '    ppath = "No preview path"
        '    format = "No format"
        '    source = "No source"

        '    If _viewModel.Line IsNot Nothing Then line = _viewModel.Line
        '    If _viewModel.Shift IsNot Nothing Then shift = _viewModel.Shift
        '    If _viewModel.PackDesc IsNot Nothing Then packDesc = _viewModel.PackDesc
        '    If _viewModel.SelectedServerPrinterName IsNot Nothing Then printer = _viewModel.SelectedServerPrinterName
        '    If _viewModel.ProdOrderNumber IsNot Nothing Then order = _viewModel.ProdOrderNumber
        '    If _viewModel.FormatName IsNot Nothing Then format = _viewModel.FormatName
        '    If _viewModel.FullPath IsNot Nothing Then path = _viewModel.FullPath
        '    If _viewModel.PreviewPath IsNot Nothing Then ppath = _viewModel.PreviewPath
        '    If _viewModel.UserId IsNot Nothing Then userId = _viewModel.UserId
        '    If _viewModel.Source IsNot Nothing Then source = _viewModel.Source

        '    If _viewModel.PrintMessages IsNot Nothing Then
        '        For Each m As String In _viewModel.PrintMessages
        '            message &= m & " " ' Append message
        '        Next

        '    End If

        '    dsTableAdapter_ProcessErrors.InsertQuery(location, userId, "Warehouse Label Print", Date.Today, Convert.ToInt32(shift), Convert.ToInt32(line), Date.Today, Date.Today, dt, 3, 1, message, message, order, format, source)


        'End Sub

        Private Shared Sub InsertError(ByVal _source As String,
                                       ByVal _message As String,
                                       ByVal _type As String,
                                       ByVal _order As String,
                                       ByVal _shift As String,
                                       ByVal _line As String,
                                       ByVal _format As String)
            'Dim ds As DataSetProcessErrors = New DataSetProcessErrors

            Dim dsTableAdapter_ProcessErrors As New DataSetErrorsTableAdapters.ProcessErrorLogTableAdapter
            Dim dt_ProcessErrors As New DataSetErrors.ProcessErrorLogDataTable
            Dim dt As DateTime = DateTime.UtcNow
            'Dim dsKiosk As DataSet() = New DataSet("DatasetKiosk")

            dsTableAdapter_ProcessErrors.Insert("HQ", "BK", "", Date.Today, Convert.ToInt32(_shift), Convert.ToInt32(_line), Date.Today, Date.Today, dt, 3, 1, _message, "", _order, _format, _source)
            'dsTableAdapter_ProcessErrors.InsertErrors(_message, _source, _type) ' .FillByComputerName(fullDataTable, hostName) '.FillByNpid(NewBenefitsDataSet.FO_HealthcateHighways_Control, "HCHRXMEDTIP")

            'If dt_ProcessErrors.Count >= 1 Then
            '    LabelKioskName.Text = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue
            '    IsKioskFound1 = True
            '    'isKioskThere = True
            '    KioskNumber1 = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue

            'Else LabelKioskName.Text = "Thats not a valid kiosk/lines "
            '    IsKioskFound1 = False
            '    'isKioskThere = False
            '    LabelComputerName.Text = hostName
            '    LabelIP.Text = ipAddress
            'End If

        End Sub

    End Class

End Namespace