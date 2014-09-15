Imports MySql.Data.MySqlClient

Module Module1
    Public Mysqlcon As MySqlConnection = Conn()
    Public Function Conn() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;password=root;database=db_pantry")
    End Function

    Public bs As New BindingSource
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader
    Public ds As New DataSet
    Public dtbl As New DataTable
    Public da As New MySqlDataAdapter


End Module

