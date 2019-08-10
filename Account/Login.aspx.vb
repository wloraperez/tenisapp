Imports TenisDB

Public Class Login
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"

        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not String.IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl &= "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Private Sub btnAcceso_Click(sender As Object, e As EventArgs) Handles btnAcceso.Click
        Me.lblMsg.Text = String.Empty

        Try
            If Page.IsValid Then
                Dim _userlog As New UserLogin

                _userlog = SeguridadDB.LoginUser(Me.txtUsuario.Text.Trim, Comun.Encrypt(Me.txtContrasena.Text))

                If Not IsNothing(_userlog) AndAlso (_userlog.IDUsuario > 0) Then
                    If _userlog.Estado And Not _userlog.Bloqueado Then
                        Session.Add("UserLogin", _userlog)
                        Response.Redirect("~")
                    Else
                        Me.lblMsg.Text = "Usuario inactivo o bloqueado. Contacte con el administrador del sistema."
                        Me.lblMsg.ForeColor = Drawing.Color.Red
                    End If
                Else
                    Me.lblMsg.Text = "Usuario o Contraseña incorrecta."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                End If
            End If
        Catch ex As Exception
            Me.lblMsg.Text = "Ha ocurrido un error al intentar ingresar al sistema, contacte con el administrador del sistema."
            Me.lblMsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub
End Class