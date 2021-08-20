Namespace CB.WebLabel.Framework
    ''' <summary>
    ''' Author: Brian Kinser
    ''' Purpose: Provides an audit framework for tracking all printed labesl
    ''' </summary>
    Public Class AuditLogger

        Public Sub New(ByVal _auditModel As AuditModel)

            If _auditModel IsNot Nothing Then
                AuditLogger.LogAuditProcess(_auditModel)
            Else
                'AuditLogger.LogAuditProcess("Audit recorded but had no info", "", "", "", "", "", "", "", "", "")
            End If

        End Sub

        Public Sub New(ByVal _message As String,
                                        ByVal _orderNum As String,
                                        ByVal _shift As String,
                                        ByVal _line As String,
                                        ByVal _formatName As String,
                                        ByVal _location As String,
                                        ByVal _qty As String,
                                        ByVal _bin As String)


            AuditLogger.LogAuditProcess(_location,
                                            _line,
                                            _bin,
                                            _orderNum,
                                            _qty,
                                            _shift,
                                            _formatName,
                                            _message)


        End Sub

        Private Shared Sub LogAuditProcess(ByVal _auditModel As AuditModel)

            Dim dsTableAdapter_ProcessAudits As New DataSetAuditTableAdapters.ProductionLineNewTableAdapter
            Dim dt As DateTime = DateTime.Now

            Try

                dsTableAdapter_ProcessAudits.InsertAudit(_auditModel.Location,
                                                         _auditModel.Line,
                                                         _auditModel.BasketNumber,
                                                         _auditModel.ProdOrderNumber,
                                                         _auditModel.Qty,
                                                        _auditModel.Shift,
                                                        _auditModel.FormatName,
                                                        _auditModel.Message,
                                                        dt, dt, dt,
                                                        "Size",
                                                        _auditModel.MeatCode,
                                                        _auditModel.Qty,
                                                        _auditModel.PriceCode,
                                                        _auditModel.CodeDate,
                                                        _auditModel.ProdDesc,
                                                        _auditModel.ProductNo)



            Catch ox As Odbc.OdbcException
                Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ox.Message, $"Audit Logger ODBC Error - LogAuditProcess Order:{_auditModel.ProdOrderNumber}")


            Catch ex As Exception
                Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ex.Message, $"Audit Logger - LogAuditProcess Order:{_auditModel.ProdOrderNumber}")


            End Try



        End Sub


        Private Shared Sub LogAuditProcess(ByVal _message As String,
                                        ByVal _orderNum As String,
                                        ByVal _shift As String,
                                        ByVal _line As String,
                                        ByVal _formatName As String,
                                        ByVal _location As String,
                                        ByVal _qty As String,
                                        ByVal _bin As String)

            Dim dsTableAdapter_ProcessAudits As New DataSetAuditTableAdapters.ProductionLineNewTableAdapter
            Dim dt As DateTime = DateTime.UtcNow

            'dsTableAdapter_ProcessAudits.InsertAudit(_location,
            '_line,
            '                                             _bin,
            '                                             _orderNum,
            '                                             _qty,
            '                                            _shift,
            '                                            _formatName,
            '                                            _message,
            '                                            dt, dt, dt, "SIZE")

        End Sub
    End Class

End Namespace


