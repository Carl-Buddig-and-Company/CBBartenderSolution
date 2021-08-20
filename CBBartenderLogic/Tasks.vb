Imports System.ComponentModel
Imports System.Threading
Namespace CB.Bartender.Logic


    Public Class Tasks
        Private BackgroundWorker1 As BackgroundWorker
        Private eResults As String

        Private Sub startBackgroundTask()

            BackgroundWorker1 = New BackgroundWorker()
            'BackgroundWorker1.DoWork += New DoWorkEventHandler(BackgroundWorker1_DoWork);
            'BackgroundWorker1.RunWorkerCompleted += New RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);

            ' Execute the Background Task
            BackgroundWorker1.RunWorkerAsync()
        End Sub

        Private Sub kickoff()
            'BackgroundWorker1 = New BackgroundWorker();
            'BackgroundWorker1.DoWork += New DoWorkEventHandler(BackgroundWorker1_DoWork());
            'BackgroundWorker1.RunWorkerCompleted += New RunWorkerCompletedEventHandler(BackgroundWorker1_RunWorkerCompleted);
        End Sub

        Private Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) 'Handles BackgroundWorker1.DoWork
            ' This method will execute in the background thread created by the BackgroundWorker componet
            ' Sleep 2 seconds to emulate getting data.
            Thread.Sleep(2000)
            e.Result = "This text was set safely by BackgroundWorker."
        End Sub

        Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) 'Handles BackgroundWorker1.RunWorkerCompleted
            ' This event fires when the DoWork event completes
            eResults = e.Result.ToString()
        End Sub


    End Class

End Namespace
