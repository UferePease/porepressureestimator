Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form1
    'Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin;Jet OLEDB:Database Password=password"
    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin;Jet OLEDB:Database Password=password"
    Dim MyConn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim tables As DataTableCollection
    Dim source1 As New BindingSource

    Dim fieldSlope, fieldIntercept As Double

    Dim dbPath = Environment.GetEnvironmentVariable("APPDATA")
    'Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) '& "\CreatedFolder\Resources\DatabaseFile.accdb"

    Public dbPathAccess As String = Application.StartupPath & "\porepressurepredictor.accdb"
    Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPathAccess

    Dim fieldName As String

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Text.Equals("Rehm and McClendon") Then
                If fieldName IsNot vbNullString Then

                    MyConn = New OleDbConnection
                    MyConn.ConnectionString = connStr
                    ds = New DataSet
                    tables = ds.Tables
                    da = New OleDbDataAdapter("Select TVD_ft, D_EXPONENT_NORMAL, D_EXPONENT_OBSERVED, OVERBURDEN_PRES_GRAD_Psf, NORMAL_PRES_GRAD_Psf, REHM_McCLENDON_Psi from " & fieldName, MyConn) 'Change items to your database name
                    da.Fill(ds, "SampleData1") 'Change items to your database name 
                    Dim view As New DataView(tables(0))
                    source1.DataSource = view
                    DataGridView1.DataSource = view

                    'Resize the DataGridView columns to fit the newly loaded content.
                    DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Else
                    MsgBox("Field name and field data must be supplied first")
                End If
            End If

            If e.Node.Text.Equals("Ben Eaton") Then
                'MsgBox("Ben Eaton", MsgBoxStyle.OkOnly, "Information")

                If fieldName IsNot vbNullString Then

                    MyConn = New OleDbConnection
                    MyConn.ConnectionString = connStr
                    ds = New DataSet
                    tables = ds.Tables
                    da = New OleDbDataAdapter("Select TVD_ft, D_EXPONENT_NORMAL, D_EXPONENT_OBSERVED, OVERBURDEN_PRES_GRAD_Psf, NORMAL_PRES_GRAD_Psf, BEN_EATON_Psi from " & fieldName, MyConn) 'Change items to your database name
                    da.Fill(ds, "SampleData1") 'Change items to your database name 
                    Dim view As New DataView(tables(0))
                    source1.DataSource = view
                    DataGridView1.DataSource = view

                    'Resize the DataGridView columns to fit the newly loaded content.
                    DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Else
                    MsgBox("Field name and field data must be supplied first")
                End If

            End If

            If e.Node.Text.Equals("Nweke and Dosunmu") Then
                If fieldName IsNot vbNullString Then

                    MyConn = New OleDbConnection
                    MyConn.ConnectionString = connStr
                    ds = New DataSet
                    tables = ds.Tables
                    da = New OleDbDataAdapter("Select TVD_ft, D_EXPONENT_NORMAL, D_EXPONENT_OBSERVED, OVERBURDEN_PRES_GRAD_Psf, NORMAL_PRES_GRAD_Psf, NWEKE_DOSUMU_Psi from " & fieldName, MyConn) 'Change items to your database name
                    da.Fill(ds, "SampleData1") 'Change items to your database name 
                    Dim view As New DataView(tables(0))
                    source1.DataSource = view
                    DataGridView1.DataSource = view

                    'Resize the DataGridView columns to fit the newly loaded content.
                    DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Else
                    MsgBox("Field name and field data must be supplied first")
                End If
            End If

            If e.Node.Text.Equals("Abnormal Pore Pressure") Then
                If fieldName IsNot vbNullString Then

                    MyConn = New OleDbConnection
                    MyConn.ConnectionString = connStr
                    ds = New DataSet
                    tables = ds.Tables
                    da = New OleDbDataAdapter("Select TVD_ft, MDT_PP_Psi, REHM_McCLENDON_Psi, BEN_EATON_Psi, NWEKE_DOSUMU_Psi, REHM_McCLENDON_ERROR_EST, BEN_EATON_ERROR_EST, NWEKE_DOSUMU_ERROR_EST from " & fieldName, MyConn) 'Change items to your database name
                    da.Fill(ds, "SampleData1") 'Change items to your database name 
                    Dim view As New DataView(tables(0))
                    source1.DataSource = view
                    DataGridView1.DataSource = view

                    'Resize the DataGridView columns to fit the newly loaded content.
                    DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                Else
                    MsgBox("Field name and field data must be supplied first")
                End If
            End If

            If e.Node.Text.Equals("Chart") Then
                'MsgBox("Chart", MsgBoxStyle.OkOnly, "Information")
                drawChart()
            End If
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PorepressurepredictorDataSet2.SampleData1' table. You can move, or remove it, as needed.

        'Me.SampleData1TableAdapter.Fill(Me.PorepressurepredictorDataSet2.SampleData1)

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ToolStripContainer1_ContentPanel_Load(sender As Object, e As EventArgs) Handles ToolStripContainer1.ContentPanel.Load

    End Sub

    Private Sub FlowLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel2.Paint

    End Sub

    Private Sub ToolStripTextBox1_Click(sender As Object, e As EventArgs) Handles ToolStripTextBox1.Click

    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    MyConn = New OleDbConnection
    '    MyConn.ConnectionString = connString
    '    ds = New DataSet
    '    tables = ds.Tables
    '    da = New OleDbDataAdapter("Select * from [items]", MyConn) 'Change items to your database name
    '    da.Fill(ds, "items") 'Change items to your database name
    '    Dim view As New DataView(tables(0))
    '    source1.DataSource = view
    '    DataGridView1.DataSource = view
    'End Sub

    Private Sub SampleDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SampleDataToolStripMenuItem.Click
        'using sample data

        'reset progress bar
        ToolStripProgressBar2.Value = 0
        'set the maximum
        ToolStripProgressBar2.Maximum = 10000
        'do long work
        For I As Integer = 0 To ToolStripProgressBar2.Maximum - 1
            'update progress
            ToolStripProgressBar2.Increment(1)
        Next
        'finish long work

        'reset progress bar
        ToolStripProgressBar2.Value = 0

        fieldName = "SampleData1"
        ToolStripStatusLabel2.Text = fieldName

        MyConn = New OleDbConnection
        MyConn.ConnectionString = connStr
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("Select TVD_ft, D_EXPONENT_NORMAL, D_EXPONENT_OBSERVED, OVERBURDEN_PRES_GRAD_Psf, NORMAL_PRES_GRAD_Psf, BEN_EATON_Psi from SampleData1", MyConn) 'Change items to your database name
        da.Fill(ds, "SampleData1") 'Change items to your database name 
        Dim view As New DataView(tables(0))
        source1.DataSource = view
        DataGridView1.DataSource = view

        'Resize the DataGridView columns to fit the newly loaded content.
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'reset progress bar
        ToolStripProgressBar2.Value = 0

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        getFieldName("Enter the field name")
    End Sub

    Private Sub getFieldName(msg As String)
        'creating new field name
        Dim message, title, defaultValue As String
        ' Set prompt.
        ' Set title.
        title = "Field Name"
        defaultValue = fieldName   ' Set default value.

        ' Display message, title, and default value. Display dialog box at position 400, 200.
        fieldName = InputBox(msg, title, defaultValue, 400, 200)
        ' If user has clicked Cancel, set myValue to defaultValue 
        If fieldName Is "" Then fieldName = defaultValue

        ToolStripStatusLabel2.Text = fieldName

        createAccessDbTable(fieldName)
    End Sub

    Private Sub createAccessDbTable(tableName As String)

        Dim con As New OleDb.OleDbConnection(connStr)

        ' get database schema

        con.Open()

        Dim dbSchema As DataTable = con.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, tableName, "TABLE"})

        con.Close()

        ' if the table exists the count will be 1...

        If dbSchema.Rows.Count > 0 Then

            ' ... do whatever you want to do if the table exists

        Else

            ' ... do whatever you want to do if the table does not exist

            ' eg create a table

            Dim cmd As New OleDb.OleDbCommand("CREATE TABLE [" + tableName + "] ([ID] COUNTER PRIMARY KEY, [TVD_ft] DOUBLE, [D_EXPONENT_NORMAL] DOUBLE, [D_EXPONENT_OBSERVED] DOUBLE, [OVERBURDEN_PRES_GRAD_Psf] DOUBLE, [NORMAL_PRES_GRAD_Psf] DOUBLE, [PP_SG] DOUBLE, [MDT_PP_Psi] DOUBLE, [BEN_EATON_Psf] DOUBLE, [BEN_EATON_Psi] DOUBLE, [BEN_EATON_ERROR_EST] DOUBLE, [NWEKE_DOSUMU_Psf] DOUBLE, [NWEKE_DOSUMU_Psi] DOUBLE, [NWEKE_DOSUMU_ERROR_EST] DOUBLE, [REHM_McCLENDON_Ppg] DOUBLE, [REHM_McCLENDON_Psi] DOUBLE, [REHM_McCLENDON_ERROR_EST] DOUBLE)", con)

            con.Open()

            cmd.ExecuteNonQuery()

            MsgBox(tableName + " table created", MsgBoxStyle.Information)

            con.Close()
        End If
    End Sub

    Function IsTable(sTblName As String) As Boolean
        'does table exists and work ?
        'note: finding the name in the TableDefs collection is not enough,
        '      since the backend might be invalid or missing

        Try
            'Dim x
            'x = DCount("*", sTblName)
            'IsTable = True
            'Exit Function
        Catch
            'Debug.Print Now, sTblName, Err.Number, Err.Description
            'IsTable = False
        End Try

    End Function

    Private Sub ImportDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDataToolStripMenuItem.Click

        Dim excelconn As OleDbConnection
        Dim exceldtr As OleDbDataReader
        Dim exceldta As OleDbDataAdapter
        Dim excelcmd As OleDbCommand
        Dim exceldts As DataSet
        Dim importexcelsheet As String
        Dim OpenFileDialog As New OpenFileDialog

        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

        If (fieldName IsNot "" And fieldName IsNot "SampleData1" And fieldName IsNot vbNullString) Then

            MsgBox("Ensure that worksheet has columns in this order:" & Chr(13) & Chr(13) & "Depth(ft)" & Chr(13) & "D-exponent Normal" & Chr(13) & "D-Exponent Observed" & Chr(13) & "Overburden Pressure(Psi/ft)" & Chr(13) & "Normal Pore Pressure(Psi/ft)" & Chr(13) & "MDT Pore Pressure(SG)", MsgBoxStyle.Information)

            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                Dim fi As New System.IO.FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName

                importexcelsheet = fi.FullName
                excelconn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + importexcelsheet + ";Extended Properties=Excel 12.0;")
                exceldta = New OleDbDataAdapter("Select * From [Sheet1$]", excelconn)
                exceldts = New DataSet
                exceldta.Fill(exceldts, "[Sheet1$]")

                For Each dr As DataRow In exceldts.Tables(0).Rows
                    'Dim str1 As String = dr(0).ToString()

                    Try
                        Dim sqlconn As New OleDb.OleDbConnection
                        Dim sqlquery As New OleDb.OleDbCommand
                        'Dim connString As String
                        'connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Visual Studio 2010\Projects\Invent\Invent\mdbInvent.accdb"
                        sqlconn.ConnectionString = connStr
                        sqlquery.Connection = sqlconn
                        sqlconn.Open()
                        sqlquery.CommandText = "INSERT INTO " & fieldName & "([TVD_ft], [D_EXPONENT_NORMAL], [D_EXPONENT_OBSERVED], [OVERBURDEN_PRES_GRAD_Psf], [NORMAL_PRES_GRAD_Psf], [PP_SG], [MDT_PP_Psi], [BEN_EATON_Psf], [BEN_EATON_Psi], [BEN_EATON_ERROR_EST], [NWEKE_DOSUMU_Psf], [NWEKE_DOSUMU_Psi], [NWEKE_DOSUMU_ERROR_EST], [REHM_McCLENDON_Ppg], [REHM_McCLENDON_Psi], [REHM_McCLENDON_ERROR_EST])VALUES(@TVD_ft, @D_EXPONENT_NORMAL, @D_EXPONENT_OBSERVED, @OVERBURDEN_PRES_GRAD_Psf, @NORMAL_PRES_GRAD_Psf, @PP_SG, @MDT_PP_Psi, @BEN_EATON_Psf, @BEN_EATON_Psi, @BEN_EATON_ERROR_EST, @NWEKE_DOSUMU_Psf, @NWEKE_DOSUMU_Psi, @NWEKE_DOSUMU_ERROR_EST, @REHM_McCLENDON_Ppg, @REHM_McCLENDON_Psi, @REHM_McCLENDON_ERROR_EST)"
                        sqlquery.Parameters.AddWithValue("@TVD_ft", dr(0))
                        sqlquery.Parameters.AddWithValue("@D_EXPONENT_NORMAL", dr(1))
                        sqlquery.Parameters.AddWithValue("@D_EXPONENT_OBSERVED", dr(2))
                        sqlquery.Parameters.AddWithValue("@OVERBURDEN_PRES_GRAD_Psf", dr(3))
                        sqlquery.Parameters.AddWithValue("@NORMAL_PRES_GRAD_Psf", dr(4))
                        sqlquery.Parameters.AddWithValue("@PP_SG", dr(5))

                        Dim pp_mdt As Double = 0.433 * dr(5) * dr(0)
                        sqlquery.Parameters.AddWithValue("@MDT_PP_Psi", pp_mdt)

                        'Ben Eaton
                        Dim bem_psf As Double = dr(3) - (dr(3) - dr(4)) * (dr(2) / dr(1)) ^ 1.2
                        Dim bem_psi As Double = bem_psf * dr(0)
                        Dim bem_err_est As Double = ((bem_psi - pp_mdt) / bem_psi) * 100

                        sqlquery.Parameters.AddWithValue("@BEN_EATON_Psf", bem_psf)
                        sqlquery.Parameters.AddWithValue("@BEN_EATON_Psi", bem_psi)
                        sqlquery.Parameters.AddWithValue("@BEN_EATON_ERROR_EST", bem_err_est)

                        'Nweke Dosunmu
                        Dim nwe_dos_psf As Double = dr(3) - (dr(3) - dr(4)) * (dr(2) / dr(1)) ^ 1
                        Dim nwe_dos_psi As Double = nwe_dos_psf * dr(0)
                        Dim nwe_dos_est As Double = ((nwe_dos_psi - pp_mdt) / nwe_dos_psi) * 100

                        sqlquery.Parameters.AddWithValue("@NWEKE_DOSUMU_Psf", nwe_dos_psf)
                        sqlquery.Parameters.AddWithValue("@NWEKE_DOSUMU_Psi", nwe_dos_psi)
                        sqlquery.Parameters.AddWithValue("@NWEKE_DOSUMU_ERROR_EST", nwe_dos_est)

                        'Rehm and McClendon
                        Dim rehm_mccl_ppg As Double = 7.65 * (Math.Log10(dr(1) - dr(2))) + 16.5
                        Dim rehm_mccl_psi As Double = 0.052 * rehm_mccl_ppg * dr(0)
                        Dim rehm_mccl_err_est As Double = ((rehm_mccl_psi - pp_mdt) / rehm_mccl_psi) * 100

                        sqlquery.Parameters.AddWithValue("@REHM_McCLENDON_Ppg", rehm_mccl_ppg)
                        sqlquery.Parameters.AddWithValue("@REHM_McCLENDON_Psi", rehm_mccl_psi)
                        sqlquery.Parameters.AddWithValue("@REHM_McCLENDON_ERROR_EST", rehm_mccl_err_est)


                        sqlquery.ExecuteNonQuery()
                        sqlconn.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Next

                MessageBox.Show("Data successfully imported")

                'DataGridView1.DataSource = exceldts
                'DataGridView1.DataMember = "[Sheet1$]"
                'excelconn.Close()

            End If
        Else
            getFieldName("No field Name has been entered. " & Chr(13) & Chr(13) & "Enter the field name to proceed")

        End If

        'Create a new table in accessdb with the field name already entered. Check that same table does not already exist

    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        'Reseting the data

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        'Exiting the application

        Dim msgRslt As MsgBoxResult = MsgBox("Are you sure you want to exit the application?.", MsgBoxStyle.YesNo)
        If msgRslt = MsgBoxResult.Yes Then
            'MsgBox("You are welcome to join.")
            Application.Exit()
        ElseIf msgRslt = MsgBoxResult.No Then
            'MsgBox("You must be at least 21 years old to join.")
        End If

    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ToolStripComboBox2_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox2.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        Dim excelconn As OleDbConnection
        Dim exceldtr As OleDbDataReader
        Dim exceldta As OleDbDataAdapter
        Dim excelcmd As OleDbCommand
        Dim exceldts As DataSet
        Dim importexcelsheet As String
        Dim OpenFileDialog As New OpenFileDialog

        If fieldName IsNot vbNullString Then
            computeNwekeDosunmuRegression()     'Compute the regression first

            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"

            MsgBox("Ensure that worksheet contains only depths(ft) that you wish to determine their corresponding pore pressures", MsgBoxStyle.Information)

            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then

                Dim fi As New System.IO.FileInfo(OpenFileDialog.FileName)
                Dim FileName As String = OpenFileDialog.FileName

                importexcelsheet = fi.FullName
                excelconn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + importexcelsheet + ";Extended Properties=Excel 12.0;")
                exceldta = New OleDbDataAdapter("Select * From [Sheet1$]", excelconn)
                exceldts = New DataSet
                exceldta.Fill(exceldts, "[Sheet1$]")

                exceldts.Tables(0).Columns.Add(New DataColumn("Pressure_Psi"))

                For Each dr As DataRow In exceldts.Tables(0).Rows
                    dr(1) = findPressureAtDepth(dr(0))
                Next

                DataGridView1.DataSource = exceldts
                DataGridView1.DataMember = "[Sheet1$]"
                excelconn.Close()

            End If
        Else
            MsgBox("Field name And field data must be supplied first")
        End If

    End Sub

    ' Initialize the form.
    'Public Sub New()

    'MsgBox("You must be at least 21 years old To join.")

    'Me.DataGridView1.Dock = DockStyle.Fill

    'Dim panel As New FlowLayoutPanel()
    'Panel.Dock = DockStyle.Top
    'Panel.AutoSize = True

    'End Sub

    Private Sub drawChart()
        Dim mdt_series, rehm_series, ben_series, nweke_series As New Series

        If fieldName IsNot vbNullString Then

            Try
                mdt_series.Name = "MDT"
                rehm_series.Name = "Rehm & McClendon"
                ben_series.Name = "Ben Eaton"
                nweke_series.Name = "Nweke & Dosunmu"

                'Change to a line graph.
                mdt_series.ChartType = SeriesChartType.Line
                rehm_series.ChartType = SeriesChartType.Line
                ben_series.ChartType = SeriesChartType.Line
                nweke_series.ChartType = SeriesChartType.Line


                MyConn = New OleDbConnection
                MyConn.ConnectionString = connStr
                ds = New DataSet
                tables = ds.Tables
                da = New OleDbDataAdapter("Select TVD_ft, MDT_PP_Psi, REHM_McCLENDON_Psi, BEN_EATON_Psi, NWEKE_DOSUMU_Psi from " & fieldName, MyConn)
                da.Fill(ds, fieldName)

                For Each dr As DataRow In ds.Tables(0).Rows
                    mdt_series.Points.AddXY(dr(0), dr(1))
                    rehm_series.Points.AddXY(dr(0), dr(2))
                    ben_series.Points.AddXY(dr(0), dr(3))
                    nweke_series.Points.AddXY(dr(0), dr(4))
                Next

                Dim view As New DataView(tables(0))
                source1.DataSource = view
                DataGridView1.DataSource = view

                DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                Chart1.Series.Add(mdt_series)
                Chart1.Series.Add(rehm_series)
                Chart1.Series.Add(ben_series)
                Chart1.Series.Add(nweke_series)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Else
            MsgBox("Field name And field data must be supplied first")
        End If

    End Sub

    Private Sub computeNwekeDosunmuRegression()

        MyConn = New OleDbConnection
        MyConn.ConnectionString = connStr
        ds = New DataSet
        tables = ds.Tables
        da = New OleDbDataAdapter("Select TVD_ft, NWEKE_DOSUMU_Psi from " & fieldName, MyConn)
        da.Fill(ds, fieldName)

        Dim totalDepth, totalPressure, meanDepth, meanPressure As Double
        Dim entryCount As Integer
        Dim totalDepthMeanDeviation, totalPressureMeanDeviation, totalDepthPressureDeviationProduct As Double
        Dim totalDepthDeviationSquared, totalPressureDeviationSquared As Double

        entryCount = 0
        totalDepth = 0
        totalPressure = 0
        totalDepthMeanDeviation = 0
        totalPressureMeanDeviation = 0
        totalDepthPressureDeviationProduct = 0
        totalDepthDeviationSquared = 0
        totalPressureDeviationSquared = 0

        For Each dr As DataRow In ds.Tables(0).Rows
            totalDepth += dr(0)
            totalPressure += dr(1)
            entryCount += 1
        Next

        meanDepth = totalDepth / entryCount
        meanPressure = totalPressure / entryCount

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim depthDeviate = dr(0) - meanDepth
            Dim pressDeviate = dr(1) - meanPressure

            totalDepthMeanDeviation += depthDeviate
            totalPressureMeanDeviation += pressDeviate

            totalDepthPressureDeviationProduct += (depthDeviate * pressDeviate)

            totalDepthDeviationSquared += depthDeviate ^ 2
            totalPressureDeviationSquared += pressDeviate ^ 2

        Next

        Dim depthVariance, depthStandardDeviation, pressureVariance, pressureStandardDeviation, rankCorrelation As Double

        depthVariance = totalDepthDeviationSquared / entryCount
        depthStandardDeviation = Math.Sqrt(depthVariance)

        pressureVariance = totalPressureDeviationSquared / entryCount
        pressureStandardDeviation = Math.Sqrt(pressureVariance)

        rankCorrelation = totalDepthPressureDeviationProduct / Math.Sqrt(totalDepthDeviationSquared * totalPressureDeviationSquared)

        fieldSlope = rankCorrelation * pressureStandardDeviation / depthStandardDeviation
        fieldIntercept = meanPressure - (fieldSlope * meanDepth)

        MsgBox("Field Slope:  " & fieldSlope & Chr(13) & "Field Intercept: " & fieldIntercept)

    End Sub

    Function findPressureAtDepth(ByVal mDepth As Double) As Double

        Dim result As Double
        result = fieldSlope * mDepth + fieldIntercept

        findPressureAtDepth = result
    End Function

End Class
