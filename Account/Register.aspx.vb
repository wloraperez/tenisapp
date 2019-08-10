Imports Microsoft.AspNet.Membership.OpenAuth

Public Class Register
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
    End Sub

    'Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs) Handles RegisterUser.CreatedUser
    '    'FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie:=False)

    '    'Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
    '    'If Not OpenAuth.IsLocalUrl(continueUrl) Then
    '    '    continueUrl = "~/"
    '    'End If

    '    'Response.Redirect(continueUrl)
    'End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.lblMsg.Text = String.Empty

        If Page.IsValid Then
            Try
                Dim _idusuario As Integer = 0

                Dim _tenisdb As New TenisDB.SeguridadDataContext(TenisDB.Comun.GetConnString)

                Dim _usuario = (From i In _tenisdb.Usuarios
                                 Where i.Usuario = Me.txtUsuario.Text.Trim
                                 Select i).FirstOrDefault()

                If Not IsNothing(_usuario) Then
                    Me.lblMsg.Text = "El nombre de usuario digitado ya existe, favor digite otro nombre de usuario."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End If

                _idusuario = TenisDB.SeguridadDB.AgregarUsuario(Me.txtUsuario.Text.Trim, TenisDB.Comun.Encrypt(Me.txtContrasena.Text), Me.txtNombre.Text)

                If _idusuario > 0 Then
                    Me.lblMsg.Text = "Usuario agregado exitosamente. Debe esperar que el administrador del sistema valide su acceso."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar el usuario, contacte con el administrador del sistema."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                End If
            Catch ex As Exception
                Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar el usuario, contacte con el administrador del sistema."
                Me.lblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
    End Sub

End Class