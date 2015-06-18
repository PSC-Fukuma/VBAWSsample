<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnBilling = New System.Windows.Forms.Button()
        Me.btnEC2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBilling
        '
        Me.btnBilling.Location = New System.Drawing.Point(48, 200)
        Me.btnBilling.Name = "btnBilling"
        Me.btnBilling.Size = New System.Drawing.Size(115, 55)
        Me.btnBilling.TabIndex = 0
        Me.btnBilling.Text = "Billing"
        Me.btnBilling.UseVisualStyleBackColor = True
        '
        'btnEC2
        '
        Me.btnEC2.Location = New System.Drawing.Point(48, 65)
        Me.btnEC2.Name = "btnEC2"
        Me.btnEC2.Size = New System.Drawing.Size(115, 55)
        Me.btnEC2.TabIndex = 1
        Me.btnEC2.Text = "EC2"
        Me.btnEC2.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 277)
        Me.Controls.Add(Me.btnEC2)
        Me.Controls.Add(Me.btnBilling)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBilling As System.Windows.Forms.Button
    Friend WithEvents btnEC2 As System.Windows.Forms.Button
End Class
