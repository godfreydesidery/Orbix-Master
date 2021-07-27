Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering

Public Class frmItemConversion
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        txtId.Text = ""
        txtConversionNo.Text = ""
        txtConversionDate.Text = Day.DAY
        txtStatus.Text = "PENDING"

        clearRawFields()
        clearEndFields()

        txtConversionNo.ReadOnly = True
        txtReason.ReadOnly = False

        btnSave.Enabled = False
        btnApprove.Enabled = False

        txtConversionNo.Text = (New ItemConversion).generateConversionNo()

        dtgrdItemsToConvert.Rows.Clear()
        dtgrdEndItems.Rows.Clear()
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbRawDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbRawDescription.KeyUp
        Dim currentText As String = cmbRawDescription.Text
        shortList.Clear()
        cmbRawDescription.Items.Clear()
        cmbRawDescription.Items.Add(currentText)
        cmbRawDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbRawDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbRawDescription.Items.AddRange(shortList.ToArray())
        cmbRawDescription.SelectionStart = cmbRawDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmbEndDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbEndDescription.KeyUp
        Dim currentText As String = cmbEndDescription.Text
        shortList.Clear()
        cmbEndDescription.Items.Clear()
        cmbRawDescription.Items.Add(currentText)
        cmbEndDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbEndDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbEndDescription.Items.AddRange(shortList.ToArray())
        cmbEndDescription.SelectionStart = cmbEndDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Function search()
        If txtConversionNo.Text = "" Then
            MsgBox("Can not process conversion. Please specify whether the conversion is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtConversionNo.ReadOnly = False Then
            Dim conversion As New ItemConversion
            If conversion.getItemConversion(txtConversionNo.Text) = True Then
                txtId.Text = conversion.GL_ID

                txtConversionNo.ReadOnly = True
                txtReason.ReadOnly = True

                txtConversionDate.Text = conversion.GL_DATE
                txtStatus.Text = conversion.GL_STATUS
                txtReason.Text = conversion.GL_REASON

                refreshRawList()
                refreshEndList()

                If txtId.Text = "" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                Dim status As String = conversion.GL_STATUS

                If status = "APPROVED" Or status = "PRINTED" Or status = "REPRINTED" Or status = "COMPLETED" Or status = "CANCELED" Then
                    btnApprove.Enabled = False
                ElseIf status = "PENDING" Then
                    btnApprove.Enabled = True
                Else
                    btnApprove.Enabled = False
                End If

                If status = "PENDING" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = False
                    txtRawItemCode.ReadOnly = False
                    cmbRawDescription.Enabled = True
                    txtRawQty.ReadOnly = False

                End If

                If status = "APPROVED" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = True
                    txtRawItemCode.ReadOnly = True
                    cmbRawDescription.Enabled = False
                    txtRawQty.ReadOnly = True

                End If
                If status = "PRINTED" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = True
                    txtRawItemCode.ReadOnly = True
                    cmbRawDescription.Enabled = False
                    txtRawQty.ReadOnly = True

                End If
                If status = "COMPLETED" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = True
                    txtRawItemCode.ReadOnly = True
                    cmbRawDescription.Enabled = False
                    txtRawQty.ReadOnly = True

                End If
                If status = "CANCELED" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = True
                    txtRawItemCode.ReadOnly = True
                    cmbRawDescription.Enabled = False
                    txtRawQty.ReadOnly = True

                End If
                If status = "ARCHIVED" Then
                    txtConversionNo.ReadOnly = True

                    txtRawBarCode.ReadOnly = True
                    txtRawItemCode.ReadOnly = True
                    cmbRawDescription.Enabled = False
                    txtRawQty.ReadOnly = True

                End If

            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If

        Return vbNull
    End Function

    Private Sub clearRawFields()
        txtRawBarCode.Text = ""
        txtRawItemCode.Text = ""
        cmbRawDescription.SelectedItem = Nothing
        txtRawQty.Text = ""
        txtRawPrice.Text = ""
    End Sub
    Private Sub clearEndFields()
        txtEndBarcode.Text = ""
        txtEndItemCode.Text = ""
        cmbEndDescription.SelectedItem = Nothing
        cmbEndDescription.Text = ""
        txtEndQty.Text = ""
        txtEndPrice.Text = ""
    End Sub
    Private Sub unlockRawFields()
        txtRawBarCode.ReadOnly = False
        txtRawItemCode.ReadOnly = False
        cmbRawDescription.Enabled = True
    End Sub
    Private Sub lockRawFields()
        txtRawBarCode.ReadOnly = True
        txtRawItemCode.ReadOnly = True
        cmbRawDescription.Enabled = False
    End Sub
    Private Sub unlockEndFields()
        txtEndBarcode.ReadOnly = False
        txtEndItemCode.ReadOnly = False
        cmbEndDescription.Enabled = True
    End Sub
    Private Sub lockEndFields()
        txtEndBarcode.ReadOnly = True
        txtEndItemCode.ReadOnly = True
        cmbEndDescription.Enabled = False
    End Sub

    Private Function checkItemToConvertDuplicate(itemCode As String, conversionId As String) As Boolean
        Dim present As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `conversion_id` FROM `items_to_convert` WHERE `item_code`='" + itemCode + "' AND `conversion_id`='" + conversionId + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                present = True

                Exit While
            End While
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return present
    End Function

    Private Function checkConvertedDuplicate(itemCode As String, conversionId As String) As Boolean
        Dim present As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `conversion_id` FROM `converted` WHERE `item_code`='" + itemCode + "' AND `conversion_id`='" + conversionId + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read

                present = True

                Exit While
            End While
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return present
    End Function

    Private Sub btnRawAdd_Click(sender As Object, e As EventArgs) Handles btnRawAdd.Click
        txtConversionNo.ReadOnly = True
        If txtReason.Text = "" Then
            MsgBox("Please provide reason for conversion")
            Exit Sub
        Else
            txtReason.ReadOnly = True
        End If
        If txtConversionNo.Text = "" Then
            MsgBox("Select new")
            clearRawFields()
            Exit Sub
        End If
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If
        'If cmbSalesPersons.Text = "" Then
        'MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
        'Exit Sub
        'End If
        Dim rawBarCode As String = txtRawBarCode.Text
        Dim rawItemCode As String = txtRawItemCode.Text
        Dim rawDescription As String = cmbRawDescription.Text

        Dim rawQty As String = txtRawQty.Text
        Dim rawPrice As String = txtRawPrice.Text
        If rawItemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If
        If Val(rawQty) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If

        Dim conversion As ItemConversion
        If txtId.Text = "" Then
            conversion = New ItemConversion
            conversion.GL_CONVERSION_NO = txtConversionNo.Text
            conversion.GL_DATE = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            conversion.GL_REASON = txtReason.Text
            conversion.GL_STATUS = "PENDING"
            If conversion.isItemConversionExist(txtConversionNo.Text) = False Then
                If conversion.addNewConversion() = True Then
                    conversion.getItemConversion(txtConversionNo.Text)
                    txtId.Text = conversion.GL_ID
                    btnSave.Enabled = True
                End If
            Else

            End If
        End If
        conversion = New ItemConversion

        conversion.GL_ID = txtId.Text
        conversion.GL_CONVERSION_NO = txtConversionNo.Text
        conversion.GL_RAW_ITEM_CODE = rawItemCode
        conversion.GL_RAW_DESCRIPTION = rawDescription
        conversion.GL_RAW_QTY = Math.Round((Val(rawQty)), 2, MidpointRounding.AwayFromZero)
        conversion.GL_RAW_PRICE = rawPrice



        If checkItemToConvertDuplicate(rawItemCode, txtId.Text) = False Then
            conversion.addItemToConvert()
        Else
            conversion.editItemToConvert(txtId.Text, rawItemCode)
        End If
        btnApprove.Enabled = True

        refreshConversionList()
        refreshRawList()

        clearRawFields()
        unlockRawFields()
        Exit Sub
    End Sub
    Private Sub refreshConversionList()
        dtgrdConversionList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`, `conversion_no`, `date`, `reason`, `status`, `user_id` FROM `item_conversion` WHERE `status`='PENDING' OR `status`='APPROVED' OR `status`='PRINTED' OR `status`='COMPLETED'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                Dim item As New Item

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("conversion_no")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("date")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("status")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdConversionList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function refreshRawList()
        dtgrdItemsToConvert.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `item_code`, `description`, `qty`, `price`, `conversion_id` FROM `items_to_convert` WHERE `conversion_id`='" + txtId.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("item_code")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("description")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("qty")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(reader.GetString("price"))
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdItemsToConvert.Rows.Add(dtgrdRow)
            End While

            conn.Close()
            'txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Function refreshEndList()
        dtgrdEndItems.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `id`, `item_code`, `description`, `qty`, `price`, `conversion_id` FROM `converted` WHERE `conversion_id`='" + txtId.Text + "' "
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("item_code")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("description")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("qty")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(reader.GetString("price"))
                dtgrdRow.Cells.Add(dtgrdCell)


                dtgrdEndItems.Rows.Add(dtgrdRow)
            End While

            conn.Close()
            'txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub frmItemConversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetAll()
        refreshConversionList()

        Dim item As New Item
        longList = item.getItems()
    End Sub

    Private Sub btnRawSearchItem_Click(sender As Object, e As EventArgs) Handles btnRawSearchItem.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtRawBarCode.Text
        Dim itemCode As String = txtRawItemCode.Text
        Dim descr As String = cmbRawDescription.Text

        If barCode <> "" Then
            itemCode = (New Item).getItemCode(barCode, "")
        ElseIf itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode("", descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtRawItemCode.Text = reader.GetString("item_code")
                cmbRawDescription.Text = reader.GetString("item_long_description")
                txtRawPrice.Text = reader.GetString("retail_price")
                'txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                valid = True
                btnRawAdd.Enabled = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                btnRawAdd.Enabled = False
            Else
                txtRawBarCode.ReadOnly = True
                txtRawItemCode.ReadOnly = True
                cmbRawDescription.Enabled = False
                btnRawAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnRawReset_Click(sender As Object, e As EventArgs) Handles btnRawReset.Click
        txtRawBarCode.Text = ""
        txtRawItemCode.Text = ""
        cmbRawDescription.Text = ""
        txtRawPrice.Text = ""
        txtRawQty.Text = ""
        cmbRawDescription.Enabled = True
        txtRawBarCode.ReadOnly = False
        txtRawItemCode.ReadOnly = False
        btnRawAdd.Enabled = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        resetAll()
    End Sub
    Private Sub resetAll()

        txtId.Text = ""
        txtConversionNo.Text = ""
        txtConversionDate.Text = ""
        txtReason.Text = ""
        txtStatus.Text = ""

        txtRawBarCode.Text = ""
        txtRawItemCode.Text = ""
        cmbRawDescription.Text = ""
        txtRawPrice.Text = ""
        txtRawQty.Text = ""

        'lock
        txtConversionNo.ReadOnly = True



        'unlock

        btnSave.Enabled = False


        dtgrdItemsToConvert.Rows.Clear()
        dtgrdEndItems.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        ' If User.authorize("EDIT PACKING LIST") = True Then


        '  Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If

        If txtId.Text = "" Then
            btnSave.Enabled = False
            txtConversionNo.ReadOnly = False
            txtReason.ReadOnly = False
            txtConversionNo.Text = ""
            txtConversionDate.Text = ""
            txtReason.Text = ""
            txtStatus.Text = ""
        Else
            btnSave.Enabled = True
            txtConversionNo.ReadOnly = True
            txtReason.ReadOnly = False
        End If

    End Sub

    Private Function validateInputs() As Boolean
        Dim valid As Boolean = True
        If txtConversionNo.Text = "" Then
            valid = False
            MsgBox("Operation failed, conversion no required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        If txtReason.Text = "" Then
            valid = False
            MsgBox("Operation failed, reason required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If
        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtConversionNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If
        If dtgrdItemsToConvert.RowCount = 0 Then
            MsgBox("Could not save, there are no product(s) to convert")
            Exit Sub
        End If
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "CANCELED" Or status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Could not modify. Only Pending, Approved or Printed documents can be modified", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        'validate entries
        If validateInputs() = False Then
            Exit Sub
        End If
        Dim conversion As New ItemConversion
        conversion.GL_CONVERSION_NO = txtConversionNo.Text
        conversion.GL_DATE = txtConversionDate.Text
        conversion.GL_STATUS = txtStatus.Text
        conversion.GL_REASON = txtReason.Text


        'check if new or existing 

        If txtId.Text = "" Then
            'save a new record
            If conversion.addNewConversion() = True Then
                conversion.getItemConversion(txtConversionNo.Text)
                MsgBox("Save success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Saving failed", vbOKOnly + vbExclamation, "Failure")
            End If
        Else
            'save an existing record

            If conversion.editConversion(txtConversionNo.Text) = True Then
                conversion.getItemConversion(txtConversionNo.Text)
                MsgBox("Edit success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Editing failed", vbOKOnly + vbExclamation, "Failure")
            End If
        End If
    End Sub
    Private Sub dtgrdItemsToConvert_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemsToConvert.RowHeaderMouseDoubleClick

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)

        If status = "PENDING" Then
            'continue delete
        Else
            MsgBox("Can not delete item, not a pending conversion", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Remove item from list?", vbYesNoCancel + vbQuestion, "Remove item")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdItemsToConvert.CurrentRow.Index


        Dim itemCode As String = dtgrdItemsToConvert.Item(0, row).Value


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `items_to_convert` WHERE `item_code`='" + itemCode + "' AND `conversion_id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            'lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        refreshRawList()

    End Sub
    Private Sub dtgrdEndItems_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdEndItems.RowHeaderMouseDoubleClick

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)

        If status = "PENDING" Then
            'continue delete
        Else
            MsgBox("Can not delete item, not a pending conversion", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Remove item from list?", vbYesNoCancel + vbQuestion, "Remove item")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdEndItems.CurrentRow.Index


        Dim itemCode As String = dtgrdEndItems.Item(0, row).Value


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `converted` WHERE `item_code`='" + itemCode + "' AND `conversion_id`='" + txtId.Text + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            conn.Close()
            'lockFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        refreshEndList()

    End Sub
    Private Sub dtgrdItemToConvert_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdItemsToConvert.RowHeaderMouseClick

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearRawFields()
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdItemsToConvert.CurrentRow.Index

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdItemsToConvert.Item(0, row).Value
        Dim description As String = dtgrdItemsToConvert.Item(1, row).Value
        Dim qty As String = dtgrdItemsToConvert.Item(2, row).Value
        Dim price As String = dtgrdItemsToConvert.Item(3, row).Value


        Dim dtgrdRow As New DataGridViewRow

        txtRawItemCode.Text = itemCode
        cmbRawDescription.Text = description
        txtRawPrice.Text = LCurrency.getValue(price)
        txtRawQty.Text = qty


        If status = "PENDING" Then
            'lock
            txtRawBarCode.ReadOnly = True
            txtRawItemCode.ReadOnly = True
            cmbRawDescription.Enabled = False

            'unlock
            txtRawQty.ReadOnly = False

            btnRawAdd.Enabled = True
        End If
        If status = "APPROVED" Then
            'lock
            txtRawBarCode.ReadOnly = True
            txtRawItemCode.ReadOnly = True
            cmbRawDescription.Enabled = False


            txtRawQty.ReadOnly = True

            btnRawAdd.Enabled = False
        End If
        If status = "PRINTED" Then
            'lock
            txtRawBarCode.ReadOnly = True
            txtRawItemCode.ReadOnly = True
            cmbRawDescription.Enabled = False
            txtRawQty.ReadOnly = True

            'unlock

            btnRawAdd.Enabled = True
        End If
        If status = "COMPLETED" Then
            'lock
            txtRawBarCode.ReadOnly = True
            txtRawItemCode.ReadOnly = True
            cmbRawDescription.Enabled = False
            txtRawQty.ReadOnly = True


            btnRawAdd.Enabled = False
            'unlock

        End If
        refreshRawList()
    End Sub
    Private Sub dtgrdEndItems_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdEndItems.RowHeaderMouseClick

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdEndItems.CurrentRow.Index

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdEndItems.Item(0, row).Value
        Dim description As String = dtgrdEndItems.Item(1, row).Value
        Dim qty As String = dtgrdEndItems.Item(2, row).Value
        Dim price As String = LCurrency.getValue(dtgrdEndItems.Item(3, row).Value)


        Dim dtgrdRow As New DataGridViewRow

        txtEndItemCode.Text = itemCode
        cmbEndDescription.Text = description
        txtEndPrice.Text = price
        txtEndQty.Text = qty


        If status = "PENDING" Then
            'lock
            txtEndBarcode.ReadOnly = True
            txtEndItemCode.ReadOnly = True
            cmbEndDescription.Enabled = False

            'unlock
            txtEndQty.ReadOnly = False

            btnEndAdd.Enabled = True
        End If
        If status = "APPROVED" Then
            'lock
            txtEndBarcode.ReadOnly = True
            txtEndItemCode.ReadOnly = True
            cmbEndDescription.Enabled = False


            txtEndQty.ReadOnly = True

            btnEndAdd.Enabled = False
        End If
        If status = "PRINTED" Then
            'lock
            txtEndBarcode.ReadOnly = True
            txtEndItemCode.ReadOnly = True
            cmbEndDescription.Enabled = False
            txtEndQty.ReadOnly = True

            'unlock

            btnEndAdd.Enabled = True
        End If
        If status = "COMPLETED" Then
            'lock
            txtEndBarcode.ReadOnly = True
            txtEndItemCode.ReadOnly = True
            cmbEndDescription.Enabled = False
            txtEndQty.ReadOnly = True


            btnEndAdd.Enabled = False
            'unlock

        End If
        refreshEndList()
    End Sub
    Private Sub dtgrdItemConversions_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdConversionList.CellClick
        Dim r As Integer = dtgrdConversionList.CurrentRow.Index
        Dim conversionNo As String = dtgrdConversionList.Item(0, r).Value.ToString
        txtConversionNo.Text = conversionNo
        txtConversionNo.ReadOnly = False
        search()
    End Sub

    Private Sub txtRawQty_TextChanged(sender As Object, e As EventArgs) Handles txtRawQty.TextChanged
        If Not IsNumeric(txtRawQty.Text) Or txtRawQty.Text.Contains("-") Or Val(txtRawQty.Text) < 0 Then
            txtRawQty.Text = ""
        End If
    End Sub

    Private Sub btnEndSearchItem_Click(sender As Object, e As EventArgs) Handles btnEndSearchItem.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtEndBarcode.Text
        Dim itemCode As String = txtEndItemCode.Text
        Dim descr As String = cmbEndDescription.Text

        If barCode <> "" Then
            itemCode = (New Item).getItemCode(barCode, "")
        ElseIf itemCode <> "" Then
            itemCode = itemCode
        ElseIf descr <> "" Then
            itemCode = (New Item).getItemCode("", descr)
        Else
            itemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtEndItemCode.Text = reader.GetString("item_code")
                cmbEndDescription.Text = reader.GetString("item_long_description")
                txtEndPrice.Text = reader.GetString("retail_price")
                'txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                valid = True
                btnEndAdd.Enabled = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                btnEndAdd.Enabled = False
            Else
                txtEndBarcode.ReadOnly = True
                txtEndItemCode.ReadOnly = True
                cmbEndDescription.Enabled = False
                btnEndAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnEndAdd_Click(sender As Object, e As EventArgs) Handles btnEndAdd.Click
        If txtId.Text = "" Then
            MsgBox("Operation failed, please select New", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If
        txtConversionNo.ReadOnly = True
        If txtReason.Text = "" Then
            MsgBox("Please provide reason for conversion")
            Exit Sub
        Else
            txtReason.ReadOnly = True
        End If
        If txtConversionNo.Text = "" Then
            MsgBox("Select new")
            clearEndFields()
            Exit Sub
        End If
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearEndFields()
            Exit Sub
        End If
        'If cmbSalesPersons.Text = "" Then
        'MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
        'Exit Sub
        'End If
        Dim endBarCode As String = txtEndBarcode.Text
        Dim endItemCode As String = txtEndItemCode.Text
        Dim endDescription As String = cmbEndDescription.Text

        Dim endQty As String = txtEndQty.Text
        Dim endPrice As String = txtEndPrice.Text
        If endItemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If
        If Val(endQty) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If

        Dim conversion As ItemConversion
        If txtId.Text = "" Then
            conversion = New ItemConversion
            conversion.GL_CONVERSION_NO = txtConversionNo.Text
            conversion.GL_DATE = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            conversion.GL_REASON = txtReason.Text
            conversion.GL_STATUS = "PENDING"
            If conversion.isItemConversionExist(txtConversionNo.Text) = False Then
                If conversion.addNewConversion() = True Then
                    conversion.getItemConversion(txtConversionNo.Text)
                    txtId.Text = conversion.GL_ID
                    btnSave.Enabled = True
                End If
            Else

            End If
        End If
        conversion = New ItemConversion

        conversion.GL_ID = txtId.Text
        conversion.GL_CONVERSION_NO = txtConversionNo.Text
        conversion.GL_END_ITEM_CODE = endItemCode
        conversion.GL_END_DESCRIPTION = endDescription
        conversion.GL_END_QTY = Math.Round((Val(endQty)), 2, MidpointRounding.AwayFromZero)
        conversion.GL_END_PRICE = endPrice



        If checkConvertedDuplicate(endItemCode, txtId.Text) = False Then
            conversion.addConverted()
        Else
            conversion.editConverted(txtId.Text, endItemCode)
        End If
        btnApprove.Enabled = True
        refreshConversionList()
        refreshEndList()

        clearEndFields()
        unlockEndFields()
        Exit Sub
    End Sub

    Private Sub btnEndReset_Click(sender As Object, e As EventArgs) Handles btnEndReset.Click
        txtEndBarcode.Text = ""
        txtEndItemCode.Text = ""
        cmbEndDescription.Text = ""
        txtEndPrice.Text = ""
        txtEndQty.Text = ""
        cmbEndDescription.Enabled = True
        txtEndBarcode.ReadOnly = False
        txtEndItemCode.ReadOnly = False
        btnEndAdd.Enabled = False
    End Sub

    Private Sub txtEndQty_TextChanged(sender As Object, e As EventArgs) Handles txtEndQty.TextChanged
        If Not IsNumeric(txtEndQty.Text) Or txtEndQty.Text.Contains("-") Or Val(txtEndQty.Text) < 0 Then
            txtEndQty.Text = ""
        End If
    End Sub

    Private Sub cmbRawDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRawDescription.SelectedIndexChanged

    End Sub

    Private Sub dtgrdConversionList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdConversionList.CellContentClick

    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not approve, already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If
        If status = "PRINTED" Then
            MsgBox("Could not approve, already printed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If
        If status = "REPRINTED" Then
            MsgBox("Could not approve, already printed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not approve, already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not approve, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            ' clearFields()
            Exit Sub
        End If
        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtConversionNo.Text = "" Then
                MsgBox("Select a conversion to approve", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Approve product conversion: " + txtConversionNo.Text + " ? Editing will be disabled after approval", vbYesNo + vbQuestion, "Approve document?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdItemsToConvert.RowCount = 0 Or dtgrdEndItems.RowCount = 0 Then
                    MsgBox("Could not approve, document has an empty list", vbOKOnly + vbExclamation, "Error: Invalid operation")
                    Exit Sub
                End If
                Dim conversion As ItemConversion = New ItemConversion
                If conversion.approveConversion(txtConversionNo.Text) = True Then
                    MsgBox("Approve Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Approve failed", vbOKOnly + vbExclamation, "Failure")
                End If

            End If
            txtStatus.Text = (New ItemConversion).getStatus(txtConversionNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshConversionList()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "PENDING" Or status = "APPROVED" Then
            'continue
        Else
            MsgBox("Can not cancel, only Pending or Approved conversion can be canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtConversionNo.Text = "" Then
                MsgBox("Select a conversion to cancel", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Cancel conversion: " + txtConversionNo.Text + " ? Conversion document can not be used after canceling", vbYesNo + vbQuestion, "Cancel document?")
            If res = DialogResult.Yes Then

                Dim conversion As ItemConversion = New ItemConversion
                If conversion.cancelConversion(txtConversionNo.Text) = True Then
                    MsgBox("Cancel Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Cancel failed", vbOKOnly + vbExclamation, "Failed")
                End If



            End If
            txtStatus.Text = (New ItemConversion).getStatus(txtConversionNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation, "Error: Access denied")
        End If
        refreshConversionList()
    End Sub

    Private Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status = "COMPLETED" Then
            'continue
        Else
            If txtConversionNo.Text = "" Then
                MsgBox("Select a conversion document to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            MsgBox("Can not archive, only completed documents can be archived", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE LPO") = True Then
            If txtConversionNo.Text = "" Then
                MsgBox("Select a document to archive", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Archive conversion document: " + txtConversionNo.Text + " ? Document will be sent to archives for future references", vbYesNo + vbQuestion, "Archive document?")
            If res = DialogResult.Yes Then

                Dim conversion As ItemConversion = New ItemConversion
                If conversion.archiveConversion(txtConversionNo.Text) = True Then
                    MsgBox("Archive Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Archive failed", vbOKOnly + vbExclamation, "Failure")
                End If
            End If
            txtStatus.Text = (New ItemConversion).getStatus(txtConversionNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshConversionList()
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If txtConversionNo.Text = "" Then
            MsgBox("Select a conversion document to complete", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        If status <> "APPROVED" Then
            MsgBox("Operation failed, Only approved documents can be completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If


        Dim res As Integer = MsgBox("Complete transaction? Converted items will be deducted from stock and end products will be added to stock", vbYesNoCancel + vbQuestion, "Complete transaction")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If


        For i As Integer = 0 To dtgrdItemsToConvert.RowCount - 1

            Dim itemCode As String = dtgrdItemsToConvert.Item(0, i).Value
            Dim qty As String = dtgrdItemsToConvert.Item(2, i).Value
            'sql for recording sales
            Dim conn As New MySqlConnection(Database.conString)
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `inventorys` SET `qty`=`qty`-'" + qty + "' WHERE `item_code`='" + itemCode + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()
                Dim inventory As New Inventory
                Dim stockCard As New StockCard
                If Val(qty) <> 0 Then
                    stockCard.qtyOut(Day.DAY, itemCode, qty, inventory.getInventory(itemCode), "Used in product conversion, Conversion No: " + txtConversionNo.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next

        For i As Integer = 0 To dtgrdEndItems.RowCount - 1

            Dim itemCode As String = dtgrdEndItems.Item(0, i).Value
            Dim qty As String = dtgrdEndItems.Item(2, i).Value
            'sql for recording sales
            Dim conn As New MySqlConnection(Database.conString)
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `inventorys` SET `qty`=`qty`+'" + qty + "' WHERE `item_code`='" + itemCode + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()
                Dim inventory As New Inventory
                Dim stockCard As New StockCard
                If Val(qty) <> 0 Then
                    stockCard.qtyIn(Day.DAY, itemCode, qty, inventory.getInventory(itemCode), "Produced from product conversion, Conversion No: " + txtConversionNo.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next


        Dim conversion As ItemConversion = New ItemConversion
        If conversion.completeConversion(txtConversionNo.Text) = True Then
            MsgBox("Complete Success", vbOKOnly + vbInformation, "Success")
        Else
            MsgBox("Complete failed", vbOKOnly + vbExclamation, "Failure")
        End If

        txtStatus.Text = (New ItemConversion).getStatus(txtConversionNo.Text)

        refreshConversionList()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim status As String = (New ItemConversion).getStatus(txtId.Text)
        If status = "APPROVED" Or status = "COMPLETED" Or status = "PRINTED" Or status = "ARCHIVED" Then
            'Dim res As Integer = MsgBox("Print conversion sheet " + txtConversionNo.Text + " ?", vbYesNo + vbQuestion, "Print conversion sheet?")
            ' If res = DialogResult.Yes Then
            'Dim conv As New ItemConversion
            'conv.printConversion(txtConversionNo.Text)''this option should not be there
            'MsgBox("Print success", vbOKOnly + vbInformation, "Success")
            'End If
            ' ElseIf status = "COMPLETED" Or status = "PRINTED" Or status = "ARCHIVED" Then

            'print documemnt only
        Else
            MsgBox("Could not print, document not approved or has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        txtConversionNo.ReadOnly = False
        search()
        refreshRawList()
        refreshEndList()



        Dim document As Document = New Document

        document.Info.Title = "Conversion"
        document.Info.Subject = "Conversion"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Conversion " & txtConversionNo.Text & ".pdf"

        myRenderer.PdfDocument.Save(filename)

        Process.Start(filename)





    End Sub

    Private Sub defineStyles(doc As Document)
        'Get the predefined style Normal.
        Dim style As Style = doc.Styles("Normal")
        'Because all styles are derived from Normal, the next line changes the
        'font of the whole document. Or, more exactly, it changes the font of
        'all styles And paragraphs that do Not redefine the font.
        style.Font.Name = "Verdana"
        'style = doc.Document.Styles(StyleNames.Header)
        style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right)
        style = doc.Styles(StyleNames.Footer)
        style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center)
        'Create a new style called Table based on style Normal
        style = doc.Styles.AddStyle("Table", "Normal")
        style.Font.Name = "Verdana"
        style.Font.Name = "Calibri"
        style.Font.Size = 10
        'Create a new style called Reference based on style Normal
        style = doc.Styles.AddStyle("Reference", "Normal")
        style.ParagraphFormat.SpaceBefore = "5mm"
        style.ParagraphFormat.SpaceAfter = "5mm"
        style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right)

    End Sub
    Private Sub createDocument(doc As Document)
        'Each MigraDoc document needs at least one section.
        Dim section As Section = doc.AddSection()
        section.PageSetup.DifferentFirstPageHeaderFooter = True
        Dim paragraph As Paragraph
        doc.FootnoteStartingNumber() = 1
        paragraph = section.Footers.Primary.AddParagraph()
        Dim _datetime As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        paragraph.AddText("Printed :" & _datetime + " By :" & User.CURRENT_ALIAS & " From :" & Company.GL_NAME)
        paragraph.Format.Font.Size = 8
        paragraph.Format.Alignment = ParagraphAlignment.Center
        paragraph.Format.Font.Color = Colors.GreenYellow
        paragraph = section.Footers.Primary.AddParagraph()
        paragraph.AddPageField()
        paragraph.AddText(" of ")
        paragraph.AddNumPagesField()
        paragraph.Format.Alignment = ParagraphAlignment.Right
        section.Footers.FirstPage = section.Footers.Primary.Clone()
        'Start of header
        Dim logoPath As String = ""
        Dim logoImage As Image = Nothing
        Dim headerTable As Table = section.Headers.FirstPage.AddTable()
        headerTable.Borders.Width = 0.2
        headerTable.Borders.Left.Width = 0.2
        headerTable.Borders.Right.Width = 0.2
        headerTable.Rows.LeftIndent = 0
        Dim headerColumn As Column
        headerColumn = headerTable.AddColumn("2.2cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("0.3cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        headerColumn = headerTable.AddColumn("12cm")
        headerColumn.Format.Alignment = ParagraphAlignment.Left
        Dim headerRow As Row
        headerRow = headerTable.AddRow()
        headerRow.Format.Font.Bold = False
        headerRow.HeadingFormat = True
        headerRow.Format.Font.Size = 9
        headerRow.Format.Alignment = ParagraphAlignment.Center
        headerRow.Borders.Color = Colors.White
        Try
            Dim logo As New System.IO.MemoryStream(CType(Company.GL_LOGO, Byte()))
            logoImage = Image.FromStream(logo)
            logoPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "TempDocumentLogo.png"
            If My.Computer.FileSystem.FileExists(logoPath) Then
                My.Computer.FileSystem.DeleteFile(logoPath)
            End If
            logoImage.Save(logoPath)
            If logo.Length > 0 Then
                headerRow.Cells(0).AddImage(logoPath).Width = "2.2cm"
                headerRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
            End If
        Catch ex As Exception
        End Try
        headerRow.Cells(1).AddParagraph("")
        Dim companyName As New Paragraph
        companyName.AddText(Company.GL_NAME + Environment.NewLine)
        companyName.Format.Font.Bold = True
        companyName.Format.Font.Size = 9
        Dim physicalAddress As New Paragraph
        physicalAddress.AddText(Company.GL_PHYSICAL_ADDRESS + Environment.NewLine)
        physicalAddress.Format.Font.Size = 8
        Dim address As New Paragraph
        address.AddText(Company.GL_POST_ADDRESS + Environment.NewLine)
        address.Format.Font.Size = 8
        Dim postCode As New Paragraph
        postCode.AddText(Company.GL_POST_CODE + Environment.NewLine)
        postCode.Format.Font.Size = 8
        Dim telephone As New Paragraph
        telephone.AddText("Tel: " + Company.GL_TELEPHONE + " Mob:" + Company.GL_MOBILE + Environment.NewLine)
        telephone.Format.Font.Size = 7
        Dim email As New Paragraph
        email.AddText("Email: " + Company.GL_EMAIL + Environment.NewLine)
        email.Format.Font.Size = 7
        email.Format.Font.Italic = True
        headerRow.Cells(2).Add(companyName)
        headerRow.Cells(2).Add(physicalAddress)
        headerRow.Cells(2).Add(postCode)
        headerRow.Cells(2).Add(address)
        headerRow.Cells(2).Add(telephone)
        headerRow.Cells(2).Add(email)
        headerRow.Cells(2).Format.Alignment = ParagraphAlignment.Left
        headerTable.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()
        Dim tittleTable As Tables.Table = section.AddTable()
        tittleTable.Borders.Width = 0.25
        tittleTable.Borders.Left.Width = 0.5
        tittleTable.Borders.Right.Width = 0.5
        tittleTable.Rows.LeftIndent = 0
        Dim titleColumn As Tables.Column
        titleColumn = tittleTable.AddColumn("2.5cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        titleColumn = tittleTable.AddColumn("12.0cm")
        titleColumn.Format.Alignment = ParagraphAlignment.Left
        Dim titleRow As Tables.Row
        Dim documentTitle As New Paragraph
        documentTitle.AddText("Product Conversion Sheet")
        documentTitle.Format.Alignment = ParagraphAlignment.Left
        documentTitle.Format.Font.Size = 10
        documentTitle.Format.Font.Color = Colors.Black
        titleRow = tittleTable.AddRow()
        titleRow.Format.Font.Bold = True
        titleRow.HeadingFormat = True
        titleRow.Format.Font.Size = 8
        titleRow.Format.Alignment = ParagraphAlignment.Center
        titleRow.Format.Font.Bold = True
        titleRow.Borders.Color = Colors.White
        titleRow.Cells(0).AddParagraph("")
        titleRow.Cells(0).Format.Alignment = ParagraphAlignment.Left
        titleRow.Cells(1).Add(documentTitle)
        titleRow.Cells(1).Format.Alignment = ParagraphAlignment.Left
        tittleTable.SetEdge(0, 0, 2, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        'end of header

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Conversion No: " + txtConversionNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Conversion Date: " + txtConversionDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Reason for conversion: " + txtReason.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Status: " + txtStatus.Text)
        paragraph.Format.Font.Size = 8




        'Add the print date field
        paragraph = section.AddParagraph()
        paragraph.Format.SpaceBefore = "1cm"
        paragraph.Style = "Reference"
        paragraph.AddTab()
        paragraph.AddText("Created: ")
        paragraph.AddDateField("dd.MM.yyyy")

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Initial Products")
        paragraph.Format.Font.Size = 8

        'Create the item table
        Dim table As Tables.Table = section.AddTable()
        table.Style = "Table"
        ' table.Borders.Color = TableBorder
        table.Borders.Width = 0.25
        table.Borders.Left.Width = 0.5
        table.Borders.Right.Width = 0.5
        table.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column As Tables.Column

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Left


        column = table.AddColumn("2cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("8.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
        row.Format.Font.Bold = False
        row.HeadingFormat = True
        row.Format.Font.Size = 8
        row.Format.Alignment = ParagraphAlignment.Center
        row.Format.Font.Bold = True
        row.Borders.Color = Colors.LightGray
        row.Cells(0).AddParagraph("SN")
        row.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row.Cells(1).AddParagraph("Item Code")
        row.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row.Cells(2).AddParagraph("Description")
        row.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row.Cells(3).AddParagraph("Qty")
        row.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row.Cells(4).AddParagraph("Price")
        row.Cells(4).Format.Alignment = ParagraphAlignment.Left



        table.SetEdge(0, 0, 5, 1, Tables.Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim totalAmount As Double = 0
        Dim totalVat As Double = 0
        Dim totalDiscount As Double = 0

        Dim status As String = (New ItemConversion).getStatus(txtConversionNo.Text)
        Dim sn As Integer = 0
        Dim itemCode As String = ""
        Dim description As String = ""
        Dim price As String = ""
        Dim qty As String = ""
        For i As Integer = 0 To dtgrdItemsToConvert.RowCount - 1

            sn = sn + 1
            itemCode = dtgrdItemsToConvert.Item(0, i).Value
            description = dtgrdItemsToConvert.Item(1, i).Value
            qty = dtgrdItemsToConvert.Item(2, i).Value
            price = dtgrdItemsToConvert.Item(3, i).Value


            row = table.AddRow()
            row.Format.Font.Bold = False
            row.Borders.Color = Colors.LightGray
            row.HeadingFormat = False
            row.Format.Font.Size = 8
            row.Format.Alignment = ParagraphAlignment.Center
            row.Borders.Color = Colors.LightGray
            row.Cells(0).AddParagraph(sn)
            row.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row.Cells(1).AddParagraph(itemCode)
            row.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row.Cells(2).AddParagraph(description)
            row.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row.Cells(3).AddParagraph(qty)
            row.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row.Cells(4).AddParagraph(price)
            row.Cells(4).Format.Alignment = ParagraphAlignment.Right



            table.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Final Products")
        paragraph.Format.Font.Size = 8

        'Create the item table
        Dim table3 As Table = section.AddTable()
        table3.Style = "Table"
        ' table.Borders.Color = TableBorder
        table3.Borders.Width = 0.25
        table3.Borders.Left.Width = 0.5
        table3.Borders.Right.Width = 0.5
        table3.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column3 As Column

        column3 = table3.AddColumn("1cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("2cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("8cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("2cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("2cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row3 As Row

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 8
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Borders.Color = Colors.LightGray
        row3.Cells(0).AddParagraph("SN")
        row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(1).AddParagraph("Item Code")
        row3.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(2).AddParagraph("Description")
        row3.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(3).AddParagraph("Qty")
        row3.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row3.Cells(4).AddParagraph("Price")
        row3.Cells(4).Format.Alignment = ParagraphAlignment.Left

        table3.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim j As Integer
        sn = 0
        For j = 0 To dtgrdEndItems.RowCount - 1

            sn = sn + 1
            itemCode = dtgrdEndItems.Item(0, j).Value
            description = dtgrdEndItems.Item(1, j).Value
            qty = dtgrdEndItems.Item(2, j).Value
            price = dtgrdEndItems.Item(3, j).Value

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 8
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.LightGray
            row3.Cells(0).AddParagraph(sn.ToString)
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(1).AddParagraph(dtgrdEndItems.Item(0, j).Value)
            row3.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(2).AddParagraph(dtgrdEndItems.Item(1, j).Value)
            row3.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(3).AddParagraph(dtgrdEndItems.Item(2, j).Value)
            row3.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(4).AddParagraph(dtgrdEndItems.Item(3, j).Value)
            row3.Cells(4).Format.Alignment = ParagraphAlignment.Right
        Next

        table3.SetEdge(0, 0, 5, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        paragraph = section.AddParagraph()
        paragraph = section.AddParagraph()

        'Create the item table
        Dim table2 As Table = section.AddTable()
        table2.Style = "Table"
        ' table.Borders.Color = TableBorder
        table2.Borders.Width = 0.25
        table2.Borders.Left.Width = 0.5
        table2.Borders.Right.Width = 0.5
        table2.Rows.LeftIndent = 0

        'Before you can add a row, you must define the columns
        Dim column2 As Column

        column2 = table2.AddColumn("2cm")
        column2.Format.Alignment = ParagraphAlignment.Left

        column2 = table2.AddColumn("3.5cm")
        column2.Format.Alignment = ParagraphAlignment.Left

        column2 = table2.AddColumn("2cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("3.5cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("2.5cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        column2 = table2.AddColumn("3.0cm")
        column2.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row2 As Row

        row2 = table2.AddRow()
        row2.Format.Font.Bold = False
        row2.HeadingFormat = True
        row2.Format.Font.Size = 9
        row2.Format.Alignment = ParagraphAlignment.Center
        row2.Borders.Color = Colors.White
        row2.Cells(0).AddParagraph("Issued by:")
        row2.Cells(0).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(1).AddParagraph()
        row2.Cells(1).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(2).AddParagraph("Verified by:")
        row2.Cells(2).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(3).AddParagraph()
        row2.Cells(3).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(4).AddParagraph("Approved by:")
        row2.Cells(4).Format.Alignment = ParagraphAlignment.Left
        row2.Cells(5).AddParagraph()
        row2.Cells(5).Format.Alignment = ParagraphAlignment.Left

        table2.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub


End Class