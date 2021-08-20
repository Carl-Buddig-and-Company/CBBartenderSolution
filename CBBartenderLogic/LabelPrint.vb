
Imports Seagull.BarTender.Print
'''
''' Label Print Class
''' Author: Brian Kinser
''' Date: 8/13/2020
''' This allows the user to open a format, select a printer, set substrings, and print.
'''
''' This sample is intended to show how to:
'''  -Generate quick thumbnails without first opening a format in BarTender.
'''  -Open a Format in BarTender.
'''  -Get a list of printers and set the printer on a format.
'''  -Set a DataGridView to use the SubStrings collection as a DataSource.
'''  -Get and Set the number of serialized copies and the number of identical copies.
'''  -Start and Stop a BarTender engine.
Namespace CB.Bartender.LabelPrint

    Public Class LabelPrint

#Region "Fields"
        ' Common strings.
        Private Const appName As String = "Label Print"
        Private Const dataSourced As String = "Data Sourced"

        Private engine As Engine = Nothing ' The BarTender Print Engine
        Private format As LabelFormatDocument = Nothing ' The currently open Format
        Private isClosing As Boolean = False ' Set to true if we are closing. This helps discontinue thumbnail loading.

        ' Label browser
        Private browsingFormats() As String ' The list of filenames in the current folder
        Private listItems As Hashtable ' A hash table containing ListViewItems and indexed by format name.
        ' It keeps track of what formats have had their image loaded.
        Private generationQueue As Queue(Of Integer) ' A queue containing indexes into browsingFormats
        ' to facilitate the generation of thumbnails

        ' Label browser indexes.
        Private topIndex As Integer ' The top visible index in the lstLabelBrowser
        Private selectedIndex As Integer ' The selected index in the lstLabelBrowser
#End Region

#Region "Enumerations"
        ' Indexes into our image list for the label browser.
        Private Enum ImageIndex
            LoadingFormatImage = 0
            FailureToLoadFormatImage = 1
        End Enum
#End Region

#Region "Methods"
		''' <summary>
		''' Called when the user opens the program.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub LabelPrint_Load(ByVal sender As Object, ByVal e As EventArgs) 'Handles MyBase.Load
			' Create and start a new BarTender Print Engine.
			Try
				engine = New Engine(True)
			Catch exception As PrintEngineException
				' If the engine is unable to start, a PrintEngineException will be thrown.
				'MessageBox.Show(Me, exception.Message, appName)
				'Me.Close() ' Close this app. We cannot run without connection to an engine.
				Return
			End Try

			' Get the list of printers
			'Dim printers As New Printers()
			'For Each printer As Printer In printers
			'	'cboPrinters.Items.Add(printer.PrinterName)
			'Next printer

			'If printers.Count > 0 Then
			' Automatically select the default printer.
			'cboPrinters.SelectedItem = printers.Default.PrinterName
			'End If

			' Setup the images used in the label browser.
			'lstLabelBrowser.View = View.LargeIcon
			'lstLabelBrowser.LargeImageList = New ImageList()
			'lstLabelBrowser.LargeImageList.ImageSize = New Size(100, 100)
			'lstLabelBrowser.LargeImageList.Images.Add(Resources.LoadingFormat)
			'lstLabelBrowser.LargeImageList.Images.Add(Resources.LoadingError)

			' Initialize a list and a queue.
			listItems = New System.Collections.Hashtable()
			generationQueue = New Queue(Of Integer)()

			' Limit the identical copies and serialized copies to 9
			' to match the user interface behavior of BarTender.
			'txtIdenticalCopies.MaxLength = 9
			'txtSerializedCopies.MaxLength = 9
		End Sub

		''' <summary>
		''' Called when the user presses the open button.
		''' Gets a list of formats in the selected folder.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) 'Handles btnOpen.Click
			'folderBrowserDialog.Description = "Select a folder that contains BarTender formats."
			'Dim result As DialogResult = folderBrowserDialog.ShowDialog()
			'If result = System.Windows.Forms.DialogResult.OK Then
			'	SyncLock generationQueue
			'		generationQueue.Clear()
			'	End SyncLock
			'	listItems.Clear()

			'	txtFolderPath.Text = folderBrowserDialog.SelectedPath
			'	btnPrint.Enabled = False

			'	browsingFormats = System.IO.Directory.GetFiles(txtFolderPath.Text, "*.btw")

			'	' Setting the VirtualListSize will cause lstLabelBrowser_RetrieveVirtualItem to be called.
			'	lstLabelBrowser.VirtualListSize = browsingFormats.Length
			'End If
		End Sub

		''' <summary>
		''' Prints the currently loaded format using the selected printer.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Function printLabel(ByVal sender As Object, ByVal e As EventArgs, ByVal noCopies As Int16, ByVal printerName As String) As String  'Handles btnPrint.Click
			' We lock on the engine here so we don't lose our format object
			' if the user were to click on a format that wouldn't load.
			Dim results = "Completed nothing"
			SyncLock engine
				Dim success As Boolean = True

				' Assign number of identical copies if it is not datasourced.
				If format.PrintSetup.SupportsIdenticalCopies = True Then
					Dim copies As Integer = 1
					success = Int32.TryParse(noCopies, copies) AndAlso (copies >= 1)
					If (Not success) Then
						results = "Identical Copies must be an integer greater than or equal to 1."
						'TODO add error message
						'MessageBox.Show(Me, "Identical Copies must be an integer greater than or equal to 1.", appName)
					Else
						format.PrintSetup.IdenticalCopiesOfLabel = copies
					End If
				End If

				' Assign number of serialized copies if it is not datasourced.
				If success AndAlso (format.PrintSetup.SupportsSerializedLabels = True) Then
					Dim copies As Integer = 1
					success = Int32.TryParse(noCopies, copies) AndAlso (copies >= 1)
					If (Not success) Then
						'MessageBox.Show(Me, "Serialized Copies must be an integer greater than or equal to 1.", appName)
					Else
						format.PrintSetup.NumberOfSerializedLabels = copies
					End If
				End If

				' If there are no incorrect values in the copies boxes then print.
				If success Then
					'Task currentTask = Task.WaitAny(Task(Of Engine)
					'Cursor.Current = Cursors.WaitCursor

					' Get the list of printers

					' Get the printer from the dropdown and assign it to the format.
					If printerName IsNot Nothing Then
						Dim printers As New Printers()
						For Each printer As Printer In printers
							If (printer.PrinterName = printerName) Then
								format.PrintSetup.PrinterName = printerName
							End If
						Next printer

						'format.PrintSetup.PrinterName = printerName ' cboPrinters.SelectedItem.ToString()
					End If

					Dim messages As Messages = Nothing
					Dim waitForCompletionTimeout As Integer = 10000 ' 10 seconds
					Dim result As Result = format.Print(appName, waitForCompletionTimeout, messages)
					Dim messageString As String = Constants.vbLf + Constants.vbLf & "Messages:"

					For Each message As Seagull.BarTender.Print.Message In messages
						messageString &= Constants.vbLf + Constants.vbLf + message.Text
					Next message

					If result = Result.Failure Then
						results = "Print Failed" & messageString
						'MessageBox.Show(Me, "Print Failed" & messageString, appName)
					Else
						results = "Label was successfully sent to printer." & messageString
						'MessageBox.Show(Me, "Label was successfully sent to printer." & messageString, appName)
					End If
				End If
			End SyncLock

			Return results
		End Function

#End Region



	End Class

End Namespace
