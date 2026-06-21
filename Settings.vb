
Public Class Settings

    ' Form Events
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadInterfaces()
        SetInterfaceLabel()
        Skye.UI.ThemeManager.ApplyTheme(Me)
    End Sub

    ' Control Events
    Private Sub LstInterfaces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBoxInterfaces.SelectedIndexChanged
        My.AppSettings.Default.InterfaceName = LBoxInterfaces.SelectedItem.ToString()
        SetInterfaceLabel()
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        My.AppSettings.Default.Save()
        Close()
    End Sub

    ' Methods
    Private Sub LoadInterfaces()
        LBoxInterfaces.Items.Clear()

        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell",
                .Arguments = "-Command ""(Get-NetAdapter | Select-Object -ExpandProperty Name)""",
                .RedirectStandardOutput = True,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Using p = Process.Start(psi)
                Dim output = p.StandardOutput.ReadToEnd()
                For Each line In output.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                    LBoxInterfaces.Items.Add(line.Trim())
                Next
            End Using
        Catch ex As Exception
            LBoxInterfaces.Items.Add("Error Loading Interfaces")
            Skye.Common.Log.Write("Settings failed to load network interfaces: " & ex.Message)
        End Try

    End Sub
    Private Sub SetInterfaceLabel()
        LblSelectedInterfaceName.Text = My.AppSettings.Default.InterfaceName.Trim()
    End Sub

End Class