Imports System.Data.OleDb

Public Class Form1
    'Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin;Jet OLEDB:Database Password=password"
    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\porepressurepredictor.accdb;User ID=admin;Jet OLEDB:Database Password=password"
    Dim MyConn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim tables As DataTableCollection
    Dim source1 As New BindingSource

    Dim dbPath = Environment.GetEnvironmentVariable("APPDATA")
    'Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) '& "\CreatedFolder\Resources\DatabaseFile.accdb"

    Public dbPathAccess As String = Application.StartupPath & "\porepressurepredictor.accdb"
    Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbPathAccess

    Dim fieldName As String

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If e.Action = TreeViewAction.ByMouse Then
            If e.Node.Text.Equals("Rehm and McClendon") Then
                MsgBox("Rehm And McClendon clicked", MsgBoxStyle.OkOnly, "Information")
            End If

            If e.Node.Text.Equals("Ben Eaton") Then
                'MsgBox("Ben Eaton", MsgBoxStyle.OkOnly, "Information")
                MsgBox(dbPathAccess, MsgBoxStyle.OkOnly, "Information")
            End If

            If e.Node.Text.Equals("Nweke and Dosunmu") Then
                MsgBox("Nweke and Dosunmu", MsgBoxStyle.OkOnly, "Information")
            End If

            If e.Node.Text.Equals("Abnormal Pore Pressure") Then
                MsgBox("Abnormal Pore Pressure", MsgBoxStyle.OkOnly, "Information")
            End If

            If e.Node.Text.Equals("Chart") Then
                MsgBox("Chart", MsgBoxStyle.OkOnly, "Information")
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
        da = New OleDbDataAdapter("Select TVD, D_EXP_NORMAL, D_EXP_OBSERVED, OVERBURDEN_PRES_GRAD, NORMAL_PRES_GRAD, MDT_PORE_PRES from SampleData1", MyConn) 'Change items to your database name
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
        'creating new field name
        Dim message, title, defaultValue As String
        ' Set prompt.
        message = "Enter the field name"
        ' Set title.
        title = "Field Name"
        defaultValue = fieldName   ' Set default value.

        ' Display message, title, and default value. Display dialog box at position 400, 200.
        fieldName = InputBox(message, title, defaultValue, 400, 200)
        ' If user has clicked Cancel, set myValue to defaultValue 
        If fieldName Is "" Then fieldName = defaultValue

        ToolStripStatusLabel2.Text = fieldName
    End Sub

    Private Sub ImportDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDataToolStripMenuItem.Click
        'Importing data from excel

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

    ' Initialize the form.
    'Public Sub New()

    'MsgBox("You must be at least 21 years old to join.")

    'Me.DataGridView1.Dock = DockStyle.Fill

    'Dim panel As New FlowLayoutPanel()
    'Panel.Dock = DockStyle.Top
    'Panel.AutoSize = True

    'End Sub
End Class
