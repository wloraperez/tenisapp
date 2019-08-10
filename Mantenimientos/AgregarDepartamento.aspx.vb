Imports TenisDB

Public Class AgregarDepartamento
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.FillEmpresa()
        End If
    End Sub

    Private Sub FillEmpresa()
        Try
            Dim _basicosdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)
            Me.ddlEmpresa.DataSource = From i In _basicosdb.Empresas Order By i.Descripcion Ascending Select i

            Me.ddlEmpresa.DataBind()
            Me.ddlEmpresa.Items.Insert(0, "--- Seleccione ---")
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.ForeColor = Drawing.Color.Red
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Me.lblMsg.ForeColor = Drawing.Color.White
            Me.lblMsg.Text = String.Empty
            Me.Validaciones()

            If String.IsNullOrEmpty(Me.lblMsg.Text) Then
                Dim _idDepto As Integer = 0

                _idDepto = TenisDB.MantenimientosDB.AgregarDepartamento(Me.txtDepartamento.Text, Me.ddlEmpresa.SelectedValue)

                If _idDepto > 0 Then
                    Me.lblMsg.Text = "Departamento agregado exitosamente."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar el jugador, contacte con el administrador."
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
        Response.Redirect("ListadoDepartamentos")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If Me.ddlEmpresa.SelectedIndex <= 0 Then
            Me.lblMsg.Text = "Debe seleccionar una Empresa."
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtDepartamento.Text) Then
            Me.lblMsg.Text = "El campo Departamento es obligatorio."
            Exit Sub
        End If
    End Sub
End Class