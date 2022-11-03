Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles txtUser.Click

        txtUser.Text = ""
        txtUser.Focus()
    End Sub



    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click

        txtPassword.Text = ""
        txtPassword.Focus()
    End Sub





End Class
