Imports Microsoft.VisualBasic
Imports System
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.PrintServer.Tasks
Imports Seagull.BarTender.PrintServer

Namespace CB.Bartender.Logic
    ''' <summary>
    ''' Example of a custom Task.
    ''' This task will load the requested format, set some substrings on it, then print the label.
    ''' The named substrings are meant to be used with the supplied Address.btw label.
    ''' 
    ''' To write a custom Task, the OnRun method must be overridden from the base class. This
    ''' is the logic that will be run by whichever Print Engine is selected to run the task.
    ''' </summary>
    Public Class PrintTask
        Inherits Task

        Private taskManager As TaskManager
        Private errorString As String
        Public printerName As String
        Public fileName As String
        Private Const appName As String = "CB Warehouse Label Print"
        Private Const dataSourced As String = "Data Sourced"
        Public messageList As List(Of String) = Nothing

        Private engine As Engine = Nothing ' The BarTender Print Engine
        Private format As LabelFormatDocument = Nothing ' The currently open Format
        Private isClosing As Boolean = False ' Set to true if we are closing. This helps discontinue thumbnail loading.



        Public Function StartPrintTask(ByVal _labelFormatFileName As String,
                       ByVal _labelPrinterName As String,
                       ByVal _labelOrderNumber As String,
                       ByVal _lineNumber As String,
                       ByVal _basketNumber As String) As List(Of String)
            Dim v As List(Of String) = Nothing
            Dim messages As Messages = Nothing

            Dim pt As PrintTask()
            'pt.p
            ' pt = New PrintTask(_labelFormatFileName, _labelPrinterName, _labelOrderNumber, _lineNumber, _basketNumber)
            Dim taskMgr As TaskManager = New TaskManager()

            v = messageList
            Return v

        End Function

        Private Sub TaskExecutor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Started
            Dim tm As TaskManager = New TaskManager()
            'AddHandler TaskManager.TaskEngineStatusChanged, AddressOf taskEngines_EngineStatusChanged
            'AddHandler TaskManager.ErrorOccurred, AddressOf taskEngines_ErrorOccurred

            '' Place a set of default Tasks into the available list
            'lstAvailableTasks.Items.Add(Resources.PrintTaskLabel)
            'lstAvailableTasks.Items.Add(Resources.ExportThumbnailLabel)
            'lstAvailableTasks.Items.Add(Resources.ExportPreviewLabel)
            'lstAvailableTasks.Items.Add(Resources.XMLScriptTaskLabel)
            'lstAvailableTasks.Items.Add(Resources.GetFormatTaskLabel)
            'lstAvailableTasks.Items.Add(Resources.GroupTaskLabel)
            'lstAvailableTasks.Items.Add(Resources.CustomTaskLabel)

            'txtNumEngines.MaxLength = 2
        End Sub
        ''' <summary>
        ''' Initialize the LabelFormat object.
        ''' </summary>
        ''' <param name="_labelFormatFileName"></param>
        ''' <param name="_labelPrinterName"></param>
        Public Sub New(ByVal _labelFormatFileName As String,
                       ByVal _labelPrinterName As String,
                       ByVal _labelOrderNumber As String,
                       ByVal _lineNumber As String,
                       ByVal _basketNumber As String)

            Try
                If format IsNot Nothing Then
                    format.Close(SaveOptions.DoNotSaveChanges)
                End If
                format = engine.Documents.Open(_labelFormatFileName, _labelPrinterName)

            Catch comException As System.Runtime.InteropServices.COMException
                ErrorString1 = String.Format("Unable to open format: {0}" & Constants.vbLf & "Reason: {1}", _labelFormatFileName, comException.Message)
                format = Nothing
                My.Application.Log.WriteException(comException,
               TraceEventType.Error,
               ErrorString1 &
               " with message " & comException.Message & ".")
            End Try

        End Sub

        ''' <summary>
        ''' Override this method to perform custom Task logic.
        ''' This sample method writes values to the named substrings on the label and then 
        ''' prints the label.
        ''' </summary>
        ''' <returns></returns>
        Protected Overrides Function OnRun() As Boolean
            Dim formatDoc As LabelFormatDocument = Nothing
            Dim waitForCompletionTimeout As Integer = 10000 ' 10 seconds
            Dim result As Result
            Dim messageString As String = Constants.vbLf + Constants.vbLf & "Messages:"
            Dim results = "Completed nothing"
            Dim v As List(Of String) = Nothing

            Try
                ' Open a LabelFormatDocument using the LabelFormat that was passed in.
                formatDoc = engine.Documents.Open(format, Messages)

                ' Assign this to the member LabelFormat variable so 
                ' it can be accessed after the Task finishes.
                format = formatDoc


                ' Set some substrings on the label
                formatDoc.SubStrings.SetSubString("ProdOrder", "12345")
                formatDoc.SubStrings.SetSubString("LineNumber", "6789")
                formatDoc.SubStrings.SetSubString("Basket", "7777")

                'formatDoc.SubStrings("FirstName").Value = "John"
                'formatDoc.SubStrings("LastName").Value = "Doe"
                'formatDoc.SubStrings("Company").Value = "Acme Widgets"
                'formatDoc.SubStrings("StreetAddress").Value = "1234 Main Street"
                'formatDoc.SubStrings("City").Value = "Bellevue"
                'formatDoc.SubStrings("State").Value = "WA"
                'formatDoc.SubStrings("Zip").Value = "98005"
                'formatDoc.PrintSetup.UseDatabase = False

                ' Print the label
                Dim printMessages As Messages = Nothing
                result = formatDoc.Print(appName + "777", waitForCompletionTimeout, printMessages)

                For Each message As Message In printMessages
                    Messages.Add(message)
                    messageString = message.Text
                    messageList.Add(messageString)
                    'messageString.a
                Next message


                ' Close the LabelFormatDocument to free up resources
                ' in the TaskEngine that was used.
                'formatDoc.Close(SaveOptions.DoNotSaveChanges)
                'result = format.Print(appName, waitForCompletionTimeout, Messages)

                'For Each message As Seagull.BarTender.Print.Message In Messages
                '    messageString &= Constants.vbLf + Constants.vbLf + message.Text
                '    v.Add(messageString)
                'Next message

                'viewModel.PrintMessages = messages

                If result = Result.Failure Then
                    results = "Print Failed" & messageString
                    'MessageBox.Show(Me, "Print Failed" & messageString, appName)
                Else
                    results = "Label was successfully sent to printer." & messageString
                    'MessageBox.Show(Me, "Label was successfully sent to printer." & messageString, appName)
                End If
                v.Add(results)

                '' Print the label
                'Dim printMessages As Messages = Nothing
                'formatDoc.Print("", 1000, printMessages)
                'For Each message As Message In printMessages
                '    Messages.Add(message)
                'Next message

                ' Close the LabelFormatDocument to free up resources
                ' in the TaskEngine that was used.
                formatDoc.Close(SaveOptions.DoNotSaveChanges)
            Catch comException As System.Runtime.InteropServices.COMException
                ErrorString1 = String.Format("Error loading format: {0}" & Constants.vbLf & "Reason: {1}", printerName, comException.Message)
                format = Nothing
                My.Application.Log.WriteException(comException,
               TraceEventType.Error,
               ErrorString1 &
               " with message " & comException.Message & ".")
            Catch
                Try
                    ' Attempt to close if the format is still open.
                    formatDoc.Close(SaveOptions.DoNotSaveChanges)
                Catch e1 As Exception
                End Try
                Throw

            End Try
            Return MyBase.OnRun()
        End Function

        ''' <summary>
        ''' Override this method to validate that this Task's properties are 
        ''' correct when it gets added to the TaskQueue. Typically you would
        ''' throw an exception that you would catch during a
        ''' TaskManager.TaskQueue.QueueTask call.
        ''' </summary>
        Protected Overrides Sub OnValidate()
        End Sub

        ''' <summary>
        ''' Allow access to the LabelFormat used in this Task.
        ''' </summary>
        Private ReadOnly Property LabelFormat() As LabelFormat
            Get
                Return format
            End Get
        End Property

        Public Property ErrorString1 As String
            Get
                Return errorString
            End Get
            Set(value As String)
                errorString = value
            End Set
        End Property
    End Class
End Namespace
