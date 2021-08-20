Public Class Keypad
    Inherits System.Web.UI.UserControl


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnOK As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents txtSource As System.Web.UI.WebControls.Label
    Protected WithEvents txtResult As System.Web.UI.HtmlControls.HtmlInputText
    'Protected WithEvents txtPasswordResult As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents lblIsPassword As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Event OnOKClicked()
    Public Event OnCancelClicked()

    Public Property IsPassword As Boolean = False
    'Public Property IsPassword() As Boolean
    '    Get
    '        Return CBool(lblIsPassword.Text)
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        lblIsPassword.Text = CStr(Value)
    '    End Set
    'End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here        
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        RaiseEvent OnOKClicked()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        RaiseEvent OnCancelClicked()
    End Sub

    Public Property Value() As String
        Get
            Return txtResult.Value
            'If IsPassword Then
            '    Return txtPasswordResult.Value
            'Else
            '    Return txtResult.Value
            'End If
        End Get
        Set(ByVal Value As String)
            txtResult.Value = Value
            'txtPasswordResult.Value = Value
        End Set
    End Property

    Public Property Source() As String
        Get
            Return txtSource.Text
        End Get
        Set(ByVal Value As String)
            txtSource.Text = Value
        End Set
    End Property

    Public Sub Show()

        Me.Visible = True
        Me.txtResult.Value = ""
        txtResult.Visible = True
        'txtPasswordResult.Visible = False
        'Me.txtPasswordResult.Value = ""
        'If IsPassword Then
        '    txtResult.Visible = False
        '    txtPasswordResult.Visible = True
        'Else
        '    txtResult.Visible = True
        '    txtPasswordResult.Visible = False
        'End If
    End Sub
    Public Sub Show(ByVal Source As String)
        Me.Source = Source
        Me.Show()
    End Sub
    Public Sub Hide()
        Me.Visible = False
    End Sub

End Class