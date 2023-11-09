Imports MySql.Data.MySqlClient
Imports System.Threading
Module koneksi
    Public mysql, sql As String
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public mdr As MySqlDataReader
    Public dt As New DataTable
    Public da As New MySqlDataAdapter


    Public Sub konek()
        Dim iniFile As New Form1.IniFile(Application.StartupPath + "\Aturan.ini")
        Dim ip, user, pass, db As String
        ip = iniFile.ReadValue("KONEKSI", "Host", "")
        user = iniFile.ReadValue("KONEKSI", "User", "")
        pass = iniFile.ReadValue("KONEKSI", "Pass", "")
        db = iniFile.ReadValue("KONEKSI", "Db", "")
        Dim contimeout As Integer = 30
        mysql = "server=" + ip.ToString + ";uid=" + user.ToString + ";pwd=" + pass.ToString + ";database=" + db.ToString + ";Pooling=False"
        con = New MySqlConnection(mysql)
        Try
            con.Open()

        Catch ex As Exception
            'MsgBox("ERROR KONEKSI KE SERVER :" + ex.Message)
        End Try
    End Sub

    Sub Main()
        AddHandler Application.ThreadException, AddressOf HandleThreadException
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf HandleUnhandledException

        ' Kode aplikasi Anda di sini
        ' ...
    End Sub

    Private Sub HandleThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        ' Menampilkan pesan error untuk unhandled exception
        Dim ex As Exception = e.Exception
        MessageBox.Show("Terjadi kesalahan yang tidak ditangani:" & Environment.NewLine & ex.Message,
                        "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub HandleUnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
        MessageBox.Show("Terjadi kesalahan yang tidak ditangani:" & Environment.NewLine & ex.Message,
                        "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Module

