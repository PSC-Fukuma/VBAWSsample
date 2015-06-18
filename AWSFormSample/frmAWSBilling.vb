Public Class frmAWSBilling

    Public _AWSid As String
    Public _AWSKey As String

    Private Sub frmAWSBilling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
    End Sub


    Private Sub btnByHour_Click(sender As Object, e As EventArgs) Handles btnByHour.Click
        'Get by Time
        Dim wStartTime As DateTime
        wStartTime = DateAdd(DateInterval.Hour, -1 * numByHour.Value, Date.UtcNow)
        AdjustDisp(60 * 60, wStartTime)
    End Sub

    Private Sub btnByDay_Click(sender As Object, e As EventArgs) Handles btnByDay.Click
        'Get by Days
        Dim wStartTime As DateTime
        wStartTime = DateAdd(DateInterval.Day, -1 * numByDay.Value, Date.UtcNow)
        AdjustDisp(60 * 60 * 24, wStartTime)
    End Sub

    ''' <summary>
    ''' for Sort DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AdjustDisp(ByVal wPeriod As Integer, ByVal wStartTime As DateTime)
        Dim wDt As DataTable = ChargeInfo(wPeriod, wStartTime)
        Dim wDv As DataView = wDt.DefaultView
        wDv.Sort = "LinkedAccount ASC,TimeStamp DESC,ServiceName ASC"

        DataGridView1.DataSource = wDv
    End Sub

    ''' <summary>
    ''' The return by the billing information to DataTable
    ''' </summary>
    ''' <param name="wPeriod">Period : by Hour(1-500)   by Day(1-90)</param>
    ''' <param name="wStartTime"></param>
    ''' <returns></returns>
    ''' <remarks>[IAM] cloudwatch:GetMetricStatistics/cloudwatch:ListMetrics</remarks>
    Private Function ChargeInfo(ByVal wPeriod As Integer, ByVal wStartTime As DateTime) As Data.DataTable
        Dim Dt As New Data.DataTable
        Dim wEndTime As DateTime = Date.UtcNow

        Try
            Dim Cw As Amazon.CloudWatch.AmazonCloudWatchClient
            Dim Cwreq As Amazon.CloudWatch.Model.ListMetricsRequest
            Dim Cwres As Amazon.CloudWatch.Model.ListMetricsResponse

            'Connect to AWS CloudWatch
            Dim cred As Amazon.Runtime.BasicAWSCredentials
            cred = New Amazon.Runtime.BasicAWSCredentials(_AWSid, _AWSKey)
            Cw = New Amazon.CloudWatch.AmazonCloudWatchClient(cred, Amazon.RegionEndpoint.USEast1)

            'Request to CloudWatch  const "EstimatedCharges" And Get Response
            Cwreq = New Amazon.CloudWatch.Model.ListMetricsRequest
            Cwreq.MetricName = "EstimatedCharges"
            Cwres = Cw.ListMetrics(Cwreq)

            'Preparation DataTable Object. for Easy to see...
            Dt.Columns.Add("LinkedAccount")
            Dt.Columns.Add("TimeStamp", Type.GetType("System.DateTime"))
            Dt.Columns.Add("ServiceName")
            'Dt.Columns.Add("Currency")   '<-- Always set "USD"
            Dt.Columns.Add("MaxValue")

            For Each wMetric As Amazon.CloudWatch.Model.Metric In Cwres.Metrics
                Dim statsReq As New Amazon.CloudWatch.Model.GetMetricStatisticsRequest
                Dim statsRes As Amazon.CloudWatch.Model.GetMetricStatisticsResponse
                statsReq.Dimensions = wMetric.Dimensions
                statsReq.MetricName = wMetric.MetricName
                statsReq.Namespace = wMetric.Namespace
                statsReq.StartTime = wStartTime
                statsReq.EndTime = wEndTime
                statsReq.Period = wPeriod
                statsReq.Statistics.Add("Maximum")


                statsRes = Cw.GetMetricStatistics(statsReq)

                'Got data structure -> Object([Name]/[Value])  convert  Name->Column Header  Value->Column Value 
                Dim wServiceName As String = ""
                Dim wCurrency As String = ""
                Dim wLinkedAccount As String = ""
                For Each wDimension As Amazon.CloudWatch.Model.Dimension In wMetric.Dimensions
                    Select Case wDimension.Name
                        Case "LinkedAccount" : wLinkedAccount = wDimension.Value
                        Case "ServiceName" : wServiceName = wDimension.Value
                        Case "Currency" : wCurrency = wDimension.Value
                    End Select
                Next

                '...And Set to Datarow
                Dim Dr As Data.DataRow
                For Each wDataPoint As Amazon.CloudWatch.Model.Datapoint In statsRes.Datapoints
                    Dr = Dt.NewRow
                    Dr("LinkedAccount") = wLinkedAccount
                    Dr("ServiceName") = wServiceName
                    '        Dr("Currency") = wCurrency
                    Dr("MaxValue") = wDataPoint.Maximum
                    Dr("TimeStamp") = wDataPoint.Timestamp
                    Dt.Rows.Add(Dr)
                Next
            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return Dt
    End Function

End Class