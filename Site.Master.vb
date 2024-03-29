﻿Public Class SiteMaster
    Inherits MasterPage

    Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Dim _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As System.EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie As HttpCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If ((Not requestCookie Is Nothing) AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue)) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie As HttpCookie = New HttpCookie(AntiXsrfTokenKey) With {.HttpOnly = True, .Value = _antiXsrfTokenValue}
            If (FormsAuthentication.RequireSSL And Request.IsSecureConnection) Then
                responseCookie.Secure = True
            End If
            Response.Cookies.Set(responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Private Sub master_Page_PreLoad(sender As Object, e As System.EventArgs)
        If (Not IsPostBack) Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, String.Empty)
        Else
            ' Validate the Anti-XSRF token
            If (Not DirectCast(ViewState(AntiXsrfTokenKey), String) = _antiXsrfTokenValue _
                Or Not DirectCast(ViewState(AntiXsrfUserNameKey), String) = If(Context.User.Identity.Name, String.Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.VerificarAcceso()
    End Sub

    Private Sub VerificarAcceso()
        Try
            Dim _userlog As New TenisDB.UserLogin

            If Not IsNothing(Session("UserLogin")) Then
                _userlog = Session("UserLogin")
                Me.activarusuario.Visible = False
                Me.usuario.Visible = True
                Me.logout.Visible = True
                Me.loginlink.Visible = False
                Me.registrar.Visible = False

                Me.usuario.Text = _userlog.NombreCompleto

                Me.aJugadores.Visible = True
                Me.aMantenimientos.Visible = True
                Me.aTorneos.Visible = True

                If _userlog.Roles.Contains(TenisDB.Roles.Admin) Then
                    Me.activarusuario.Visible = True
                End If
            Else
                Me.activarusuario.Visible = False
                Me.usuario.Visible = False
                Me.logout.Visible = False
                Me.loginlink.Visible = True
                Me.registrar.Visible = True

                Me.aJugadores.Visible = False
                Me.aMantenimientos.Visible = False
                Me.aTorneos.Visible = False

                If Request.Url.AbsoluteUri.Contains("Mantenimientos") Or Request.Url.AbsoluteUri.Contains("Torneos") Or Request.Url.AbsoluteUri.Contains("Jugadores") Then
                    Response.Redirect("~")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class