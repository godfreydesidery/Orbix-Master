Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmTransactions

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If User.authorize("ACCOUNTS") Then
            frmAllocations.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If User.authorize("ACCOUNTS") Then
            frmGoodsReturnedByCustomers.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If User.authorize("PROCUREMENT") Then
            frmGoodsReceivedNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub frmSupplir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If User.authorize("ACCOUNTS") Then
            frmReceipts.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If User.authorize("ACCOUNTS") Then
            frmQuotations.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If User.authorize("PROCUREMENT") Then
            frmGoodsReturnedNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If User.authorize("ACCOUNTS") Then
            frmSalesLedge.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If User.authorize("ACCOUNTS") Then
            frmSalesJournal.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub btnCustomerCreditNotes_Click(sender As Object, e As EventArgs) Handles btnCustomerCreditNotes.Click

        If User.authorize("ACCOUNTS") Then
            frmCustomerCreditNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        If User.authorize("ACCOUNTS") Then
            frmSupplierCreditNote.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click


        If User.authorize("ACCOUNTS") Then
            frmInvoiceBook.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If User.authorize("SALE INVOICE") Then
            frmSaleInvoice.ShowDialog()
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim appXL As Excel.Application
        Dim wbXl As Excel.Workbook
        Dim shXL As Excel.Worksheet
        Dim raXL As Excel.Range
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True
        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet
        ' Add table headers going cell by cell.
        shXL.Cells(1, 1).Value = "First Name"
        shXL.Cells(1, 2).Value = "Last Name"
        shXL.Cells(1, 3).Value = "Full Name"
        shXL.Cells(1, 4).Value = "Specialization"
        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "D1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        ' Create an array to set multiple values at once.
        Dim students(5, 2) As String
        students(0, 0) = "Zara"
        students(0, 1) = "Ali"
        students(1, 0) = "Nuha"
        students(1, 1) = "Ali"
        students(2, 0) = "Arilia"
        students(2, 1) = "RamKumar"
        students(3, 0) = "Rita"
        students(3, 1) = "Jones"
        students(4, 0) = "Umme"
        students(4, 1) = "Ayman"
        ' Fill A2:B6 with an array of values (First and Last Names).
        shXL.Range("A2", "B6").Value = students
        ' Fill C2:C6 with a relative formula (=A2 & " " & B2).
        raXL = shXL.Range("C2", "C6")
        raXL.Formula = "=A2 & "" "" & B2"
        ' Fill D2:D6 values.
        With shXL
            .Cells(2, 4).Value = "Biology"
            .Cells(3, 4).Value = "Mathmematics"
            .Cells(4, 4).Value = "Physics"
            .Cells(5, 4).Value = "Mathmematics"
            .Cells(6, 4).Value = "Arabic"
        End With
        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "D1")
        raXL.EntireColumn.AutoFit()
        ' Make sure Excel is visible and give the user control
        ' of Excel's lifetime.
        appXL.Visible = True
        appXL.UserControl = True
        ' Release object references.
        raXL = Nothing
        shXL = Nothing
        wbXl = Nothing
        appXL.Quit()
        appXL = Nothing
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub
End Class