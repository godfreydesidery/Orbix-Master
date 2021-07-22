Public Class Priveledge

    Public Property id As String
    Public Property name As String
    Public Property role As Role = New Role

    Public Shared PRIVELEDGES = New String() {
        "PRODUCT MANAGEMENT",
        "PRODUCT INQUIRY",
        "EDIT INVENTORY",
        "COMPANY MANAGEMENT",
        "SUPPLIER MANAGEMENT",
        "PROCUREMENT",
        "VIEW REPORTS",
        "ACCOUNTS",
        "END DAY",
        "USER MANAGEMENT",
        "TILL MANAGEMENT",
        "ACCESS MANAGEMENT",
        "FLOAT MANAGEMENT",
        "CASH PICK UP",
        "PETTY CASH MANAGEMENT",
        "SELLING",
        "VOID",
        "DISCOUNT",
        "SPECIAL",
        "ADMIN",
        "APPROVE LPO",
        "EDIT LPO",
        "SALE INVOICE",
        "CUSTOM DATING"
    }
End Class
