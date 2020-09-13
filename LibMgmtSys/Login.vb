Imports System.Data
Imports System.Data.SqlClient

Public Class LoginForm
    Private Sub but_Login_Click(sender As Object, e As EventArgs) Handles but_Login.Click

        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        'Check if either textboxes are empty
        If (String.IsNullOrEmpty(txt_username.Text)) And (String.IsNullOrEmpty(txt_password.Text)) Then
            MessageBox.Show("Your Username or Password boxes are not filled.")
        Else
            'Connection Settings
            conn = GetConnect()
            cmd = conn.CreateCommand
            conn.Open()

            'SQL String 
            cmd.CommandText = "SELECT * FROM users WHERE userID ='" & txt_username.Text & "' AND password = '" & txt_password.Text & "'"
            Dim da As New SqlDataAdapter(cmd.CommandText, conn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            'Try query, if error throw an exception.
            Try
                If dr.Read = False Then
                    MessageBox.Show("Username or Password combination incorrect.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    txt_username.Text = ""
                    txt_password.Text = ""
                    'Choose based on UserType
                    If String.Compare(dr.Item("userType"), "ADMIN") Then
                        AdminMenu.Show()
                        Me.Close()
                    ElseIf String.Compare(dr.Item("userType"), "STAFF") Then
                        StaffMenu.Show()
                        Me.Close()
                    ElseIf String.Compare(dr.Item("userType"), "USER") Then
                        UserMenu.Show()
                        Me.Close()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
            conn.Close()
        End If

    End Sub

    Private Sub but_Register_Click(sender As Object, e As EventArgs) Handles but_Register.Click
        RegisterForm.Show()
        Me.Close()
    End Sub
End Class
