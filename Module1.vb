Imports MySql.Data.MySqlClient
Imports System.IO
Imports ClosedXML.Excel



Module Module1
    Public myconn As New MySql.Data.MySqlClient.MySqlConnection
    Public myConnectionString As String
    Public strSQL As String

    Public currentDate As DateTime = DateTime.Now
    Public strpassword = "password"
    Public xlsFiles As String = "C:\Users\Buban\source\repos\Buban_UX\"

    Public Sub Connect_to_DB()
        myConnectionString = "server=127.0.0.1;" _
                    & "uid=root;" _
                    & "pwd=sql199bubanfeliciano;" _
                    & "database=mydatabase"
        Try
            myconn.ConnectionString = myConnectionString
            myconn.Open()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            Select Case ex.Number
                Case 0
                    MsgBox("Cannot Connect to Server")
                Case 1045
                    MsgBox("Invalid Username or password")
            End Select

        End Try
    End Sub

    Public Sub Disconnect_to_DB()
        myconn.Close()
        myconn.Dispose()
    End Sub

    Public Sub ExportToExcel(ByVal dgv As DataGridView, ByVal templatefilename As String)

            If dgv IsNot Nothing AndAlso dgv.Rows.Count > 0 Then
                Dim workbook As New XLWorkbook()
                Dim worksheet = workbook.Worksheets.Add("Sheet1")

                For columnIndex As Integer = 0 To dgv.Columns.Count - 1
                    worksheet.Cell(1, columnIndex + 1).Value = dgv.Columns(columnIndex).HeaderText
                Next

                For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                    For columnIndex As Integer = 0 To dgv.Columns.Count - 1
                        worksheet.Cell(rowIndex + 2, columnIndex + 1).Value = If(dgv.Rows(rowIndex).Cells(columnIndex).Value IsNot Nothing, dgv.Rows(rowIndex).Cells(columnIndex).Value.ToString(), String.Empty)
                    Next
                Next
                Dim filePath As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExcelTable", templatefilename)
                workbook.SaveAs(filePath)


                MessageBox.Show("Exported to:" & filePath)

            Else
                MessageBox.Show("Empty Data")
            End If

        End Sub


    End Module