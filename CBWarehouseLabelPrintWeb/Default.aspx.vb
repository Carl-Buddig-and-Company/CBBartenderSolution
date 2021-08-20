Imports CB.WebLabel.Framework.CB.WebLabel.Framework
Imports CBWarehouseLabelPrint

Public Class _Default
    Inherits Page

    Private kioskNumber As String
    Private lineNumber As String
    Private ipAddress As String
    Private hostName As String
    Private printerName As String
    Private isKioskFound As Boolean
    Private hasComputerName As Boolean

#Region "Properties"
    Public Property KioskNumber1 As String
        Get
            Return kioskNumber
        End Get
        Set(value As String)
            kioskNumber = value
        End Set
    End Property

    Public Property IpAddress1 As String
        Get
            Return ipAddress
        End Get
        Set(value As String)
            ipAddress = value
        End Set
    End Property

    Public Property HostName1 As String
        Get
            Return hostName
        End Get
        Set(value As String)
            hostName = value
        End Set
    End Property

    Public Property IsKioskFound1 As Boolean
        Get
            Return isKioskFound
        End Get
        Set(value As Boolean)
            isKioskFound = value
        End Set
    End Property

    Public Property HasComputerName1 As Boolean
        Get
            Return hasComputerName
        End Get
        Set(value As Boolean)
            hasComputerName = value
        End Set
    End Property

    Public Property PrinterName1 As String
        Get
            Return printerName
        End Get
        Set(value As String)
            printerName = value
        End Set
    End Property
#End Region



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            IpAddress1 = CType(Session.Item("IP"), String)
            HostName1 = CType(Session.Item("Host"), String)

            If IpAddress1 IsNot String.Empty And HostName1 IsNot String.Empty Then

                HasComputerName1 = True
            Else
                HasComputerName1 = False

            End If

        Else
            GetComputerNameAndIP()

            If hasComputerName Then
                If isKioskThere() Then
                    ForwardDataSession()
                End If
            Else
                LabelKioskName.Text = "Your computer name or ip address cannot be loaded"
                LabelIP.Text = ipAddress
                LabelComputerName.Text = hostName
                Dim errMsg As String = $"Computer name: {hostName} IP: {ipAddress} has no associated record in the kiosk table"
                Dim ks As KioskException =
                New KioskException($"Error. The current kiosk was not found", errMsg, KioskException.KioskExceptionType.kioskWarning)

            End If
            ' IpAddress1 = FindKiosk()
            ' HostName1 = GetComputerName()

        End If




    End Sub

