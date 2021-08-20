Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Login1_LoggingIn(sender As Object, e As LoginCancelEventArgs)
        Dim pwd As String = My.Settings.AdminPassword
        If Login1.Password = pwd Then
            Response.Redirect("Admin.aspx")
        Else
            Login1.FailureText = "Incorrect password"
            Dim unused = e.Cancel()
        End If
    End Sub


End Class