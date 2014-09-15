Imports MySql.Data.MySqlClient
Public Class Form1




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call labas()
        'If con.State = ConnectionState.Closed Then
        '    'con.Open()
        '    MsgBox("Ready")
        'Else
        '    MsgBox("Can't connect to database")
        'End If



    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If RadioButton1.Checked Then
            TextBox17.Text = Val(TextBox20.Text) + Val(TextBox18.Text)
        ElseIf RadioButton2.Checked Then
            TextBox17.Text = Val(TextBox20.Text) - Val(TextBox18.Text)
        End If

        TextBox5.Text = TextBox1.Text + ", " + TextBox4.Text + " " + TextBox3.Text
        TextBox8.Text = Val(TextBox6.Text) * Val(TextBox7.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub




    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ianinsert("INSERT INTO `db_pantry`.`tbl_employee` (`Emp_lname`,`Emp_fname`,`Emp_mname`,`Emp_number`,`Emp_fullname`) " & _
                    "VALUES ('" & TextBox1.Text & "', '" & TextBox4.Text & "', '" & TextBox3.Text & "','" & TextBox2.Text & "','" & TextBox5.Text & "');")
        Call labas()

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            con.Open()
            Dim q4 As String
            q4 = "SELECT * FROM `tbl_items` WHERE `item_name` = '" & ComboBox2.Text & "'"
            cmd = New MySqlCommand(q4, con)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox7.Text = dr.GetInt32("item_price")
                TextBox15.Text = dr.GetString("item_cstock")
                TextBox16.Text = dr.GetString("item_cstock")
            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ianinsert("INSERT INTO `tbl_acquireditems`(`employeename`, `dateacquired`, `duedate`, `quantity`, `itemprice`, `totalprice`, `itemname`) " & _
                    "VALUES ('" & ComboBox1.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "');")

        ianupdate("UPDATE `tbl_items` SET `item_cstock`='" & TextBox15.Text & "' WHERE `item_name` = '" & ComboBox2.Text & "';")

        Call labas()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ianinsert("INSERT INTO `tbl_items`(`item_name`, `item_price`,`item_cstock`) " & _
                    "VALUES ('" & TextBox10.Text & "','" & TextBox9.Text & "','" & TextBox12.Text & "');")
        Call labas()
    End Sub

    'SELECT * FROM `tbl_acquireditems` WHERE `dateacquired` = '9/8/2014' AND `duedate` = '9/10/2014'

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            con.Open()
            Dim q4 As String
            q4 = "SELECT SUM(`totalprice`) FROM `tbl_acquireditems` WHERE `duedate` = '" & DateTimePicker3.Text & "' AND `employeename` = '" & ComboBox3.Text & "'"
            cmd = New MySqlCommand(q4, con)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox11.Text = dr.GetInt32("SUM(`totalprice`)")
            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()

        End Try
    End Sub


    Private Sub labas()

        '   Try
        '   con.Open()
        '   cmd = New MySqlCommand
        '   Dim query As String
        '   query = "Select * from `db_pantry`.`tbl_employee`"
        '   cmd = New MySqlCommand(query, con)
        '   da.SelectCommand = cmd
        '   da.Fill(dtbl)
        '    bs.DataSource = dtbl
        '    DataGridView1.DataSource = bs
        '    da.Update(dtbl)
        '    con.Close()
        '    Catch ex As Exception
        ' MsgBox(ex.Message)
        ' End Try
        Try
            con.Open()
            Dim str As String
            str = "Select * from `db_pantry`.`tbl_employee`"
            cmd = New MySqlCommand(str, con)
            dr = cmd.ExecuteReader
            ListView1.Items.Clear()
            Do While dr.Read

                Dim ls As ListViewItem = ListView1.Items.Add(dr.Item("ID").ToString)
                ls.SubItems.Add(dr.Item("Emp_lname").ToString)
                ls.SubItems.Add(dr.Item("Emp_fname").ToString)
                ls.SubItems.Add(dr.Item("Emp_mname").ToString)
                ls.SubItems.Add(dr.Item("Emp_number").ToString)
                ls.SubItems.Add(dr.Item("Emp_fullname").ToString)
            Loop


            dr.Dispose()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception

        End Try

        Try
            con.Open()
            Dim q1 As String
            q1 = "SELECT * FROM `tbl_items`"
            cmd = New MySqlCommand(q1, con)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sName1 = dr.GetString("item_name")
                ComboBox2.Items.Add(sName1)
            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            con.Open()
            Dim q2 As String
            q2 = "SELECT * FROM `tbl_items`"
            cmd = New MySqlCommand(q2, con)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sName2 = dr.GetString("item_name")
                ComboBox4.Items.Add(sName2)

            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            con.Open()
            Dim q3 As String
            q3 = "SELECT * FROM `tbl_employee`"
            cmd = New MySqlCommand(q3, con)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sName3 = dr.GetString("Emp_fullname")
                ComboBox1.Items.Add(sName3)
            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            con.Open()
            Dim q4 As String
            q4 = "SELECT * FROM `tbl_employee`"
            cmd = New MySqlCommand(q4, con)
            dr = cmd.ExecuteReader
            While dr.Read
                Dim sName4 = dr.GetString("Emp_fullname")
                ComboBox3.Items.Add(sName4)

            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = Nothing Then
            TextBox15.Text = TextBox16.Text
        Else
            TextBox15.Text = Val(TextBox15.Text) - Val(TextBox6.Text)
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Try
            con.Open()
            Dim q4 As String
            q4 = "SELECT * FROM `tbl_items` WHERE `item_name` = '" & ComboBox4.Text & "'"
            cmd = New MySqlCommand(q4, con)
            dr = cmd.ExecuteReader
            While dr.Read
                TextBox19.Text = dr.GetInt32("item_price")
                TextBox20.Text = dr.GetString("item_cstock")
            End While
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ianupdate("UPDATE `tbl_items` SET `item_price` ='" & TextBox19.Text & "',`item_cstock`='" & TextBox17.Text & "' WHERE `item_name` = '" & ComboBox4.Text & "';")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        iandelete("DELETE FROM `tbl_acquireditems` WHERE `employeename` = '" & ComboBox3.Text & "' AND `duedate` ='" & DateTimePicker3.Text & "'")
    End Sub
End Class