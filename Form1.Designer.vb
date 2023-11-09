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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_cabang = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_tottoko = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.dg_toko = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pbar = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_brand = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lbl_loading = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.picbox = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.treeViewExplorer = New System.Windows.Forms.TreeView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.listViewFiles = New System.Windows.Forms.ListView()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_toko, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_cabang)
        Me.GroupBox1.Location = New System.Drawing.Point(254, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 52)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "- opsi cabang -"
        '
        'cb_cabang
        '
        Me.cb_cabang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_cabang.FormattingEnabled = True
        Me.cb_cabang.Location = New System.Drawing.Point(19, 20)
        Me.cb_cabang.Name = "cb_cabang"
        Me.cb_cabang.Size = New System.Drawing.Size(217, 22)
        Me.cb_cabang.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_tottoko)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CheckBox2)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(255, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 169)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "- opsi file -"
        '
        'lbl_tottoko
        '
        Me.lbl_tottoko.AutoSize = True
        Me.lbl_tottoko.Location = New System.Drawing.Point(46, 148)
        Me.lbl_tottoko.Name = "lbl_tottoko"
        Me.lbl_tottoko.Size = New System.Drawing.Size(14, 14)
        Me.lbl_tottoko.TabIndex = 4
        Me.lbl_tottoko.Text = "0"
        Me.lbl_tottoko.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total :"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(9, 15)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(83, 18)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Check ALL"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.CheckOnClick = True
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Location = New System.Drawing.Point(97, 12)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(139, 154)
        Me.CheckedListBox2.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.date1)
        Me.GroupBox3.Location = New System.Drawing.Point(257, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(244, 68)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tanggal DTO :"
        '
        'date1
        '
        Me.date1.CustomFormat = "dd-MM-yyyy"
        Me.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.date1.Location = New System.Drawing.Point(26, 33)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(169, 20)
        Me.date1.TabIndex = 0
        '
        'dg_toko
        '
        Me.dg_toko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lucida Fax", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dg_toko.DefaultCellStyle = DataGridViewCellStyle1
        Me.dg_toko.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dg_toko.Location = New System.Drawing.Point(512, 6)
        Me.dg_toko.Name = "dg_toko"
        Me.dg_toko.ReadOnly = True
        Me.dg_toko.RowHeadersVisible = False
        Me.dg_toko.Size = New System.Drawing.Size(321, 295)
        Me.dg_toko.TabIndex = 3
        '
        'pbar
        '
        '
        '
        '
        Me.pbar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbar.Location = New System.Drawing.Point(15, 59)
        Me.pbar.Name = "pbar"
        Me.pbar.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.pbar.ProgressColor = System.Drawing.Color.SteelBlue
        Me.pbar.ProgressTextVisible = True
        Me.pbar.Size = New System.Drawing.Size(223, 167)
        Me.pbar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbar.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 253)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(227, 47)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "PROSES"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbl_brand
        '
        Me.lbl_brand.AutoSize = True
        Me.lbl_brand.BackColor = System.Drawing.Color.Transparent
        Me.lbl_brand.Font = New System.Drawing.Font("Constantia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_brand.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_brand.Location = New System.Drawing.Point(56, 1)
        Me.lbl_brand.Name = "lbl_brand"
        Me.lbl_brand.Size = New System.Drawing.Size(89, 13)
        Me.lbl_brand.TabIndex = 6
        Me.lbl_brand.Text = "ZipDTO v1.0.0.0"
        Me.lbl_brand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BackgroundWorker1
        '
        '
        'lbl_loading
        '
        Me.lbl_loading.AutoSize = True
        Me.lbl_loading.Location = New System.Drawing.Point(11, 237)
        Me.lbl_loading.Name = "lbl_loading"
        Me.lbl_loading.Size = New System.Drawing.Size(60, 14)
        Me.lbl_loading.TabIndex = 8
        Me.lbl_loading.Text = "Loading .."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 635)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Label3"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lbl_brand)
        Me.Panel1.Location = New System.Drawing.Point(10, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 38)
        Me.Panel1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Constantia", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(42, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "EDP Regional II Bandung"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picbox
        '
        Me.picbox.Image = Global.ZipDTO.My.Resources.Resources.Zerode_Plump_Folder_Archive_zip_256
        Me.picbox.Location = New System.Drawing.Point(10, 51)
        Me.picbox.Name = "picbox"
        Me.picbox.Size = New System.Drawing.Size(228, 182)
        Me.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picbox.TabIndex = 11
        Me.picbox.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.treeViewExplorer)
        Me.Panel2.Location = New System.Drawing.Point(13, 354)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 251)
        Me.Panel2.TabIndex = 12
        '
        'treeViewExplorer
        '
        Me.treeViewExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeViewExplorer.Location = New System.Drawing.Point(0, 0)
        Me.treeViewExplorer.Name = "treeViewExplorer"
        Me.treeViewExplorer.Size = New System.Drawing.Size(260, 247)
        Me.treeViewExplorer.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.listViewFiles)
        Me.Panel3.Location = New System.Drawing.Point(284, 354)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(549, 251)
        Me.Panel3.TabIndex = 13
        '
        'listViewFiles
        '
        Me.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewFiles.HideSelection = False
        Me.listViewFiles.Location = New System.Drawing.Point(0, 0)
        Me.listViewFiles.Name = "listViewFiles"
        Me.listViewFiles.Size = New System.Drawing.Size(545, 247)
        Me.listViewFiles.TabIndex = 0
        Me.listViewFiles.UseCompatibleStateImageBehavior = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 303)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(85, 14)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Open explorer"
        Me.LinkLabel1.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(15, 326)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(815, 23)
        Me.Panel4.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 14)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "File explorer"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 321)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.picbox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_loading)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.dg_toko)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Lucida Fax", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_toko, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dg_toko As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents pbar As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_brand As Label
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents cb_cabang As ComboBox
    Friend WithEvents lbl_tottoko As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_loading As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picbox As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents treeViewExplorer As TreeView
    Friend WithEvents listViewFiles As ListView
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
End Class
