Public Class ActivarUsuario
    Inherits Page

    Dim _userlog As New TenisDB.UserLogin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            If Not IsNothing(Session("UserLogin")) Then
                _userlog = Session("UserLogin")
                If Not _userlog.Roles.Contains(TenisDB.Roles.Admin) Then
                    Response.Redirect("~")
                End If

                Me.FIllDDL()
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
                If IsNothing(_userlog) Then
                    Me.lblMsg.Text = "Sesion perdida."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End If

                Dim _oret As Boolean = False

                _oret = TenisDB.SeguridadDB.ActivarUsuario(Me.ddlUsuario.SelectedValue, _userlog.IDUsuario)

                Dim _oret2 = TenisDB.SeguridadDB.AgregarRol(Me.ddlUsuario.SelectedValue, TenisDB.Roles.Consultas)

                If _oret Then
                    Me.lblMsg.Text = "Usuario activado."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar activar el usuario."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                End If
            Catch ex As Exception
                TenisDB.Comun.GuardarErrores(ex.Message, ex.StackTrace)
                Me.lblMsg.Text = "Ha ocurrido un error al intentar activar el usuario."
                Me.lblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
    End Sub

    Private Sub FIllDDL()
        Try
            Dim _seg As New TenisDB.SeguridadDataContext(TenisDB.Comun.GetConnString)

            Dim _usuarios = From i In _seg.vUsuarios Where i.Estado = False Or i.Bloqueado = True Select i

            Me.ddlUsuario.DataSource = _usuarios
            Me.ddlUsuario.DataBind()
        Catch ex As Exception
            TenisDB.Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

End Class