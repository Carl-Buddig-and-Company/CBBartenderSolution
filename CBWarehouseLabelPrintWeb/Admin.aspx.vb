Imports System.ServiceProcess
Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CBLabelPrinterBLL.CB.Bartender
Imports CBLabelPrinterBLL.CB.Bartender.Models
Imports CBWarehouseLabelPrint

Public Class Admin
    Inherits System.Web.UI.Page

#Region "Variables"





    Private _IPAddress As String
    Private _HostName As String
    Private _KioskId As String
    Private _Kiosk As String

    Public Property IPAddress As String
        Get
            Return _IPAddress
        End Get
        Set
            _IPAddress = Value
        End Set
    End Property

    Public Property HostName As String
        Get
            Return _HostName
        End Get
        Set
            _HostName = Value
        End Set
    End Property

    Public Property KioskId As String
        Get
            Return _KioskId
        End Get
        Set
            _KioskId = Value
        End Set
    End Property

    Public Property Kiosk As String
        Get
            Return _Kiosk
        End Get
        Set
            _Kiosk = Value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            'TODO turn on security
            'If Request.UrlReferrer Is Nothing Then Response.Redirect("Login.aspx")
            'If Not Request.UrlReferrer.AbsolutePath = "/Login" Then Response.Redirect("Login.aspx")

            RunCheckup_CheckLogs()
            RunCheckup_BartenderServices()
            RunCheckup_Folders()

            SetComputerNameAndIP()

            ReadCookies()
        Else

        End If

    End Sub




