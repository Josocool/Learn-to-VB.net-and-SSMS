Imports System.Data.SqlClient

Public Class FormInsert

    ' Downloads info from Database show in DataGridView
    Private Sub LoadData()
        Dim connectionString As String = "Data Source=10.150.1.93;Initial Catalog=tst;User ID=ERP_Test01;Password=1234;"
        Dim query As String = "SELECT * FROM Test_ERP01"

        Using conn As New SqlConnection(connectionString)
            Dim adapter As New SqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
        End Using

        ' Customize column is perfect auto
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub


    ' Load info period open form
    Private Sub FormInsert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub


    ' Button Insert Adding new infor improve in Database
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        ' Connecting String
        Dim connectionString As String = "Data Source=10.150.1.93;Initial Catalog=tst;User ID=ERP_Test01;Password=1234;"

        ' Query Insert SQL
        Dim query As String = "INSERT INTO Test_ERP01 (id, cust_id, cust_name, age, province, district, tel) VALUES (@id, @cust_id, @cust_name, @age, @province, @district, @tel)"

        ' Checking Data Entry khop or br khop
        If txtCustID.Text = "" Or txtCustName.Text = "" Or txtAge.Text = "" Then
            MessageBox.Show("Entry Infor hai khop thuan!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    ' Define Value Parameter
                    cmd.Parameters.AddWithValue("@id", txtID.Text)
                    cmd.Parameters.AddWithValue("@cust_id", txtCustID.Text)
                    cmd.Parameters.AddWithValue("@cust_name", txtCustName.Text)
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text))
                    cmd.Parameters.AddWithValue("@province", txtProvince.Text)
                    cmd.Parameters.AddWithValue("@district", txtDistrict.Text)
                    cmd.Parameters.AddWithValue("@tel", txtTel.Text)

                    ' Open connecting and run program
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            ' Alert and Loading new information
            MessageBox.Show("Add Information is Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData() ' Loads infor improve insight in new DataGridView

            ' Clear  Srng krk infor
            txtID.Clear()
            txtCustID.Clear()
            txtCustName.Clear()
            txtAge.Clear()
            txtProvince.Clear()
            txtDistrict.Clear()
            txtTel.Clear()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Button Cancel Close your form
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    ' when click row in DataGridView will be infor popup right now! TextBox
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            txtID.Text = row.Cells("id").Value.ToString()
            txtCustID.Text = row.Cells("cust_id").Value.ToString()
            txtCustName.Text = row.Cells("cust_name").Value.ToString()
            txtAge.Text = row.Cells("age").Value.ToString()
            txtProvince.Text = row.Cells("province").Value.ToString()
            txtDistrict.Text = row.Cells("district").Value.ToString()
            txtTel.Text = row.Cells("tel").Value.ToString()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim connectionString As String = "Data Source=10.150.1.93;Initial Catalog=tst;User ID=ERP_Test01;Password=1234;"
        Dim query As String = "Update Test_ERP01 SET cust_name = @cust_name, age = @age, province = @province, district = @district , tel = @tel where cust_id = @cust_id"
        If txtCustID.Text = "" Then
            MessageBox.Show("You Should The Data you want to edit", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)

                    cmd.Parameters.AddWithValue("@cust_id", txtCustID.Text)
                    cmd.Parameters.AddWithValue("@cust_name", txtCustName.Text)
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtAge.Text))
                    cmd.Parameters.AddWithValue("@province", txtProvince.Text)
                    cmd.Parameters.AddWithValue("@district", txtDistrict.Text)
                    cmd.Parameters.AddWithValue("@tel", txttel.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Update infor is Finish!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadData()
        Catch ex As Exception
            MessageBox.Show("An error Ocurred!" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' Button Delete for You choose
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim connectionString As String = "Data Source=10.150.1.93;Initial Catalog=tst;User ID=ERP_Test01;Password=1234;"
        Dim query As String = "DELETE FROM Test_ERP01 WHERE cust_id = @cust_id"

        ' Checking User Already choose information alright?
        If txtCustID.Text = "" Then
            MessageBox.Show("You Should the Data You want to Deltet!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Comfirm Information Delete
        Dim confirm As DialogResult = MessageBox.Show("You Want to Delete Information, Right!", "Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then
            Exit Sub
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@cust_id", txtCustID.Text)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Delete Information iS Done!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Loading Information After that Delete
            LoadData()

            ' Clear Entry Flieds
            txtID.Clear()
            txtCustID.Clear()
            txtCustName.Clear()
            txtAge.Clear()
            txtProvince.Clear()
            txtDistrict.Clear()
            txttel.Clear()

        Catch ex As Exception
            MessageBox.Show("An error ocurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class