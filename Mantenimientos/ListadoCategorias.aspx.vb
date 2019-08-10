Imports TenisDB

Public Class ListadoCategorias
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("IDCategoria")

            'FIllGV()
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _tenisdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)

            Dim _categorias = From i In _tenisdb.Categorias _
                             Where i.IDCategoria.Contains(Me.txtIDCategoria.Text) And _
                                i.Descripcion.Contains(Me.txtDescripcion.Text) _
                             Select i

            Me.gvCategorias.DataSource = _categorias
            Me.gvCategorias.DataBind()
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Me.FIllGV()
    End Sub

    Private Sub gvCategorias_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvCategorias.RowCommand
        Select Case e.CommandName
            Case "EditRecord"

            Case "ViewRecord"
                'Session.Add("IDCategoria", e.CommandArgument)
                'Response.Redirect(String.Format("DetalleJugador.aspx"), False)
            Case "DeleteRecord"

        End Select
    End Sub
End Class