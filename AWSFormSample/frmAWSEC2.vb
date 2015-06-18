Public Class frmAWSEC2
    Public _AWSid As String
    Public _AWSKey As String
    Public _AWSRegion As Amazon.RegionEndpoint

    Private Sub frmAWSEC2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = EC2toDataTable()
    End Sub

    ''' <summary>
    ''' EC2情報をDataTableで返す
    ''' </summary>
    ''' <param name="InstID"></param>
    ''' <returns></returns>
    ''' <remarks>[IAM]ec2:DescribeInstances</remarks>
    Private Function EC2toDataTable(Optional ByVal InstID As String = "") As DataTable
        Dim ec2client As Amazon.EC2.AmazonEC2Client
        Dim ec2listresponse As Amazon.EC2.Model.DescribeInstancesResponse
        Dim ec2listrequest As Amazon.EC2.Model.DescribeInstancesRequest
        Try
            Dim cred As Amazon.Runtime.BasicAWSCredentials
            cred = New Amazon.Runtime.BasicAWSCredentials(_AWSid, _AWSKey)
            ec2client = New Amazon.EC2.AmazonEC2Client(cred, _AWSRegion)

            ec2listrequest = New Amazon.EC2.Model.DescribeInstancesRequest()
            '対象インスタンスが決まっているのならそほど


            If InstID.Length > 0 Then ec2listrequest.InstanceIds.Add(InstID)
            ec2listresponse = ec2client.DescribeInstances(ec2listrequest)


            'データ生成
            Dim Dt As New Data.DataTable
            Dt.Columns.Add("Name")
            Dt.Columns.Add("PrivateIP")
            Dt.Columns.Add("Global-IP")
            Dt.Columns.Add("SecurityGroup")
            Dt.Columns.Add("Instance-ID")
            Dt.Columns.Add("SecurityG-ID")
            Dt.Columns.Add("Type")
            Dt.Columns.Add("State-Code")
            Dt.Columns.Add("State-Name")
            'ステータスはステータスリクエストからとる→Stop時はとれない
            Dt.Columns.Add("System-Status")
            Dt.Columns.Add("System-Detail")
            Dt.Columns.Add("Instance-Status")
            Dt.Columns.Add("Instance-Detail")

            'ステータステーブルを取得する
            Dim statusDT As Data.DataTable = fncInstanceStatus(ec2client)


            Dim Dr As Data.DataRow
            For Each instance In ec2listresponse.Reservations
                Dr = Dt.NewRow()

                Dr("Name") = ""

                'For Each wName In instance.RunningInstance.Item(0).Tag
                For Each wName In instance.Instances(0).Tags
                    If wName.Key = "Name" Then Dr("Name") = wName.Value
                Next


                Dr("PrivateIP") = instance.Instances(0).PrivateIpAddress
                Dr("Global-IP") = instance.Instances(0).PublicIpAddress


                If instance.Instances(0).SecurityGroups.Count > 0 Then
                    Dr("SecurityGroup") = instance.Instances(0).SecurityGroups(0).ToString
                    Dr("SecurityG-ID") = instance.Instances(0).SecurityGroups(0).GroupId.ToString
                End If
                Dr("State-Code") = instance.Instances(0).State.Code
                Dr("State-Name") = instance.Instances(0).State.Name
                Dr("Instance-ID") = instance.Instances(0).InstanceId
                Dr("Type") = instance.Instances(0).InstanceType

                If Dr("Name").ToString.Length = 0 Then Dr("Name") = Dr("Instance-ID") '補正：Nameが無ければインスタンスID

                'インスタンスステータス取得
                For i As Integer = 0 To statusDT.Rows.Count - 1
                    If Dr("Instance-ID") = statusDT.Rows(i)("Instance-ID") Then
                        Dr("System-Status") = statusDT.Rows(i)("System-Status")
                        Dr("System-Detail") = statusDT.Rows(i)("System-Detail")
                        Dr("Instance-Status") = statusDT.Rows(i)("Instance-Status")
                        Dr("Instance-Detail") = statusDT.Rows(i)("Instance-Detail")
                        Exit For
                    End If
                Next


                Dt.Rows.Add(Dr)
            Next

            Return Dt
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' [Private]インスタンスステータスをDataTableで返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>[IAM] ec2:DescribeInstanceStatus</remarks>
    Private Function fncInstanceStatus(ByVal ec2client As Amazon.EC2.AmazonEC2Client) As System.Data.DataTable
        Try
            Dim StatusReq As Amazon.EC2.Model.DescribeInstanceStatusRequest = New Amazon.EC2.Model.DescribeInstanceStatusRequest
            Dim StatusRes As Amazon.EC2.Model.DescribeInstanceStatusResponse = ec2client.DescribeInstanceStatus(StatusReq)

            Dim sDt As New Data.DataTable
            sDt.Columns.Add("Instance-ID")
            sDt.Columns.Add("System-Status")
            sDt.Columns.Add("System-Detail")
            sDt.Columns.Add("Instance-Status")
            sDt.Columns.Add("Instance-Detail")

            Dim sDr As Data.DataRow
            'For Each wInstStatus As Amazon.EC2.Model.InstanceStatus In StatusRes.DescribeInstanceStatusResult.InstanceStatus
            For Each wInstStatus As Amazon.EC2.Model.InstanceStatus In StatusRes.InstanceStatuses
                sDr = sDt.NewRow
                sDr("Instance-ID") = wInstStatus.InstanceId
                sDr("System-Status") = wInstStatus.SystemStatus.Status
                sDr("System-Detail") = wInstStatus.SystemStatus.Details(0)
                sDr("Instance-Status") = wInstStatus.InstanceState.Code
                sDr("Instance-Detail") = wInstStatus.InstanceState.Name
                sDt.Rows.Add(sDr)
            Next

            Return sDt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class