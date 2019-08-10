Imports TenisDB

Public Class AgregarCategoria
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
                Dim _idcat As String = ""

                _idcat = TenisDB.MantenimientosDB.AgregarCategoria(Me.txtIDCategoria.Text, Me.txtCategoria.Text)

                If Not String.IsNullOrEmpty(_idcat) Then
                    Me.lblMsg.Text = "Categoría agregada exitosamente."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar la categoría, contacte con el administrador."
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
        Response.Redirect("ListadoCategorias.aspx")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If String.IsNullOrEmpty(Me.txtIDCategoria.Text) Then
            Me.lblMsg.Text = "El campo Nombre de categoría es obligatorio"
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtCategoria.Text) Then
            Me.lblMsg.Text = "El campo Descripción de categoría es obligatorio"
            Exit Sub
        End If
    End Sub
End Class