Imports System.Data.SqlClient
Module ConexionMaestra
    REM Conectando con la base de datos con el siguiente codigo rapido
    Public conexion As New SqlConnection("Data Source=IGARCIA\SQLEXPRESS;Initial Catalog=BASECOLEGIO;Integrated Security=True")

    REM Abriendo servidor con base de datos
    Sub abrir()
        If conexion.State = 0 Then
            conexion.Open()

        End If
    End Sub



    REM Cerrando Conexion de base de datos
    Sub Cerrar()
        If conexion.State = 1 Then
            conexion.Close()
        End If
    End Sub

End Module
