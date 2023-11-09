Imports System.Text
Imports System.IO
Public Class ClsDTO
    Public Shared Sub Tulislog(slog As String)
        Try
            Dim thn As String = Format(Now, "yyyy-MM-dd")
            Dim th As String = Format(Now, "yyyyMM")
            Dim thnn As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim tulis As StreamWriter
            If Not File.Exists(Application.StartupPath & "\TRACELOG_" + th + ".txt") Then
                tulis = File.CreateText(Application.StartupPath & "\TRACELOG_" + th + ".txt")
                tulis.WriteLine("##### LOG PROGRAM #####")
                tulis.WriteLine(thnn & " : " & slog)
                tulis.Flush()
                tulis.Close()
            Else
                tulis = File.AppendText(Application.StartupPath & "\TRACELOG_" + th + ".txt")
                tulis.WriteLine(thnn & " : " & slog)
                tulis.Flush()
                tulis.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
