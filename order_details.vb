Imports MySql.Data.MySqlClient

Public Class order_details
    Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"

    Private Sub order_details_Load1(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Using connection As New MySqlConnection(myConnectionString)
                connection.Open()
                Dim query As String = "SELECT * FROM order_table"
                Dim command As New MySqlCommand(query, connection)
                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                Guna2DataGridView1.DataSource = table
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
