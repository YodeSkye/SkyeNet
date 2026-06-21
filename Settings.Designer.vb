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
        LBoxInterfaces = New ListBox()
        BtnSave = New Button()
        LblInterfaces = New Skye.UI.Label()
        LblSelectedInterfaceName = New Skye.UI.Label()
        LblSelectedInterface = New Skye.UI.Label()
        SuspendLayout()
        ' 
        ' LBoxInterfaces
        ' 
        LBoxInterfaces.FormattingEnabled = True
        LBoxInterfaces.Location = New Point(13, 30)
        LBoxInterfaces.Margin = New Padding(4)
        LBoxInterfaces.Name = "LBoxInterfaces"
        LBoxInterfaces.Size = New Size(524, 151)
        LBoxInterfaces.TabIndex = 0
        ' 
        ' BtnSave
        ' 
        BtnSave.Image = My.Resources.Resources.ImageSave32
        BtnSave.Location = New Point(13, 221)
        BtnSave.Margin = New Padding(4)
        BtnSave.Name = "BtnSave"
        BtnSave.Size = New Size(48, 48)
        BtnSave.TabIndex = 2
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' LblInterfaces
        ' 
        LblInterfaces.Location = New Point(12, 9)
        LblInterfaces.Name = "LblInterfaces"
        LblInterfaces.Size = New Size(152, 23)
        LblInterfaces.TabIndex = 3
        LblInterfaces.Text = "Select An Interface:"
        ' 
        ' LblSelectedInterfaceName
        ' 
        LblSelectedInterfaceName.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LblSelectedInterfaceName.Location = New Point(143, 185)
        LblSelectedInterfaceName.Name = "LblSelectedInterfaceName"
        LblSelectedInterfaceName.Size = New Size(394, 23)
        LblSelectedInterfaceName.TabIndex = 4
        ' 
        ' LblSelectedInterface
        ' 
        LblSelectedInterface.Location = New Point(12, 185)
        LblSelectedInterface.Name = "LblSelectedInterface"
        LblSelectedInterface.Size = New Size(135, 23)
        LblSelectedInterface.TabIndex = 5
        LblSelectedInterface.Text = "Selected Interface:"
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(550, 282)
        Controls.Add(LblSelectedInterface)
        Controls.Add(LblSelectedInterfaceName)
        Controls.Add(BtnSave)
        Controls.Add(LBoxInterfaces)
        Controls.Add(LblInterfaces)
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        ResumeLayout(False)
    End Sub

    Friend WithEvents LBoxInterfaces As ListBox
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblInterfaces As Skye.UI.Label
    Friend WithEvents LblSelectedInterfaceName As Skye.UI.Label
    Friend WithEvents LblSelectedInterface As Skye.UI.Label
End Class
