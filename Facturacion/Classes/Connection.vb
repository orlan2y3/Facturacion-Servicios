Imports System.Data.OleDb
Public Class Connection
    Public CadenaConnection As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\Database.mdb" _
                                                           & ";Jet OLEDB:Database Password=cladatos-ao;"

    Public Cnn As OleDbConnection = New OleDbConnection(CadenaConnection)

    Sub Conectar()
        Cnn.Open()
    End Sub

    Sub Desconectar()
        Cnn.Close()
    End Sub

End Class
