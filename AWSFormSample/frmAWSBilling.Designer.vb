<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAWSBilling
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.numByHour = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numByDay = New System.Windows.Forms.NumericUpDown()
        Me.btnByHour = New System.Windows.Forms.Button()
        Me.btnByDay = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.numByHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numByDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(549, 344)
        Me.DataGridView1.TabIndex = 0
        '
        'pnlTop
        '
        Me.pnlTop.Controls.Add(Me.btnByDay)
        Me.pnlTop.Controls.Add(Me.btnByHour)
        Me.pnlTop.Controls.Add(Me.Label3)
        Me.pnlTop.Controls.Add(Me.Label4)
        Me.pnlTop.Controls.Add(Me.numByDay)
        Me.pnlTop.Controls.Add(Me.Label2)
        Me.pnlTop.Controls.Add(Me.Label1)
        Me.pnlTop.Controls.Add(Me.numByHour)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(3, 3)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(549, 56)
        Me.pnlTop.TabIndex = 1
        '
        'pnlBottom
        '
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(3, 403)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(549, 42)
        Me.pnlBottom.TabIndex = 2
        '
        'numByHour
        '
        Me.numByHour.Location = New System.Drawing.Point(44, 9)
        Me.numByHour.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numByHour.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numByHour.Name = "numByHour"
        Me.numByHour.Size = New System.Drawing.Size(61, 19)
        Me.numByHour.TabIndex = 0
        Me.numByHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numByHour.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Last:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(111, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hours"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Days"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Last:"
        '
        'numByDay
        '
        Me.numByDay.Location = New System.Drawing.Point(211, 9)
        Me.numByDay.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.numByDay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numByDay.Name = "numByDay"
        Me.numByDay.Size = New System.Drawing.Size(61, 19)
        Me.numByDay.TabIndex = 3
        Me.numByDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.numByDay.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'btnByHour
        '
        Me.btnByHour.Location = New System.Drawing.Point(11, 30)
        Me.btnByHour.Name = "btnByHour"
        Me.btnByHour.Size = New System.Drawing.Size(135, 20)
        Me.btnByHour.TabIndex = 6
        Me.btnByHour.Text = "Get by Hour"
        Me.btnByHour.UseVisualStyleBackColor = True
        '
        'btnByDay
        '
        Me.btnByDay.Location = New System.Drawing.Point(178, 30)
        Me.btnByDay.Name = "btnByDay"
        Me.btnByDay.Size = New System.Drawing.Size(135, 20)
        Me.btnByDay.TabIndex = 7
        Me.btnByDay.Text = "Get by Day"
        Me.btnByDay.UseVisualStyleBackColor = True
        '
        'frmAWSBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 448)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.Name = "frmAWSBilling"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "frmAWSBilling"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.numByHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numByDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnByDay As System.Windows.Forms.Button
    Friend WithEvents btnByHour As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numByDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numByHour As System.Windows.Forms.NumericUpDown
End Class
