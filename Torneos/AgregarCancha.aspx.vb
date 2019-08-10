Imports TenisDB

Public Class AgregarCancha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.FillTorneos()
        End If
    End Sub

    Private Sub FillTorneos()
        Try
            Dim _torneodb As New TenisDB.TorneoDataContext(TenisDB.Comun.GetConnString)
            Me.ddlTorneo.DataSource = From i In _torneodb.Torneos _
                                      Where i.Estado = True _
                                      Order By i.Descripcion Ascending Select i

            Me.ddlTorneo.DataBind()
            Me.ddlTorneo.Items.Insert(0, "--- Seleccione ---")
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
                Dim _idcancha As Integer = 0

                _idcancha = TorneosDB.AgregarCancha(Me.ddlTorneo.SelectedValue, Me.txtCancha.Text)

                If _idcancha > 0 Then
                    Me.lblMsg.Text = "Cancha agregada exitosamente."
                    Me.lblMsg.ForeColor = Drawing.Color.Green
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar la Cancha, contacte con el administrador."
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
        Response.Redirect("ListadoCanchas")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If Me.ddlTorneo.SelectedIndex <= 0 Then
            Me.lblMsg.Text = "Debe seleccionar un torneo."
            Exit Sub
        End If

        If String.IsNullOrEmpty(Me.txtCancha.Text) Then
            Me.lblMsg.Text = "El campo Cancha es obligatorio."
            Exit Sub
        End If
    End Sub

    Private Sub btnNueva_Click(sender As Object, e As EventArgs) Handles btnNueva.Click
        Me.lblMsg.Text = String.Empty
        Me.ddlTorneo.SelectedIndex = 0
        Me.txtCancha.Text = String.Empty
    End Sub
End Class