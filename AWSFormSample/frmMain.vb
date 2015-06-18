Public Class frmMain
    '1:フォームロード時に、アカウントファイルを読み込む
    '処理：CSVファイルを読み込み、パラメータを取得する

    Private _AWSID As String = ""
    Private _AWSKEY As String = ""


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim wTitle As String = ""

        'Open File Dialog --- Select Certifaction file.(download from aws console)
        Dim Ofd As New OpenFileDialog
        Ofd.Filter = "csv File(*.csv)|*.csv|ALL File(*.*)|*.*"
        Ofd.FilterIndex = 2
        Ofd.Title = "Select AWS CertFile"
        Ofd.RestoreDirectory = True
        If Ofd.ShowDialog() = DialogResult.OK Then
            Dim Sr As New System.IO.StreamReader(Ofd.FileName) '  System.Text.Encoding.GetEncoding("shift_jis"))
            Dim wLine As String = "" 'Hold the Last line
            While Sr.Peek() > -1
                wLine = Sr.ReadLine()
            End While
            Sr.Close()

            'Seplate wLine
            Dim wCell() As String = wLine.Split(",")
            If wCell.Length = 3 Then
                wTitle = wCell(0)
                _AWSID = wCell(1)
                _AWSKEY = wCell(2)
            End If
        End If

        If wTitle.Length = 0 Then
            MsgBox("You chose an illegal authentication file")
            End
        Else
            Me.Text = "AWSFormSample -- " + wTitle

            'からの
            'IAMからパーミッション情報を取得して表示（予定）

        End If

    End Sub

    Private Sub btnEC2_Click(sender As Object, e As EventArgs) Handles btnEC2.Click
        Dim f As New frmAWSEC2
        f._AWSid = _AWSID
        f._AWSKey = _AWSKEY
        f._AWSRegion = Amazon.RegionEndpoint.APNortheast1
        f.ShowDialog()
        f.Dispose()
    End Sub


    Private Sub btnBilling_Click(sender As Object, e As EventArgs) Handles btnBilling.Click
        Dim f As New frmAWSBilling
        f._AWSid = _AWSID
        f._AWSKey = _AWSKEY
        f.ShowDialog()
        f.Dispose()
    End Sub

End Class