Imports TenisDB

Public Class AgregarTorneo
    Inherits System.Web.UI.Page
    Dim _userlog As New TenisDB.UserLogin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("UserLogin")) Then
            _userlog = Session("UserLogin")
        Else
            Response.Redirect("~")
        End If

        If Not IsPostBack Then
            Try
                Me.cIni.SelectedDate = DateTime.Today
                Me.cFinal.SelectedDate = DateTime.Today

                Me.FillCategorias()
            Catch ex As Exception
                Comun.GuardarErrores(ex.Message, ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FillCategorias()
        Try
            Dim _basicosdb As New DatosBasicosDataContext(Comun.GetConnString)
            Me.cblCategorias.DataSource = From i In _basicosdb.Categorias _
                                        Order By i.Descripcion Ascending _
                                        Select i

            Me.cblCategorias.DataValueField = "IDCategoria"
            Me.cblCategorias.DataTextField = "Descripcion"

            Me.cblCategorias.DataBind()
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
                If Not IsNothing(Session("UserLogin")) Then
                    _userlog = Session("UserLogin")
                Else
                    Response.Redirect("~")
                End If

                Dim _idTorneo As Integer = 0
                Dim _idtorneoCat As Integer = 0
                Dim _idtorneoJug As Integer = 0
                Dim _oret As Boolean = False

                _idTorneo = TorneosDB.AgregarTorneo(Me.txtDescripción.Text, Me.cIni.SelectedDate, Me.cFinal.SelectedDate)

                If _idTorneo > 0 Then
                    For Each item As ListItem In Me.cblCategorias.Items
                        If item.Selected Then
                            _idtorneoCat = TorneosDB.AgregarTorneoCategorias(item.Value, _idTorneo)
                        End If
                    Next

                    For Each item As GridViewRow In Me.gvJugadores.Rows
                        Dim chk As CheckBox = CType(item.Cells(0).FindControl("chkID"), CheckBox)
                        If chk.Checked Then
                            Dim lblID As Label = CType(item.Cells(0).FindControl("lblIDJugador"), Label)
                            Dim lblca As Label = CType(item.Cells(3).FindControl("lblIDCategoria"), Label)
                            Dim ddlC As DropDownList = CType(item.Cells(3).FindControl("ddlCategoria"), DropDownList)

                            _idtorneoJug = TorneosDB.AgregarTorneoJugador(_idTorneo, lblID.Text, ddlC.SelectedValue)
                            _oret = JugadoresDB.EditarJugadorCat(CInt(lblID.Text), ddlC.SelectedValue, _userlog.IDUsuario)
                        End If
                    Next

                    If _idTorneo > 0 And _idtorneoCat > 0 And _idtorneoJug > 0 Then
                        Response.Redirect("ListadoTorneos")
                    End If
                Else
                    Me.lblMsg.Text = "Ha ocurrido un error al intentar agregar el torneo, contacte con el administrador."
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
        Response.Redirect("ListadoTorneos")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If String.IsNullOrEmpty(Me.txtDescripción.Text) Then
            Me.lblMsg.Text = "Debe digitar el Nombre del Torneo."

            Me.mvTorneo.ActiveViewIndex = 0
            Exit Sub
        End If

        Dim op As Boolean = False

        For Each item As ListItem In Me.cblCategorias.Items
            If item.Selected Then
                op = True
            End If
        Next
        If Not op Then
            Me.lblMsg.Text = "Debe seleccionar al menos una Categoría."
            Me.mvTorneo.ActiveViewIndex = 1
            Exit Sub
        End If

        For Each item As GridViewRow In Me.gvJugadores.Rows
            Dim chk As CheckBox = CType(item.Cells(0).FindControl("chkID"), CheckBox)
            If chk.Checked Then
                op = True
            End If
        Next
        If Not op Then
            Me.lblMsg.Text = "Debe seleccionar al menos un jugador."
            Me.mvTorneo.ActiveViewIndex = 2
            Exit Sub
        End If
    End Sub

    Private Sub btnTorneo_Click(sender As Object, e As EventArgs) Handles btnTorneo.Click
        Me.lblMsg.Text = String.Empty

        If String.IsNullOrEmpty(Me.txtDescripción.Text) Then
            Me.lblMsg.Text = "Debe digitar el Nombre del Torneo."
            Me.lblMsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Me.mvTorneo.ActiveViewIndex = 1
    End Sub

    Private Sub btnTorneoCat_Click(sender As Object, e As EventArgs) Handles btnTorneoCat.Click
        Dim op As Boolean = False

        For Each item As ListItem In Me.cblCategorias.Items
            If item.Selected Then
                op = True
            End If
        Next
        If Not op Then
            Me.lblMsg.Text = "Debe seleccionar al menos una Categoría."
            Exit Sub
        End If

        Me.FIllGV()
        Me.mvTorneo.ActiveViewIndex = 2
    End Sub

    Private Sub btnBackTorneo_Click(sender As Object, e As EventArgs) Handles btnBackTorneo.Click
        Me.mvTorneo.ActiveViewIndex = 0
    End Sub

    Private Sub btnBackCateg_Click(sender As Object, e As EventArgs) Handles btnBackCateg.Click
        Me.mvTorneo.ActiveViewIndex = 1
    End Sub

    Private Sub FIllGV()
        Try
            Dim _tenisdb As New JugadoresDataContext(Comun.GetConnString)

            Dim _categList As New List(Of String)
            Dim _categ As String = ""

            For Each item As ListItem In Me.cblCategorias.Items
                If item.Selected Then
                    _categList.Add(item.Value)
                End If
            Next

            Dim _jugadores = From i In _tenisdb.vJugadores Where _categList.Contains(i.IDCategoria) Select i

            Me.gvJugadores.DataSource = _jugadores
            Me.gvJugadores.DataBind()
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            Dim _basicosdb As New DatosBasicosDataContext(Comun.GetConnString)

            Dim ddlCategoria As DropDownList = CType(e.Row.FindControl("ddlCategoria"), DropDownList)

            ddlCategoria.DataSource = From i In _basicosdb.Categorias _
                                        Order By i.Descripcion Ascending _
                                        Select i

            ddlCategoria.DataBind()
            ddlCategoria.Items.Insert(0, "--- Seleccione ---")

            Dim country As String = CType(e.Row.FindControl("lblIDCategoria"), Label).Text
            ddlCategoria.Items.FindByValue(country).Selected = True
        End If
    End Sub
End Class