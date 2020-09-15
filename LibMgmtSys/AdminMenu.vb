Imports System.Data
Imports System.Data.SqlClient
Public Class AdminMenu
    Private Sub AdminMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'LibMgmtSysDataSet.users' table. You can move, or remove it, as needed.
        Me.UsersTableAdapter.Fill(Me.LibMgmtSysDataSet.users)
        RTC.Start()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        AdminMenu_Tabbed.SetPage("Dashboard")
        Header.Text = "Dashboard"
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        AdminMenu_Tabbed.SetPage("Profile")
        Header.Text = "Profile"
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click

    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click

    End Sub

    Private Sub BunifuButton5_Click(sender As Object, e As EventArgs) Handles BunifuButton5.Click

    End Sub

    Private Sub BunifuButton6_Click(sender As Object, e As EventArgs) Handles BunifuButton6.Click

    End Sub

    Private Sub BunifuButton7_Click(sender As Object, e As EventArgs) Handles BunifuButton7.Click
        AdminMenu_Tabbed.SetPage("UserAcc")
        Header.Text = "User Accounts"
    End Sub

    Private Sub BunifuButton11_Click(sender As Object, e As EventArgs) Handles BunifuButton11.Click
        AdminMenu_Tabbed.SetPage("About")
        Header.Text = "About Application"
    End Sub



    Private Sub RTC_Tick(sender As Object, e As EventArgs) Handles RTC.Tick
        Dim CurrentDateTime As DateTime
        CurrentDateTime = DateTime.Now
        CurTime.Text = CurrentDateTime.ToString("hh:mm:ss  tt")
    End Sub










    'Inside User Accounts
    'Add Module
    Private Sub AddButton_UserAccount_Click(sender As Object, e As EventArgs) Handles AddButton_UserAccount.Click
        UserAcc_Pages.SetPage("Add_UserAcc")
        underline.Location = New Point(7, 47)
    End Sub

    Private Sub Modify_UserAccount_Click(sender As Object, e As EventArgs) Handles Modify_UserAccount.Click
        UserAcc_Pages.SetPage("Modify_UserAcc")
        underline.Location = New Point(167, 47)
    End Sub







    Private Sub Add_userAcc_button_Click(sender As Object, e As EventArgs) Handles Add_userAcc_button.Click
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        'Check if either textboxes are empty
        If (String.IsNullOrEmpty(userid_add_useracc.Text)) And (String.IsNullOrEmpty(password_add_useracc.Text)) Then
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
            cmd.Parameters.AddWithValue("userID", userid_add_useracc.Text)
            cmd.Parameters.AddWithValue("fullname", fullname_add_useracc.Text)
            cmd.Parameters.AddWithValue("password", password_add_useracc.Text)
            cmd.Parameters.AddWithValue("phone_no", phoneno_add_useracc.Text)
            cmd.Parameters.AddWithValue("matric_id", matricID_add_useracc.Text)
            cmd.Parameters.AddWithValue("userType", userType_add_useracc.Text)
            cmd.Parameters.AddWithValue("bio", DBNull.Value)
            Console.WriteLine(cmd.CommandText)
            'Try query, if error throw an exception.
            Try
                If cmd.ExecuteNonQuery > 0 Then
                    MessageBox.Show("You are registered.")
                Else
                    MessageBox.Show("Account is Registered.")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try


            conn.Close()
        End If
    End Sub

    Private Sub userid_add_useracc_Leave(sender As Object, e As EventArgs) Handles userid_add_useracc.Leave
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand


        'Connection Settings
        conn = GetConnect()
        cmd = conn.CreateCommand
        conn.Open()

        'SQL String 
        cmd.CommandText = "SELECT * FROM users WHERE userID ='" & userid_add_useracc.Text & "'"
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

    Private Sub ModifyUserAttribute_UserAcc_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ModifyUserAttribute_UserAcc.CellContentClick
        Try
            userID_dt_Modify_UserAcc.Text = ModifyUserAttribute_UserAcc.Rows(e.RowIndex).Cells(0).Value
            fullname_dt_Modify_UserAcc.Text = ModifyUserAttribute_UserAcc.Rows(e.RowIndex).Cells(1).Value
            password_dt_Modify_UserAcc.Text = ModifyUserAttribute_UserAcc.Rows(e.RowIndex).Cells(2).Value
            matid_dt_Modify_UserAcc.Text = ModifyUserAttribute_UserAcc.Rows(e.RowIndex).Cells(3).Value
            userType_dt_Modify_UserAcc.Text = ModifyUserAttribute_UserAcc.Rows(e.RowIndex).Cells(4).Value
        Catch ex As Exception
            MessageBox.Show("You clicked on an invalid row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub SearchBox_Modify_UserAcc_TextChanged(sender As Object, e As EventArgs) Handles SearchBox_Modify_UserAcc.TextChanged
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim ModifyUserAcc As New DataTable()


        'Connection Settings
        conn = GetConnect()
        cmd = conn.CreateCommand
        conn.Open()

        'SQL String 
        cmd.CommandText = "SELECT * FROM users WHERE userID Like '%" & SearchBox_Modify_UserAcc.Text & "%'"
        Dim da As New SqlDataAdapter(cmd.CommandText, conn)
        da.Fill(ModifyUserAcc)
        ModifyUserAttribute_UserAcc.DataSource = ModifyUserAcc
        conn.Close()
    End Sub

    Private Sub UpdateButton_Modify_UserAcc_Click(sender As Object, e As EventArgs) Handles UpdateButton_Modify_UserAcc.Click

    End Sub

    Private Sub DeleteButton_Modify_UserAcc_Click(sender As Object, e As EventArgs) Handles DeleteButton_Modify_UserAcc.Click

    End Sub


End Class