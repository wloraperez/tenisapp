Imports TenisDB

Public Class ListadoDepartamentos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("IDDepartamento")

            Me.FillEmpresa()
            'FIllGV()
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _tenisdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)

            Dim _empresa As Integer = 0
            Dim _departamento As String = ""

            _departamento = Me.txtDepartamento.Text

            If Me.ddlEmpresa.SelectedIndex > 0 Then
                _empresa = Me.ddlEmpresa.SelectedValue
            End If

            Dim _depto = From i In _tenisdb.vDepartamentos Select i

            If Not String.IsNullOrEmpty(_departamento) Then
                _depto = _depto.Where(Function(d) d.Departamento.Contains(_departamento))
            End If

            If _empresa > 0 Then
                _depto = _depto.Where(Function(d) d.IDEmpresa = _empresa)
            End If

            Me.gvDepartamentos.DataSource = _depto
            Me.gvDepartamentos.DataBind()
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub FillEmpresa()
        Try
            Dim _basicosdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)
            Me.ddlEmpresa.DataSource = From i In _basicosdb.Empresas _
                                        Order By i.Descripcion Ascending _
                                        Select i

            Me.ddlEmpresa.DataBind()
            Me.ddlEmpresa.Items.Insert(0, "--- Seleccione ---")
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Visible = True
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Me.FIllGV()
    End Sub

    Private Sub gvDepartamentos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvDepartamentos.RowCommand
        Select Case e.CommandName

            Case "EditRecord"

            Case "ViewRecord"

            Case "DeleteRecord"

        End Select
    End Sub
End Class