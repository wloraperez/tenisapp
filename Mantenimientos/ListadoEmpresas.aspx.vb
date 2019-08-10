Imports TenisDB

Public Class ListadoEmpresas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("IDEmpresa")

            'FIllGV()
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _tenisdb As New DatosBasicosDataContext(TenisDB.Comun.GetConnString)

            Dim _empresas = From i In _tenisdb.Empresas _
                             Where i.Descripcion.Contains(Me.txtEmpresa.Text) _
                             Select i

            Me.gvempresas.DataSource = _empresas
            Me.gvempresas.DataBind()
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Me.FIllGV()
    End Sub

    Private Sub gvempresas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvEmpresas.RowCommand
        Select Case e.CommandName
            Case "EditRecord"

            Case "ViewRecord"
                'Session.Add("IDCategoria", e.CommandArgument)
                'Response.Redirect(String.Format("DetalleJugador.aspx"), False)
            Case "DeleteRecord"

        End Select
    End Sub
End Class