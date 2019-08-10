Public Class DetalleJugador
    Inherits System.Web.UI.Page

    Public Property IDJugador() As Integer
        Get
            Return ViewState("IDJugador")
        End Get

        Set(ByVal value As Integer)
            ViewState("IDJugador") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsNothing(Session("IDJugador")) Then
                Me.IDJugador = CType(Session("IDJugador"), Integer)
                FIllDV(Me.IDJugador)
            End If
        End If
    End Sub

    Private Sub FIllDV(ByVal idjugador As Integer)
        Try
            Dim _tenisdb As New TenisDB.JugadoresDataContext(TenisDB.Comun.GetConnString)

            Dim _jugador = From i In _tenisdb.vJugadores
                             Where i.IDJugador = idjugador
                             Select i

            Me.dvJugador.DataSource = _jugador
            Me.dvJugador.DataBind()

            Session.Add("IDJugador", _jugador.SingleOrDefault.IDJugador)

            Me.imgFoto.ImageUrl = "Foto.aspx"
        Catch ex As Exception
        End Try
    End Sub

End Class