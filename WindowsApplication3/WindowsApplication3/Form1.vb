Imports System.Data.OleDb
Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Db_pantryDataSet.tbl_employee' table. You can move, or remove it, as needed.
        Me.Tbl_employeeTableAdapter.Fill(Me.Db_pantryDataSet.tbl_employee)
        If con.State = ConnectionState.Closed Then
            con.Open()
            MsgBox("Ready")
        Else
            MsgBox("Can't connect to database")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String = "INSERT INTO tbl_employee(Emp_lname,Emp_fname,Emp_mname,Emp_number) Values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
        Dim sqlcmd As New OleDbCommand

        With sqlcmd
            .CommandText = sql
            .Connection = con
            .ExecuteNonQuery()
        End With
        MsgBox("Success!", vbInformation, "Info")

    End Sub
End Class