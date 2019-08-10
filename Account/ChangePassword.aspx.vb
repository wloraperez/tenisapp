Public Class ChangePassword
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Dim _userlog As New TenisDB.UserLogin

            If Not IsNothing(Session("UserLogin")) Then
                _userlog = Session("UserLogin")

                Me.txtUsuario.Text = _userlog.Usuario
                Me.lblID.Text = _userlog.IDUsuario
            Else
                Response.Redirect("~")
            End If
        Catch ex As Exception
            Response.Redirect("~")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.lblMsg.Text = String.Empty

        If Page.IsValid Then
            Try
                Dim _oret As Boolean = False
                Dim _idusuario As Integer = CInt(Me.lblID.Text)

                Dim _userlog As New TenisDB.UserLogin

                _userlog = TenisDB.SeguridadDB.LoginUser(Me.txtUsuario.Text.Trim, TenisDB.Comun.Encrypt(Me.txtContrasena.Text))

                If IsNothing(_userlog) AndAlso (_userlog.IDUsuario <= 0) Then
                    Me.lblMsg.Text = "Contraseña anterior incorrecta."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End If

                _oret = TenisDB.SeguridadDB.CambiarContrasena(_idusuario, TenisDB.Comun.Encrypt(Me.txtContrasena.Text))

                If _oret Then
                    Me.lblMsg.Text = "Cambio de contraseña exitoso."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar cambiar la contraseña, contacte con el administrador del sistema."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                End If
            Catch ex As Exception
                Me.lblMsg.Text = "Ha ocurrido un error al intentar cambiar la contraseña, contacte con el administrador del sistema."
                Me.lblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
    End Sub

End Class