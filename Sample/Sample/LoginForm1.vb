Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        openCon()
        Try
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM tbl_users WHERE username='" & UsernameTextBox.Text & "' AND password='" & PasswordTextBox.Text & "'"
            reader = cmd.ExecuteReader()

            If reader.Read() = True Then
                con.Close()
                MsgBox("Welcome User")
                Dim OBJ As New Form1
                OBJ.username = UsernameTextBox.Text
                OBJ.Show()
                Me.Hide()

            Else
                MsgBox("Wrong Credentials")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openCon()
        'MsgBox("Connected")
        con.Close()

    End Sub
End Class
