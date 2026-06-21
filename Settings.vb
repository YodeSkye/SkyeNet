
Imports Skye.UI

Public Class Settings

    ' Form Events
    Private Sub SettingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Skye.UI.ThemeManager.ApplyTheme(Me)
        For Each thm In SkyeThemes.AllThemes
            CoBoxTheme.Items.Add(thm.Name)
        Next
        CoBoxTheme.SelectedItem = My.AppSettings.Default.Theme
        ChkBoxThemeAuto.Checked = My.AppSettings.Default.ThemeAuto
        SetThemesList()
        LoadInterfaces()
        SetInterfaceLabel()
    End Sub

    ' Control Events
    Private Sub LstInterfaces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LBoxInterfaces.SelectedIndexChanged
        My.AppSettings.Default.InterfaceName = LBoxInterfaces.SelectedItem.ToString()
        SetInterfaceLabel()
    End Sub
    Private Sub CoBxTheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoBoxTheme.SelectedIndexChanged
        Dim selectedName As String = CoBoxTheme.SelectedItem.ToString()
        Dim selected As Skye.UI.SkyeTheme = Skye.UI.SkyeThemes.GetTheme(selectedName)
        My.AppSettings.Default.Theme = selected.Name
        If Not My.AppSettings.Default.ThemeAuto Then
            Skye.UI.ThemeManager.SetTheme(selected)
        End If
        My.AppSettings.Default.Save()
    End Sub
    Private Sub ChkBoxThemeAuto_Click(sender As Object, e As EventArgs) Handles ChkBoxThemeAuto.Click
        My.AppSettings.Default.ThemeAuto = ChkBoxThemeAuto.Checked
        SetThemesList()
        If My.AppSettings.Default.ThemeAuto Then
            Skye.UI.ThemeManager.SetTheme(Skye.UI.ThemeManager.DetectWindowsTheme())
        Else
            Skye.UI.ThemeManager.SetTheme(Skye.UI.SkyeThemes.GetTheme(My.AppSettings.Default.Theme))
        End If
        My.AppSettings.Default.Save()
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
    Private Sub SetThemesList()
        If My.AppSettings.Default.ThemeAuto Then
            CoBoxTheme.Enabled = False
        Else
            CoBoxTheme.Enabled = True
        End If
    End Sub

End Class