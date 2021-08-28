﻿Public Class frmPayPoint
    Public Shared cashReceived As Double = 0
    Public Shared balance As Double = 0

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim amount As Double = txtTotal.Text
        If Val(txtBalance.Text) >= 0 Then
            ' Dim confirm As Integer = MessageBox.Show("Total amount payable is " + LCurrency.displayValue(amount.ToString) + ". Confirm payment?", "Confirm payment", MessageBoxButtons.YesNo)
            Dim confirm As Integer = MsgBox("Total amount payable is " + LCurrency.displayValue(amount.ToString) + ". Confirm payment?", vbQuestion + vbYesNo, "Confirm Payment: " + LCurrency.displayValue(amount.ToString))
            If confirm = DialogResult.Yes Then
                cashReceived = LCurrency.displayValue(txtAmountReceived.Text)
                balance = LCurrency.displayValue(txtBalance.Text)
                'commit payment
                cash = Val(txtCash.Text) - Val(LCurrency.getValue(txtBalance.Text))
                voucher = Val(txtVoucher.Text)
                deposit = Val(txtDeposit.Text)
                loyalty = Val(txtLoyalty.Text)
                CRCard = Val(txtCRCard.Text)
                CAP = Val(txtCAP.Text)
                invoice = Val(txtInvoice.Text)
                CRNote = Val(txtCRNote.Text)
                mobile = Val(txtMobile.Text)
                cheque = Val(txtCheque.Text)
                Payment.setPayment(cash, voucher, deposit, loyalty, CRCard, CAP, invoice, CRNote, mobile)

                'till register
                'Till.tillTotalRegister(Till.TILLNO, cash, voucher, cheque, deposit, loyalty, CRCard, CAP, invoice, CRNote, mobile)
                Me.Dispose()
            Else
                'dont commit payment
            End If
        Else
            MsgBox("Could not process payment. Insufficient funds", vbExclamation + vbOKOnly, "Error: Insufficient funds")
        End If

    End Sub
    Public Shared cash As Double = 0
    Public Shared voucher As Double = 0
    Public Shared deposit As Double = 0
    Public Shared loyalty As Double = 0
    Public Shared CRCard As Double = 0
    Public Shared CAP As Double = 0
    Public Shared invoice As Double = 0
    Public Shared CRNote As Double = 0
    Public Shared mobile As Double = 0
    Public Shared cheque As Double = 0
    Public Shared other As Double = 0

    Public Shared Function updateTill()
        SaleSequence.seqNo = SaleSequence.seqNo + 1
        Till.tillTotalRegister(Till.TILLNO, cash, voucher, cheque, deposit, loyalty, CRCard, CAP, invoice, CRNote, mobile)
        Return vbNull
    End Function

    Private Function recordSale(saleId As String)
        'sql for recording sale with the specified id

        Return vbNull

    End Function


    Private Function calculateTotal()
        Dim totalAmount As Double = Val(Replace(txtTotal.Text, ",", ""))
        Dim totalReceived As Double = 0
        Dim balance As Double
        Dim cash As Double, voucher As Double, cheque As Double, deposit As Double, loyalty As Double, CRCard As Double, CAP As Double, invoice As Double, CRNote As Double, mobile As Double

        cash = Val(txtCash.Text)
        voucher = Val(txtVoucher.Text)
        cheque = Val(txtCheque.Text)
        deposit = Val(txtDeposit.Text)
        loyalty = Val(txtLoyalty.Text)
        CRCard = Val(txtCRCard.Text)
        CAP = Val(txtCAP.Text)
        invoice = Val(txtInvoice.Text)
        CRNote = Val(txtCRNote.Text)
        mobile = Val(txtMobile.Text)

        totalReceived = cash + voucher + cheque + deposit + loyalty + CRCard + CAP + invoice + CRNote + mobile
        txtAmountReceived.Text = FormatNumber(totalReceived.ToString, 2, , , TriState.True)
        balance = totalReceived - totalAmount
        txtBalance.Text = FormatNumber(balance.ToString, 2, , , TriState.True)
        Return vbNull
    End Function

    Private Sub txtCash_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCash.KeyUp
        'use the plus equal key
        If e.KeyCode = Keys.Oemplus Then
            clearAll()
            txtCash.Text = LCurrency.getValue(txtTotal.Text)
        End If
    End Sub

    Private Sub txtCash_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles txtCash.MouseDoubleClick
        clearAll()
        txtCash.Text = LCurrency.getValue(txtTotal.Text)
    End Sub
    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        If validateInput(txtCash.Text) = False Then
            txtCash.Text = ""
        End If

        calculateTotal()
    End Sub

    Private Sub txtVoucher_TextChanged(sender As Object, e As EventArgs) Handles txtVoucher.TextChanged
        If validateInput(txtVoucher.Text) = False Then
            txtVoucher.Text = ""
        End If
        calculateTotal()

    End Sub

    Private Sub txtDeposit_TextChanged(sender As Object, e As EventArgs) Handles txtDeposit.TextChanged
        If validateInput(txtDeposit.Text) = False Then
            txtDeposit.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtLoyalty_TextChanged(sender As Object, e As EventArgs) Handles txtLoyalty.TextChanged
        If validateInput(txtLoyalty.Text) = False Then
            txtLoyalty.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtCRCard_TextChanged(sender As Object, e As EventArgs) Handles txtCRCard.TextChanged
        If validateInput(txtCRCard.Text) = False Then
            txtCRCard.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtCAP_TextChanged(sender As Object, e As EventArgs) Handles txtCAP.TextChanged
        If validateInput(txtCAP.Text) = False Then
            txtCAP.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtInvoice_TextChanged(sender As Object, e As EventArgs) Handles txtInvoice.TextChanged
        If validateInput(txtInvoice.Text) = False Then
            txtInvoice.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtCRNote_TextChanged(sender As Object, e As EventArgs) Handles txtCRNote.TextChanged
        If validateInput(txtCRNote.Text) = False Then
            txtCRNote.Text = ""
        End If
        calculateTotal()
    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged
        If validateInput(txtMobile.Text) = False Then
            txtMobile.Text = ""
        End If
        calculateTotal()
    End Sub
    Private Function clearAll()
        'clears all the fields
        txtCash.Text = ""
        txtVoucher.Text = ""
        txtDeposit.Text = ""
        txtLoyalty.Text = ""
        txtCRCard.Text = ""
        txtCAP.Text = ""
        txtInvoice.Text = ""
        txtCRNote.Text = ""
        txtMobile.Text = ""

        Return vbNull
    End Function
    Private Function validateInput(input As String)
        Dim number As Double = 0
        Dim valid As Boolean = False
        If IsNumeric(input) = True Then
            valid = True
        End If
        Return valid
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        clearAll()
    End Sub

    Private Sub txtBalance_TextChanged(sender As Object, e As EventArgs) Handles txtBalance.TextChanged
        If Val(txtBalance.Text) < 0 Then
            txtValidBalance.Text = "Invalid Balance Value!"
        Else
            txtValidBalance.Text = ""
        End If
    End Sub

    Private Sub frmPayPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        clearAll()

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 6

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 6
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        calculateTotal()
        txtCash.Focus()
    End Sub

    Private Sub btnEq_Click(sender As Object, e As EventArgs)
        clearAll()
        txtCash.Text = LCurrency.getValue(txtTotal.Text)
    End Sub

    Private Sub txtSaleId_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtCRNote_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCRNote.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCRNote.Text = (New CRNote).getCreditNoteNo(txtCRNote.Text).ToString
        End If
    End Sub

    Private Sub txtValidBalance_TextChanged(sender As Object, e As EventArgs) Handles txtValidBalance.TextChanged

    End Sub
    Dim MODE As String = ""
    Protected Overridable Function place(key As String)

        Try
            If MODE = "CASH" Then
                txtCash.Focus()
                txtCash.SelectionStart = txtCash.Text.Length
                txtCash.SelectionLength = 0
                SendKeys.Send(key)
            End If
        Catch ex As Exception

        End Try
        'Try
        '    Dim row As Integer = dtgrdViewItemList.CurrentCell.RowIndex
        '    Dim col As Integer = dtgrdViewItemList.CurrentCell.ColumnIndex
        '    If dtgrdViewItemList.CurrentCell.ColumnIndex = 0 Or dtgrdViewItemList.CurrentCell.ColumnIndex = 7 Then

        '        dtgrdViewItemList.Select()
        '        dtgrdViewItemList.CurrentCell = dtgrdViewItemList.Item(col, row)
        '        Dim control As TextBox = DirectCast(dtgrdViewItemList.EditingControl, TextBox)
        '        control.SelectionStart = dtgrdViewItemList.CurrentCell.Value.ToString.Length
        '        control.SelectionLength = 0
        '        SendKeys.Send(key)
        '    Else
        '        dtgrdViewItemList.Select()
        '        dtgrdViewItemList.CurrentCell = dtgrdViewItemList.Item(col, row)
        '        SendKeys.Send(key)
        '    End If
        'Catch ex As Exception
        '    Try
        '        SendKeys.Send(key)
        '    Catch ex2 As Exception

        '    End Try

        'End Try
        Return vbNull
    End Function

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        place("1")
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        place("2")
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        place("3")
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        place("4")
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        place("5")
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        place("6")
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        place("7")
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        place("8")
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        place("9")
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        place("0")
    End Sub

    Private Sub btnDot_Click(sender As Object, e As EventArgs) Handles btnDot.Click
        place(".")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        place("{BACKSPACE}")
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        place("~") 'the enter key  ENTER for numeric keypad
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        place("{UP}")
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        place("{LEFT}")
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        place("{RIGHT}")
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        place("{DOWN}")
    End Sub

    Private Sub txtCash_GotFocus(sender As Object, e As EventArgs) Handles txtCash.GotFocus
        MODE = "CASH"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearAll()
        txtCash.Text = LCurrency.getValue(txtTotal.Text)
    End Sub
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub startOSK()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start(osk)
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start(osk)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        startOSK()
    End Sub
End Class