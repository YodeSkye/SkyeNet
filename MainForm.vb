
Imports System.Net.NetworkInformation
Imports System.Windows.Forms.Design
Imports Skye.UI

Public Class MainForm

    ' Declarations
    Private Tray As NotifyIcon
    Private Shadows Menu As ContextMenuStrip
    Private TimerCheckState As New Timer() With {.Interval = 10000}

    ' Form Events
    Public Sub New()
        InitializeComponent()

#If DEBUG Then
        Skye.Common.Log.Initialize(App.GetAssemblyName() & "DEV")
#Else
        Skye.Common.Log.Initialize(App.GetAssemblyName())
#End If
        Skye.Common.Log.Write(App.GetAssemblyName() & " Started...")

        AddHandler AppDomain.CurrentDomain.UnhandledException,
            Sub(sender, e)
                Skye.Common.Log.Write("UNHANDLED EXCEPTION: " & e.ExceptionObject.ToString())
            End Sub
        AddHandler Application.ThreadException,
            Sub(sender, e)
                Skye.Common.Log.Write("THREAD EXCEPTION: " & e.Exception.ToString())
            End Sub

        ' Theme
        If My.AppSettings.Default.ThemeAuto Then
            Skye.UI.ThemeManager.SetTheme(Skye.UI.ThemeManager.DetectWindowsTheme())
        Else
            Skye.UI.ThemeManager.CurrentTheme = Skye.UI.SkyeThemes.GetTheme(My.AppSettings.Default.Theme)
        End If
        AddHandler Skye.UI.ThemeManager.ThemeChanged, AddressOf OnThemeChanged

        Tray = New NotifyIcon() With {.Icon = My.Resources.IconSkyeNet, .Visible = True, .Text = "SkyeNet - Monitoring Network Profile"}
        Menu = New ContextMenuStrip With {.Font = App.CMFont}
        Menu.Items.Add("Settings", My.Resources.ImageSettings16, AddressOf OpenSettings)
        Menu.Items.Add("Log", My.Resources.ImageLog16, AddressOf OpenLog)
        Menu.Items.Add("Exit", My.Resources.ImageExit16, AddressOf ExitApp)
        Tray.ContextMenuStrip = Menu
        Menu.Renderer = New Skye.UI.SkyeMenuRenderer

        AddHandler NetworkChange.NetworkAddressChanged, AddressOf NetworkChanged
        AddHandler TimerCheckState.Tick, AddressOf TimerCheckState_Tick

        TimerCheckState.Start()

    End Sub
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Visible = False
        ShowInTaskbar = False
        WindowState = FormWindowState.Minimized
    End Sub
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)

        Skye.Common.Log.Write("..." & App.GetAssemblyName() & " Closed")
    End Sub

    ' Control Events
    Private Sub OpenSettings(sender As Object, e As EventArgs)
        Using f As New Settings()
            f.ShowDialog()
        End Using
    End Sub
    Private Sub OpenLog(sender As Object, e As EventArgs)
        Skye.Common.Log.ShowViewer()
        Skye.UI.ThemeManager.ApplyThemeToAllOpenForms()
    End Sub
    Private Sub ExitApp(sender As Object, e As EventArgs)
        Tray.Visible = False
        Application.Exit()
    End Sub

    ' Handlers
    Private Sub NetworkChanged(sender As Object, e As EventArgs)
        Skye.Common.Log.Write("NetworkChanged event fired")
        EnforceCategory()
    End Sub
    Private Sub TimerCheckState_Tick(sender As Object, e As EventArgs)
        EnforceCategory()
    End Sub
    Private Sub OnThemeChanged(sender As Object, e As EventArgs)
        Skye.UI.ThemeManager.ApplyThemeToAllOpenForms()
    End Sub

    ' Methods
    Private Sub EnforceCategory()
        Dim aliasName = My.AppSettings.Default.InterfaceName
        If String.IsNullOrWhiteSpace(aliasName) Then Exit Sub
        Dim category = GetNetworkCategory(aliasName)
        If category <> "Private" Then
            Skye.Common.Log.Write($"Category was {category}, correcting to Private")
            SetNetworkPrivate(aliasName)
        End If
    End Sub
    Private Function GetNetworkCategory(interfaceName As String) As String
        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell",
                .Arguments = "-Command ""(Get-NetConnectionProfile -InterfaceAlias '" & interfaceName & "').NetworkCategory""",
                .RedirectStandardOutput = True,
                .UseShellExecute = False,
                .CreateNoWindow = True
            }

            Using p = Process.Start(psi)
                Dim output = p.StandardOutput.ReadToEnd().Trim()
                If Not String.Equals(output, "Private", StringComparison.OrdinalIgnoreCase) Then
                    Skye.Common.Log.Write("GetNetworkCategory returned NON-PRIVATE: " & output)
                End If
                Return output
            End Using

        Catch ex As Exception
            Skye.Common.Log.Write("GetNetworkCategory ERROR: " & ex.Message)
            Return String.Empty
        End Try
    End Function
    Private Sub SetNetworkPrivate(interfaceName As String)
        Try
            Dim psi As New ProcessStartInfo With {
                .FileName = "powershell.exe",
                .Arguments = $"-Command ""Set-NetConnectionProfile -InterfaceAlias '{interfaceName}' -NetworkCategory Private""",
                .UseShellExecute = False,
                .CreateNoWindow = True
            }
            Process.Start(psi)
            Skye.Common.Log.Write($"Changed network category to Private for interface '{interfaceName}'.")
            Debug.WriteLine($"Changed network category to Private for interface '{interfaceName}'.")
        Catch ex As Exception
            Skye.Common.Log.Write($"Failed to change network category for interface '{interfaceName}': {ex.Message}")
            Debug.WriteLine($"Failed to change network category for interface '{interfaceName}': {ex.Message}")
        End Try
    End Sub

End Class
