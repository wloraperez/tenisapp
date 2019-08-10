Imports TenisDB

Public Class ListadoTorneos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("IDTorneo")
            Me.cFecha.SelectedDate = DateTime.Today
            Me.chkEstado.Checked = True
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _torneodb As New TenisDB.TorneoDataContext(TenisDB.Comun.GetConnString)

            Dim _categ As String = ""
            Dim _empresa As Integer = 0
            Dim _departamento As Integer = 0

            Dim _torneo = From i In _torneodb.vTorneos _
                             Where i.Descripcion.Contains(Me.txtDescripcion.Text) And _
                                    i.Estado = Me.chkEstado.Checked And _
                                    (i.FechaInicio <= Me.cFecha.SelectedDate Or i.FechaFinal >= Me.cFecha.SelectedDate) _
                             Select i

            Me.gv.DataSource = _torneo
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

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        Response.Redirect("Listados")
    End Sub
End Class