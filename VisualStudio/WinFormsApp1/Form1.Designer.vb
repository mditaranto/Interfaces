<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtNombre = New TextBox()
        Label1 = New Label()
        btnSaludar = New Button()
        ErrorVacio = New Label()
        SuspendLayout()
        ' 
        ' txtNombre
        ' 
        txtNombre.Location = New Point(108, 73)
        txtNombre.Name = "txtNombre"
        txtNombre.Size = New Size(100, 23)
        txtNombre.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(51, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 15)
        Label1.TabIndex = 1
        Label1.Text = "Nombre:"
        ' 
        ' btnSaludar
        ' 
        btnSaludar.Location = New Point(119, 121)
        btnSaludar.Name = "btnSaludar"
        btnSaludar.Size = New Size(75, 23)
        btnSaludar.TabIndex = 2
        btnSaludar.Text = "Saludo"
        btnSaludar.UseVisualStyleBackColor = True
        ' 
        ' ErrorVacio
        ' 
        ErrorVacio.AutoSize = True
        ErrorVacio.ForeColor = Color.Red
        ErrorVacio.Location = New Point(90, 48)
        ErrorVacio.Name = "ErrorVacio"
        ErrorVacio.Size = New Size(0, 15)
        ErrorVacio.TabIndex = 3
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(ErrorVacio)
        Controls.Add(btnSaludar)
        Controls.Add(Label1)
        Controls.Add(txtNombre)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaludar As Button
    Friend WithEvents ErrorVacio As Label
End Class
