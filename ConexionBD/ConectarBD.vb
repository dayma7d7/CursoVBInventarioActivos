Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Module ConectarBD
    Public ip As String = "", user As String = "", pass As String = "", bd As String = ""
    Public conexion As SqlConnection
    Public adapter As SqlDataAdapter
    Public tabla As DataTable

    Public nombre As String
    Public usuario As String
    Public tipousuario As String

    Public Sub establecerConexion()
        Try
            If File.Exists(Application.StartupPath + "IP.txt") Then
                ip = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "IP.txt")
            End If
            If File.Exists(Application.StartupPath + "USER.txt") Then
                user = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "USER.txt")
            End If
            If File.Exists(Application.StartupPath + "PASS.txt") Then
                pass = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "PASS.txt")
            End If
            If File.Exists(Application.StartupPath + "bd.txt") Then
                bd = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "bd.txt")
            End If

            If ip.Length = 0 Or user.Length = 0 Or pass.Length = 0 Or bd.Length = 0 Then
                MsgBox("Faltan parametros de conexión", vbCritical, "ERROR DE CONEXIÓN")
            Else
                conexion = New SqlConnection("Data Source=" & ip.Trim & "; Initial Catalog=" & bd.Trim & "; User Id=" & user.Trim & "; Password=" & pass.Trim & "; ")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function obtenerConexion() As String
        Dim miconexion As String = ""
        Try
            If File.Exists(Application.StartupPath + "IP.txt") Then
                ip = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "IP.txt")
            End If
            If File.Exists(Application.StartupPath + "USER.txt") Then
                user = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "USER.txt")
            End If
            If File.Exists(Application.StartupPath + "PASS.txt") Then
                pass = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "PASS.txt")
            End If
            If File.Exists(Application.StartupPath + "bd.txt") Then
                bd = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "bd.txt")
            End If

            If ip.Length = 0 Or user.Length = 0 Or pass.Length = 0 Or bd.Length = 0 Then
                MsgBox("Faltan parametros de conexión", vbCritical, "ERROR DE CONEXIÓN")
            Else
                miconexion = "Data Source=" & ip.Trim & "; Initial Catalog=" & bd.Trim & "; User Id=" & user.Trim & "; Password=" & pass.Trim & "; "
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return miconexion

    End Function

End Module
