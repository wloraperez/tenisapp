Imports TenisDB

Public Class AgregarEmpresa
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Me.lblMsg.ForeColor = Drawing.Color.White
            Me.lblMsg.Text = String.Empty
            Me.Validaciones()

            If String.IsNullOrEmpty(Me.lblMsg.Text) Then
                Dim _idEmpresa As Integer = 0

                _idEmpresa = MantenimientosDB.AgregarEmpresa(Me.txtEmpresa.Text)

                If _idEmpresa > 0 Then
                    Me.lblMsg.Text = "Empresa agregada exitosamente."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar la empresa, contacte con el administrador."
                    Me.lblMsg.ForeColor = Drawing.Color.Red
                End If
            Else
                Me.lblMsg.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.ForeColor = Drawing.Color.Red
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("ListadoEmpresas.aspx")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If String.IsNullOrEmpty(Me.txtEmpresa.Text) Then
            Me.lblMsg.Text = "El campo Nombre de la empresa es obligatorio"
            Exit Sub
        End If
    End Sub
End Class