#Region "Methods"


    ''' <summary>
    ''' Check cookie of current user and set session variables
    ''' </summary>
    Public Sub setKioskId()
        Dim hostName = GetComputerName()
        Dim ipAddress = LabelIP.Text
        Dim kiosk = LabelComputerName.Text
        Dim pc = LabelComputerName.Text
        Dim kioskId = "1" ' LabelKioskName.Text

        If Request.Cookies("ProcessMonitorKiosk") Is Nothing Then

            Dim aCookie As New HttpCookie("ProcessMonitorKiosk")

            aCookie.Values.Add("hostName", hostName)
            aCookie.Values.Add("address", ipAddress)
            aCookie.Values.Add("kiosk", kiosk)
            aCookie.Values.Add("kioskId", kioskId)

            aCookie.Expires = DateTime.Now.AddDays(30)

            Response.Cookies.Add(aCookie)

        Else

            'Dim cookie As HttpCookie = HttpContext.Current.Request.Cookies("UserName")

            'cookie.Value = "UserName"

            'cookie.Expires = DateTime.Now.AddDays(30)

            'Response.Cookies.Add(cookie)

        End If

        'set session variables for hostname, kiosk and ipadress
        'Session("PrinterName") = GridViewFullDataset.SelectedRow.Cells(12).Text
        Session("HostName") = hostName
        Session("Kiosk") = kioskNumber
        Session("KioskId") = kioskId
        Session("IPAddress") = ipAddress

    End Sub

    ''' <summary>
    ''' Looks up the computer name in the DB, checks the cookie for kiosk information
    ''' </summary>
    ''' <returns></returns>
    Public Function isKioskThere() As Boolean

        Dim fullDSTableAdapter As New LineFullTableAdapters.FullDataSetTableAdapter
        Dim fullDataTable As New LineFull.FullDataSetDataTable
        Dim ds As New DataSet()

        fullDSTableAdapter.FillByComputerName(fullDataTable, hostName) '.FillByNpid(NewBenefitsDataSet.FO_HealthcateHighways_Control, "HCHRXMEDTIP")

        If fullDataTable.Count >= 1 Then
            LabelKioskName.Text = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue
            IsKioskFound1 = True
            isKioskThere = True
            KioskNumber1 = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue

        ElseIf Request.Cookies("ProcessMonitorKiosk") IsNot Nothing Then
            KioskNumber1 = Request.Cookies("ProcessMonitorKiosk")("kioskId")
            IsKioskFound1 = True
            isKioskThere = True

        Else

            LabelKioskName.Text = "You dont have a default kiosk/lines "
            IsKioskFound1 = False
            isKioskThere = False
            LabelComputerName.Text = hostName
            LabelIP.Text = ipAddress
        End If
    End Function

    ''' <summary>
    ''' Gets the computer name and ip address of the current user and sets in session variable
    ''' </summary>
    Public Sub GetComputerNameAndIP()
        Dim strIPAddress As String = String.Empty
        Dim strHostName As String = GetComputerName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                strIPAddress = ipheal.ToString()
            End If
        Next

        If strIPAddress IsNot String.Empty And strHostName IsNot String.Empty Then
            IpAddress1 = strIPAddress
            HostName1 = strHostName
            Session("IP") = IpAddress1
            Session("Host") = HostName1

            HasComputerName1 = True
        Else
            HasComputerName1 = False

        End If


    End Sub

    ''' <summary>
    ''' Set the session varialbes and forward to process form
    ''' </summary>
    Private Sub ForwardDataSession()

        'Session("PrinterName") = GridViewFullDataset.SelectedRow.Cells(12).Text
        'Session("PrinterId") = GridViewFullDataset.SelectedRow.Cells(11).Text
        Session("Kiosk") = kioskNumber
        'Session("Line") = GridViewFullDataset.SelectedRow.Cells(3).Text
        'Response.Redirect("About.aspx")
        Response.Redirect("KeypadForm.aspx")

    End Sub

    ''' <summary>
    ''' Gets the computer name of the curent user
    ''' </summary>
    ''' <returns></returns>
    Public Function GetComputerName() As String
        Dim strHostName As String = System.Net.Dns.GetHostName()

        GetComputerName = strHostName

    End Function
#End Region

#Region "Buttons"

    ''' <summary>
    ''' Selects a row in the kiosk setup table and sets values to the add new text box section
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub GridViewFullDataset_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridViewFullDataset.SelectedIndexChanged

        'Session("PrinterName") = GridViewFullDataset.SelectedRow.Cells(12).Text
        'Session("PrinterId") = GridViewFullDataset.SelectedRow.Cells(11).Text
        Session("Kiosk") = GridViewFullDataset.SelectedRow.Cells(2).Text
        'Session("Line") = GridViewFullDataset.SelectedRow.Cells(3).Text
        Response.Redirect("KeypadForm.aspx")
    End Sub


    Protected Sub ButtonAddKiosk_Click(sender As Object, e As EventArgs) Handles ButtonAddKiosk.Click
        PanelAddNewKiosk.Visible = True
        TextBoxHostName.Text = HostName1
        TextBoxIP.Text = IpAddress1
    End Sub

    Protected Sub ButtonAddNewSubmit_Click(sender As Object, e As EventArgs) Handles ButtonAddNewSubmit.Click
        Dim fullDSTableAdapter As New LineFullTableAdapters.FullDataSetTableAdapter
        Dim fullDataTable As New LineFull.FullDataSetDataTable
        Dim ds As New DataSet()
        'Dim dsKiosk As DataSet() = New DataSet("DatasetKiosk")

        fullDSTableAdapter.FillByComputerName(fullDataTable, hostName) '.FillByNpid(NewBenefitsDataSet.FO_HealthcateHighways_Control, "HCHRXMEDTIP")

        If fullDataTable.Count >= 1 Then
            LabelKioskName.Text = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue
            IsKioskFound1 = True
            'isKioskThere = True
            KioskNumber1 = fullDataTable.fk_nDefaultKioskIdColumn.DefaultValue

        Else LabelKioskName.Text = "Thats not a valid kiosk/lines "
            IsKioskFound1 = False
            'isKioskThere = False
            LabelComputerName.Text = hostName
            LabelIP.Text = ipAddress
        End If


    End Sub

    Protected Sub ButtonAddKioskCookie_Click(sender As Object, e As EventArgs) Handles ButtonAddKioskCookie.Click
        setKioskId()
    End Sub
#End Region

End Class