Imports System.Data
Imports System.Data.SqlClient

Module DatabaseLibMgmtSys
    Public conn As SqlConnection

    Public Function GetConnect()
        conn = New SqlConnection("Data Source=DESKTOP-03IS95H;Initial Catalog=LibMgmtSys;Integrated Security=True")
        Return conn
    End Function
End Module
