Imports MySql.Data.MySqlClient

Public Class category
    Private Sub Ordermanagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable


        Try

            conn.Open()
            Dim query As String = "SELECT * FROM category_table;"
            Dim cmd As New MySqlCommand(query, conn)
            da.SelectCommand = cmd
            da.Fill(dt)



            If dt.Rows.Count > 0 Then
                Guna2DataGridView1.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        LoadData() ' Call LoadData() method when refresh button is clicked
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Call ExportToExcel(Guna2DataGridView1, "category.xlsx")
    End Sub
End Class
