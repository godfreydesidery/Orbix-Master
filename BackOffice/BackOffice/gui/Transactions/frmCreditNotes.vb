Imports Devart.Data.MySql

Public Class frmCreditNotes
    Private Function lock()
        txtBillNo.ReadOnly = True
        txtCrDate.ReadOnly = True
        txtCrNo.ReadOnly = True
        txtCrDetails.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtBillNo.ReadOnly = False
        txtCrDate.ReadOnly = False
        txtCrNo.ReadOnly = False
        txtCrDetails.ReadOnly = False
        Return vbNull
    End Function
    Private Function clear()
        txtBillNo.Text = ""
        txtCrDate.Text = ""
        txtCrNo.Text = ""
        txtCrDetails.Text = ""
        cmbCreditor.Text = ""
        cmbType.Text = ""
        cmbStatus.Text = ""
        txtAmount.Text = ""
        Return vbNull
    End Function
    Dim EDIT_MODE As String = ""
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        clear()
        btnDelete.Enabled = False
        btnEdit.Enabled = False
        EDIT_MODE = "NEW"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        unlock()
        txtCrNo.ReadOnly = True
        btnDelete.Enabled = True
        btnSave.Enabled = True
        EDIT_MODE = ""
    End Sub
    Private Function updateCreditNote() As Boolean
        Dim success As Boolean = False
        Dim crNote As New CreditNote
        Dim totalAmount As Double = 0
        For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
            totalAmount = totalAmount + Val(LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value))
        Next
        txtCrDate.Text = Day.DAY
        crNote.updateCreditNote(txtCrNo.Text, txtBillNo.Text, cmbCreditor.Text, cmbType.Text, cmbStatus.Text, LCurrency.getValue(txtAmount.Text), txtCrDetails.Text)
        For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
            Dim itemCode As String = dtgrdCrNoteList.Item(0, i).Value.ToString
            Dim description As String = dtgrdCrNoteList.Item(1, i).Value.ToString
            Dim qty As String = dtgrdCrNoteList.Item(2, i).Value.ToString
            Dim price As String = LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value.ToString)
            Dim amount As String = LCurrency.getValue(dtgrdCrNoteList.Item(4, i).Value.ToString)

            crNote.updateCreditNoteParticulars(txtCrNo.Text, itemCode, price, qty)
        Next
        Return success
    End Function
    Private Function createNewCreditNote() As Boolean
        Dim success As Boolean = False
        Dim crNote As New CreditNote
        Dim totalAmount As Double = 0
        For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
            totalAmount = totalAmount + Val(LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value))
        Next
        Dim crNo As String = ""
        txtCrDate.Text = Day.DAY
        While True
            crNo = crNote.createCreditNote(txtBillNo.Text, cmbType.Text, cmbCreditor.Text, cmbStatus.Text, txtCrDetails.Text, txtCrDate.Text, totalAmount.ToString)
            If crNo <> "" Then
                success = True
                Exit While
            End If
        End While
        txtCrNo.Text = crNo
        For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
            Dim itemCode As String = dtgrdCrNoteList.Item(0, i).Value.ToString
            Dim description As String = dtgrdCrNoteList.Item(1, i).Value.ToString
            Dim qty As String = dtgrdCrNoteList.Item(2, i).Value.ToString
            Dim price As String = LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value.ToString)
            Dim amount As String = LCurrency.getValue(dtgrdCrNoteList.Item(4, i).Value.ToString)
            crNote.createCreditNoteParticulars(crNo, itemCode, price, qty)
        Next
        Return success
    End Function
    Private Function searchCrNote(crNoteNo As String, billNo As String) As String
        dtgrdCrNoteList.Rows.Clear()
        Dim crNo As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            If crNoteNo <> "" And billNo = "" Then
                query = "SELECT `cr_note_no`, `cr_note_bill_no`, `sr_note_creditor`, `cr_note_type`, `cr_note_status`, `cr_note_description`, `cr_note_date`, `credit_amount` FROM `credit_notes` WHERE `cr_note_no`='" + crNoteNo + "'"
            ElseIf crNoteNo <> "" And billNo <> "" Then
                query = "SELECT `cr_note_no`, `cr_note_bill_no`, `sr_note_creditor`, `cr_note_type`, `cr_note_status`, `cr_note_description`, `cr_note_date`, `credit_amount`FROM `credit_notes` WHERE `cr_note_no`='" + crNoteNo + "' AND `cr_note_bill_no`='" + billNo + "'"
            ElseIf crNoteNo = "" And billNo <> "" Then
                query = "SELECT `cr_note_no`, `cr_note_bill_no`, `sr_note_creditor`, `cr_note_type`, `cr_note_status`, `cr_note_description`, `cr_note_date`, `credit_amount` FROM `credit_notes` WHERE `cr_note_bill_no`='" + billNo + "'"
            Else
                Return crNo
                Exit Function
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtCrNo.Text = reader.GetString("cr_note_no")
                txtBillNo.Text = reader.GetString("cr_note_bill_no")
                txtCrDate.Text = reader.GetString("cr_note_date")
                cmbCreditor.Text = reader.GetString("sr_note_creditor")
                cmbType.Text = reader.GetString("cr_note_type")
                cmbStatus.Text = reader.GetString("cr_note_status")
                txtCrDetails.Text = reader.GetString("cr_note_description")
                txtAmount.Text = LCurrency.displayValue(reader.GetString("credit_amount"))
                crNo = reader.GetString("cr_note_no")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            crNo = ""
            MsgBox(ex.Message)
        End Try
        Return crNo
    End Function
    Private Function getParticulars(crNoteNo As String)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `cr_note_no`, `item_code`, `qty`, `price` FROM `credit_note_particulars` WHERE `cr_note_no`='" + crNoteNo + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim itemCode As String = ""
            Dim qty As String = ""
            Dim price As String = ""
            Dim amount As String = ""
            Dim description As String = ""

            While reader.Read

                itemCode = reader.GetString("item_code")
                qty = reader.GetString("qty")
                price = reader.GetString("price")
                amount = (Val(qty) * Val(price)).ToString
                description = (New Item).getItemLongDescription(itemCode)

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = itemCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = description
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = qty
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(price)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(amount)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCrNoteList.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Function search()
        Dim found As Boolean = False
        Dim crNoteNo As String = searchCrNote(txtCrNo.Text, txtBillNo.Text)
        If crNoteNo <> "" Then
            getParticulars(crNoteNo)
            lock()
            btnDelete.Enabled = False
            btnSave.Enabled = False
            found = True
        End If
        Return found
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If search() <> True Then
            MsgBox("No matching record")
            Exit Sub
        End If
        btnEdit.Enabled = True
    End Sub
    Private Function refreshList()
        For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
            Dim amount As Double = 0
            Dim price As Double = 0
            Dim qty As Double = 0
            price = Val(LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value.ToString))
            qty = Val(LCurrency.getValue(dtgrdCrNoteList.Item(2, i).Value.ToString))
            amount = price * qty
            dtgrdCrNoteList.Item(4, i).Value = LCurrency.displayValue(amount.ToString)
        Next
        Return vbNull
    End Function
    Private Sub dtgrdCrNoteList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdCrNoteList.CellContentClick

    End Sub

    Private Sub frmCreditNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub cmbCreditor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCreditor.SelectedIndexChanged

    End Sub
    Private Function deleteCreditNote(crNo As String) As Boolean

        Return vbNull
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        search()
        Dim crNote As New CreditNote
        crNote.deleteCreditNote(txtCrNo.Text)
        clear()
    End Sub
    Private Function validateFields() As Boolean
        Dim valid As Boolean = True
        If txtBillNo.Text = "" Then
            valid = False
        End If
        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If EDIT_MODE = "NEW" Then
            txtCrNo.Text = ""
            If validateFields() <> True Then
                MsgBox("Invalid entries", vbOKOnly + vbCritical, "Error: Invalid entries")
                Exit Sub
            End If
            If createNewCreditNote() = True Then
                MsgBox("New credit note created", vbOKOnly + vbInformation, "Success")
                searchCrNote(txtCrNo.Text, "")
                EDIT_MODE = ""
            End If
        Else
            If validateFields() <> True Then
                MsgBox("Invalid entries", vbOKOnly + vbCritical, "Error: Invalid entries")
                Exit Sub
            End If
            If updateCreditNote() = True Then
                MsgBox("Credit note updated", vbOKOnly + vbInformation, "Success")
                searchCrNote(txtCrNo.Text, "")
                EDIT_MODE = ""
            End If
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStatus.SelectedIndexChanged

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub
End Class