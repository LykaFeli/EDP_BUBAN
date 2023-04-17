Imports MySql.Data.MySqlClient

Public Class category

    Private myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"

    Private Sub CategoryManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New MySqlConnection(myConnectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM categories table"
                Dim command As New MySqlCommand(query, connection)
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                Guna2DataGridView1.DataSource = table
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
