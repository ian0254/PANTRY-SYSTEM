Imports MySql.Data.MySqlClient
Module Module2
    Dim result As Integer
    Dim cmd As New MySqlCommand
    Public con As MySqlConnection = Conn()
    Public Sub ianinsert(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("Data has been Inserted!")

                Else
                    MsgBox("Successfully saved!")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Close()

    End Sub

    Public Sub ianupdate(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("No Data has been Updated!")

                Else

                    MsgBox("New Data is updated succesfully!")

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)


        End Try
        con.Close()

    End Sub

    Public Sub iandelete(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("No Data has been deleted!")

                Else
                    MsgBox("Data is deleted succesfully!")

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Close()

    End Sub

End Module