Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json
Imports System.IO
Imports ComponentAce.Compression.ZipForge
Imports ComponentAce.Compression.Archiver
Public Class Form1
    Dim allcab As String
    Dim toko, gudang, namatoko, k, dtk, path_simpan, yymmdd, yymmdd1, yymm, mmdd, day, dd, ddmmy1, ddmmy2, namafiledto As String
    Dim mnu, mnu1, loca As String
    Private isFormExpanded As Boolean = False
    Private defaultFormSize As Size
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        defaultFormSize = Me.Size
        Me.Text = Application.ProductName + " v" + Application.ProductVersion
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        lbl_brand.Text = Application.ProductName + " v" + Application.ProductVersion
        pbar.Value = 75
        cabang()
        file()
        loaddata()
        picbox.BringToFront()
        pbar.SendToBack()
        Try
            date1.Text = DateAdd("d", +1, Date.Now)
            Dim bln As String
            bln = Microsoft.VisualBasic.Mid(date1.Text, 4, 2)
            If bln = "10" Then
                bln = "A"
            ElseIf bln = "11" Then
                bln = "B"
            ElseIf bln = "12" Then
                bln = "C"
            Else
                bln = Microsoft.VisualBasic.Mid(date1.Text, 5, 1)
            End If

            Dim thn As String
            thn = Microsoft.VisualBasic.Right(date1.Text, 1)
            Dim tgl As String
            tgl = Microsoft.VisualBasic.Left(date1.Text, 2)

            yymmdd = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2) - 1
            If Microsoft.VisualBasic.Left(date1.Text, 2) - 1 < 10 Then
                dd = "0" & Microsoft.VisualBasic.Left(date1.Text, 2) - 1
            Else
                dd = Microsoft.VisualBasic.Left(date1.Text, 2) - 1
            End If
            ddmmy1 = dd & Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Right(date1.Text, 1)
            ddmmy2 = Microsoft.VisualBasic.Left(date1.Text, 2) & Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Right(date1.Text, 1)
            Label3.Text = thn + bln + tgl
            day = Microsoft.VisualBasic.Left(date1.Text, 2)
            yymmdd = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2) - 1
            yymmdd1 = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2)

        Catch ex As Exception
            HandleError(ex)
            MyBase.Close()
        End Try

    End Sub
    Private Sub loadexplorer()



        ' Mengisi TreeView dengan folder awal (misalnya Desktop)
        Dim drives As String() = Directory.GetLogicalDrives()
        For Each drive As String In drives
            treeViewExplorer.Nodes.Add(drive)
        Next

        ' Add the root directory (D:\ in this case) to the TreeView
        Dim rootDirectoryPath As String = "D:\"
        Dim rootDirectory As DirectoryInfo = New DirectoryInfo(rootDirectoryPath)
        Dim rootNode As TreeNode = treeViewExplorer.Nodes.Add(rootDirectoryPath)
        rootNode.Tag = rootDirectoryPath
        FillTreeView(rootDirectory, rootNode.Nodes)
        listViewFiles.View = View.Details
        listViewFiles.Columns.Add("Name", 200)
        listViewFiles.Columns.Add("Size", 100)
        listViewFiles.Columns.Add("Last Modified", 150)
        ' Enable column header click to sort items
        listViewFiles.FullRowSelect = True
        listViewFiles.GridLines = True
        listViewFiles.Sorting = SortOrder.Ascending
        AddHandler listViewFiles.ColumnClick, AddressOf ListViewColumnSort
    End Sub
    Private Sub ListViewColumnSort(ByVal sender As Object, ByVal e As ColumnClickEventArgs)
        ' Sort the items based on the clicked column
        If e.Column = CType(CType(sender, ListView).Tag, Integer) Then
            ' Change the sort order if the same column is clicked again
            If CType(CType(sender, ListView).Tag, Integer) Mod 2 = 0 Then
                listViewFiles.Sorting = SortOrder.Descending
            Else
                listViewFiles.Sorting = SortOrder.Ascending
            End If
        Else
            ' Set the sort order to ascending by default for the new column
            listViewFiles.Sorting = SortOrder.Ascending
            CType(sender, ListView).Tag = e.Column
        End If

        CType(sender, ListView).ListViewItemSorter = New ListViewItemComparer(e.Column, listViewFiles.Sorting)
    End Sub

    Private Class ListViewItemComparer
        Implements IComparer

        Private col As Integer
        Private order As SortOrder

        Public Sub New(ByVal col As Integer, ByVal order As SortOrder)
            Me.col = col
            Me.order = order
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim returnVal As Integer = -1
            returnVal = [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            If order = SortOrder.Descending Then
                returnVal *= -1
            End If
            Return returnVal
        End Function
    End Class
    Private Sub FillTreeView(directory As DirectoryInfo, nodeCollection As TreeNodeCollection)
        ' Mengisi TreeView dengan subfolder dan file dalam folder yang ditentukan
        Try
            Dim currentNode As TreeNode = nodeCollection.Add(directory.Name)
            currentNode.Tag = directory.FullName

            For Each subDirectory As DirectoryInfo In directory.GetDirectories()
                FillTreeView(subDirectory, currentNode.Nodes)
            Next

        Catch ex As Exception
            ' Penanganan kesalahan jika diperlukan
        End Try
    End Sub
    Private Sub treeViewExplorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeViewExplorer.AfterSelect
        listViewFiles.Items.Clear()
        Dim selectedNode As TreeNode = treeViewExplorer.SelectedNode
        If selectedNode IsNot Nothing AndAlso selectedNode.Tag IsNot Nothing Then
            Dim directoryPath As String = selectedNode.Tag.ToString()

            Try
                Dim directoryInfo As DirectoryInfo = New DirectoryInfo(directoryPath)
                For Each file As FileInfo In directoryInfo.GetFiles()
                    Dim item As New ListViewItem(file.Name)
                    item.SubItems.Add(file.Length.ToString())
                    item.SubItems.Add(file.LastWriteTime.ToString())
                    listViewFiles.Items.Add(item)
                Next
            Catch ex As Exception
                ' Handle errors if necessary
            End Try
        End If
    End Sub
    Private Sub cabang()
        Try
            konek()
            Dim query As String = "SELECT id,kdcab FROM m_cabang where recid='*'"
            Using command As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    cb_cabang.Items.Add("ALL CABANG")
                    While reader.Read()
                        Dim id As Integer = reader.GetInt32("id")
                        Dim nama As String = reader.GetString("kdcab")
                        cb_cabang.Items.Add(nama)

                    End While
                End Using
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            HandleError(ex)
            Me.Close()
        End Try

    End Sub

    Private Sub pbar_ValueChanged(sender As Object, e As EventArgs) Handles pbar.ValueChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If isFormExpanded Then
            Me.Size = defaultFormSize
            isFormExpanded = False
            LinkLabel1.Text = "Open explorer"
        Else
            Me.Size = New Size(861, 656)
            isFormExpanded = True
            LinkLabel1.Text = "Close explorer"
        End If
    End Sub

    Private Sub file()
        Try
            konek()
            Dim query As String = "SELECT nama_file FROM m_file where recid='*'"
            Using command As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    'CheckedListBox1.Items.Add("ALL", CheckState.Unchecked)
                    While reader.Read()
                        'Dim id As Integer = reader.GetInt32("id")
                        Dim nama As String = reader.GetString("nama_file")
                        CheckedListBox2.Items.Add(nama, CheckState.Unchecked)
                        CheckedListBox2.SetItemChecked(CheckedListBox2.Items.Count - 1, False)
                        CheckedListBox2.Tag = nama
                    End While
                End Using
            End Using
            con.Close()
        Catch ex As Exception
            con.Close()
            HandleError(ex)
            Me.Close()
        End Try

    End Sub


    Private Sub HandleError(ByVal ex As Exception)
        ' Menampilkan pesan error kepada pengguna
        MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)

        ' Menyimpan informasi kesalahan ke log atau melakukan tindakan pemulihan lainnya
        ' ...
    End Sub
    Public Shadows Class IniFile
        Private _path As String

        Public Sub New(ByVal path As String)
            _path = path
        End Sub

        <DllImport("kernel32")>
        Private Shared Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
        End Function

        <DllImport("kernel32")>
        Private Shared Function WritePrivateProfileString(ByVal section As String, ByVal key As String, ByVal val As String, ByVal filePath As String) As Boolean
        End Function

        Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal [default] As String) As String
            Dim sb As New StringBuilder(255)
            GetPrivateProfileString(section, key, [default], sb, 255, _path)
            Return sb.ToString()
        End Function

        Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
            WritePrivateProfileString(section, key, value, _path)
        End Sub
    End Class

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim checked1 As Boolean = Me.CheckBox2.Checked
        If checked1 Then
            For i As Integer = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To CheckedListBox2.Items.Count - 1
                CheckedListBox2.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub tampiltoko()
        Call konek()
        Try
            dt.Clear()
            'dg_toko.Rows.Clear()
            sql = "SELECT KodeGudang as CAB,KodeToko as TOKO,NamaToko as Nama FROM master_toko WHERE KodeGudang IN(SELECT kdcab from m_cabang where recid='*' " + allcab + ") and `status`='Toko Normal'"
            da = New MySqlDataAdapter(sql, con)
            da.Fill(dt)
            dg_toko.DataSource = dt
            lbl_tottoko.Text = dg_toko.Rows.Count - 1
            dg_toko.Columns(0).Width = 50
            dg_toko.Columns(1).Width = 50
            dg_toko.Columns(2).Width = 220

        Catch ex As Exception
            HandleError(ex)
            Me.Close()
        End Try
    End Sub
    Private Sub cb_cabang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_cabang.SelectedIndexChanged
        allcab = ""
        If cb_cabang.Text = "ALL CABANG" Then
            Dim combinedData As New System.Text.StringBuilder()
            For Each item As Object In cb_cabang.Items

                If item.ToString() <> "ALL CABANG" Then
                    combinedData.Append("'" & item.ToString() & "',")
                End If
            Next
            If combinedData.Length > 0 Then
                combinedData.Length -= 1
            End If
            allcab = "and kdcab in(" + combinedData.ToString + ")"
        Else
            allcab = "and kdcab='" + cb_cabang.Text + "'"
        End If
        tampiltoko()
    End Sub

    Sub disablemenu()
        Button1.Enabled = False
        cb_cabang.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
    End Sub
    Sub enablemenu()
        Button1.Enabled = True
        cb_cabang.Enabled = True
        GroupBox2.Enabled = True
        GroupBox3.Enabled = True
    End Sub

    Private Sub proses()
        picbox.SendToBack()
        pbar.BringToFront()
        Dim blnsewa As String
        blnsewa = Microsoft.VisualBasic.Mid(date1.Text, 4, 2) - 1
        If blnsewa <= 9 Then
            blnsewa = "0" & Microsoft.VisualBasic.Mid(date1.Text, 4, 2) - 1
        Else
            blnsewa = Microsoft.VisualBasic.Mid(date1.Text, 4, 2) - 1
        End If
        If blnsewa = "00" Then
            blnsewa = "12"
        End If
        Dim blnss As String
        blnss = Microsoft.VisualBasic.Mid(date1.Text, 4, 2)
        Dim thna As String
        thna = Microsoft.VisualBasic.Right(date1.Text, 2)
        Try
            disablemenu()
            Dim a As Integer = lbl_tottoko.Text
            pbar.Maximum = 100
            pbar.Minimum = 0
            For i As Integer = 0 To a
                If i = a Then
                    MsgBox("Selesai")
                    pbar.Value = 0
                    lbl_loading.Text = "Loading .."
                    enablemenu()
                    picbox.BringToFront()
                    pbar.SendToBack()
                Else
                    lbl_loading.Text = dg_toko.Rows(i).Cells(0).Value.ToString + " - " + dg_toko.Rows(i).Cells(1).Value.ToString
                    toko = dg_toko.Rows(i).Cells(1).Value.ToString
                    gudang = dg_toko.Rows(i).Cells(0).Value.ToString
                    namatoko = dg_toko.Rows(i).Cells(2).Value.ToString
                    path_simpan = "D:\DTO\" + gudang.ToUpper + "\" + day
                    If Not Directory.Exists(path_simpan) Then
                        System.IO.Directory.CreateDirectory(path_simpan)
                    End If
                    k = Microsoft.VisualBasic.Left(toko, 1)
                    dtk = Microsoft.VisualBasic.Right(toko, 3)
                    namafiledto = "DTO" + Label3.Text + k + "." + dtk
                    pbar.Value = (i * 100) / a
                    Dim checkedValues As String() = AmbilNilaiChecked()
                    Dim arrayLength As Integer = checkedValues.Length
                    For x As Integer = 0 To arrayLength - 1
                        Dim namafile As String = checkedValues(x)
                        Dim path As String = Application.StartupPath + "\Master_path.ini"
                        Dim json As String = System.IO.File.ReadAllText(path)
                        Dim data1 As List(Of Dictionary(Of String, String)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(json)
                        For Each entry As Dictionary(Of String, String) In data1
                            Dim snamafile As String = ""
                            snamafile = entry("nama_file")
                            Dim spath As String = ""
                            spath = entry("sumber")
                            Dim lokasifile As String = ""
                            lokasifile = "D:\DTO MASTER\" + gudang + spath

                            If Not Directory.Exists(lokasifile) Then
                                System.IO.Directory.CreateDirectory(lokasifile)
                            End If
                            If namafile = snamafile Then
                                Dim archiver As ZipForge = New ZipForge()
                                If namafile = "ALL FILES" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "*.*"
                                    loca = lokasifile
                                End If
                                If namafile = "ALOK" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "ALOK" + gudang + k + dtk + yymmdd + ".CSV"
                                    loca = lokasifile
                                End If
                                If namafile = "FT" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "FT" + gudang + k + dtk + "*.CSV"
                                    loca = lokasifile
                                End If
                                If namafile = "SS" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "SS" + gudang + k + dtk + "*.CSV"
                                    loca = lokasifile
                                End If
                                If namafile = "FILE T" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    If blnsewa = 12 Then
                                        thna = thna - 1
                                    End If
                                    mnu = k + dtk + thna + blnsewa + "." + dtk
                                    loca = lokasifile
                                    thna = Microsoft.VisualBasic.Right(date1.Text, 2)
                                End If
                                If namafile = "SCREEN SAVER" Then
                                    If k = "T" Then
                                        archiver.FileName = path_simpan + "\" + namafiledto
                                        mnu = "*.jpg"
                                        mnu1 = "*.gif"
                                        loca = lokasifile
                                    Else
                                        Continue For
                                    End If

                                End If
                                If namafile = "ICOA" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "*OA" + toko + "*.CSV"
                                    loca = lokasifile
                                End If
                                If namafile = "SIMULASI" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "*.*"
                                    loca = lokasifile
                                End If
                                If namafile = "PJR" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "PJR" + yymmdd1 + k + "." + dtk
                                    loca = lokasifile
                                End If
                                If namafile = "NPT" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "NPT" + gudang.ToString + k + dtk + "*.ZIP"
                                    loca = lokasifile
                                End If

                                If namafile = "TAT" Then
                                    archiver.FileName = path_simpan + "\" + namafiledto
                                    mnu = "TAT*.CSV"
                                    loca = lokasifile
                                End If

                                'MsgBox("PROSES : " + archiver.FileName + vbCrLf + "FILE :" + namafile)
                                If System.IO.File.Exists(archiver.FileName) Then
                                    archiver.OpenArchive(System.IO.FileMode.Open)
                                    archiver.Options.Overwrite = OverwriteMode.IfNewer
                                    archiver.BaseDir = loca

                                    If namafile = "SCREEN SAVER" Then
                                        If k = "T" Then
                                            archiver.AddFiles(mnu)
                                            archiver.AddFiles(mnu1)
                                        End If
                                    Else
                                        ClsDTO.Tulislog("File name ada :" + archiver.FileName + ",Proses file : " + namafile + ",mnu : " + mnu + ",Loca :" + loca)
                                        archiver.AddFiles(mnu)
                                    End If
                                    archiver.CloseArchive()
                                Else
                                    ClsDTO.Tulislog("File name :" + archiver.FileName + ",Proses file : " + namafile + ",mnu : " + mnu + ",Loca :" + loca)
                                    archiver.OpenArchive(System.IO.FileMode.Create)
                                    archiver.BaseDir = loca
                                    If namafile = "SCREEN SAVER" Then
                                        If k = "T" Then
                                            archiver.AddFiles(mnu)
                                            archiver.AddFiles(mnu1)
                                        End If
                                    Else
                                        'ClsDTO.Tulislog("File name tidak ada :" + archiver.FileName + ",Proses file : " + namafile + ",mnu : " + mnu)
                                        archiver.AddFiles(mnu)
                                    End If
                                    archiver.CloseArchive()
                                End If
                            End If
                        Next
                    Next
                End If

            Next
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Catch ex As Exception
            ClsDTO.Tulislog("PROSES : " + path_simpan + "\" + namafiledto + vbCrLf + "MNU : " + mnu)
            ClsDTO.Tulislog(ex.Message + ex.StackTrace)
            HandleError(ex)
            enablemenu()
        End Try

    End Sub

    Private Sub date1_ValueChanged(sender As Object, e As EventArgs) Handles date1.ValueChanged
        Dim bln As String
        bln = Microsoft.VisualBasic.Mid(date1.Text, 4, 2)
        If bln = "10" Then
            bln = "A"
        ElseIf bln = "11" Then
            bln = "B"
        ElseIf bln = "12" Then
            bln = "C"
        Else
            bln = Microsoft.VisualBasic.Mid(date1.Text, 5, 1)
        End If

        Dim thn As String
        thn = Microsoft.VisualBasic.Right(date1.Text, 1)
        Dim tgl As String
        tgl = Microsoft.VisualBasic.Left(date1.Text, 2)

        Label3.Text = thn + bln + tgl
        yymmdd = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2) - 1
        yymmdd1 = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2)

        yymm = Microsoft.VisualBasic.Right(date1.Text, 2) + Microsoft.VisualBasic.Mid(date1.Text, 4, 2)
        mmdd = Microsoft.VisualBasic.Mid(date1.Text, 4, 2) + Microsoft.VisualBasic.Left(date1.Text, 2) - 1
        day = Microsoft.VisualBasic.Left(date1.Text, 2)
    End Sub

    Private Sub loaddata()
        Try
            Call konek()
            Dim sql As String = "Select nama_file,sumber FROM m_file WHERE recid='*'"
            Dim cmd As New MySqlCommand(sql, con)
            Dim mdr As MySqlDataReader = cmd.ExecuteReader()
            Dim data As New List(Of Dictionary(Of String, String))()
            While mdr.Read()
                Dim entry As New Dictionary(Of String, String)()
                entry.Add("nama_file", mdr("nama_file").ToString())
                entry.Add("sumber", mdr("sumber").ToString())
                data.Add(entry)
            End While
            mdr.Close()
            con.Close()

            Dim json As String = JsonConvert.SerializeObject(data, Formatting.Indented)
            Dim path As String = Application.StartupPath + "\Master_path.ini"
            System.IO.File.WriteAllText(path, json)
            Console.WriteLine("File JSON berhasil dibuat.")
            Console.ReadLine()


        Catch ex As Exception
            HandleError(ex)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If cb_cabang.Text = "" Then
            MsgBox("Harap pilih cabang terlebih dahulu", MsgBoxStyle.Exclamation)
        ElseIf GetCheckedTotal = 0 Then
            MsgBox("Harap pilih file terlebih dahulu", MsgBoxStyle.Exclamation)
        Else
            proses()
        End If

    End Sub
    Private Function GetCheckedTotal() As Integer
        Dim totalChecked As Integer = 0

        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) Then
                totalChecked += 1
            End If
        Next
        Return totalChecked
    End Function

    Private Function AmbilNilaiChecked() As String()
        Dim checkedValues As New List(Of String)()
        For i As Integer = 0 To CheckedListBox2.Items.Count - 1
            If CheckedListBox2.GetItemChecked(i) Then
                checkedValues.Add(CheckedListBox2.Items(i).ToString())
            End If
        Next
        Dim checkedArray As String() = checkedValues.ToArray()
        Return checkedArray
    End Function
End Class
