Public Class Form1
    Public Property username As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = username
        Call loadTable()
        con.Close()

    End Sub

    Sub loadTable(Optional ByVal q As String = "")
        cmd.Connection = con
        Try
            If q.Length > 0 Then
                cmd.CommandText = "SELECT firstname, lastname, code, subject, grade FROM tbl_users u, tbl_subjects s, tbl_grades g WHERE u.id = g.stid AND s.id = g.subid AND s.subject LIKE '%" & TextBox1.Text & "%' AND u.username = '" & username & "'"
            Else
                cmd.CommandText = "SELECT firstname, lastname, code, subject, grade FROM tbl_users u, tbl_subjects s, tbl_grades g WHERE u.id = g.stid AND s.id = g.subid AND u.username = '" & username & "'"
            End If

            adapter.SelectCommand = cmd
            info.Clear()
            adapter.Fill(info)
            DataGridView1.DataSource = info
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call loadTable(TextBox1.Text)
    End Sub
End Class
