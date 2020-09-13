<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.txt_fullname = New System.Windows.Forms.TextBox()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.txt_confirmpass = New System.Windows.Forms.TextBox()
        Me.txt_phone_no = New System.Windows.Forms.TextBox()
        Me.txt_matricid = New System.Windows.Forms.TextBox()
        Me.Register = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_username
        '
        Me.txt_username.Location = New System.Drawing.Point(541, 96)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(226, 20)
        Me.txt_username.TabIndex = 0
        '
        'txt_fullname
        '
        Me.txt_fullname.Location = New System.Drawing.Point(541, 122)
        Me.txt_fullname.Name = "txt_fullname"
        Me.txt_fullname.Size = New System.Drawing.Size(226, 20)
        Me.txt_fullname.TabIndex = 1
        '
        'txt_password
        '
        Me.txt_password.Location = New System.Drawing.Point(541, 148)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(226, 20)
        Me.txt_password.TabIndex = 2
        '
        'txt_confirmpass
        '
        Me.txt_confirmpass.Location = New System.Drawing.Point(541, 174)
        Me.txt_confirmpass.Name = "txt_confirmpass"
        Me.txt_confirmpass.Size = New System.Drawing.Size(226, 20)
        Me.txt_confirmpass.TabIndex = 3
        '
        'txt_phone_no
        '
        Me.txt_phone_no.Location = New System.Drawing.Point(541, 200)
        Me.txt_phone_no.Name = "txt_phone_no"
        Me.txt_phone_no.Size = New System.Drawing.Size(226, 20)
        Me.txt_phone_no.TabIndex = 4
        '
        'txt_matricid
        '
        Me.txt_matricid.Location = New System.Drawing.Point(541, 227)
        Me.txt_matricid.Name = "txt_matricid"
        Me.txt_matricid.Size = New System.Drawing.Size(226, 20)
        Me.txt_matricid.TabIndex = 5
        '
        'Register
        '
        Me.Register.Location = New System.Drawing.Point(692, 264)
        Me.Register.Name = "Register"
        Me.Register.Size = New System.Drawing.Size(75, 23)
        Me.Register.TabIndex = 6
        Me.Register.Text = "Register"
        Me.Register.UseVisualStyleBackColor = True
        '
        'RegisterForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Register)
        Me.Controls.Add(Me.txt_matricid)
        Me.Controls.Add(Me.txt_phone_no)
        Me.Controls.Add(Me.txt_confirmpass)
        Me.Controls.Add(Me.txt_password)
        Me.Controls.Add(Me.txt_fullname)
        Me.Controls.Add(Me.txt_username)
        Me.Name = "RegisterForm"
        Me.Text = "RegisterForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_username As TextBox
    Friend WithEvents txt_fullname As TextBox
    Friend WithEvents txt_password As TextBox
    Friend WithEvents txt_confirmpass As TextBox
    Friend WithEvents txt_phone_no As TextBox
    Friend WithEvents txt_matricid As TextBox
    Friend WithEvents Register As Button
End Class
