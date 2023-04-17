Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Btnlogin_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim username As String = Guna2TextBox1.Text
        Dim password As String = Guna2TextBox2.Text

        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)

        Try
            conn.ConnectionString = myConnectionString
            conn.Open()


            Dim query As String = "SELECT * FROM user_table;"


            Dim cmd As New MySqlCommand(query, conn)


            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then
                MessageBox.Show("Login successful!")
                Me.Hide()
                Dim dashboard As New dashboard()
                dashboard.Show()
            Else
                MessageBox.Show("Invalid username or password!")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Btncancel_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click

    End Sub

    Private Sub Guna2HtmlLabel3_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel3.Click

    End Sub
End Class