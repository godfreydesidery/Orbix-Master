Imports Devart.Data.MySql

Public Class frmSupplierCreditNote
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function searchCrNote(crNoteNo As String) As String
        dtgrdCrNoteList.Rows.Clear()
        Dim crNo As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = "SELECT `cr_no`, `cr_date`, `cr_order_no`, `cr_amount`, `status`, `cr_details` FROM `supplier_credit_notes` WHERE `cr_no`='" + crNoteNo + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtCrNo.Text = reader.GetString("cr_no")
                txtOrderNo.Text = reader.GetString("cr_order_no")
                txtCrDate.Text = reader.GetString("cr_date")
                txtCrDetails.Text = reader.GetString("cr_details")
                txtCrAmount.Text = LCurrency.displayValue(reader.GetString("cr_amount"))
                txtCrStatus.Text = reader.GetString("status")

                crNo = reader.GetString("cr_no")
                Exit While
                lock()
            End While
            conn.Close()
        Catch ex As Exception
            crNo = ""
            MsgBox(ex.Message)
        End Try
        Return crNo
    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub frmCustomerCreditNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        dtgrdCrNoteList.Rows.Clear()
    End Sub
    Private Function lock()
        txtCrNo.ReadOnly = True
        txtOrderNo.ReadOnly = True
        txtCrDate.ReadOnly = True
        txtCrAmount.ReadOnly = True
        txtCrStatus.ReadOnly = True
        txtCrDetails.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        txtCrNo.ReadOnly = False
        txtOrderNo.ReadOnly = False
        txtCrDate.ReadOnly = False
        txtCrAmount.ReadOnly = False
        txtCrStatus.ReadOnly = False
        txtCrDetails.ReadOnly = False
        Return vbNull
    End Function
    Private Function clear()
        txtCrNo.Text = ""
        txtOrderNo.Text = ""
        txtCrDate.Text = ""
        txtCrAmount.Text = ""
        txtCrStatus.Text = ""
        txtCrDetails.Text = ""
        Return vbNull
    End Function

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub
    Private Function search()
        Dim crNo As String = searchCrNote(txtCrNo.Text)
        If crNo <> "" Then
            getParticulars(crNo)
            btnDelete.Enabled = False
            btnSave.Enabled = False
            lock()
        Else
            MsgBox("Could not find a matching credit note", vbOKOnly + vbCritical, "Error: Not found")
        End If
        Return vbNull
    End Function
    Private Sub txtCrNo_KeyPreview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtCrNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search()
        End If
    End Sub
    Dim EDIT_MODE As String = ""
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        EDIT_MODE = "NEW"
        unlock()
        clear()
        txtCrNo.ReadOnly = True
        txtCrDate.ReadOnly = True
        txtCrStatus.ReadOnly = True
        btnDelete.Enabled = False
        btnSave.Enabled = True
        txtCrDate.Text = Day.DAY
        dtgrdCrNoteList.Rows.Clear()
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        EDIT_MODE = ""
        lock()
        txtOrderNo.ReadOnly = False
        txtCrAmount.ReadOnly = False
        txtCrDetails.ReadOnly = False
        btnDelete.Enabled = True
        btnSave.Enabled = True

        If txtCrNo.Text = "" Then
            clear()
            unlock()
            btnSave.Enabled = False
            btnDelete.Enabled = False
        End If
    End Sub
    Private Function validateFields() As Boolean
        Dim valid As Boolean = True
        If Val(txtCrAmount.Text) <= 0 Then
            valid = False
        End If
        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validateFields() = False Then
            MsgBox("Invalid credit value. Pease enter a valid credit amount", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        Dim crNote As New CreditNote
        If EDIT_MODE = "NEW" Then
            'save new credit note
            Dim crNo As String = ""
            While True
                crNo = crNote.createSupplierCreditNote(txtCrDate.Text, txtOrderNo.Text, txtCrAmount.Text, "ADJUST DUE", txtCrDetails.Text)
                If crNo <> "" Then
                    Exit While
                End If
            End While
            ''create cr particulars
            For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
                Dim itemCode As String = dtgrdCrNoteList.Item(0, i).Value.ToString
                Dim qty As String = dtgrdCrNoteList.Item(2, i).Value.ToString
                Dim price As String = LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value.ToString)
                crNote.createCreditNoteParticulars(crNo, itemCode, price, qty)
            Next
            txtCrNo.Text = crNo
            MsgBox("Credit note: " + crNo + " created successifully", vbOKOnly + vbInformation, "Success: Create supplier credit note")
        Else
            'update the credit note
            crNote.updateSupplierCreditNote(txtCrNo.Text, txtOrderNo.Text, LCurrency.getValue(txtCrAmount.Text), txtCrDetails.Text)
            'delete the current particulars
            crNote.deleteCreditNoteParticulars(txtCrNo.Text)
            'insert new particulars
            For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
                Dim itemCode As String = dtgrdCrNoteList.Item(0, i).Value.ToString
                Dim qty As String = dtgrdCrNoteList.Item(2, i).Value.ToString
                Dim price As String = LCurrency.getValue(dtgrdCrNoteList.Item(3, i).Value.ToString)
                crNote.createCreditNoteParticulars(txtCrNo.Text, itemCode, price, qty)
            Next
        End If
        getParticulars(txtCrNo.Text)
    End Sub

    Private Function getParticulars(crNoteNo As String)
        dtgrdCrNoteList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected credit note?", vbYesNo + vbQuestion, "Delete credit note?")
        If res = DialogResult.Yes Then
            Dim crNote As New CreditNote
            If crNote.deleteSupplierCreditNote(txtCrNo.Text) = True Then
                MsgBox("Credit note has been deleted", vbOKOnly + vbInformation, "Success: Credit note deleted")
                clear()
                dtgrdCrNoteList.Rows.Clear()
            Else
                MsgBox("Could not complete operation", vbOKOnly + vbCritical, "Error")
            End If
        End If
    End Sub

    Private Sub btnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
        If txtCrStatus.Text = "ADJUSTED" Then
            MsgBox("Credit note alredy adjusted", vbOKOnly + vbExclamation, "")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to adjust the selected credit note? Inventory will be adjusted.", vbYesNo + vbQuestion, "Adjust?")
        If res = DialogResult.Yes Then
            Dim crNote As New CreditNote
            If crNote.adjustSupplierCreditNote(txtCrNo.Text) = True Then
                'update inventory
                Dim inventory As New Inventory
                For i As Integer = 0 To dtgrdCrNoteList.RowCount - 2
                    Dim itemCode As String = dtgrdCrNoteList.Item(0, i).Value.ToString
                    Dim qty As String = dtgrdCrNoteList.Item(2, i).Value.ToString
                    inventory.adjustInventory(itemCode, -Val(qty)) 'adjust items in the inventory
                Next
                MsgBox("Credit note adjusted", vbOKOnly + vbInformation, "Success: Adjust credit note")
            Else
                MsgBox("Could not adjust the selected credit note", vbOKOnly + vbCritical, "Error: Operation failed")
            End If
        End If
    End Sub


    Private Sub dtgrdItemList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdCrNoteList.CellEndEdit
        If txtCrNo.Text = "" Then
            Try
                MsgBox("Please select an existing credit note or create a new one", vbOKOnly + vbCritical, "Error: No selection")
                dtgrdCrNoteList.Rows.Remove(dtgrdCrNoteList.CurrentRow)
            Catch ex As Exception

            End Try
            Exit Sub
        End If

        Try

            Dim row As Integer = dtgrdCrNoteList.CurrentCell.RowIndex
            Dim col As Integer = dtgrdCrNoteList.CurrentCell.ColumnIndex

            Dim itemCode As String = dtgrdCrNoteList.Item(0, row).Value.ToString

            If dtgrdCrNoteList.CurrentCell.ColumnIndex = 0 Then
                Dim item As New Item
                If item.searchItem(itemCode) = True Then
                    dtgrdCrNoteList.Item(1, row).Value = item.GL_LONG_DESCR
                    dtgrdCrNoteList.Item(3, row).Value = item.GL_COST_PRICE
                Else
                    MsgBox("Could not find item", vbOKOnly + vbCritical, "Error: Not found")
                    dtgrdCrNoteList.Rows.Remove(dtgrdCrNoteList.CurrentRow)
                End If
            End If
            If dtgrdCrNoteList.CurrentCell.ColumnIndex = 2 Then
                Dim qty As String = dtgrdCrNoteList.Item(2, row).Value
                If IsNumeric(qty) And qty > 0 Then
                    dtgrdCrNoteList.Item(4, row).Value = LCurrency.displayValue((Val(qty) * Val(LCurrency.getValue(dtgrdCrNoteList.Item(3, row).Value))))
                Else
                    MsgBox("Invalid quantity value. Quantity values should be more than zero", vbOKOnly + vbCritical, "Error: Invalid entry")
                End If
            End If

        Catch ex As Exception

        End Try


    End Sub

End Class