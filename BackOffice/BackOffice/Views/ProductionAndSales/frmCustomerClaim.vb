Imports BackOffice
Imports Devart.Data.MySql
Imports MigraDoc.DocumentObjectModel
Imports MigraDoc.DocumentObjectModel.Tables
Imports MigraDoc.Rendering
Public Class frmCustomerClaim


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        txtId.Text = ""
        txtClaimNo.Text = ""
        txtClaimDate.Text = Day.DAY
        txtStatus.Text = "PENDING"

        clearClaimFields()
        clearReplacementFields()

        txtClaimNo.ReadOnly = True
        txtIssueNo.ReadOnly = False
        txtInvoiceNo.ReadOnly = False
        txtClientName.ReadOnly = False
        txtClientPhone.ReadOnly = False
        txtClientAddress.ReadOnly = False
        txtReturnedBy.ReadOnly = False
        txtReceivedBy.ReadOnly = False

        txtIssueNo.Text = ""
        txtInvoiceNo.Text = ""
        txtClientName.Text = ""
        txtClientPhone.Text = ""
        txtClientAddress.Text = ""
        txtReturnedBy.Text = ""
        txtReceivedBy.Text = ""


        btnSave.Enabled = False
        btnApprove.Enabled = False

        txtClaimNo.Text = (New CustomerClaim).generateClaimNo()

        dtgrdClaimDetails.Rows.Clear()
        dtgrdClaimReplacements.Rows.Clear()
    End Sub

    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbclaimDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbClaimDescription.KeyUp
        Dim currentText As String = cmbClaimDescription.Text
        shortList.Clear()
        cmbClaimDescription.Items.Clear()
        cmbClaimDescription.Items.Add(currentText)
        cmbClaimDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbClaimDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbClaimDescription.Items.AddRange(shortList.ToArray())
        cmbClaimDescription.SelectionStart = cmbClaimDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub cmbEndDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbReplacementDescription.KeyUp
        Dim currentText As String = cmbReplacementDescription.Text
        shortList.Clear()
        cmbReplacementDescription.Items.Clear()
        cmbReplacementDescription.Items.Add(currentText)
        cmbReplacementDescription.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbReplacementDescription.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbReplacementDescription.Items.AddRange(shortList.ToArray())
        cmbReplacementDescription.SelectionStart = cmbReplacementDescription.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Function search()
        If txtClaimNo.Text = "" Then
            MsgBox("Can not process claim. Please specify whether the claim is new or existing by selecting New or Edit", vbOKOnly + vbCritical, "Invalid operation")
            Return vbNull
            Exit Function
        End If
        If txtClaimNo.ReadOnly = False Then
            Dim claim As New CustomerClaim
            If claim.getCustomerClaim(txtClaimNo.Text) = True Then
                txtId.Text = claim.GL_ID
                txtIssueNo.Text = claim.GL_ISSUE_NO
                txtInvoiceNo.Text = claim.GL_INVOICE_NO
                txtClientName.Text = claim.GL_CUSTOMER_NAME
                txtClientPhone.Text = claim.GL_CUSTOMER_PHONE
                txtClientAddress.Text = claim.GL_CUSTOMER_ADDRESS
                txtReturnedBy.Text = claim.GL_RETURNED_BY
                txtReceivedBy.Text = claim.GL_RECEIVED_BY
                txtOther.Text = claim.GL_OTHER

                txtClaimNo.ReadOnly = True

                txtClaimDate.Text = claim.GL_CLAIM_DATE
                txtSettlementDate.Text = claim.GL_SETTLEMENT_DATE

                txtStatus.Text = claim.GL_STATUS

                'refreshClaimList()
                refreshClaimDetailsList()
                refreshReplacementList()

                If txtId.Text = "" Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                Dim status As String = claim.GL_STATUS

                If status = "APPROVED" Or status = "PRINTED" Or status = "ARCHIVED" Or status = "COMPLETED" Or status = "CANCELED" Then
                    btnApprove.Enabled = False
                ElseIf status = "PENDING" Then
                    btnApprove.Enabled = True
                Else
                    btnApprove.Enabled = False
                End If

                If status = "PENDING" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = False
                    txtClaimItemCode.ReadOnly = False
                    cmbClaimDescription.Enabled = True
                    txtClaimQty.ReadOnly = False
                    txtClaimReason.ReadOnly = False
                    txtClaimRemarks.ReadOnly = False
                    cmbClaimType.Enabled = True

                End If

                If status = "APPROVED" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = True
                    txtClaimItemCode.ReadOnly = True
                    cmbClaimDescription.Enabled = False
                    txtClaimQty.ReadOnly = True
                    txtClaimReason.ReadOnly = True
                    txtClaimRemarks.ReadOnly = True
                    cmbClaimType.Enabled = False

                End If
                If status = "PRINTED" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = True
                    txtClaimItemCode.ReadOnly = True
                    cmbClaimDescription.Enabled = False
                    txtClaimQty.ReadOnly = True
                    txtClaimReason.ReadOnly = True
                    txtClaimRemarks.ReadOnly = True
                    cmbClaimType.Enabled = False

                End If
                If status = "COMPLETED" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = True
                    txtClaimItemCode.ReadOnly = True
                    cmbClaimDescription.Enabled = False
                    txtClaimQty.ReadOnly = True
                    txtClaimReason.ReadOnly = True
                    txtClaimRemarks.ReadOnly = True
                    cmbClaimType.Enabled = False

                End If
                If status = "CANCELED" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = True
                    txtClaimItemCode.ReadOnly = True
                    cmbClaimDescription.Enabled = False
                    txtClaimQty.ReadOnly = True
                    txtClaimReason.ReadOnly = True
                    txtClaimRemarks.ReadOnly = True
                    cmbClaimType.Enabled = False

                End If
                If status = "ARCHIVED" Then
                    txtClaimNo.ReadOnly = True

                    txtClaimBarCode.ReadOnly = True
                    txtClaimItemCode.ReadOnly = True
                    cmbClaimDescription.Enabled = False
                    txtClaimQty.ReadOnly = True
                    txtClaimReason.ReadOnly = True
                    txtClaimRemarks.ReadOnly = True
                    cmbClaimType.Enabled = False

                End If

            Else
                MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
                Return vbNull
                Exit Function
            End If
        End If

        Return vbNull
    End Function

    Private Sub clearClaimFields()
        txtClaimId.Text = ""
        txtClaimBarCode.Text = ""
        txtClaimItemCode.Text = ""
        cmbClaimDescription.SelectedItem = Nothing
        cmbClaimDescription.Text = ""
        txtClaimQty.Text = ""
        txtClaimPrice.Text = ""
        txtClaimReason.Text = ""
        txtClaimRemarks.Text = ""
        cmbClaimType.SelectedItem = Nothing
        cmbClaimType.Text = ""
    End Sub
    Private Sub clearReplacementFields()
        txtReplacementId.Text = ""
        txtReplacementBarcode.Text = ""
        txtReplacementItemCode.Text = ""
        cmbReplacementDescription.SelectedItem = Nothing
        cmbReplacementDescription.Text = ""
        txtReplacementQty.Text = ""
        txtreplacementPrice.Text = ""
    End Sub
    Private Sub unlockClaimFields()
        txtClaimBarCode.ReadOnly = False
        txtClaimItemCode.ReadOnly = False
        cmbClaimDescription.Enabled = True
        cmbClaimDescription.SelectedItem = Nothing
        txtClaimReason.ReadOnly = False
        txtClaimRemarks.ReadOnly = False
        cmbClaimType.Enabled = True
        cmbClaimType.SelectedItem = Nothing
    End Sub
    Private Sub lockclaimFields()
        txtClaimBarCode.ReadOnly = True
        txtClaimItemCode.ReadOnly = True
        cmbClaimDescription.Enabled = False
        txtClaimReason.ReadOnly = True
        txtClaimRemarks.ReadOnly = True
        cmbClaimType.Enabled = False
    End Sub
    Private Sub unlockReplacementFields()
        txtReplacementBarcode.ReadOnly = False
        txtReplacementItemCode.ReadOnly = False
        cmbReplacementDescription.Enabled = True
    End Sub
    Private Sub lockReplacementFields()
        txtReplacementBarcode.ReadOnly = True
        txtReplacementItemCode.ReadOnly = True
        cmbReplacementDescription.Enabled = False
    End Sub

    Private Sub btnClaimAdd_Click(sender As Object, e As EventArgs) Handles btnClaimAdd.Click
        txtClaimNo.ReadOnly = True
        If txtClaimNo.Text = "" Then
            MsgBox("Select new")
            clearClaimFields()
            Exit Sub
        End If
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If
        'If cmbSalesPersons.Text = "" Then
        'MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
        'Exit Sub
        'End If
        Dim claimBarcode As String = txtClaimBarCode.Text
        Dim claimItemCode As String = txtClaimItemCode.Text
        Dim claimDescription As String = cmbClaimDescription.Text
        Dim claimQty As String = txtClaimQty.Text
        Dim claimPrice As String = txtClaimPrice.Text
        Dim claimReason As String = txtClaimReason.Text
        Dim claimRemarks As String = txtClaimRemarks.Text
        Dim claimType As String = cmbClaimType.Text

        If claimItemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If
        If Val(claimQty) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If
        If txtClaimReason.Text = "" Then
            MsgBox("Reason required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If
        If cmbClaimType.Text = "" Then
            MsgBox("Claim type required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If

        Dim claim As CustomerClaim
        If txtId.Text = "" Then
            claim = New CustomerClaim
            claim.GL_CLAIM_NO = txtClaimNo.Text
            claim.GL_CLAIM_DATE = (New Day).getCurrentDay.ToString("yyyy-MM-dd")
            claim.GL_SETTLEMENT_DATE = ""
            claim.GL_STATUS = "PENDING"
            claim.GL_INVOICE_NO = txtInvoiceNo.Text
            claim.GL_ISSUE_NO = txtIssueNo.Text
            claim.GL_CUSTOMER_NAME = txtClientName.Text
            claim.GL_CUSTOMER_PHONE = txtClientPhone.Text
            claim.GL_CUSTOMER_ADDRESS = txtClientAddress.Text
            claim.GL_RECEIVED_BY = txtReceivedBy.Text
            claim.GL_RETURNED_BY = txtReturnedBy.Text
            claim.GL_OTHER = txtOther.Text
            If claim.addNewClaim() = True Then
                claim.getCustomerClaim(txtClaimNo.Text)
                txtId.Text = claim.GL_ID
                btnSave.Enabled = True
            End If
        End If
        claim = New CustomerClaim
        claim.GL_ID = txtId.Text
        claim.GL_CLAIM_SN = txtClaimId.Text
        claim.GL_CLAIM_NO = txtClaimNo.Text
        claim.GL_CLAIM_ITEM_CODE = claimItemCode
        claim.GL_CLAIM_DESCRIPTION = claimDescription
        claim.GL_CLAIM_QTY = Math.Round((Val(claimQty)), 2, MidpointRounding.AwayFromZero)
        claim.GL_CLAIM_PRICE = claimPrice
        claim.GL_CLAIM_REASON = claimReason
        claim.GL_CLAIM_REMARKS = claimRemarks
        claim.GL_CLAIM_TYPE = claimType


        If txtClaimId.Text = "" Then
            claim.addClaimDetail()
        Else
            claim.editClaimDetail(txtClaimId.Text)
        End If


        btnApprove.Enabled = True

        refreshClaimList()
        refreshClaimDetailsList()
        refreshReplacementList()

        clearClaimFields()
        unlockClaimFields()
        Exit Sub
    End Sub
    Private Sub refreshClaimList()
        dtgrdClaimList.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id`,
                                            `claim_no`,
                                            `claim_date`,
                                            `settlement_date`,
                                            `status`, 
                                            `customer_name`, 
                                            `customer_phone`,
                                            `customer_address`, 
                                            `issue_no`, 
                                            `invoice_no`, 
                                            `other`,
                                            `returned_by`,
                                            `received_by`
                                        FROM 
                                            `customer_claims`
                                        WHERE 
                                            `status`='PENDING' OR `status`='PRINTED' OR `status`='COMPLETED' OR `status`='APPROVED'"
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
                dtgrdCell.Value = reader.GetString("claim_no")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("claim_date")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("status")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdClaimList.Rows.Add(dtgrdRow)

            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function refreshClaimDetailsList()
        dtgrdClaimDetails.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT
                                        `id`,
                                        `item_code`, 
                                        `description`,
                                        `qty`,
                                        `price`,
                                        `reason`,
                                        `remarks`, 
                                        `claim_type`,
                                        `claim_id` 
                                        FROM
                                            `claim_details`
                                        WHERE
                                            `claim_id`='" + txtId.Text + "'"
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

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(reader.GetString("qty") * Val(reader.GetString("price")).ToString)))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("claim_type")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("reason")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("remarks")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("id")
                dtgrdRow.Cells.Add(dtgrdCell)



                dtgrdClaimDetails.Rows.Add(dtgrdRow)
            End While

            conn.Close()
            'txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Function refreshReplacementList()
        dtgrdClaimReplacements.Rows.Clear()
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT 
                                        `id`, 
                                        `item_code`, 
                                        `description`, 
                                        `qty`,
                                        `price`,
                                        `claim_id`
                                    FROM 
	                                    `claim_replacement_details`
                                    WHERE 
	                                    `claim_id`='" + txtId.Text + "'"
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

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue((Val(reader.GetString("qty") * Val(reader.GetString("price")).ToString)))
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = reader.GetString("id")
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdClaimReplacements.Rows.Add(dtgrdRow)
            End While

            conn.Close()
            'txtTotalAmountIssued.Text = LCurrency.displayValue(amountIssued.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function

    Private Sub frmCustomerClaim_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        refreshClaimList()

        Dim item As New Item
        longList = item.getItems()
    End Sub

    Private Sub btnclaimSearchItem_Click(sender As Object, e As EventArgs) Handles btnClaimSearchItem.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim barCode As String = txtClaimBarCode.Text
        Dim itemCode As String = txtClaimItemCode.Text
        Dim descr As String = cmbClaimDescription.Text

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
                txtClaimItemCode.Text = reader.GetString("item_code")
                cmbClaimDescription.Text = reader.GetString("item_long_description")
                txtClaimPrice.Text = reader.GetString("retail_price")
                'txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                valid = True
                btnClaimAdd.Enabled = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                btnClaimAdd.Enabled = False
            Else
                txtClaimBarCode.ReadOnly = True
                txtClaimItemCode.ReadOnly = True
                cmbClaimDescription.Enabled = False
                btnClaimAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnclaimReset_Click(sender As Object, e As EventArgs) Handles btnClaimReset.Click
        clearClaimFields()
        cmbClaimDescription.Enabled = True
        txtClaimBarCode.ReadOnly = False
        txtClaimItemCode.ReadOnly = False
        btnClaimAdd.Enabled = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtId.Text = ""
        txtClaimNo.Text = ""
        txtClaimDate.Text = ""
        txtSettlementDate.Text = ""
        txtStatus.Text = ""
        txtClientName.Text = ""
        txtClientPhone.Text = ""
        txtClientAddress.Text = ""
        txtIssueNo.Text = ""
        txtInvoiceNo.Text = ""
        txtOther.Text = ""
        txtReceivedBy.Text = ""
        txtReturnedBy.Text = ""

        txtClaimBarCode.Text = ""
        txtClaimItemCode.Text = ""
        cmbClaimDescription.Text = ""
        txtClaimPrice.Text = ""
        txtClaimQty.Text = ""

        'lock
        txtClaimNo.ReadOnly = True

        'unlock

        btnSave.Enabled = False

        dtgrdClaimDetails.Rows.Clear()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        ' If User.authorize("EDIT PACKING LIST") = True Then


        '  Else
        'MsgBox("Action denied for current user.", vbOKOnly + vbExclamation, "Action denied")
        'Exit Sub
        ' End If

        If txtId.Text = "" Then
            btnSave.Enabled = False
            txtClaimNo.ReadOnly = False
            txtClaimNo.Text = ""
            txtClaimDate.Text = ""
            txtStatus.Text = ""
        Else
            btnSave.Enabled = True
            txtClaimNo.ReadOnly = True
        End If

    End Sub

    Private Function validateInputs() As Boolean
        Dim valid As Boolean = True
        If txtClaimNo.Text = "" Then
            valid = False
            MsgBox("Operation failed, claim no required", vbOKOnly + vbCritical, "Error: Missing information")
            Return valid
            Exit Function
        End If

        Return valid
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtClaimNo.Text = "" Then
            MsgBox("Please select document")
            Exit Sub
        End If
        If dtgrdClaimDetails.RowCount = 0 Then
            MsgBox("Could not save, there are no product(s) to convert")
            Exit Sub
        End If
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "CANCELED" Or status = "COMPLETED" Or status = "ARCHIVED" Then
            MsgBox("Could not modify. Only Pending, Approved or Printed documents can be modified", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        'validate entries
        If validateInputs() = False Then
            Exit Sub
        End If
        Dim claim As New CustomerClaim
        claim.GL_CLAIM_NO = txtClaimNo.Text
        claim.GL_CLAIM_DATE = txtClaimDate.Text

        claim.GL_ISSUE_NO = txtIssueNo.Text
        claim.GL_INVOICE_NO = txtInvoiceNo.Text
        claim.GL_CUSTOMER_NAME = txtClientName.Text
        claim.GL_CUSTOMER_PHONE = txtClientPhone.Text
        claim.GL_CUSTOMER_ADDRESS = txtClientAddress.Text
        claim.GL_RETURNED_BY = txtReturnedBy.Text
        claim.GL_RECEIVED_BY = txtReceivedBy.Text
        claim.GL_OTHER = txtOther.Text

        claim.GL_STATUS = txtStatus.Text


        'check if new or existing 

        If txtId.Text = "" Then
            'save a new record
            If claim.addNewClaim() = True Then
                claim.getCustomerClaim(txtClaimNo.Text)
                MsgBox("Save success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Saving failed", vbOKOnly + vbExclamation, "Failure")
            End If
        Else
            'save an existing record

            If claim.editClaim(txtClaimNo.Text) = True Then
                claim.getCustomerClaim(txtClaimNo.Text)
                MsgBox("Edit success", vbOKOnly + vbInformation, "Success")
            Else
                MsgBox("Editing failed", vbOKOnly + vbExclamation, "Failure")
            End If
        End If
    End Sub
    Private Sub dtgrdClaimDetails_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdClaimDetails.RowHeaderMouseDoubleClick

        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)

        If status = "PENDING" Then
            'continue delete
        Else
            MsgBox("Can not delete item, not a pending claim", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Remove item from list?", vbYesNoCancel + vbQuestion, "Remove item")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdClaimDetails.CurrentRow.Index


        Dim sn As String = dtgrdClaimDetails.Item(8, row).Value


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `claim_details` WHERE `id`='" + sn + "'"
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
        clearClaimFields()
        refreshClaimDetailsList()

    End Sub
    Private Sub dtgrdreplacementItems_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdClaimReplacements.RowHeaderMouseDoubleClick

        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)

        If status = "PENDING" Then
            'continue delete
        Else
            MsgBox("Can not delete item, not a pending claim", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        Dim res As Integer = MsgBox("Remove item from list?", vbYesNoCancel + vbQuestion, "Remove item")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdClaimReplacements.CurrentRow.Index


        Dim sn As String = dtgrdClaimReplacements.Item(5, row).Value


        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "DELETE FROM `claim_replacement_details` WHERE `id`='" + sn + "'"
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

        clearReplacementFields()
        refreshReplacementList()

    End Sub
    Private Sub dtgrdItemToConvert_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdClaimDetails.RowHeaderMouseClick

        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearClaimFields()
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdClaimDetails.CurrentRow.Index

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim itemCode As String = dtgrdClaimDetails.Item(0, row).Value
        Dim description As String = dtgrdClaimDetails.Item(1, row).Value
        Dim qty As String = dtgrdClaimDetails.Item(2, row).Value
        Dim price As String = dtgrdClaimDetails.Item(3, row).Value
        Dim claimType As String = dtgrdClaimDetails.Item(5, row).Value
        Dim reason As String = dtgrdClaimDetails.Item(6, row).Value
        Dim remarks As String = dtgrdClaimDetails.Item(7, row).Value
        Dim sn As String = dtgrdClaimDetails.Item(8, row).Value


        Dim dtgrdRow As New DataGridViewRow

        txtClaimItemCode.Text = itemCode
        cmbClaimDescription.Text = description
        txtClaimPrice.Text = LCurrency.getValue(price)
        txtClaimQty.Text = qty
        cmbClaimType.Text = claimType
        txtClaimReason.Text = reason
        txtClaimRemarks.Text = remarks
        txtClaimId.Text = sn


        If status = "PENDING" Then
            'lock
            txtClaimBarCode.ReadOnly = True
            txtClaimItemCode.ReadOnly = True
            cmbClaimDescription.Enabled = False

            'unlock
            txtClaimQty.ReadOnly = False
            txtClaimReason.ReadOnly = False
            txtClaimRemarks.ReadOnly = False
            cmbClaimType.Enabled = True

            btnClaimAdd.Enabled = True
        End If
        If status = "APPROVED" Then
            'lock
            txtClaimBarCode.ReadOnly = True
            txtClaimItemCode.ReadOnly = True
            cmbClaimDescription.Enabled = False


            txtClaimQty.ReadOnly = True
            txtClaimReason.ReadOnly = True
            txtClaimRemarks.ReadOnly = True
            cmbClaimType.Enabled = False

            btnClaimAdd.Enabled = False
        End If
        If status = "PRINTED" Then
            'lock
            txtClaimBarCode.ReadOnly = True
            txtClaimItemCode.ReadOnly = True
            cmbClaimDescription.Enabled = False

            txtClaimQty.ReadOnly = True
            txtClaimReason.ReadOnly = True
            txtClaimRemarks.ReadOnly = True
            cmbClaimType.Enabled = False

            'unlock

            btnClaimAdd.Enabled = True
        End If
        If status = "COMPLETED" Then
            'lock
            txtClaimBarCode.ReadOnly = True
            txtClaimItemCode.ReadOnly = True
            cmbClaimDescription.Enabled = False

            txtClaimQty.ReadOnly = True
            txtClaimReason.ReadOnly = True
            txtClaimRemarks.ReadOnly = True
            cmbClaimType.Enabled = False

            btnClaimAdd.Enabled = False
            'unlock

        End If
        refreshClaimList()
    End Sub
    Private Sub dtgrdEndItems_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdClaimReplacements.RowHeaderMouseClick

        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If

        Dim row As Integer = -1
        row = dtgrdClaimReplacements.CurrentRow.Index

        'Dim barCode As String = dtgrdItemList.Item(0, row).Value
        Dim replacementItemCode As String = dtgrdClaimReplacements.Item(0, row).Value
        Dim replacementDescription As String = dtgrdClaimReplacements.Item(1, row).Value
        Dim replacementQty As String = dtgrdClaimReplacements.Item(2, row).Value
        Dim replacementPrice As String = LCurrency.getValue(dtgrdClaimReplacements.Item(3, row).Value)
        Dim replacementId As String = dtgrdClaimReplacements.Item(5, row).Value


        Dim dtgrdRow As New DataGridViewRow

        txtReplacementId.Text = replacementId
        txtReplacementItemCode.Text = replacementItemCode
        cmbReplacementDescription.Text = replacementDescription
        txtreplacementPrice.Text = replacementPrice
        txtReplacementQty.Text = replacementQty


        If status = "PENDING" Then
            'lock
            txtReplacementBarcode.ReadOnly = True
            txtReplacementItemCode.ReadOnly = True
            cmbReplacementDescription.Enabled = False

            'unlock
            txtReplacementQty.ReadOnly = False

            btnReplacementAdd.Enabled = True
        End If
        If status = "APPROVED" Then
            'lock
            txtReplacementBarcode.ReadOnly = True
            txtReplacementItemCode.ReadOnly = True
            cmbReplacementDescription.Enabled = False


            txtReplacementQty.ReadOnly = True

            btnReplacementAdd.Enabled = False
        End If
        If status = "PRINTED" Then
            'lock
            txtReplacementBarcode.ReadOnly = True
            txtReplacementItemCode.ReadOnly = True
            cmbReplacementDescription.Enabled = False
            txtReplacementQty.ReadOnly = True

            'unlock

            btnReplacementAdd.Enabled = True
        End If
        If status = "COMPLETED" Then
            'lock
            txtReplacementBarcode.ReadOnly = True
            txtReplacementItemCode.ReadOnly = True
            cmbReplacementDescription.Enabled = False
            txtReplacementQty.ReadOnly = True


            btnReplacementAdd.Enabled = False
            'unlock

        End If
        refreshReplacementList()
    End Sub
    Private Sub dtgrdCustomerClaims_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdClaimList.CellClick
        Dim r As Integer = dtgrdClaimList.CurrentRow.Index
        Dim claimNo As String = dtgrdClaimList.Item(0, r).Value.ToString
        txtClaimNo.Text = claimNo
        txtClaimNo.ReadOnly = False
        search()
    End Sub

    Private Sub txtclaimQty_TextChanged(sender As Object, e As EventArgs) Handles txtClaimQty.TextChanged
        If Not IsNumeric(txtClaimQty.Text) Or txtClaimQty.Text.Contains("-") Or Val(txtClaimQty.Text) < 0 Then
            txtClaimQty.Text = ""
        End If
    End Sub

    Private Sub btnEndSearchItem_Click(sender As Object, e As EventArgs) Handles btnReplacementSearch.Click
        Dim found As Boolean = False
        Dim valid As Boolean = False
        Dim replacementbarCode As String = txtReplacementBarcode.Text
        Dim replacementitemCode As String = txtReplacementItemCode.Text
        Dim replacementdescr As String = cmbReplacementDescription.Text

        If replacementbarCode <> "" Then
            replacementitemCode = (New Item).getItemCode(replacementbarCode, "")
        ElseIf replacementitemCode <> "" Then
            replacementitemCode = replacementitemCode
        ElseIf replacementdescr <> "" Then
            replacementitemCode = (New Item).getItemCode("", replacementdescr)
        Else
            replacementitemCode = ""
        End If

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code`, `item_long_description`, `pck`,`unit_cost_price`, `retail_price`,`vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_code`='" + replacementitemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtReplacementItemCode.Text = reader.GetString("item_code")
                cmbReplacementDescription.Text = reader.GetString("item_long_description")
                txtreplacementPrice.Text = reader.GetString("retail_price")
                'txtStockSize.Text = (New Inventory).getInventory(reader.GetString("item_code"))
                found = True
                valid = True
                btnReplacementAdd.Enabled = True
                Exit While
            End While
            conn.Close()
            If found = False Then
                MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                btnReplacementAdd.Enabled = False
            Else
                txtReplacementBarcode.ReadOnly = True
                txtReplacementItemCode.ReadOnly = True
                cmbReplacementDescription.Enabled = False
                btnReplacementAdd.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnreplacementAdd_Click(sender As Object, e As EventArgs) Handles btnReplacementAdd.Click
        If txtId.Text = "" Then
            MsgBox("Operation failed, please select New", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If
        txtClaimNo.ReadOnly = True

        If txtClaimNo.Text = "" Then
            MsgBox("Select new")
            clearReplacementFields()
            Exit Sub
        End If
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "APPROVED" Then
            MsgBox("Could not edit, document already approved", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If
        If status = "COMPLETED" Then
            MsgBox("Could not edit, document already completed", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If
        If status = "CANCELED" Then
            MsgBox("Could not edit, document has been canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            clearReplacementFields()
            Exit Sub
        End If
        'If cmbSalesPersons.Text = "" Then
        'MsgBox("Could not add item, sales person required", vbOKOnly + vbCritical, "Error: Missing Information")
        'Exit Sub
        'End If
        Dim replacementBarCode As String = txtReplacementBarcode.Text
        Dim replacementItemCode As String = txtReplacementItemCode.Text
        Dim replacementDescription As String = cmbReplacementDescription.Text

        Dim replacementQty As String = txtReplacementQty.Text
        Dim replacementPrice As String = txtreplacementPrice.Text
        If replacementItemCode = "" Then
            MsgBox("Item required", vbOKOnly + vbCritical, "Error: Missing information")
            Exit Sub
        End If
        If Val(replacementQty) <= 0 Then
            MsgBox("Could not add item. Invalid issue qty, qty should be non-negative", vbOKOnly + vbCritical, "Error: Invalid entry")
            Exit Sub
        End If

        Dim claim As CustomerClaim
        If txtId.Text = "" Then
            MsgBox("Claim required")
            Exit Sub
        End If
        claim = New CustomerClaim

        claim.GL_ID = txtId.Text
        claim.GL_CLAIM_NO = txtClaimNo.Text
        claim.GL_REPLACEMENT_ITEM_CODE = replacementItemCode
        claim.GL_REPLACEMENT_DESCRIPTION = replacementDescription
        claim.GL_REPLACEMENT_QTY = Math.Round((Val(replacementQty)), 2, MidpointRounding.AwayFromZero)
        claim.GL_REPLACEMENT_PRICE = replacementPrice

        If txtReplacementId.Text = "" Then
            claim.addReplacement()
        Else
            claim.editReplacement(txtReplacementId.Text)
        End If
        btnApprove.Enabled = True
        refreshClaimList()
        refreshReplacementList()

        clearReplacementFields()
        unlockReplacementFields()
        Exit Sub
    End Sub

    Private Sub btnReplacementReset_Click(sender As Object, e As EventArgs) Handles btnReplacementReset.Click
        txtReplacementBarcode.Text = ""
        txtReplacementItemCode.Text = ""
        cmbReplacementDescription.Text = ""
        txtreplacementPrice.Text = ""
        txtReplacementQty.Text = ""
        cmbReplacementDescription.Enabled = True
        txtReplacementBarcode.ReadOnly = False
        txtReplacementItemCode.ReadOnly = False
        btnReplacementAdd.Enabled = False
    End Sub

    Private Sub txtReplacementQty_TextChanged(sender As Object, e As EventArgs) Handles txtReplacementQty.TextChanged
        If Not IsNumeric(txtReplacementQty.Text) Or txtReplacementQty.Text.Contains("-") Or Val(txtReplacementQty.Text) < 0 Then
            txtReplacementQty.Text = ""
        End If
    End Sub

    Private Sub cmbclaimDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClaimDescription.SelectedIndexChanged

    End Sub

    Private Sub dtgrdClaimList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdClaimList.CellContentClick

    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
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
            If txtClaimNo.Text = "" Then
                MsgBox("Select a claim document to approve", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Approve client claim: " + txtClaimNo.Text + " ? Editing will be disabled after approval", vbYesNo + vbQuestion, "Approve document?")
            If res = DialogResult.Yes Then
                'approve order

                If dtgrdClaimDetails.RowCount = 0 Or dtgrdClaimReplacements.RowCount = 0 Then
                    MsgBox("Could not approve, document has an empty list", vbOKOnly + vbExclamation, "Error: Invalid operation")
                    Exit Sub
                End If
                Dim claim As CustomerClaim = New CustomerClaim
                If claim.approveClaim(txtClaimNo.Text) = True Then
                    MsgBox("Approve Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Approve failed", vbOKOnly + vbExclamation, "Failure")
                End If

            End If
            txtStatus.Text = (New CustomerClaim).getStatus(txtClaimNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation)
        End If
        refreshClaimList()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status = "PENDING" Or status = "APPROVED" Then
            'continue
        Else
            MsgBox("Can not cancel, only Pending or Approved claim documents can be canceled", vbOKOnly + vbCritical, "Error: Invalid operation")
            Exit Sub
        End If

        If 1 = 1 Then ' User.authorize("APPROVE PACKING LIST") = True Then
            If txtClaimNo.Text = "" Then
                MsgBox("Select a claim to cancel", vbOKOnly + vbExclamation, "Error: No selection")
                Exit Sub
            End If
            Dim res As Integer = MsgBox("Cancel claim document: " + txtClaimNo.Text + " ? Claim document can not be used after canceling", vbYesNo + vbQuestion, "Cancel document?")
            If res = DialogResult.Yes Then

                Dim claim As CustomerClaim = New CustomerClaim
                If claim.cancelClaim(txtClaimNo.Text) = True Then
                    MsgBox("Cancel Success", vbOKOnly + vbInformation, "Success")
                Else
                    MsgBox("Cancel failed", vbOKOnly + vbExclamation, "Failed")
                End If



            End If
            txtStatus.Text = (New CustomerClaim).getStatus(txtClaimNo.Text)
        Else
            MsgBox("Access denied!", vbOKOnly + vbExclamation, "Error: Access denied")
        End If
        refreshClaimList()
    End Sub


    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If txtClaimNo.Text = "" Then
            MsgBox("Select a claim document to complete", vbOKOnly + vbExclamation, "Error: No selection")
            Exit Sub
        End If
        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        If status <> "APPROVED" Then
            MsgBox("Operation failed, Only approved documents can be completed", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If


        Dim res As Integer = MsgBox("Settle claim? Returned products will be returned to stock and replaced products will be removed from stock", vbYesNoCancel + vbQuestion, "Settle claim?")
        If Not res = DialogResult.Yes Then
            Exit Sub
        End If

        For i As Integer = 0 To dtgrdClaimReplacements.RowCount - 1

            Dim itemCode As String = dtgrdClaimReplacements.Item(0, i).Value
            Dim qty As String = dtgrdClaimReplacements.Item(2, i).Value
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
                    stockCard.qtyOut(Day.DAY, itemCode, qty, inventory.getInventory(itemCode), "Replaced in client claim, Claim No: " + txtClaimNo.Text)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next


        Dim claim As CustomerClaim = New CustomerClaim
        If claim.completeClaim(txtClaimNo.Text) = True Then
            MsgBox("Complete Success", vbOKOnly + vbInformation, "Success")
        Else
            MsgBox("Complete failed", vbOKOnly + vbExclamation, "Failure")
        End If

        txtStatus.Text = (New CustomerClaim).getStatus(txtClaimNo.Text)

        refreshClaimList()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim status As String = (New CustomerClaim).getStatus(txtId.Text)
        If status = "APPROVED" Or status = "COMPLETED" Or status = "PRINTED" Or status = "ARCHIVED" Then
            'Dim res As Integer = MsgBox("Print claim sheet " + txtClaimNo.Text + " ?", vbYesNo + vbQuestion, "Print claim sheet?")
            ' If res = DialogResult.Yes Then
            'Dim conv As New CustomerClaim
            'conv.printClaim(txtClaimNo.Text)''this option should not be there
            'MsgBox("Print success", vbOKOnly + vbInformation, "Success")
            'End If
            ' ElseIf status = "COMPLETED" Or status = "PRINTED" Or status = "ARCHIVED" Then

            'print documemnt only
        Else

            MsgBox("Could not print, document not approved or has been canceled", vbOKOnly + vbExclamation, "Error: Invalid operation")
            Exit Sub
        End If

        txtClaimNo.ReadOnly = False
        search()
        refreshClaimList()
        refreshReplacementList()



        Dim document As Document = New Document

        document.Info.Title = "Claim"
        document.Info.Subject = "Claim"
        document.Info.Author = "Orbit"

        defineStyles(document)
        createDocument(document)

        Dim myRenderer As PdfDocumentRenderer = New PdfDocumentRenderer(True)
        myRenderer.Document = document
        myRenderer.RenderDocument()

        Dim filename As String = LSystem.getRoot & "\Claim " & txtClaimNo.Text & ".pdf"

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
        documentTitle.AddText("Customer Claim")
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
        paragraph.AddFormattedText("Claim No: " + txtClaimNo.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Claim Date: " + txtClaimDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Settlement Date: " + txtSettlementDate.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Client Name: " + txtClientName.Text)
        paragraph.Format.Font.Size = 8
        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Contacts: " + txtClientAddress.Text + "  " + txtClientPhone.Text)
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
        paragraph.AddFormattedText("Claimed Products")
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

        column = table.AddColumn("0.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Left

        column = table.AddColumn("5.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("1.5cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.0cm")
        column.Format.Alignment = ParagraphAlignment.Right

        column = table.AddColumn("2.3cm")
        column.Format.Alignment = ParagraphAlignment.Right

        'Create the header of the table
        Dim row As Row

        row = table.AddRow()
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
        row.Cells(5).AddParagraph("Amount")
        row.Cells(5).Format.Alignment = ParagraphAlignment.Left
        row.Cells(6).AddParagraph("Reason")
        row.Cells(6).Format.Alignment = ParagraphAlignment.Left
        row.Cells(7).AddParagraph("Remarks")
        row.Cells(7).Format.Alignment = ParagraphAlignment.Left
        row.Cells(8).AddParagraph("Type")
        row.Cells(8).Format.Alignment = ParagraphAlignment.Left

        table.SetEdge(0, 0, 9, 1, Tables.Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim status As String = (New CustomerClaim).getStatus(txtClaimNo.Text)
        Dim sn As Integer = 0
        Dim itemCode As String = ""
        Dim description As String = ""
        Dim price As String = ""
        Dim qty As String = ""
        Dim amount As String = ""
        Dim reason As String = ""
        Dim remarks As String = ""
        Dim type As String = ""


        For i As Integer = 0 To dtgrdClaimDetails.RowCount - 1

            sn = sn + 1
            itemCode = dtgrdClaimDetails.Item(0, i).Value
            description = dtgrdClaimDetails.Item(1, i).Value
            qty = dtgrdClaimDetails.Item(2, i).Value
            price = dtgrdClaimDetails.Item(3, i).Value
            amount = LCurrency.displayValue((Val(LCurrency.getValue(price)) * Val(qty)).ToString)
            reason = dtgrdClaimDetails.Item(6, i).Value
            remarks = dtgrdClaimDetails.Item(7, i).Value
            type = dtgrdClaimDetails.Item(5, i).Value


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
            row.Cells(5).AddParagraph(amount)
            row.Cells(5).Format.Alignment = ParagraphAlignment.Right
            row.Cells(6).AddParagraph(reason)
            row.Cells(6).Format.Alignment = ParagraphAlignment.Left
            row.Cells(7).AddParagraph(remarks)
            row.Cells(7).Format.Alignment = ParagraphAlignment.Left
            row.Cells(8).AddParagraph(type)
            row.Cells(8).Format.Alignment = ParagraphAlignment.Left



            table.SetEdge(0, 0, 9, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)
        Next

        paragraph = section.AddParagraph()

        paragraph = section.AddParagraph()
        paragraph.AddFormattedText("Replacement Products")
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

        column3 = table3.AddColumn("0.5cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("1.5cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("5.0cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("1.0cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("1.5cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        column3 = table3.AddColumn("2.0cm")
        column3.Format.Alignment = ParagraphAlignment.Left

        'Create the header of the table
        Dim row3 As Row

        row3 = table3.AddRow()
        row3.Format.Font.Bold = False
        row3.HeadingFormat = True
        row3.Format.Font.Size = 8
        row3.Format.Alignment = ParagraphAlignment.Center
        row3.Format.Font.Bold = True
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
        row3.Cells(5).AddParagraph("Amount")
        row3.Cells(5).Format.Alignment = ParagraphAlignment.Left

        table3.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

        Dim j As Integer
        sn = 0
        For j = 0 To dtgrdClaimReplacements.RowCount - 1

            sn = sn + 1
            itemCode = dtgrdClaimReplacements.Item(0, j).Value
            description = dtgrdClaimReplacements.Item(1, j).Value
            qty = dtgrdClaimReplacements.Item(2, j).Value
            price = dtgrdClaimReplacements.Item(3, j).Value
            amount = LCurrency.displayValue((Val(LCurrency.getValue(price)) * Val(qty)).ToString)

            row3 = table3.AddRow()
            row3.Format.Font.Bold = False
            row3.HeadingFormat = True
            row3.Format.Font.Size = 8
            row3.Format.Alignment = ParagraphAlignment.Center
            row3.Borders.Color = Colors.LightGray
            row3.Cells(0).AddParagraph(sn.ToString)
            row3.Cells(0).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(1).AddParagraph(itemCode)
            row3.Cells(1).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(2).AddParagraph(description)
            row3.Cells(2).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(3).AddParagraph(qty)
            row3.Cells(3).Format.Alignment = ParagraphAlignment.Left
            row3.Cells(4).AddParagraph(price)
            row3.Cells(4).Format.Alignment = ParagraphAlignment.Right
            row3.Cells(5).AddParagraph(amount)
            row3.Cells(5).Format.Alignment = ParagraphAlignment.Right
        Next

        table3.SetEdge(0, 0, 6, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty)

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