Imports System.Data.SqlClient
Public Class Usuarios

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        Mostrar()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel4.Visible = True
        lblIdUsuario.Visible = False
        Label6.Visible = False
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        REM Dim nombres As String
        REM Dim numeroEntero As Integer
        REM Dim numeroDecimales As Double
        REM Dim fecha As Date


        REM insertar datos desde visual studio hasta sqlServer
        Try

            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("insertar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@nombres", txtNombre.Text)
            cmd.Parameters.AddWithValue("@login", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@password", txtContraseña.Text)
            cmd.ExecuteNonQuery()
            Cerrar()
            Mostrar()
            Panel4.Visible = False



        Catch ex As Exception : MsgBox(ex.Message)

        End Try

    End Sub


    REM Mostrar datos de la base de datos
    Sub Mostrar()
        Dim dt As New DataTable
        Dim da As SqlDataAdapter

        Try
            abrir()
            da = New SqlDataAdapter("mostrar_usuario", conexion)
            da.Fill(dt)
            dataListado.DataSource = dt
            Cerrar()

        Catch ex As Exception : MessageBox.Show(ex.Message)

        End Try
    End Sub


    REM Seleccionar Usuario
    Private Sub dataListado_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellDoubleClick
        Try
            Panel4.Visible = True
            GuardarToolStripMenuItem.Visible = False
            GuardarCambiosToolStripMenuItem.Visible = True

            txtNombre.Text = dataListado.SelectedCells.Item(2).Value
            txtUsuario.Text = dataListado.SelectedCells.Item(3).Value
            txtContraseña.Text = dataListado.SelectedCells.Item(4).Value
            lblIdUsuario.Text = dataListado.SelectedCells.Item(1).Value

        Catch ex As Exception

        End Try
    End Sub


    REM Editar Usuario
    Private Sub GuardarCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarCambiosToolStripMenuItem.Click
        Try

            Dim cmd As New SqlCommand
            abrir()
            cmd = New SqlCommand("editar_usuario", conexion)
            cmd.CommandType = 4
            cmd.Parameters.AddWithValue("@idusuario", lblIdUsuario.Text)
            cmd.Parameters.AddWithValue("@nombres", txtNombre.Text)
            cmd.Parameters.AddWithValue("@login", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@password", txtContraseña.Text)
            cmd.ExecuteNonQuery()
            Cerrar()
            Mostrar()
            Panel4.Visible = False


            '            @idusuario int,
            '@nombres varchar(50),
            '@login varchar(50),
            '@password varchar(50)



        Catch ex As Exception : MsgBox(ex.Message)

        End Try
    End Sub


    REM Eliminar Usuario
    Private Sub dataListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataListado.CellContentClick
        If e.ColumnIndex = Me.dataListado.Columns.Item("Eli").Index Then
            Dim result As DialogResult
            result = MessageBox.Show("¿Esta seguro que desea eliminar este usuario?", "Eliminando Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)

            If result = DialogResult.OK Then
                Try

                    Dim cmd As New SqlCommand
                    abrir()
                    cmd = New SqlCommand("eliminar_usuario", conexion)
                    cmd.CommandType = 4
                    cmd.Parameters.AddWithValue("@idusuario", dataListado.SelectedCells.Item(1).Value)

                    cmd.ExecuteNonQuery()
                    Cerrar()
                    Mostrar()
                    '@idusuario int,




                Catch ex As Exception : MsgBox(ex.Message)

                End Try
            Else
                MessageBox.Show("Cancelada la eliminacion de regsitro", "Eliminando Registros", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        End If
    End Sub


End Class