#Region "Mtehods"
    Protected Sub RunCheckup_CheckLogs()
        Dim util As Utilities.Utilities = New Utilities.Utilities
        Dim logStrings As List(Of String) = util.CheckLogs()

        For Each log As String In logStrings
            BulletedListLog.Items.Add(log)
        Next
    End Sub

    Protected Sub RunCheckup_BartenderServices()

        Dim scBTStatus As Boolean = New ServiceController("BarTender System Service").Status = ServiceControllerStatus.Running
        Dim scBTLicenseStatus As Boolean = New ServiceController("BarTender Licensing Service").Status = ServiceControllerStatus.Running
        Dim scBTIntegrationStatus As Boolean = New ServiceController("BarTender Integration Service").Status = ServiceControllerStatus.Running
        Dim scBTPrinterStatus As Boolean = New ServiceController("BarTender Print Scheduler").Status = ServiceControllerStatus.Running
        Dim scBTPrintMaestroStatus As Boolean = New ServiceController("Maestro").Status = ServiceControllerStatus.Running

        Dim scASPState As Boolean = New ServiceController("aspnet_state").Status = ServiceControllerStatus.Running

        If scASPState Then
            BulletedListServices.Items.Add("ASP.Net State Service is running")
        Else
            BulletedListServicesStopped.Items.Add("ASP.Net State Service is not running")
        End If

        If scBTStatus Then
            BulletedListServices.Items.Add("BarTender System Service is running")
        Else
            BulletedListServicesStopped.Items.Add("BarTender System Service is not running")
        End If

        If scBTPrintMaestroStatus Then
            BulletedListServices.Items.Add("Maestro is running")
        Else
            BulletedListServicesStopped.Items.Add("Maestro is not running")
        End If

        If scBTPrinterStatus Then
            BulletedListServices.Items.Add("BarTender Print Scheduler is running")
        Else
            BulletedListServicesStopped.Items.Add("BarTender Print Scheduler is not running")
        End If

        If scBTIntegrationStatus Then
            BulletedListServices.Items.Add("BarTender Integration Service is running")
        Else
            BulletedListServicesStopped.Items.Add("BarTender Integration Service is not running")
        End If

        If scBTLicenseStatus Then
            BulletedListServices.Items.Add("BarTender Licensing Service is running")
        Else
            BulletedListServicesStopped.Items.Add("BarTender Licensing Service is not running")
        End If



    End Sub

    Protected Sub RunCheckup_Printers()
        Dim dtsa As New DataSetPrintersTableAdapters.PrinterTableAdapter
        Dim printTable As New DataSetPrinters.PrinterDataTable
        Dim dt As DateTime = DateTime.Now
        Dim isPrnt As Boolean
        Dim printName As String
        Dim printInfo As ServerPrinterInfo

        Try
            printTable = dtsa.GetData()

            If printTable Is Nothing Or IsDBNull(printTable) Or printTable.Count = 0 Then
                isPrnt = False

            Else
                isPrnt = True

                For Each row As DataRow In printTable
                    printName = row.Item(1)

                    printInfo = ServerPrinterInfo.GetServerPrinters(printName)
                    'isPrinterReady = True

                    If String.IsNullOrEmpty(printInfo.PrinterName) Or printInfo.PrinterName Is Nothing Then
                        BulletedListPrintersMissing.Items.Add($"{printName} is not installed")

                    Else
                        BulletedListPrinters.Items.Add($"{printName} is ok")
                    End If
                Next
            End If

        Catch ox As Odbc.OdbcException
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ox.Message, $"Canada Cert Lookup-Datatuility")


        Catch ex As Exception
            Dim ks As KioskException = New KioskException(KioskException.KioskExceptionType.kioskError, ex.Message, $"Canada Cert Lookup-Datatuility")


        End Try

    End Sub

    Protected Sub RunCheckup_Folders()
        Dim previewFolder As String = Server.MapPath("~/Previews")
        Dim formatFolder As String = Server.MapPath("~/Documents")

        If Not System.IO.Directory.Exists(previewFolder) Then
            System.IO.Directory.CreateDirectory(previewFolder)
            BulletedListFoldersStopped.Items.Add("Preview folder " & previewFolder & " does not exist")
            If System.IO.Directory.Exists(previewFolder) Then
                BulletedListFolders.Items.Add("Created preview folder")
            End If
        Else
            BulletedListFolders.Items.Add("Preview folder exists")
        End If

        If Not System.IO.Directory.Exists(formatFolder) Then
            System.IO.Directory.CreateDirectory(formatFolder)
            BulletedListFoldersStopped.Items.Add("Format folder " & formatFolder & " does not exist")
            If System.IO.Directory.Exists(previewFolder) Then
                BulletedListFolders.Items.Add("Created format folder")
            End If
        Else
            BulletedListFolders.Items.Add("Format folder exists")
        End If


    End Sub

    Private Sub ReadCookies()

        If Request.Cookies("ProcessMonitorKiosk") Is Nothing Then

            'Dim aCookie As New HttpCookie("ProcessMonitorKiosk")
            LabelCookie.Text = "No cookie found for your kiosk, please create or select one"
            MultiView1.ActiveViewIndex = 3
            LabelMessage.Text = LabelCookie.Text
            'aCookie.Expires = DateTime.Now.AddDays(30)

        Else
            LabelWelcome.Text = $"Your using {Request.Cookies("ProcessMonitorKiosk")("kiosk")} - {Request.Cookies("ProcessMonitorKiosk")("kioskId")}"
            LabelCookie.Text = $"Kiosk exists:{Request.Cookies("ProcessMonitorKiosk")("kiosk")} ID: {Request.Cookies("ProcessMonitorKiosk")("kioskId")}"
            Session("Kiosk") = Request.Cookies("ProcessMonitorKiosk")("kioskId")

        End If


    End Sub

    Private Sub DeleteCookies()
        If Request.Cookies("ProcessMonitorKiosk") IsNot Nothing Then

            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("ProcessMonitorKiosk")

            cookie.Expires = DateTime.Now.AddDays(-1D)

            Response.Cookies.Add(cookie)

        End If
    End Sub

    Private Sub CreateCookies()

        If Request.Cookies("ProcessMonitorKiosk") Is Nothing Then

            Dim aCookie As New HttpCookie("ProcessMonitorKiosk")


            aCookie.Expires = DateTime.Now.AddDays(30)

            Response.Cookies.Add(aCookie)

        Else

            Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("ProcessMonitorKiosk")

            cookie.Value = "UserName"

            cookie.Expires = DateTime.Now.AddDays(30)

            Response.Cookies.Add(cookie)

        End If

    End Sub

    Public Sub SetCookieValues()


        If Request.Cookies("ProcessMonitorKiosk") Is Nothing Then

            Dim aCookie As New HttpCookie("ProcessMonitorKiosk")

            aCookie.Values.Add("hostName", TextBoxHostName.Text)
            aCookie.Values.Add("address", TextBoxIP.Text)
            aCookie.Values.Add("kiosk", TextBoxKiosk.Text)
            aCookie.Values.Add("kioskId", TextBoxKioskId.Text)


            aCookie.Expires = DateTime.Now.AddDays(30)

            Response.Cookies.Add(aCookie)

            LabelMessage.Text = $"Success! Your Kiosk {TextBoxKiosk.Text} with ID {TextBoxKioskId} is now setup"

        End If

        'Dim kioskId = label
    End Sub

    Public Sub SetComputerNameAndIP()
        Dim strIPAddress As String = String.Empty
        HostName = System.Net.Dns.GetHostName()

        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(HostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                strIPAddress = ipheal.ToString()
            End If
        Next


        IPAddress = strIPAddress

        TextBoxIP.Text = IPAddress
        TextBoxHostName.Text = HostName

        Session("IP") = IPAddress
        Session("Host") = HostName

    End Sub

    Public Function GetComputerName() As String
        Return System.Net.Dns.GetHostName()

    End Function

#End Region

#Region "Buttons"
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        RunCheckup_CheckLogs()
        RunCheckup_BartenderServices()
        RunCheckup_Folders()

    End Sub
    Protected Sub ButtonAddKioskCookie_Click(sender As Object, e As EventArgs) Handles ButtonAddKioskCookie.Click
        SetCookieValues()
    End Sub

    Protected Sub MenuView_MenuItemClick(sender As Object, e As MenuEventArgs) Handles MenuView.MenuItemClick
        Dim i As Integer
        'Make the selected menu item reflect the correct imageurl
        For i = 0 To MenuView.Items.Count - 1
            If i = e.Item.Value Then

                MultiView1.ActiveViewIndex = i

                Select Case i
                    'Setup view
                    Case 0


                    'Error view
                    Case 1


                    'Checkup view
                    Case 2
                        RunCheckup_Printers()
                    Case 3
                        'Audit view
                    Case 4

                End Select

            Else

            End If
        Next
    End Sub

    Protected Sub GridViewFullDataset0_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewErrors.SelectedIndexChanged
        Dim row = GridViewErrors.SelectedRow
        Dim i = GridViewErrors.Columns.Count() - 1
        Dim dataItem As DataGridItem = GridViewErrors.SelectedRow.DataItem
        LabelErrorMessage.Text = $"{GridViewErrors.SelectedRow.Cells(2).Text} {row.Cells(1).Text}"

    End Sub

    Protected Sub GridViewFullDataset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewFullDataset.SelectedIndexChanged
        TextBoxKiosk.Text = GridViewFullDataset.SelectedRow.Cells(1).Text
        TextBoxKioskId.Text = GridViewFullDataset.SelectedRow.Cells(2).Text
    End Sub

    Protected Sub ButtonAddNewSubmit_Click(sender As Object, e As EventArgs) Handles ButtonAddNewSubmit.Click
        DeleteCookies()
    End Sub

    Protected Sub DataListPlants_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataListPlants.SelectedIndexChanged
        LabelLocation.Text = DataListPlants.SelectedValue.ToString()
        GridViewKioskDetails.Visible = True
    End Sub

    Protected Sub DetailsViewAudit_PageIndexChanging(sender As Object, e As DetailsViewPageEventArgs)

    End Sub

    Protected Sub GridViewKioskDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewKioskDetails.SelectedIndexChanged
        TextBoxKiosk.Text = GridViewKioskDetails.SelectedRow.Cells(1).Text
        TextBoxKioskId.Text = GridViewKioskDetails.SelectedRow.Cells(2).Text
        LabelMessage.Visible = True
        LabelMessage.Text = $"You have selected {TextBoxKiosk.Text} as your Kiosk, click create to assign"
    End Sub










#End Region





End Class