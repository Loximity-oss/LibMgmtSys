Imports System.Data
Imports System.Data.SqlClient

Public Class RegisterForm
    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        'Check if either textboxes are empty
        If (String.IsNullOrEmpty(txt_username.Text)) And (String.IsNullOrEmpty(txt_password.Text)) Then


            MessageBox.Show("Your Username or Password boxes are not filled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Connection Settings
            conn = GetConnect()
            cmd = conn.CreateCommand
            conn.Open()

            'SQL String 
            cmd.CommandText = "INSERT INTO users(userID, fullname, password, phone_no, matric_id, userType, bio) VALUES(@userID, @fullname, @password, @phone_no, @matric_id, @userType, @bio)"

            'Execute Non Query
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("userID", txt_username.Text)
            cmd.Parameters.AddWithValue("fullname", txt_fullname.Text)
            cmd.Parameters.AddWithValue("password", txt_password.Text)
            cmd.Parameters.AddWithValue("phone_no", txt_phone_no.Text)
            cmd.Parameters.AddWithValue("matric_id", txt_matricid.Text)
            cmd.Parameters.AddWithValue("userType", "USER")
            cmd.Parameters.AddWithValue("bio", DBNull.Value)

            'Try query, if error throw an exception.
            Try
                If cmd.ExecuteNonQuery > 0 Then
                    MessageBox.Show("You are registered.")
                Else
                    MessageBox.Show("Existing Data.")
                End If
            Catch ex As Exception
                MessageBox.Show("Account is Registered.")
            End Try


            conn.Close()
        End If
    End Sub

    Private Sub txt_username_Leave(sender As Object, e As EventArgs) Handles txt_username.Leave
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        'Check if boxes not empty


        'Connection Settings
        conn = GetConnect()
        cmd = conn.CreateCommand
        conn.Open()

        'SQL String 
        cmd.CommandText = "SELECT * FROM users WHERE userID ='" & txt_username.Text & "'"
        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        'Try query, if error throw an exception.
        Try
            If dr.Read = False Then
                MessageBox.Show("The username is available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("The username is not available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        conn.Close()

    End Sub

    Private Sub txt_confirmpass_Leave(sender As Object, e As EventArgs) Handles txt_confirmpass.Leave
        'Check if password similar
        If txt_password IsNot txt_confirmpass Then
            MessageBox.Show("Password is not similar", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class