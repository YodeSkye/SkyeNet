
Imports System.Reflection

Module App

    ' DECLARATIONS

    ' METHODS
    Friend Function GetAssemblyName() As String
        Dim asm = Assembly.GetExecutingAssembly()
        Dim name = asm.GetName().Name

        If Not String.IsNullOrEmpty(name) Then
            Return name
        End If

        ' Fallback: use the EXE filename
        Return IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)
    End Function

End Module
