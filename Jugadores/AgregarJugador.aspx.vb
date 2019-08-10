Imports TenisDB

Public Class AgregarJugador
    Inherits System.Web.UI.Page

    Dim _userlog As New TenisDB.UserLogin

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Session("UserLogin")) Then
            _userlog = Session("UserLogin")
        Else
            Response.Redirect("~")
        End If

        If Not IsPostBack Then
            Me.FillEmpresa()
            Me.FillDepartamento(0)
            Me.FillCategoria()
            Me.FillMano()
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
            Me.lblMsg.ForeColor = Drawing.Color.Red
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
            Me.lblMsg.ForeColor = Drawing.Color.Red
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Private Sub FillMano()
        Try
            Me.ddlMano.Items.Insert(0, New ListItem("Derecha", "Derecha"))
            Me.ddlMano.Items.Insert(1, New ListItem("Izquierda", "Izquierda"))
            Me.ddlMano.Items.Insert(2, New ListItem("Ambidiestro(a)", "Ambidiestro(a)"))
        Catch ex As Exception
            Comun.GuardarErrores(ex.Message, ex.StackTrace)
            Me.lblMsg.ForeColor = Drawing.Color.Red
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Me.lblMsg.ForeColor = Drawing.Color.White
            Me.lblMsg.Text = String.Empty
            Me.Validaciones()

            If String.IsNullOrEmpty(Me.lblMsg.Text) Then
                Dim _idjug As Integer = 0

                Dim _idempresa As Integer
                Dim _iddepartamento As Integer

                If Me.ddlEmpresa.SelectedIndex > 0 Then
                    _idempresa = Me.ddlEmpresa.SelectedValue
                End If
                If Me.ddlDepartamento.SelectedIndex > 0 Then
                    _iddepartamento = Me.ddlDepartamento.SelectedValue
                End If

                Dim _imagen As Byte() = Nothing
                Dim _tamano As Integer = 0
                Dim _tipo As String = ""

                If (Not IsNothing(Me.ImageUploadToDB.PostedFile) AndAlso Me.ImageUploadToDB.PostedFile.FileName <> "") Then
                    _imagen = New Byte(ImageUploadToDB.PostedFile.ContentLength - 1) {}
                    Dim Posted_Image As HttpPostedFile = ImageUploadToDB.PostedFile
                    Posted_Image.InputStream.Read(_imagen, 0, CInt(ImageUploadToDB.PostedFile.ContentLength))
                    _tamano = ImageUploadToDB.PostedFile.ContentLength
                    _tipo = ImageUploadToDB.PostedFile.ContentType
                End If

                _idjug = TenisDB.JugadoresDB.AgregarJugador(Me.txtNombres.Text, Me.txtApellidos.Text, _idempresa, _iddepartamento, _
                                                          Me.ddlCategoria.SelectedValue, Me.txtTelefono.Text, Me.txtCorreo.Text, _
                                                          Me.txtTwitter.Text, Me.txtInstagram.Text, Me.ddlMano.SelectedValue,
                                                          Me.txtTshirt.Text, Me.txtPantalon.Text, _imagen, _tipo, _tamano, _userlog.IDUsuario)

                If _idjug > 0 Then
                    Me.lblMsg.Text = "Jugador agregado exitosamente."
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
        Response.Redirect("ListadoJugadores")
    End Sub

    Private Sub Validaciones()
        Me.lblMsg.Text = String.Empty

        If String.IsNullOrEmpty(Me.txtNombres.Text) Then
            Me.lblMsg.Text = "El campo Nombres es obligatorio"
            Exit Sub
        End If
        If String.IsNullOrEmpty(Me.txtApellidos.Text) Then
            Me.lblMsg.Text = "El campo Apellidos es obligatorio"
            Exit Sub
        End If
        If Me.ddlCategoria.SelectedIndex <= 0 Then
            Me.lblMsg.Text = "El campo Categoría es obligatorio"
            Exit Sub
        End If

    End Sub

End Class