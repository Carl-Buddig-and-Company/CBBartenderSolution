Public Class About
    Inherits Page

    Protected isPrinterReady As Boolean = False
    Protected isDataReady As Boolean = False


    Protected Property PrinterName() As String ' = CType(Session.Item("PrinterName"), String)
    Public Property LineSelected() As String '= CType(Session.Item("Line"), String)
    Public Property KioskSelected() As String '= CType(Session.Item("Kiosk"), String)
    Public Property PrinterSelected() As String '= CType(Session.Item("PrinterId"), String)
    Public Property ProductionOrder() As DataSet





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load




    End Sub



End Class