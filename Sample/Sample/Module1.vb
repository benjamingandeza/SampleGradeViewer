Imports System.Data.OleDb
Module Module1
    Public con As New OleDb.OleDbConnection
    Public cmd As New OleDb.OleDbCommand
    Public adapter As New OleDb.OleDbDataAdapter(Nothing, con)
    Public reader As OleDb.OleDbDataReader

    Public info As New DataTable

    Sub openCon()
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_grades.mdb"
        con.Open()


    End Sub

End Module
