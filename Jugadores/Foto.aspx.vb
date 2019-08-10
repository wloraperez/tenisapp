Imports System.Data.SqlClient
Imports TenisDB

Public Class Foto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strQuery As String = "select Foto, TipoFoto from Jugadores where IDJugador = @id"
        Dim cmd As SqlCommand = New SqlCommand(strQuery)
        cmd.Parameters.Add("@id", SqlDbType.Int).Value() = Convert.ToInt32(Session("IDJugador"))
        Dim dt As DataTable = Comun.getdata(cmd)

        If dt IsNot Nothing Then
            Dim bytes() As Byte = CType(dt.Rows(0)("Foto"), Byte())
            Response.Buffer = True
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = dt.Rows(0)("TipoFoto").ToString()
            Response.AddHeader("content-disposition", "attachment;filename=" + "foto")
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.End()
        End If
    End Sub

End Class