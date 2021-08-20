Imports CBBartenderLogic.CB.Bartender.Models
Imports Seagull.BarTender.Print
Imports Seagull.BarTender.PrintServer

Namespace CB.Bartender.Utilities



    Public Class Utilities
        Public Function DisplayPrinters() As List(Of ServerPrinterInfo)
            Dim serverPrintersList As List(Of ServerPrinterInfo) = ServerPrinterInfo.GetServerPrinters()

            'ViewBag.CurrentPage = "DisplayPrinters"
            Return serverPrintersList
        End Function

    End Class

End Namespace