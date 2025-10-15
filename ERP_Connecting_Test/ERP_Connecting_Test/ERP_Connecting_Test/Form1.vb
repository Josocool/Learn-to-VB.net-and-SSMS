Imports System.Data.SqlClient ' Module Connect to DB


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create Connecting String for Connect SQL SERVE ' 
        Dim connectionString As String = "Data Source =10.150.1.93;Initial Catalog=tst;User ID=ERP_Test01;Password=1234;"
        Dim query As String = "Select * From Test_ERP01"

        Using conn As New SqlConnection(connectionString)
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table ' Show Information in DataGridView
        End Using
    End Sub

    Private Sub btnOpenInsert_Click(sender As Object, e As EventArgs) Handles btnOpenInsert.Click
        ' When Click Button open to Insert Form
        Dim frm As New FormInsert()
        frm.ShowDialog() ' Show Insert Form by popup
    End Sub



End Class
