Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmCorporateCustomers
    Private Function clearFields()
        txtId.Text = ""
        txtNo.Text = ""
        cmbName.SelectedItem = Nothing
        cmbName.Text = ""
        txtContactName.Text = ""
        txtTin.Text = ""
        txtVrn.Text = ""
        txtBankAccountName.Text = ""
        txtBankAddress.Text = ""
        txtBankPostCode.Text = ""
        txtBankName.Text = ""
        txtBankAccountNo.Text = ""
        txtPostAddress.Text = ""
        txtPostCode.Text = ""
        txtPhysicalAddress.Text = ""
        txtTelephone.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        chkActive.Checked = False
        txtInvoiceLimit.Text = ""
        txtCreditLimit.Text = ""
        txtCreditDays.Text = ""
        Return vbNull
    End Function
    Private Function lock()
        'txtSupplierCode.ReadOnly = True
        cmbName.Enabled = False
        txtContactName.ReadOnly = True
        txtTin.ReadOnly = True
        txtVrn.ReadOnly = True
        txtBankAccountName.ReadOnly = True
        txtBankAddress.ReadOnly = True
        txtBankPostCode.ReadOnly = True
        txtBankName.ReadOnly = True
        txtBankAccountNo.ReadOnly = True
        txtPostAddress.ReadOnly = True
        txtPostCode.ReadOnly = True
        txtPhysicalAddress.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtMobile.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        chkActive.Enabled = False
        txtInvoiceLimit.ReadOnly = True
        txtCreditLimit.ReadOnly = True
        txtCreditDays.ReadOnly = True
        Return vbNull
    End Function
    Private Function unlock()
        'txtSupplierCode.ReadOnly = False
        cmbName.Enabled = True
        txtContactName.ReadOnly = False
        txtTin.ReadOnly = False
        txtVrn.ReadOnly = False
        txtBankAccountName.ReadOnly = False
        txtBankAddress.ReadOnly = False
        txtBankPostCode.ReadOnly = False
        txtBankName.ReadOnly = False
        txtBankAccountNo.ReadOnly = False
        txtPostAddress.ReadOnly = False
        txtPostCode.ReadOnly = False
        txtPhysicalAddress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtMobile.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        chkActive.Enabled = True
        txtInvoiceLimit.ReadOnly = False
        txtCreditLimit.ReadOnly = False
        txtCreditDays.ReadOnly = False
        Return vbNull
    End Function

    Private Function setValues()
        Return vbNull
    End Function

    Private Function validateFields() As Boolean
        Dim valid As Boolean = True
        Dim error_ As String = ""
        If txtNo.Text = "" Then
            valid = False
            error_ = "Customer No required"
        End If
        If cmbName.Text = "" Then
            valid = False
            error_ = "Customer name required"
        End If
        If txtContactName.Text = "" Then
            valid = False
            error_ = "Contact name required"
        End If
        If txtTin.Text = "" Then
            valid = False
            error_ = "Customer TIN required"
        End If
        If txtVrn.Text = "" Then
            valid = False
            error_ = "Customer VRN required"
        End If
        If valid = False Then
            MsgBox("Operation failed. " + error_, vbOKOnly + vbCritical, "Error: Invalid input")
        End If
        Return valid
    End Function
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Public Shared GLOBAL_SUPPLIER_CODE As String = ""

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        dtgrdCustomerList.Enabled = False
        clearFields() 'clear the fields
        txtNo.ReadOnly = False
        btnDelete.Enabled = False
        btnSearch.Enabled = False
        btnSave.Enabled = True
        unlock()
        txtNo.ReadOnly = True
        txtNo.Text = "NA"
    End Sub
    Private Function search(customerNo As String, customerName As String) As Boolean

        txtId.Text = ""
        If customerNo = "" And customerName = "" Then
            MsgBox("Please specify a record to search. Enter Customer NO or Customer name.", vbOKOnly + vbExclamation, "Error: Search key not specified")
            Return vbNull
            Exit Function
        End If
        txtNo.ReadOnly = True
        cmbName.Enabled = False
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            If customerNo <> "" Then
                response = Web.get_("corporate_customers/get_by_no?no=" + customerNo)
                json = JObject.Parse(response)
            ElseIf customerName <> "" Then
                response = Web.get_("corporate_customers/get_by_name?name=" + customerName)
                json = JObject.Parse(response)
            End If
        Catch ex As Exception
            Return False
            Exit Function
        End Try

        Dim customer As CorporateCustomer = JsonConvert.DeserializeObject(Of CorporateCustomer)(json.ToString)
        If customer.id.ToString = "" Then
            btnDelete.Enabled = False
            MsgBox("No matching record", vbOKOnly + vbCritical, "Error: Not found")
            txtNo.ReadOnly = False
            cmbName.Enabled = True
        Else
            txtId.Text = customer.id
            txtNo.Text = customer.no
            cmbName.Text = customer.name
            txtContactName.Text = customer.contactName
            txtTin.Text = customer.tin
            txtVrn.Text = customer.vrn
            txtPostAddress.Text = customer.postAddress
            txtPostCode.Text = customer.postCode
            txtPhysicalAddress.Text = customer.physicalAddress
            txtTelephone.Text = customer.telephone
            txtMobile.Text = customer.mobile
            txtEmail.Text = customer.email
            txtFax.Text = customer.fax
            txtBankAccountName.Text = customer.bankAccountName
            txtBankPostCode.Text = customer.bankPostCode
            txtBankAddress.Text = customer.bankPostAddress
            txtBankName.Text = customer.bankName
            txtBankAccountNo.Text = customer.bankAccountNo
            txtInvoiceLimit.Text = customer.invoiceLimit
            txtCreditLimit.Text = customer.creditLimit
            txtCreditDays.Text = customer.creditDays


            dtgrdCustomerList.Enabled = True
            btnDelete.Enabled = True
            txtNo.ReadOnly = True
            lock()

            If customer.active = 0 Then
                chkActive.Checked = False
            Else
                chkActive.Checked = True
            End If
        End If

        Return vbNull
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search(txtNo.Text, cmbName.Text)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If validateValues() = False Then
        'stop operation if the values are invalid
        'Exit Sub
        'End If
        Dim customer As CorporateCustomer
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtId.Text = "" Then
            customer = New CorporateCustomer
        Else
            response = Web.get_("corporate_customers/get_by_id?id=" + txtId.Text)
            json = JObject.Parse(response)
            customer = JsonConvert.DeserializeObject(Of CorporateCustomer)(json.ToString)
        End If
        customer.id = txtId.Text
        customer.no = txtNo.Text
        customer.name = cmbName.Text
        customer.contactName = txtContactName.Text
        customer.tin = txtTin.Text
        customer.vrn = txtVrn.Text
        customer.postAddress = txtPostAddress.Text
        customer.postCode = txtPostCode.Text
        customer.physicalAddress = txtPhysicalAddress.Text
        customer.telephone = txtTelephone.Text
        customer.mobile = txtMobile.Text
        customer.email = txtEmail.Text
        customer.fax = txtFax.Text
        customer.bankAccountName = txtBankAccountName.Text
        customer.bankPostCode = txtBankPostCode.Text
        customer.bankPostAddress = txtBankAddress.Text
        customer.bankName = txtBankName.Text
        customer.bankAccountNo = txtBankAccountNo.Text
        customer.invoiceLimit = Val(txtInvoiceLimit.Text)
        customer.creditLimit = Val(txtCreditLimit.Text)
        customer.creditDays = Val(txtCreditDays.Text)
        If chkActive.Checked = True Then
            customer.active = 1
        Else
            customer.active = 0
        End If

        Try
            Dim success As Boolean = False
            If txtId.Text = "" Then
                response = Web.post(customer, "corporate_customers/new")
                json = JObject.Parse(response)
                txtId.Text = json.SelectToken("id")
                success = True
                ' btnSave.Enabled = False

                dtgrdCustomerList.Enabled = True
                refreshList()

                MsgBox("Customer created successifully", vbOKOnly + vbInformation, "Success: Customer saved.")
            Else
                If Web.put(customer, "corporate_customers/edit_by_id?id=" + txtId.Text) = True Then
                    ' btnSave.Enabled = False
                    dtgrdCustomerList.Enabled = True
                    refreshList()
                    MsgBox("Customer successifully modified", vbOKOnly + vbInformation, "Success: Customer modified.")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        btnDelete.Enabled = False
        btnSearch.Enabled = True
        If txtId.Text = "" Then
            txtNo.ReadOnly = False
            btnSave.Enabled = False
        Else
            txtNo.ReadOnly = True
            btnSave.Enabled = True
        End If
        dtgrdCustomerList.Enabled = True
        'clearFields()
        unlock()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected customer? All information about the customer will be removed from the system. This action can not be undone.", vbYesNo + vbQuestion, "Delete Customer")
        If res = DialogResult.Yes Then
            'proceed
        Else
            'discard operation
            Exit Sub
        End If
        Try
            Dim response As String
            response = Web.delete("corporate_customers/delete_by_id?id=" + txtId.Text)
            btnDelete.Enabled = False
            clearFields() 'clear the fields
            refreshList()
            MsgBox("Customer record deleted successifully", vbOKOnly + vbInformation, "Success: Delete customer record")
            Exit Sub
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSupplierCode_TextChanged(sender As Object, e As EventArgs) Handles txtNo.TextChanged
        If txtNo.Text.Contains("'") Then
            txtNo.Text = ""
        End If
    End Sub
    Private Sub txtSupplierCode_preview(sender As Object, e As PreviewKeyDownEventArgs) Handles txtNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            search(txtNo.Text, cmbName.Text)
        End If
    End Sub
    Private Sub txtSupplierCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo.KeyDown
        If Keys.KeyCode = Keys.Down Then
            cmbName.Focus()
        End If

    End Sub

    Private Sub txtSupplierName_KeyDown(sender As Object, e As KeyEventArgs)
        If Keys.KeyCode = Keys.Down Then
            txtContactName.Focus()
        End If

    End Sub

    Private Sub txtContactName_TextChanged(sender As Object, e As EventArgs) Handles txtContactName.TextChanged
        If txtContactName.Text.Contains("'") Then
            txtContactName.Text = ""
        End If
    End Sub

    Private Sub txtContactName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactName.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtTin.Focus()
        End If

    End Sub

    Private Sub txtTIN_TextChanged(sender As Object, e As EventArgs) Handles txtTin.TextChanged
        If txtTin.Text.Contains("'") Then
            txtTin.Text = ""
        End If
    End Sub

    Private Sub txtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTin.KeyDown
        If Keys.KeyCode = Keys.Down Then
            txtVrn.Focus()
        End If

    End Sub

    Private Sub frmSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearFields()
        refreshList()
        Dim customer As New CorporateCustomer
        longList = customer.getNames()
    End Sub
    Private Function refreshList()
        dtgrdCustomerList.Rows.Clear()

        Dim list As New List(Of CorporateCustomer)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("corporate_customers")
            list = JsonConvert.DeserializeObject(Of List(Of CorporateCustomer))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each customer As CorporateCustomer In list

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell


            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = customer.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = customer.no
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = customer.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = customer.contactName
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            If customer.active = 0 Then
                dtgrdCell.Value = "DEACTIVATED"
            Else
                dtgrdCell.Value = "ACTIVE"
            End If
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCustomerList.Rows.Add(dtgrdRow)
        Next

        Return vbNull
    End Function

    Private Sub dtgrdSuppliers_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgrdCustomerList.RowHeaderMouseClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdCustomerList.CurrentRow.Index
            col = dtgrdCustomerList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        Dim customerNo As String = ""
        row = dtgrdCustomerList.CurrentRow.Index
        customerNo = dtgrdCustomerList.Item(1, row).Value.ToString
        search(customerNo, "")
    End Sub


    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)
    Private Sub cmbDescription_KeyUp(sender As Object, e As EventArgs) Handles cmbName.KeyUp

        Dim currentText As String = cmbName.Text
        shortList.Clear()
        cmbName.Items.Clear()
        cmbName.Items.Add(currentText)

        cmbName.DroppedDown = True
        For Each text As String In longList
            Dim formattedText As String = text.ToUpper()
            If formattedText.Contains(cmbName.Text.ToUpper()) Then
                shortList.Add(text)
            End If
        Next
        cmbName.Items.AddRange(shortList.ToArray())
        cmbName.SelectionStart = cmbName.Text.Length
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbName.SelectedIndexChanged

    End Sub

    Private Sub txtVRN_TextChanged(sender As Object, e As EventArgs) Handles txtVrn.TextChanged
        If txtVrn.Text.Contains("'") Then
            txtVrn.Text = ""
        End If
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtPostAddress.TextChanged
        If txtPostAddress.Text.Contains("'") Then
            txtPostAddress.Text = ""
        End If
    End Sub

    Private Sub txtPostCode_TextChanged(sender As Object, e As EventArgs) Handles txtPostCode.TextChanged
        If txtPostCode.Text.Contains("'") Then
            txtPostCode.Text = ""
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearFields()
        If txtId.Text = "" Then
            txtNo.ReadOnly = False
        End If
    End Sub


    Private Sub generateCode()
        Dim no As String = ""

        Dim KeyGen As RandomKeyGenerator
        Dim NumKeys As Integer
        Dim i_Keys As Integer
        Dim RandomKey As String = ""

        ' MODIFY THIS TO GET MORE KEYS    - LAITH - 27/07/2005 22:48:30 -
        NumKeys = 6

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyLetters = "1234567890"
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 3
        For i_Keys = 1 To NumKeys
            RandomKey = KeyGen.Generate()
        Next
        Dim str As String = ""
        While str.Length <> 3
            str = Math.Ceiling(VBMath.Rnd * 1000)
            If str.Length = 3 Then
                Exit While
            End If
        End While
        Dim code As String = str + RandomKey.ToString

        txtNo.Text = code
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class