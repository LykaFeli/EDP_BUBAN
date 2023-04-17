Imports MySql.Data.MySqlClient

Public Class Productmanagement
    Private Sub Productmanagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)
        Dim da As New MySqlDataAdapter
        Dim dt As New DataTable

        Try
            conn.Open()
            Dim query As String = "SELECT * FROM products_table;"
            Dim cmd As New MySqlCommand(query, conn)
            da.SelectCommand = cmd
            da.Fill(dt)
            If Guna2DataGridView2 IsNot Nothing Then
                Guna2DataGridView2.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub ClearFields()
        Text_productid.Text = ""
        Text_catid.Text = ""
        Text_price.Text = ""
        Text_productname.Text = ""
        Text_productdesc.Text = ""
    End Sub

    Private Sub Guna2Button1add_Click(sender As Object, e As EventArgs) Handles Guna2Button1add.Click
        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)

        Try
            conn.Open()
            Dim query As String = "INSERT INTO products_table (product_name, category_id, product_price, product_description) VALUES (@product_name, @category_id, @product_price, @product_description)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@product_name", Text_productname.Text)
            cmd.Parameters.AddWithValue("@category_id", Text_catid.Text)
            cmd.Parameters.AddWithValue("@product_price", Text_price.Text)
            cmd.Parameters.AddWithValue("@product_description", Text_productdesc.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product added successfully.")
            LoadData()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Guna2Button2delete_Click(sender As Object, e As EventArgs) Handles Guna2Button2delete.Click
        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)

        Try
            conn.Open()

            ' Check if the product exists before deleting
            Dim query As String = "SELECT COUNT(*) FROM products_table WHERE product_id = @product_id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@product_id", Text_productid.Text)
            Dim result As Integer = cmd.ExecuteScalar()

            If result > 0 Then
                ' Delete the corresponding records from the order_items table first
                query = "DELETE FROM order_items table WHERE product_id = @product_id"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@product_id", Text_productid.Text)
                cmd.ExecuteNonQuery()

                ' Then delete the record from the products_table table
                query = "DELETE FROM products_table WHERE product_id = @product_id"
                cmd = New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@product_id", Text_productid.Text)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Product deleted successfully.")
                LoadData()
                ClearFields()
            Else
                MessageBox.Show("No product found with this ID.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub




    Private Sub Guna2Button3update_Click(sender As Object, e As EventArgs) Handles Guna2Button3update.Click
        Dim myConnectionString As String = "server=localhost;user id=root;password=sql199bubanfeliciano;database=mydatabase"
        Dim conn As New MySqlConnection(myConnectionString)

        Try
            conn.Open()
            Dim query As String = "UPDATE products_table SET product_name=@product_name, category_id=@category_id, product_price=@product_price, product_description=@product_description WHERE product_id=@product_id"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@product_name", Text_productname.Text)
            cmd.Parameters.AddWithValue("@category_id", Text_catid.Text)
            cmd.Parameters.AddWithValue("@product_price", Text_price.Text)
            cmd.Parameters.AddWithValue("@product_description", Text_productdesc.Text)
            cmd.Parameters.AddWithValue("@product_id", Text_productid.Text)
            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Product updated successfully.")
                LoadData()
                ClearFields()
            Else
                MessageBox.Show("No product found with this ID.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class
