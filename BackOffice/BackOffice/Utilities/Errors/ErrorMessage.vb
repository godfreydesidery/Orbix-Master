Public Class ErrorMessage
    Public Shared Function dbConnectionError()
        MsgBox("Could not connect to database", vbCritical + vbOKOnly, "Error: Database")
        Return vbNull
    End Function

End Class
