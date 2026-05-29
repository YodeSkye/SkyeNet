<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        LstInterfaces = New ListBox()
        TxtInterface = New TextBox()
        BtnSave = New Button()
        SuspendLayout()
        ' 
        ' LstInterfaces
        ' 
        LstInterfaces.FormattingEnabled = True
        LstInterfaces.Location = New Point(12, 12)
        LstInterfaces.Name = "LstInterfaces"
        LstInterfaces.Size = New Size(402, 109)
        LstInterfaces.TabIndex = 0
        ' 
        ' TxtInterface
        ' 
        TxtInterface.Location = New Point(12, 127)
        TxtInterface.Name = "TxtInterface"
        TxtInterface.Size = New Size(402, 23)
        TxtInterface.TabIndex = 1
        ' 
        ' BtnSave
        ' 
        BtnSave.Location = New Point(12, 166)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(75, 23)
        BtnSave.TabIndex = 2
        BtnSave.Text = "Save"
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(428, 197)
        Controls.Add(BtnSave)
        Controls.Add(TxtInterface)
        Controls.Add(LstInterfaces)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LstInterfaces As ListBox
    Friend WithEvents TxtInterface As TextBox
    Friend WithEvents BtnSave As Button
End Class
