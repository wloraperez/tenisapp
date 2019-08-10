Imports TenisDB

Public Class ListadoJugadores
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Remove("IDJugador")

            Me.FillEmpresa()
            Me.FillDepartamento(0)
            Me.FillCategoria()

            'FIllGV()
        End If
    End Sub

    Private Sub FIllGV()
        Try
            Dim _tenisdb As New TenisDB.JugadoresDataContext(TenisDB.Comun.GetConnString)

            Dim _categ As String = ""
            Dim _empresa As Integer = 0
            Dim _departamento As Integer = 0

            If Me.ddlCategoria.SelectedIndex > 0 Then
                _categ = Me.ddlCategoria.SelectedValue
            End If
            If Me.ddlEmpresa.SelectedIndex > 0 Then
                _empresa = Me.ddlEmpresa.SelectedValue
            End If
            If Me.ddlDepartamento.SelectedIndex > 0 Then
                _departamento = Me.ddlDepartamento.SelectedValue
            End If

            Dim _jugadores = From i In _tenisdb.vJugadores
                             Where i.Nombres.Contains(Me.txtNombres.Text) And _
                                i.Apellidos.Contains(Me.txtApellidos.Text)
                             Select i

            If Not String.IsNullOrEmpty(_categ) Then
                _jugadores = _jugadores.Where(Function(d) d.IDCategoria = _categ)
            End If
            If _empresa > 0 Then
                _jugadores = _jugadores.Where(Function(d) d.IDEmpresa = _empresa)
            End If
            If _departamento > 0 Then
                _jugadores = _jugadores.Where(Function(d) d.IDDepartamento = _departamento)
            End If

            Me.gvJugadores.DataSource = _jugadores
            Me.gvJugadores.DataBind()
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

    Private Sub FillDepartamento(ByVal IDEmpresa As Integer)
        Try
            Dim _basicosdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)
            Me.ddlDepartamento.DataSource = From i In _basicosdb.Departamentos Where i.IDEmpresa = IDEmpresa _
                                            Order By i.Descripcion Ascending _
                                            Select i

            Me.ddlDepartamento.DataBind()
            Me.ddlDepartamento.Items.Insert(0, "--- Seleccione ---")
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Visible = True
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub FillCategoria()
        Try
            Dim _basicosdb As New TenisDB.DatosBasicosDataContext(TenisDB.Comun.GetConnString)
            Me.ddlCategoria.DataSource = From i In _basicosdb.Categorias _
                                        Order By i.Descripcion Ascending _
                                        Select i

            Me.ddlCategoria.DataBind()
            Me.ddlCategoria.Items.Insert(0, "--- Seleccione ---")
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Visible = True
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub ddlEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlEmpresa.SelectedIndexChanged
        If Me.ddlEmpresa.SelectedIndex > 0 Then
            Me.FillDepartamento(Me.ddlEmpresa.SelectedValue)
        Else
            Me.FillDepartamento(0)
        End If
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Me.FIllGV()
    End Sub

    Private Sub gvJugadores_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvJugadores.RowCommand
        Select Case e.CommandName
            Case "EditRecord"
                Response.Redirect(String.Format("EditJugador?id={0}", e.CommandArgument), False)
            Case "ViewRecord"
                Session.Add("IDJugador", e.CommandArgument)
                Response.Redirect(String.Format("DetalleJugador"), False)
            Case "DeleteRecord"

        End Select
    End Sub
End Class