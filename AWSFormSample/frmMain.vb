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
        End If

    End Sub

End Class