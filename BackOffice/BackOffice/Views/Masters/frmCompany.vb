Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmCompany
    Private Sub btnBack_Click(sender As Object, e As EventArgs) 
        Me.Dispose()
    End Sub
    Private Function validateDetails() As Boolean
        Dim valid As Boolean = True
        If txtName.Text = "" Then
            valid = False
        End If
        If txtContactName.Text = "" Then
            valid = False
        End If
        If txtTIN.Text = "" Then
            valid = False
        End If
        If txtVRN.Text = "" Then
            valid = False
        End If
        Return valid
    End Function
    Private Function lock()
        txtName.ReadOnly = True
        txtContactName.ReadOnly = True
        txtTIN.ReadOnly = True
        txtVRN.ReadOnly = True
        txtBankAccName.ReadOnly = True
        txtBankAccAddress.ReadOnly = True
        txtBankPostCode.ReadOnly = True
        txtBankName.ReadOnly = True
        txtBankAccNo.ReadOnly = True
        txtAddress.ReadOnly = True
        txtPostCode.ReadOnly = True
        txtPhysicalAddress.ReadOnly = True
        txtTelephone.ReadOnly = True
        txtMobile.ReadOnly = True
        txtEmail.ReadOnly = True
        txtFax.ReadOnly = True
        btnChangeLogo.Enabled = False
        Return vbNull
    End Function
    Private Function unlock()
        txtName.ReadOnly = False
        txtContactName.ReadOnly = False
        txtTIN.ReadOnly = False
        txtVRN.ReadOnly = False
        txtBankAccName.ReadOnly = False
        txtBankAccAddress.ReadOnly = False
        txtBankPostCode.ReadOnly = False
        txtBankName.ReadOnly = False
        txtBankAccNo.ReadOnly = False
        txtAddress.ReadOnly = False
        txtPostCode.ReadOnly = False
        txtPhysicalAddress.ReadOnly = False
        txtTelephone.ReadOnly = False
        txtMobile.ReadOnly = False
        txtEmail.ReadOnly = False
        txtFax.ReadOnly = False
        btnChangeLogo.Enabled = True
        Return vbNull
    End Function
    Private Function getDepartments()
        dtgrdDepartment.Rows.Clear()

        Dim list As New List(Of Department)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("departments")
            list = JsonConvert.DeserializeObject(Of List(Of Department))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each department_ As Department In list

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = department_.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = department_.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = department_.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdDepartment.Rows.Add(dtgrdRow)
        Next
        Return vbNull
    End Function
    Private Function getClasses()
        dtgrdClass.Rows.Clear()

        Dim list As New List(Of Class_)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("classes")
            ' If deptName = "" Then

            '    Else
            'response = Web.get_("classes/department_name=" + deptName)
            '   End If
            list = JsonConvert.DeserializeObject(Of List(Of Class_))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each class_ As Class_ In list
            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = class_.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = class_.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = class_.department.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = class_.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdClass.Rows.Add(dtgrdRow)
        Next
        Return vbNull
    End Function
    Private Function getSubClasses()
        dtgrdsubClass.Rows.Clear()
        Dim list As New List(Of SubClass)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("sub_classes")
            '    If className = "" Then

            '    Else
            '  response = Web.get_("sub_classes/class_name=" + className)
            '  End If
            list = JsonConvert.DeserializeObject(Of List(Of SubClass))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try

        For Each subClass As SubClass In list

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = subClass.code
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = subClass.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = subClass.clas.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = subClass.department.name
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = subClass.id
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdsubClass.Rows.Add(dtgrdRow)
        Next
        Return vbNull
    End Function
    Private Sub frmCompany_Load(sender As Object, e As EventArgs) Handles Me.Shown
        loadCompanyDetails()
        txtDepartmentName.Text = ""
    End Sub
    Private Function refreshAll()
        txtDeptId.Text = ""
        txtDepartmentCode.Text = ""
        txtDepartmentName.Text = ""

        txtClassId.Text = ""
        txtClassCode.Text = ""
        txtClassName.Text = ""
        cmbClassDepartment.SelectedItem = Nothing
        cmbClassDepartment.Text = ""

        txtSubClassId.Text = ""
        txtSubClasscode.Text = ""
        txtSubClassName.Text = ""
        cmbSubClassDepartment.SelectedItem = Nothing
        cmbSubClassDepartment.Text = ""
        cmbSubClassClass.SelectedItem = Nothing
        cmbSubClassClass.Text = ""

        getDepartments()
        getClasses()
        getSubClasses()
        loadUnits()

        dtgrdDepartment.ClearSelection()
        dtgrdClass.ClearSelection()
        dtgrdsubClass.ClearSelection()
        Return vbNull
    End Function
    Private Function loadUnits()
        cmbClassDepartment.Items.Clear()
        cmbSubClassDepartment.Items.Clear()
        Dim list As New List(Of Department)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("departments")
            list = JsonConvert.DeserializeObject(Of List(Of Department))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNull
            Exit Function
        End Try
        For Each department_ As Department In list
            cmbClassDepartment.Items.Add(department_.name)
            cmbSubClassDepartment.Items.Add(department_.name)
        Next
        Return vbNull
    End Function
    Private Sub frmCompany_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        refreshAll()
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
    End Sub

    Private Sub btnAddDepartment_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        dtgrdDepartment.ClearSelection()
        txtDeptId.Text = ""
        txtDepartmentCode.Text = ""
        txtDepartmentName.Text = ""
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
        btnSaveDepartment.Enabled = True
        txtDepartmentName.ReadOnly = False

    End Sub

    Private Sub btnDeleteDepartment_Click(sender As Object, e As EventArgs) Handles btnDeleteDepartment.Click
        If txtDeptId.Text = "" Then
            MsgBox("Please select department to delete", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Department?", vbYesNo + vbQuestion, "Delete Department")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If
        Try
            Dim response As String
            response = Web.delete("departments/delete_by_id?id=" + txtDeptId.Text)
            MsgBox("Department successifully deleted", vbOKOnly + vbInformation, "Success: Delete success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        refreshAll()
        txtDepartmentName.Text = ""
        btnEditDepartment.Enabled = False
        btnSaveDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
    End Sub

    Private Sub btnSaveDepartment_Click(sender As Object, e As EventArgs) Handles btnSaveDepartment.Click
        If txtDepartmentName.Text = "" Then
            MsgBox("Department name can not be empty.", vbOKOnly + vbCritical, "Eroor: No entry")
            Exit Sub
        End If

        Dim department_ As Department
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtDeptId.Text = "" Then
            department_ = New Department
            txtDepartmentCode.Text = generateCode()
        Else
            response = Web.get_("departments/get_by_id?id=" + txtDeptId.Text)
            json = JObject.Parse(response)
            department_ = JsonConvert.DeserializeObject(Of Department)(json.ToString)
        End If
        department_.id = txtDeptId.Text
        department_.code = txtDepartmentCode.Text
        department_.name = txtDepartmentName.Text
        Try
            Dim success As Boolean = False
            If txtDeptId.Text = "" Then
                response = Web.post(department_, "departments/new")
                json = JObject.Parse(response)
                department_ = JsonConvert.DeserializeObject(Of Department)(json.ToString)

                txtDeptId.Text = department_.id
                txtDepartmentCode.Text = department_.code
                MsgBox("Department successifully saved.", vbOKOnly + vbInformation, "Success: Department saved.")
            Else
                If Web.put(department_, "departments/edit_by_id?id=" + txtDeptId.Text) = True Then
                    MsgBox("Department successifully modified.", vbOKOnly + vbInformation, "Success: Department saved.")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
        btnSaveDepartment.Enabled = False
        btnEditDepartment.Enabled = False
        btnDeleteDepartment.Enabled = False
        txtDepartmentName.Text = ""
        txtDepartmentName.ReadOnly = True
        refreshAll()
    End Sub

    Private Sub btnEditDepartment_Click(sender As Object, e As EventArgs) Handles btnEditDepartment.Click
        txtDepartmentName.ReadOnly = False
        btnSaveDepartment.Enabled = True
    End Sub

    Private Sub dtgrdDepartment_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdDepartment.CellClick
        btnEditDepartment.Enabled = True
        btnDeleteDepartment.Enabled = True
        btnSaveDepartment.Enabled = False
        txtDepartmentName.ReadOnly = True
        Try
            If dtgrdDepartment.CurrentRow.Index >= 0 Then
                txtDeptId.Text = dtgrdDepartment.Item(2, e.RowIndex).Value.ToString
                txtDepartmentCode.Text = dtgrdDepartment.Item(0, e.RowIndex).Value.ToString
                txtDepartmentName.Text = dtgrdDepartment.Item(1, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dtgrdclass_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdClass.CellClick
        btnEditClass.Enabled = True
        btnDeleteClass.Enabled = True
        btnSaveClass.Enabled = False
        txtClassName.ReadOnly = True
        Try
            If dtgrdClass.CurrentRow.Index >= 0 Then
                txtClassId.Text = dtgrdClass.Item(3, e.RowIndex).Value.ToString
                txtClassCode.Text = dtgrdClass.Item(0, e.RowIndex).Value.ToString
                txtClassName.Text = dtgrdClass.Item(1, e.RowIndex).Value.ToString
                cmbClassDepartment.Text = dtgrdClass.Item(2, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgrdSubClass_cellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdsubClass.CellClick
        btnEditSubClass.Enabled = True
        btnDeleteSubClass.Enabled = True
        btnSaveSubClass.Enabled = False
        txtSubClassName.ReadOnly = True
        Try
            If dtgrdsubClass.CurrentRow.Index >= 0 Then
                txtSubClassName.Text = dtgrdsubClass.Item(1, e.RowIndex).Value.ToString
                txtSubClassId.Text = dtgrdsubClass.Item(4, e.RowIndex).Value.ToString
                txtSubClasscode.Text = dtgrdsubClass.Item(0, e.RowIndex).Value.ToString

                cmbSubClassDepartment.Text = dtgrdsubClass.Item(3, e.RowIndex).Value.ToString
                cmbSubClassClass.Text = dtgrdsubClass.Item(2, e.RowIndex).Value.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frmCompany_Load_1(sender As Object, e As EventArgs) Handles Me.Shown
        Dim company As New Company
        Company.loadCompanyDetails()
    End Sub

    Private Sub cmbClassDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClassDepartment.SelectedIndexChanged
        Dim deptName As String = cmbClassDepartment.Text
        '   btnSaveClass.Enabled = False
        btnDeleteClass.Enabled = False
        txtClassName.Text = ""
        ' txtClassName.ReadOnly = True
        '  getClasses(deptName)
    End Sub

    Private Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click
        '  If cmbClassDepartment.Text = "" Then
        ' MsgBox("Select Department", vbOKOnly + vbCritical, "Error: Empty field")
        ' Exit Sub
        ' End If
        cmbClassDepartment.SelectedItem = Nothing
        cmbClassDepartment.Text = ""
        txtClassId.Text = ""
        txtClassCode.Text = ""
        txtClassName.Text = ""
        txtClassName.ReadOnly = False
        btnEditClass.Enabled = False
        btnDeleteClass.Enabled = False
        btnSaveClass.Enabled = True

    End Sub

    Private Sub btnEditClass_Click(sender As Object, e As EventArgs) Handles btnEditClass.Click
        txtClassName.ReadOnly = False
        btnSaveClass.Enabled = True
        btnDeleteClass.Enabled = False
    End Sub

    Private Sub btnSaveClass_Click(sender As Object, e As EventArgs) Handles btnSaveClass.Click
        If cmbClassDepartment.Text = "" Then
            MsgBox("Please select department.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If
        If txtClassName.Text = "" Then
            MsgBox("Class name can not be empty.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If

        Dim class_ As Class_
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtClassId.Text = "" Then
            class_ = New Class_
            txtClassCode.Text = generateCode()
        Else
            response = Web.get_("classes/get_by_id?id=" + txtClassId.Text)
            json = JObject.Parse(response)
            class_ = JsonConvert.DeserializeObject(Of Class_)(json.ToString)
        End If
        class_.id = txtClassId.Text
        class_.code = txtClassCode.Text
        class_.name = txtClassName.Text
        class_.department.name = cmbClassDepartment.Text
        Try
            Dim success As Boolean = False
            If txtClassId.Text = "" Then
                response = Web.post(class_, "classes/new")
                json = JObject.Parse(response)
                class_ = JsonConvert.DeserializeObject(Of Class_)(json.ToString)
                txtClassId.Text = class_.id
                txtClassCode.Text = class_.code
                MsgBox("Class successifully saved.", vbOKOnly + vbInformation, "Success: Class saved.")
            Else
                If Web.put(class_, "classes/edit_by_id?id=" + txtClassId.Text) = True Then
                    MsgBox("Class successifully modified.", vbOKOnly + vbInformation, "Success: Class saved.")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
        btnSaveClass.Enabled = False
        btnEditClass.Enabled = False
        btnDeleteClass.Enabled = False
        dtgrdClass.Rows.Clear()
        getClasses()
        dtgrdClass.ClearSelection()
        txtClassName.Text = ""
        txtClassName.ReadOnly = True
        refreshAll()
    End Sub

    Private Sub cmbSubClassDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClassDepartment.SelectedIndexChanged
        If cmbSubClassDepartment.Text = "" Then
            Exit Sub
        End If
        cmbSubClassClass.Items.Clear()
        '   btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        txtSubClassName.Text = ""
        '   txtSubClassName.ReadOnly = True

        Dim list As New List(Of Class_)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("classes/get_by_department_name?department_name=" + cmbSubClassDepartment.Text)
            list = JsonConvert.DeserializeObject(Of List(Of Class_))(response.ToString)
        Catch ex As Exception
            ' MsgBox(ex.ToString)
            Exit Sub
        End Try
        For Each class_ As Class_ In list
            cmbSubClassClass.Items.Add(class_.name)
        Next
    End Sub

    Private Sub cmbSubClassClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubClassClass.SelectedIndexChanged
        Dim className As String = cmbSubClassClass.Text
        '     btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        txtSubClassName.Text = ""
        '  txtSubClassName.ReadOnly = True
        '   getSubClasses(className)


    End Sub

    Private Sub btnAddSubClass_Click(sender As Object, e As EventArgs) Handles btnAddSubClass.Click
        '    If cmbSubClassDepartment.Text = "" Then
        '    MsgBox("Select Department", vbOKOnly + vbCritical, "Error: Empty field")
        '    Exit Sub
        '   End If
        '   If cmbSubClassClass.Text = "" Then
        '    MsgBox("Select Class", vbOKOnly + vbCritical, "Error: Empty field")
        '   Exit Sub
        '    End If
        cmbSubClassDepartment.SelectedItem = Nothing
        cmbSubClassDepartment.Text = ""
        cmbSubClassClass.SelectedItem = Nothing
        cmbSubClassClass.Text = ""
        txtSubClassId.Text = ""
        txtSubClasscode.Text = ""
        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = False
        btnEditSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
        btnSaveSubClass.Enabled = True
    End Sub

    Private Sub btnEditSubClass_Click(sender As Object, e As EventArgs) Handles btnEditSubClass.Click
        txtSubClassName.ReadOnly = False
        btnSaveSubClass.Enabled = True
        btnDeleteSubClass.Enabled = False
    End Sub

    Private Sub btnDeleteClass_Click(sender As Object, e As EventArgs) Handles btnDeleteClass.Click
        If txtClassId.Text = "" Then
            MsgBox("Please select class to delete", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Class?", vbYesNo + vbQuestion, "Delete Class")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If
        Try
            Dim response As String
            response = Web.delete("classes/delete_by_id?id=" + txtClassId.Text)
            MsgBox("Class successifully deleted", vbOKOnly + vbInformation, "Success: Delete success")
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        refreshAll()
        txtClassName.Text = ""
        btnEditClass.Enabled = False
        btnSaveClass.Enabled = False
        btnDeleteClass.Enabled = False
    End Sub

    Private Sub btnDeleteSubClass_Click(sender As Object, e As EventArgs) Handles btnDeleteSubClass.Click
        If txtSubClassId.Text = "" Then
            MsgBox("Please select sub-class to delete", vbOKOnly + vbCritical, "Error: No selection")
            Exit Sub
        End If
        Dim res As Integer = MsgBox("Are you sure you want to delete the selected Sub-Class?", vbYesNo + vbQuestion, "Delete Sub class")
        If res = DialogResult.Yes Then
            'continue with operation
        Else
            Exit Sub
        End If

        Try
            Dim response As String
            response = Web.delete("sub_classes/delete_by_id?id=" + txtDeptId.Text)
            MsgBox("Sub-Class successifully deleted", vbOKOnly + vbInformation, "Success: Delete success")
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        refreshAll()
        txtSubClassName.Text = ""
        btnEditSubClass.Enabled = False
        btnSaveSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False
    End Sub

    Private Sub btnSaveSubClass_Click(sender As Object, e As EventArgs) Handles btnSaveSubClass.Click
        If cmbSubClassDepartment.Text = "" Then
            MsgBox("Please select department.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If
        If cmbSubClassClass.Text = "" Then
            MsgBox("Please select class.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If
        If txtSubClassName.Text = "" Then
            MsgBox("Sub-Class name can not be empty.", vbOKOnly + vbCritical, "Error: No entry")
            Exit Sub
        End If

        Dim subClass_ As SubClass
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        If txtSubClassId.Text = "" Then
            subClass_ = New SubClass
            txtSubClasscode.Text = generateCode()
        Else
            response = Web.get_("sub_classes/get_by_id?id=" + txtSubClassId.Text)
            json = JObject.Parse(response)
            subClass_ = JsonConvert.DeserializeObject(Of SubClass)(json.ToString)
        End If
        subClass_.id = txtSubClassId.Text
        subClass_.code = txtSubClasscode.Text
        subClass_.name = txtSubClassName.Text
        subClass_.clas.name = cmbSubClassClass.Text
        subClass_.department.name = cmbSubClassDepartment.Text

        Try
            If txtSubClassId.Text = "" Then
                response = Web.post(subClass_, "sub_classes/new")
                json = JObject.Parse(response)
                subClass_ = JsonConvert.DeserializeObject(Of SubClass)(json.ToString)
                txtSubClassId.Text = subClass_.id
                txtSubClasscode.Text = subClass_.code
                MsgBox("Sub-Class successifully saved.", vbOKOnly + vbInformation, "Success: Sub-Class saved.")
            Else
                If Web.put(subClass_, "sub_classes/edit_by_id?id=" + txtSubClassId.Text) = True Then
                    MsgBox("Sub-Class successifully modified.", vbOKOnly + vbInformation, "Success: Sub-Class saved.")
                Else
                    MsgBox("Update failed")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Operation failed")
            Exit Sub
        End Try
        btnSaveSubClass.Enabled = False
        btnEditSubClass.Enabled = False
        btnDeleteSubClass.Enabled = False

        dtgrdsubClass.Rows.Clear()
        getSubClasses()
        dtgrdsubClass.ClearSelection()

        txtSubClassName.Text = ""
        txtSubClassName.ReadOnly = True
        refreshAll()
    End Sub

    Dim locked As Boolean = True
    Private Function validateCompanyDetails() As Boolean
        Dim valid As Boolean = False
        'validate company details
        'flush error for invalid details

        Return valid
    End Function
    Private Function loadCompanyDetails() As Boolean
        If Company.loadCompanyDetails Then
            txtName.Text = Company.GL_NAME
            txtContactName.Text = Company.GL_CONTACT_NAME
            txtTIN.Text = Company.GL_TIN
            txtVRN.Text = Company.GL_VRN
            txtBankAccName.Text = Company.GL_BANK_ACCOUNT_NAME
            txtBankAccAddress.Text = Company.GL_BANK_ADDRESS
            txtBankPostCode.Text = Company.GL_BANK_POST_CODE
            txtBankName.Text = Company.GL_BANK_NAME
            txtBankAccNo.Text = Company.GL_BANK_ACCOUNT_NO
            txtAddress.Text = Company.GL_POST_ADDRESS
            txtPostCode.Text = Company.GL_POST_CODE
            txtPhysicalAddress.Text = Company.GL_PHYSICAL_ADDRESS
            txtTelephone.Text = Company.GL_TELEPHONE
            txtEmail.Text = Company.GL_EMAIL
            txtMobile.Text = Company.GL_MOBILE
            txtFax.Text = Company.GL_FAX
            Try
                Dim byteImage() As Byte = Company.GL_LOGO
                Dim logo As New System.IO.MemoryStream(byteImage)
                pctLogo.Image = Image.FromStream(logo)
            Catch ex As Exception
                pctLogo.Image = Nothing
            End Try
            Return True
        End If
        Return False
    End Function

    Private Sub btnEditCompanyDetails_Click(sender As Object, e As EventArgs) Handles btnEditCompanyDetails.Click
        If locked = True Then
            unlock()
            locked = False
            btnSaveCompanyDetails.Enabled = True
        Else
            lock()
            locked = True
            btnSaveCompanyDetails.Enabled = False
        End If
    End Sub

    Private Sub btnSaveCompanyDetails_Click(sender As Object, e As EventArgs) Handles btnSaveCompanyDetails.Click

        If validateDetails() = True Then
            Company.GL_NAME = txtName.Text
            Company.GL_CONTACT_NAME = txtContactName.Text
            Company.GL_TIN = txtTIN.Text
            Company.GL_VRN = txtVRN.Text
            Company.GL_BANK_ACCOUNT_NAME = txtBankAccName.Text
            Company.GL_BANK_ADDRESS = txtBankAccAddress.Text
            Company.GL_BANK_POST_CODE = txtBankPostCode.Text
            Company.GL_BANK_NAME = txtBankName.Text
            Company.GL_BANK_ACCOUNT_NO = txtBankAccNo.Text
            Company.GL_POST_ADDRESS = txtAddress.Text
            Company.GL_POST_CODE = txtPostCode.Text
            Company.GL_PHYSICAL_ADDRESS = txtPhysicalAddress.Text
            Company.GL_TELEPHONE = txtTelephone.Text
            Company.GL_MOBILE = txtMobile.Text
            Company.GL_EMAIL = txtEmail.Text
            Company.GL_FAX = txtFax.Text
            Try
                Dim ms As New MemoryStream
                pctLogo.Image.Save(ms, pctLogo.Image.RawFormat)
                Dim logo As Byte() = ms.GetBuffer()
                Company.GL_LOGO = logo
            Catch ex As Exception
                Company.GL_LOGO = Nothing
            End Try

            Company.saveCompanyDetails()
            btnSaveCompanyDetails.Enabled = False
            lock()
            Company.loadCompanyDetails()
        Else
            MsgBox("Could not save company information. Important fields missing. Make sure the fields marked with * are filled", vbOKOnly + vbCritical, "Error: Missing information")
        End If
    End Sub

    Private Sub frmCompany_Load_2(sender As Object, e As EventArgs) Handles MyBase.Load
        lock()
    End Sub

    Private Sub btnChangeLogo_Click(sender As Object, e As EventArgs) Handles btnChangeLogo.Click
        If fileDialog.ShowDialog = DialogResult.OK Then
            pctLogo.ImageLocation = fileDialog.FileName
        End If
    End Sub

    Private Function generateCode() As String
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
        Return str + RandomKey.ToString
    End Function

End Class