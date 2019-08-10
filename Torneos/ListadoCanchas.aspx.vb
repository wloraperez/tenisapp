Imports TenisDB

Public Class ListadoCanchas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.fillTorneos()
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _torneodb As New TenisDB.TorneoDataContext(TenisDB.Comun.GetConnString)

            Dim _idtorneo As Integer = 0

            If Me.ddlTorneo.SelectedIndex > 0 Then
                _idtorneo = Me.ddlTorneo.SelectedValue
            End If

            Dim _canchas = From i In _torneodb.vCanchas _
                             Where i.Cancha.Contains(Me.txtDescripcion.Text) _
                             Select i

            If _idtorneo > 0 Then
                _canchas = _canchas.Where(Function(d) d.IDTorneo = _idtorneo)
            End If

            Me.gv.DataSource = _canchas
            Me.gv.DataBind()
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Me.FIllGV()
    End Sub

    Private Sub gv_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gv.RowCommand
        Select Case e.CommandName
            Case "EditRecord"

            Case "ViewRecord"

            Case "DeleteRecord"

        End Select
    End Sub

    Private Sub fillTorneos()
        Try
            Dim _torneodb As New TenisDB.TorneoDataContext(TenisDB.Comun.GetConnString)
            Dim _torneo = From i In _torneodb.vTorneos Select i

            Me.ddlTorneo.DataSource = _torneo
            Me.ddlTorneo.DataBind()
            Me.ddlTorneo.Items.Insert(0, "--- Seleccione ---")
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        Response.Redirect("Listados")
    End Sub
End Class