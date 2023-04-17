Imports MySql.Data.MySqlClient

Public Class usermngmnt
    Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
    Dim conn As New MySqlConnection(myConnectionString)
    Dim selectedUserId As Integer = 0

    Private Sub usermngmnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUsers()
    End Sub

    Private Sub LoadUsers()
        Try
            conn.Open()
            Dim query As String = "SELECT user_id, username, password FROM user_table;"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            Guna2DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ClearInputs()
        Guna2TextBox1.Text = ""
        Guna2TextBox2.Text = ""
        selectedUserId = 0
    End Sub

    Private Sub Guna2DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = Guna2DataGridView1.Rows(e.RowIndex)
            selectedUserId = row.Cells("user_id").Value
            Guna2TextBox1.Text = row.Cells("username").Value.ToString()
            Guna2TextBox2.Text = row.Cells("password").Value.ToString()
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            conn.Open()
            Dim query As String = "INSERT INTO user_table(username, password) VALUES(@username, @password);"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", Guna2TextBox1.Text)
            cmd.Parameters.AddWithValue("@password", Guna2TextBox2.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("User added successfully!")
            ClearInputs()
            LoadUsers()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If selectedUserId > 0 Then
            Try
                conn.Open()
                Dim query As String = "UPDATE user_table SET username=@username, password=@password WHERE user_id=@user_id;"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", Guna2TextBox1.Text)
                cmd.Parameters.AddWithValue("@password", Guna2TextBox2.Text)
                cmd.Parameters.AddWithValue("@user_id", selectedUserId)
                cmd.ExecuteNonQuery()
                MessageBox.Show("User updated successfully!")
                ClearInputs()
                LoadUsers()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MessageBox.Show("Please select a user to update.")
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If selectedUserId > 0 Then
            Try
                conn.Open()
                Dim query As String = "DELETE FROM user_table WHERE user_id=@user_id;"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@user_id", selectedUserId)
                cmd.ExecuteNonQuery()
                MessageBox.Show("User deleted successfully!")
                ClearInputs()
                LoadUsers()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        Else
            MessageBox.Show("Please select a user to delete.")
        End If
    End Sub

    Private Sub Guna2HtmlLabel3_Click(sender As Object, e As EventArgs) Handles Guna2HtmlLabel3.Click

    End Sub
End Class
