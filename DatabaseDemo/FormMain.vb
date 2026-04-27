Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.OleDb
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace DatabaseDemo

    Public Class FormMain
        Inherits System.Windows.Forms.Form
        Private CONNECTION_STRING As String

        Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
        Private WithEvents btnOpen As System.Windows.Forms.Button
        Private workspaceViewer1 As Atalasoft.Imaging.WinControls.WorkspaceViewer
        Private WithEvents btnSaveToDatabase As System.Windows.Forms.Button
        Private txtCaption As System.Windows.Forms.TextBox
        Private label1 As System.Windows.Forms.Label
        Private WithEvents btnOpenFromDatabase As System.Windows.Forms.Button
        Private WithEvents AboutBtn As System.Windows.Forms.Button
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            'CONNECTION_STRING = "Data Source=; Initial Catalog=; user id=; password=;"
            'CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "images.mdb;User ID=Admin;"
            CONNECTION_STRING = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & System.AppDomain.CurrentDomain.BaseDirectory & "images.mdb;User ID=Admin;"
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.btnOpen = New System.Windows.Forms.Button()
            Me.workspaceViewer1 = New Atalasoft.Imaging.WinControls.WorkspaceViewer()
            Me.btnSaveToDatabase = New System.Windows.Forms.Button()
            Me.txtCaption = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.btnOpenFromDatabase = New System.Windows.Forms.Button()
            Me.AboutBtn = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' btnOpen
            ' 
            Me.btnOpen.Location = New System.Drawing.Point(4, 4)
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.Size = New System.Drawing.Size(88, 23)
            Me.btnOpen.TabIndex = 0
            Me.btnOpen.Text = "Open from File"
            '			Me.btnOpen.Click += New System.EventHandler(Me.btnOpen_Click);
            ' 
            ' workspaceViewer1
            ' 
            Me.workspaceViewer1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.workspaceViewer1.DisplayProfile = Nothing
            Me.workspaceViewer1.Location = New System.Drawing.Point(0, 64)
            Me.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White
            Me.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.workspaceViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.workspaceViewer1.Name = "workspaceViewer1"
            Me.workspaceViewer1.OutputProfile = Nothing
            Me.workspaceViewer1.Selection = Nothing
            Me.workspaceViewer1.Size = New System.Drawing.Size(464, 212)
            Me.workspaceViewer1.TabIndex = 1
            Me.workspaceViewer1.Text = "workspaceViewer1"
            Me.workspaceViewer1.ZoomRectangle = Nothing
            ' 
            ' btnSaveToDatabase
            ' 
            Me.btnSaveToDatabase.Location = New System.Drawing.Point(100, 4)
            Me.btnSaveToDatabase.Name = "btnSaveToDatabase"
            Me.btnSaveToDatabase.Size = New System.Drawing.Size(108, 23)
            Me.btnSaveToDatabase.TabIndex = 2
            Me.btnSaveToDatabase.Text = "Save To Database"
            '			Me.btnSaveToDatabase.Click += New System.EventHandler(Me.btnSaveToDatabase_Click);
            ' 
            ' txtCaption
            ' 
            Me.txtCaption.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.txtCaption.Location = New System.Drawing.Point(56, 32)
            Me.txtCaption.Name = "txtCaption"
            Me.txtCaption.Size = New System.Drawing.Size(400, 20)
            Me.txtCaption.TabIndex = 3
            Me.txtCaption.Text = ""
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(4, 36)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(46, 16)
            Me.label1.TabIndex = 4
            Me.label1.Text = "Caption:"
            ' 
            ' btnOpenFromDatabase
            ' 
            Me.btnOpenFromDatabase.Location = New System.Drawing.Point(216, 4)
            Me.btnOpenFromDatabase.Name = "btnOpenFromDatabase"
            Me.btnOpenFromDatabase.Size = New System.Drawing.Size(128, 23)
            Me.btnOpenFromDatabase.TabIndex = 5
            Me.btnOpenFromDatabase.Text = "Open From Database"
            '			Me.btnOpenFromDatabase.Click += New System.EventHandler(Me.btnOpenFromDatabase_Click);
            ' 
            ' AboutBtn
            ' 
            Me.AboutBtn.Location = New System.Drawing.Point(352, 3)
            Me.AboutBtn.Name = "AboutBtn"
            Me.AboutBtn.Size = New System.Drawing.Size(104, 24)
            Me.AboutBtn.TabIndex = 6
            Me.AboutBtn.Text = "About ..."
            '			Me.AboutBtn.Click += New System.EventHandler(Me.AboutBtn_Click);
            ' 
            ' FormMain
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(464, 278)
            Me.Controls.Add(Me.AboutBtn)
            Me.Controls.Add(Me.btnOpenFromDatabase)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.txtCaption)
            Me.Controls.Add(Me.btnSaveToDatabase)
            Me.Controls.Add(Me.workspaceViewer1)
            Me.Controls.Add(Me.btnOpen)
            Me.Name = "FormMain"
            Me.Text = "Database Demo"
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()> _
        Shared Sub Main()
            Application.Run(New FormMain())
        End Sub

        Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpen.Click
            Me.openFileDialog1.Filter = HelperMethods.CreateDialogFilter(True)
            If Me.openFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                Me.workspaceViewer1.Open(openFileDialog1.FileName)
            End If
        End Sub

        Private Sub btnSaveToDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveToDatabase.Click
            Try
                'SaveToSqlDatabase(workspaceViewer1.Image);
                SaveToOleDatabase(workspaceViewer1.Image)
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End Sub

        Private Sub SaveToSqlDatabase(ByVal image As AtalaImage)
            Dim myConnection As SqlConnection = Nothing
            Try
                'save image to byte array and allocate enough memory for the image
                Dim imagedata As Byte() = image.ToByteArray(New Atalasoft.Imaging.Codec.JpegEncoder(75))

                'create the SQL statement to add the image data
                myConnection = New SqlConnection(CONNECTION_STRING)
                Dim myCommand As SqlCommand = New SqlCommand("INSERT INTO Atalasoft_Image_Database (Caption, ImageData) VALUES ('" & txtCaption.Text & "', @Image)", myConnection)
                Dim myParameter As SqlParameter = New SqlParameter("@Image", SqlDbType.Image, imagedata.Length)
                myParameter.Value = imagedata
                myCommand.Parameters.Add(myParameter)

                'open the connection and execture the statement
                myConnection.Open()
                myCommand.ExecuteNonQuery()
            Finally
                myConnection.Close()
            End Try
        End Sub

        Private Sub SaveToOleDatabase(ByVal image As AtalaImage)
            Dim myConnection As OleDbConnection = Nothing
            Try
                'save image to byte array and allocate enough memory for the image
                Dim imagedata As Byte() = image.ToByteArray(New Atalasoft.Imaging.Codec.JpegEncoder(75))

                'create the SQL statement to add the image data
                myConnection = New OleDbConnection(CONNECTION_STRING)
                Dim myCommand As OleDbCommand = New OleDbCommand("INSERT INTO Atalasoft_Image_Database (Caption, ImageData) VALUES ('" & txtCaption.Text & "', ?)", myConnection)
                Dim myParameter As OleDbParameter = New OleDbParameter("@Image", OleDbType.LongVarBinary, imagedata.Length)
                myParameter.Value = imagedata
                myCommand.Parameters.Add(myParameter)

                'open the connection and execture the statement
                myConnection.Open()
                myCommand.ExecuteNonQuery()
            Finally
                myConnection.Close()
            End Try
        End Sub

        Private Sub btnOpenFromDatabase_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOpenFromDatabase.Click
            Try
                'workspaceViewer1.Image = OpenFromSqlDatabase();
                workspaceViewer1.Image = OpenFromOleDatabase()
            Catch err As Exception
                MessageBox.Show(err.Message)
            End Try
        End Sub

        Private Function OpenFromSqlDatabase() As AtalaImage
            Dim myConnection As SqlConnection = Nothing
            Try
                'establish connection and SELECT statement
                myConnection = New SqlConnection(CONNECTION_STRING)
                Dim myCommand As SqlCommand = New SqlCommand("SELECT ImageData FROM Atalasoft_Image_Database WHERE Caption = '" & txtCaption.Text & "'", myConnection)
                myConnection.Open()

                'get the image from the database
                Dim imagedata As Byte() = CType(myCommand.ExecuteScalar(), Byte())
                If Not imagedata Is Nothing Then
                    Return AtalaImage.FromByteArray(imagedata)
                Else
                    MessageBox.Show("Image does not exist in database.")
                    Return Nothing
                End If
            Finally
                myConnection.Close()
            End Try
        End Function

        Private Function OpenFromOleDatabase() As AtalaImage
            Dim myConnection As OleDbConnection = Nothing
            Try
                'establish connection and SELECT statement
                myConnection = New OleDbConnection(CONNECTION_STRING)
                Dim myCommand As OleDbCommand = New OleDbCommand("SELECT ImageData FROM [Atalasoft_Image_Database] WHERE Caption = '" & txtCaption.Text & "'", myConnection)
                myConnection.Open()

                'get the image from the database
                Dim imagedata As Byte() = CType(myCommand.ExecuteScalar(), Byte())
                If Not imagedata Is Nothing Then
                    Return AtalaImage.FromByteArray(imagedata)
                Else
                    MessageBox.Show("Image does not exist in database.")
                    Return Nothing
                End If

            Finally
                myConnection.Close()
            End Try
        End Function

        Private Sub AboutBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AboutBtn.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft DotImage Database Demo", "DotImage Database Demo")
            aboutBox.Description = "Demonstrates how to open an image from a database and save it back.  There is a sample MS Access database included.  The source code for this demo shows this functionality with an OLE database and can be easily modified to work with other data sources such as SQL."
            aboutBox.ShowDialog()
        End Sub
    End Class
End Namespace
