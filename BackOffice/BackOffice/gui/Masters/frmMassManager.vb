Imports Devart.Data.MySql
Imports Microsoft.Office.Interop
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmMassManager
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmMassManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim path As String = ""
    Dim count As Integer = 0
    Dim itemMasterAttributes = New String() {"PRIMARY_BARCODE",
                                            "CODE",
                                            "DESCRIPTION",
                                            "SHORT_DESCRIPTION",
                                            "COMMON_DESCRIPTION",
                                            "INGREDIENTS",
                                            "PACK_SIZE",
                                            "STANDARD_UOM",
                                            "SUPPLIER_CODE",
                                            "SUPPLIER_NAME",
                                            "DEPARTMENT_CODE",
                                            "DEPARTMENT_NAME",
                                            "CLASS_CODE",
                                            "CLASS_NAME",
                                            "SUB_CLASS_CODE",
                                            "SUB_CLASS_NAME",
                                            "COST_PRICE_VAT_INCL",
                                            "COST_PRICE_VAT_EXCL",
                                            "SELLING_PRICE_VAT_INCL",
                                            "SELLING_PRICE_VAT_EXCL",
                                            "PROFIT_MARGIN",
                                            "VAT",
                                            "DISCOUNT",
                                            "STATUS",
                                            "SELLABLE",
                                            "RETURNABLE",
                                            "STOCK",
                                            "MINIMUM_INVENTORY",
                                            "MAXIMUM_INVENTORY",
                                            "DEFAULT_REORDER_LEVEL",
                                            "DEFAULT_REORDER_QTY"
                                            }
    'Dim itemMasterAttributes = New String() {"ITEM_CODE", "PRIMARY_SCAN_CODE", "DESCR", "SHORT_DESCR", "PACK_SIZE", "DEPT", "DEPT_NAME", "CLASS", "CLASS_NAME", "SUB_CLASS", "SUB_CLASS_NAME", "SUPPLIER", "SUPPLIER_NAME", "CPRICE_VAT_EXCL", "VAT", "CPRICE_VAT_INCL", "MARGIN", "DISC", "SPRICE", "STOCK", "MIN_STOCK", "MAX_STOCK", "REORDER_LEVEL", "UOM"}

    Dim supplierMasterAttributes = New String() {
                                                "CODE",
                                                "NAME",
                                                "CONTACT_NAME",
                                                "TIN",
                                                "VRN",
                                                "STATUS",
                                                "TERMS_OF_CONTRACT",
                                                "PHYSICAL_ADDRESS",
                                                "POST_CODE",
                                                "POST_ADDRESS",
                                                "TELEPHONE",
                                                "MOBILE",
                                                "EMAIL",
                                                "FAX",
                                                "BANK_ACCOUNT_NAME",
                                                "BANK_ADDRESS",
                                                "BANK_POST_CODE",
                                                "BANK_NAME",
                                                "BANK_ACCOUNT_NO"
                                                }
    '  Dim supplierMasterAttributes = New String() {"SUPPLIER_CODE", "SUPPLIER_NAME", "ADDRESS", "POST_CODE", "PHYSICAL_ADDRESS", "CONTACT_NAME", "BANK_ACC_NAME", "BANK_ACC_ADDRESS", "BANK_POST_CODE", "BANK_NAME", "BANK_ACC_NO", "TELEPHONE", "MOBILE", "EMAIL", "FAX", "TIN", "VRN", "NOTES"}

    Dim unitsAttributes = New String() {"DEPARTMENT_CODE",
                                        "DEPARTMENT_NAME",
                                        "CLASS_CODE",
                                        "CLASS_NAME",
                                        "SUB_CLASS_CODE",
                                        "SUB_CLASS_NAME"
                                        }

    Private Function validateFileFormat(path As String)
        Dim valid As Boolean = False

        valid = True

        Return valid
    End Function
    Private Function validateUnitMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> unitsAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> unitsAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> unitsAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> unitsAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> unitsAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> unitsAttributes(5) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Sub btnUploadUnitMaster_Click(sender As Object, e As EventArgs) Handles btnuploadUnits.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateUnitMasterFormat(path) = True Then
                count = getRecordCount(path)

                Dim objXLApp As Excel.Application
                Dim objXLWb As Excel.Workbook
                Dim objXLWs As Excel.Worksheet

                objXLApp = New Excel.Application
                objXLApp.Workbooks.Open(path)
                objXLWb = objXLApp.Workbooks(1)
                objXLWs = objXLWb.Worksheets(1)

                Try
                    prgBar.Value = 0
                    lblOperation.Text = "Uploading departments... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim department As Department = New Department
                        department.code = departmentCode
                        department.name = departmentName

                        Try
                            Web.post(department, "departments/new")
                        Catch ex As Exception

                        End Try
                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim class_ As Class_ = New Class_
                        class_.code = classCode
                        class_.name = className

                        Try
                            Web.post(class_, "classes/new")
                        Catch ex As Exception

                        End Try

                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading sub classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim subClass As SubClass = New SubClass
                        subClass.code = subClassCode
                        subClass.name = subClassName

                        Try
                            Web.post(subClass, "sub_classes/new")
                        Catch ex As Exception

                        End Try
                    Next
                    lblOperation.Text = ""
                    MsgBox("Operation completed")
                    prgBar.Value = 0
                Catch ex As Exception
                    MsgBox(ex.StackTrace)
                End Try
                objXLApp.Quit()


            Else
                MsgBox("Invalid Format. The arrangement of the attributes Is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl Or xls) format")
        End If
    End Sub
    Private Sub btnUpdateUnitMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateUnits.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateUnitMasterFormat(path) = True Then
                count = getRecordCount(path)

                Dim objXLApp As Excel.Application
                Dim objXLWb As Excel.Workbook
                Dim objXLWs As Excel.Worksheet

                objXLApp = New Excel.Application
                objXLApp.Workbooks.Open(path)
                objXLWb = objXLApp.Workbooks(1)
                objXLWs = objXLWb.Worksheets(1)
                Try
                    prgBar.Value = 0
                    lblOperation.Text = "Updating departments... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim department As Department = New Department
                        department.code = departmentCode
                        department.name = departmentName

                        Try
                            Web.put(department, "departments/edit/code=" + departmentCode)
                        Catch ex As Exception

                        End Try
                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim class_ As Class_ = New Class_
                        class_.code = classCode
                        class_.name = className

                        Try
                            Web.put(class_, "classes/edit/code=" + classCode)
                        Catch ex As Exception

                        End Try

                    Next
                    lblOperation.Text = ""
                    lblOperation.Text = "Uploading sub classes... please wait"
                    For i As Integer = 2 To count
                        showProgress(i, count)
                        'upload items

                        Dim departmentCode As String = objXLWs.Range("A" & i).Value
                        Dim departmentName As String = objXLWs.Range("B" & i).Value
                        Dim classCode As String = objXLWs.Range("C" & i).Value
                        Dim className As String = objXLWs.Range("D" & i).Value
                        Dim subClassCode As String = objXLWs.Range("E" & i).Value
                        Dim subClassName As String = objXLWs.Range("F" & i).Value

                        Dim subClass As SubClass = New SubClass
                        subClass.code = subClassCode
                        subClass.name = subClassName

                        Try
                            Web.put(subClass, "sub_classes/edit/code=" + subClassCode)
                        Catch ex As Exception

                        End Try
                    Next
                    lblOperation.Text = ""
                    MsgBox("Operation completed")
                    prgBar.Value = 0
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                objXLApp.Quit()
            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If
        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Function validateSupplierMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> supplierMasterAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> supplierMasterAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> supplierMasterAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> supplierMasterAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> supplierMasterAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> supplierMasterAttributes(5) Then
                valid = False
            End If
            If objXLWs.Range("G" & 1).Value.ToString <> supplierMasterAttributes(6) Then
                valid = False
            End If
            If objXLWs.Range("H" & 1).Value.ToString <> supplierMasterAttributes(7) Then
                valid = False
            End If
            If objXLWs.Range("I" & 1).Value.ToString <> supplierMasterAttributes(8) Then
                valid = False
            End If
            If objXLWs.Range("J" & 1).Value.ToString <> supplierMasterAttributes(9) Then
                valid = False
            End If
            If objXLWs.Range("K" & 1).Value.ToString <> supplierMasterAttributes(10) Then
                valid = False
            End If
            If objXLWs.Range("L" & 1).Value.ToString <> supplierMasterAttributes(11) Then
                valid = False
            End If
            If objXLWs.Range("M" & 1).Value.ToString <> supplierMasterAttributes(12) Then
                valid = False
            End If
            If objXLWs.Range("N" & 1).Value.ToString <> supplierMasterAttributes(13) Then
                valid = False
            End If
            If objXLWs.Range("O" & 1).Value.ToString <> supplierMasterAttributes(14) Then
                valid = False
            End If
            If objXLWs.Range("P" & 1).Value.ToString <> supplierMasterAttributes(15) Then
                valid = False
            End If
            If objXLWs.Range("Q" & 1).Value.ToString <> supplierMasterAttributes(16) Then
                valid = False
            End If
            If objXLWs.Range("R" & 1).Value.ToString <> supplierMasterAttributes(17) Then
                valid = False
            End If
            If objXLWs.Range("S" & 1).Value.ToString <> supplierMasterAttributes(17) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Sub btnUploadSupplierMaster_Click(sender As Object, e As EventArgs) Handles btnUploadSupplier.Click
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateSupplierMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Uploading... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items

                            Dim code As String = objXLWs.Range("A" & i).Value
                            Dim name As String = objXLWs.Range("B" & i).Value
                            Dim contactName As String = objXLWs.Range("C" & i).Value
                            Dim tin As String = objXLWs.Range("D" & i).Value
                            Dim vrn As String = objXLWs.Range("E" & i).Value
                            Dim status As String = objXLWs.Range("F" & i).Value
                            Dim termsOfContract As String = objXLWs.Range("G" & i).Value
                            Dim physicalAddress As String = objXLWs.Range("H" & i).Value
                            Dim postCode As String = objXLWs.Range("I" & i).Value
                            Dim postAddress As String = objXLWs.Range("J" & i).Value
                            Dim telephone As String = objXLWs.Range("K" & i).Value
                            Dim mobile As String = objXLWs.Range("L" & i).Value
                            Dim email As String = objXLWs.Range("M" & i).Value
                            Dim fax As String = objXLWs.Range("N" & i).Value
                            Dim bankAccountName As String = objXLWs.Range("O" & i).Value
                            Dim bankPostAddress As String = objXLWs.Range("P" & i).Value
                            Dim bankPostCode As String = objXLWs.Range("Q" & i).Value
                            Dim bankName As String = objXLWs.Range("R" & i).Value
                            Dim bankAccountNo As String = objXLWs.Range("S" & i).Value

                            Dim supplier As Supplier = New Supplier
                            supplier.code = code
                            supplier.contactName = contactName
                            supplier.tin = tin
                            supplier.vrn = vrn
                            supplier.status = status
                            supplier.termsOfContract = termsOfContract
                            supplier.physicalAddress = physicalAddress
                            supplier.postCode = postCode
                            supplier.postAddress = postAddress
                            supplier.telephone = telephone
                            supplier.mobile = mobile
                            supplier.email = email
                            supplier.fax = fax
                            supplier.bankAccountName = bankAccountName
                            supplier.bankPostAddress = bankPostAddress
                            supplier.bankPostCode = bankPostCode
                            supplier.bankName = bankName
                            supplier.bankAccountNo = bankAccountNo

                            Try
                                Web.post(supplier, "suppliers/new")
                            Catch ex As Exception

                            End Try
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.StackTrace)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Sub btnUpdateSupplierMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateSupplier.Click
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateSupplierMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'update items

                            Dim code As String = objXLWs.Range("A" & i).Value
                            Dim name As String = objXLWs.Range("B" & i).Value
                            Dim contactName As String = objXLWs.Range("C" & i).Value
                            Dim tin As String = objXLWs.Range("D" & i).Value
                            Dim vrn As String = objXLWs.Range("E" & i).Value
                            Dim status As String = objXLWs.Range("F" & i).Value
                            Dim termsOfContract As String = objXLWs.Range("G" & i).Value
                            Dim physicalAddress As String = objXLWs.Range("H" & i).Value
                            Dim postCode As String = objXLWs.Range("I" & i).Value
                            Dim postAddress As String = objXLWs.Range("J" & i).Value
                            Dim telephone As String = objXLWs.Range("K" & i).Value
                            Dim mobile As String = objXLWs.Range("L" & i).Value
                            Dim email As String = objXLWs.Range("M" & i).Value
                            Dim fax As String = objXLWs.Range("N" & i).Value
                            Dim bankAccountName As String = objXLWs.Range("O" & i).Value
                            Dim bankPostAddress As String = objXLWs.Range("P" & i).Value
                            Dim bankPostCode As String = objXLWs.Range("Q" & i).Value
                            Dim bankName As String = objXLWs.Range("R" & i).Value
                            Dim bankAccountNo As String = objXLWs.Range("S" & i).Value

                            Dim supplier As Supplier = New Supplier
                            supplier.code = code
                            supplier.contactName = contactName
                            supplier.tin = tin
                            supplier.vrn = vrn
                            supplier.status = status
                            supplier.termsOfContract = termsOfContract
                            supplier.physicalAddress = physicalAddress
                            supplier.postCode = postCode
                            supplier.postAddress = postAddress
                            supplier.telephone = telephone
                            supplier.mobile = mobile
                            supplier.email = email
                            supplier.fax = fax
                            supplier.bankAccountName = bankAccountName
                            supplier.bankPostAddress = bankPostAddress
                            supplier.bankPostCode = bankPostCode
                            supplier.bankName = bankName
                            supplier.bankAccountNo = bankAccountNo

                            Try
                                Web.put(supplier, "suppliers/edit/code=" + code)
                            Catch ex As Exception

                            End Try
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
    End Sub
    Private Function validateMasterFormat(path As String)
        Dim valid As Boolean = False
        lblOperation.Text = "Validating file... please wait"
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            Dim count As Integer = 0
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)

            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            valid = True

            If objXLWs.Range("A" & 1).Value.ToString <> itemMasterAttributes(0) Then
                valid = False
            End If
            If objXLWs.Range("B" & 1).Value.ToString <> itemMasterAttributes(1) Then
                valid = False
            End If
            If objXLWs.Range("C" & 1).Value.ToString <> itemMasterAttributes(2) Then
                valid = False
            End If
            If objXLWs.Range("D" & 1).Value.ToString <> itemMasterAttributes(3) Then
                valid = False
            End If
            If objXLWs.Range("E" & 1).Value.ToString <> itemMasterAttributes(4) Then
                valid = False
            End If
            If objXLWs.Range("F" & 1).Value.ToString <> itemMasterAttributes(5) Then
                valid = False
            End If
            If objXLWs.Range("G" & 1).Value.ToString <> itemMasterAttributes(6) Then
                valid = False
            End If
            If objXLWs.Range("H" & 1).Value.ToString <> itemMasterAttributes(7) Then
                valid = False
            End If
            If objXLWs.Range("I" & 1).Value.ToString <> itemMasterAttributes(8) Then
                valid = False
            End If
            If objXLWs.Range("J" & 1).Value.ToString <> itemMasterAttributes(9) Then
                valid = False
            End If
            If objXLWs.Range("K" & 1).Value.ToString <> itemMasterAttributes(10) Then
                valid = False
            End If
            If objXLWs.Range("L" & 1).Value.ToString <> itemMasterAttributes(11) Then
                valid = False
            End If
            If objXLWs.Range("M" & 1).Value.ToString <> itemMasterAttributes(12) Then
                valid = False
            End If
            If objXLWs.Range("N" & 1).Value.ToString <> itemMasterAttributes(13) Then
                valid = False
            End If
            If objXLWs.Range("O" & 1).Value.ToString <> itemMasterAttributes(14) Then
                valid = False
            End If
            If objXLWs.Range("P" & 1).Value.ToString <> itemMasterAttributes(15) Then
                valid = False
            End If
            If objXLWs.Range("Q" & 1).Value.ToString <> itemMasterAttributes(16) Then
                valid = False
            End If
            If objXLWs.Range("R" & 1).Value.ToString <> itemMasterAttributes(17) Then
                valid = False
            End If
            If objXLWs.Range("S" & 1).Value.ToString <> itemMasterAttributes(18) Then
                valid = False
            End If
            If objXLWs.Range("T" & 1).Value.ToString <> itemMasterAttributes(19) Then
                valid = False
            End If
            If objXLWs.Range("U" & 1).Value.ToString <> itemMasterAttributes(20) Then
                valid = False
            End If
            If objXLWs.Range("V" & 1).Value.ToString <> itemMasterAttributes(21) Then
                valid = False
            End If
            If objXLWs.Range("W" & 1).Value.ToString <> itemMasterAttributes(22) Then
                valid = False
            End If
            If objXLWs.Range("X" & 1).Value.ToString <> itemMasterAttributes(23) Then
                valid = False
            End If
            If objXLWs.Range("Y" & 1).Value.ToString <> itemMasterAttributes(24) Then
                valid = False
            End If
            If objXLWs.Range("Z" & 1).Value.ToString <> itemMasterAttributes(25) Then
                valid = False
            End If
            If objXLWs.Range("AA" & 1).Value.ToString <> itemMasterAttributes(26) Then
                valid = False
            End If
            If objXLWs.Range("AB" & 1).Value.ToString <> itemMasterAttributes(27) Then
                valid = False
            End If
            If objXLWs.Range("AC" & 1).Value.ToString <> itemMasterAttributes(28) Then
                valid = False
            End If
            If objXLWs.Range("AD" & 1).Value.ToString <> itemMasterAttributes(29) Then
                valid = False
            End If
            If objXLWs.Range("AE" & 1).Value.ToString <> itemMasterAttributes(30) Then
                valid = False
            End If
            lblOperation.Text = ""
            objXLApp.Quit()

        Catch ex As Exception
            MsgBox(ex.Message)
            valid = False
        End Try
        lblOperation.Text = ""
        Return valid
    End Function
    Private Function getRecordCount(path As String)
        Dim count As Integer = 0
        Try
            Dim objXLApp As Microsoft.Office.Interop.Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)
            count = objXLWs.UsedRange.Rows.Count
            objXLApp.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return count
    End Function
    Private Function validateMasterRecords(path As String)
        Dim valid As Boolean = True
        Dim count As Integer = getRecordCount(path)
        '  MsgBox("Total number of records:  " + (count - 1).ToString)
        Dim k As Integer = 0
        Try
            Dim objXLApp As Excel.Application
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet
            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(path)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)

            'validate item codes, for duplicates and empty string
            lblOperation.Text = "Validating Records... please wait"
            prgBar.Value = 0
            Dim res As Integer = MsgBox("Total records " + (count - 1).ToString, vbYesNo, "Continue?")
            If res = DialogResult.No Then
                valid = False
                Return valid
                Exit Function
            End If
            ' valid = True
            For i As Integer = 2 To count
                k = i
                showProgress(i, count)
                Dim code As String = objXLWs.Range("B" & i).Value.ToString
                Dim description As String = objXLWs.Range("C" & i).Value.ToString
                Dim shortDescription As String = objXLWs.Range("D" & i).Value.ToString
                '           Dim short_descr As String = objXLWs.Range("D" & i).Value.ToString
                '           Dim pck As String = objXLWs.Range("E" & i).Value.ToString
                '           Dim dept_name As String = objXLWs.Range("G" & i).Value.ToString
                '           Dim _class_name As String = objXLWs.Range("I" & i).Value.ToString
                '            Dim sub_class_name As String = objXLWs.Range("K" & i).Value.ToString
                '            Dim supplier As String = objXLWs.Range("L" & i).Value.ToString
                '           Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value.ToString
                '          Dim vat As String = objXLWs.Range("O" & i).Value.ToString
                '          Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value.ToString
                '          Dim margin As String = objXLWs.Range("Q" & i).Value.ToString
                '          Dim discount As String = objXLWs.Range("R" & i).Value.ToString
                '         Dim sprice As String = objXLWs.Range("S" & i).Value.ToString
                '          Dim stock As String = objXLWs.Range("T" & i).Value.ToString
                '         Dim min_stock As String = objXLWs.Range("U" & i).Value.ToString
                '         Dim max_stock As String = objXLWs.Range("V" & i).Value.ToString
                '         Dim reorder_level As String = objXLWs.Range("W" & i).Value.ToString
                '         Dim uom As String = objXLWs.Range("X" & i).Value.ToString

                'For j As Integer = i + 1 To count
                If code.ToString = "" Then
                    valid = False
                    MsgBox("Empty field in code in record no " + i.ToString)
                    'Exit For
                Else
                    'valid = True
                End If
                If description.ToString = "" Then
                    valid = False
                    MsgBox("Empty field in description in record no " + i.ToString)
                    'Exit For
                Else
                    'valid = True
                End If
                If shortDescription.ToString = "" Then
                    valid = False
                    MsgBox("Empty field in short description in record no " + i.ToString)
                    'Exit For
                Else
                    'valid = True
                End If

                '           If itemcode.Contains("'") Or scancode.Contains("'") Or descr.Contains("'") Or short_descr.Contains("'") Or pck.Contains("'") Or dept_name.Contains("'") Or _class_name.Contains("'") Or sub_class_name.Contains("'") Or supplier.Contains("'") Or cprice_vat_excl.Contains("'") Or vat.Contains("'") Or cprice_vat_incl.Contains("'") Or margin.Contains("'") Or discount.Contains("'") Or sprice.Contains("'") Or stock.Contains("'") Or min_stock.Contains("'") Or max_stock.Contains("'") Or reorder_level.Contains("'") Or uom.Contains("'") Then
                '           MsgBox("Invalid character ' at record no" + i.ToString)
                '           valid = False
                'Exit For
                '            End If

                'If valid = False Then
                'Exit For
                'End If
                ' Next
                If valid = False Then
                    Exit For
                End If
            Next
            lblOperation.Text = ""
            prgBar.Value = 0
            objXLApp.Quit()
        Catch e As NullReferenceException
            valid = False
            MsgBox("Error in record no " + k.ToString + " This record might have empty key values. Please fix the problem before proceeding")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return valid
    End Function
    Private Sub showProgress(number As Integer, count As Integer)
        prgBar.Value = (number / count) * 100
    End Sub

    Private Sub btnUploadMaster_Click(sender As Object, e As EventArgs) Handles btnUploadMaster.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Uploading... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items

                            Dim primaryBarcode As String = objXLWs.Range("A" & i).Value
                            Dim code As String = objXLWs.Range("B" & i).Value
                            Dim description As String = objXLWs.Range("C" & i).Value
                            Dim shortDescription As String = objXLWs.Range("D" & i).Value
                            Dim commonDescription As String = objXLWs.Range("E" & i).Value
                            Dim ingredients As String = objXLWs.Range("F" & i).Value
                            Dim packSize As String = objXLWs.Range("G" & i).Value
                            Dim standardUom As String = objXLWs.Range("H" & i).Value
                            Dim supplierCode As String = objXLWs.Range("I" & i).Value
                            Dim supplierName As String = objXLWs.Range("J" & i).Value
                            Dim departmentCode As String = objXLWs.Range("K" & i).Value
                            Dim departmentName As String = objXLWs.Range("L" & i).Value
                            Dim classCode As String = objXLWs.Range("M" & i).Value
                            Dim className As String = objXLWs.Range("N" & i).Value
                            Dim subClassCode As String = objXLWs.Range("O" & i).Value
                            Dim subClassName As String = objXLWs.Range("P" & i).Value
                            Dim costPriceVatIncl As String = objXLWs.Range("Q" & i).Value
                            Dim costPriceVatExcl As String = objXLWs.Range("R" & i).Value
                            Dim sellingPriceVatIncl As String = objXLWs.Range("S" & i).Value
                            Dim sellingPriceVatExcl As String = objXLWs.Range("T" & i).Value
                            Dim profitMargin As String = objXLWs.Range("U" & i).Value
                            Dim vat As String = objXLWs.Range("V" & i).Value
                            Dim discount As String = objXLWs.Range("W" & i).Value
                            Dim status As String = objXLWs.Range("X" & i).Value
                            Dim sellable As String = objXLWs.Range("Y" & i).Value
                            Dim returnable As String = objXLWs.Range("Z" & i).Value

                            Dim stock As String = objXLWs.Range("AA" & i).Value
                            Dim minimumInventory As String = objXLWs.Range("AB" & i).Value
                            Dim maximumInventory As String = objXLWs.Range("AC" & i).Value
                            Dim defaultReorderlevel As String = objXLWs.Range("AD" & i).Value
                            Dim defaultReorderQty As String = objXLWs.Range("AE" & i).Value

                            Dim product As Product = New Product
                            product.primaryBarcode = primaryBarcode
                            product.code = code
                            product.description = description
                            product.shortDescription = shortDescription
                            product.commonDescription = commonDescription
                            product.ingredients = ingredients
                            product.packSize = packSize
                            product.standardUom = standardUom
                            product.primarySupplier.code = supplierCode
                            product.primarySupplier.name = supplierName
                            product.department.code = departmentCode
                            product.department.name = departmentName
                            product.clas.code = classCode
                            product.clas.name = className
                            product.subClass.code = subClassCode
                            product.subClass.name = subClassName
                            product.costPriceVatIncl = costPriceVatIncl
                            product.costPriceVatExcl = costPriceVatExcl
                            product.sellingPriceVatIncl = sellingPriceVatIncl
                            product.sellingPriceVatExcl = sellingPriceVatExcl
                            product.profitMargin = profitMargin
                            product.vat = vat
                            product.discount = discount
                            product.status = status
                            product.sellable = sellable
                            product.returnable = returnable

                            product.stock = stock
                            product.minimumStock = minimumInventory
                            product.maximumStock = maximumInventory
                            product.defaultReorderLevel = defaultReorderlevel
                            product.defaultReorderQty = defaultReorderQty

                            Try
                                Web.post(product, "products/new")
                            Catch ex As Exception

                            End Try
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdatePrice_Click(sender As Object, e As EventArgs) Handles btnUpdatePrice.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0
        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating prices... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)



                            'upload items
                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            'Dim scancode As String = objXLWs.Range("B" & i).Value
                            'Dim descr As String = objXLWs.Range("C" & i).Value
                            ' Dim short_descr As String = objXLWs.Range("D" & i).Value
                            'Dim pck As String = objXLWs.Range("E" & i).Value
                            'Dim dept_name As String = objXLWs.Range("G" & i).Value
                            'Dim _class_name As String = objXLWs.Range("I" & i).Value
                            'Dim sub_class_name As String = objXLWs.Range("K" & i).Value
                            'Dim supplier As String = objXLWs.Range("L" & i).Value
                            Dim cprice_vat_excl As String = objXLWs.Range("N" & i).Value
                            Dim vat As String = objXLWs.Range("O" & i).Value
                            Dim cprice_vat_incl As String = objXLWs.Range("P" & i).Value
                            Dim margin As String = objXLWs.Range("Q" & i).Value
                            Dim discount As String = objXLWs.Range("R" & i).Value
                            Dim sprice As String = objXLWs.Range("S" & i).Value
                            'Dim stock As String = objXLWs.Range("T" & i).Value
                            'Dim min_stock As String = objXLWs.Range("U" & i).Value
                            'Dim max_stock As String = objXLWs.Range("V" & i).Value
                            'Dim reorder_level As String = objXLWs.Range("W" & i).Value
                            'Dim uom As String = objXLWs.Range("X" & i).Value
                            If itemcode = "" Then
                                Continue For
                            End If
                            Dim oldPrice As Double = (New Item).getItemPrice(itemcode)
                            If oldPrice = Val(sprice) Then
                                Continue For
                            End If
                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `items` SET `unit_cost_price`='" + cprice_vat_incl + "',`retail_price`='" + sprice + "',`discount`='" + discount + "',`vat`='" + vat + "',`margin`='" + margin + "' WHERE `item_code`='" + itemcode + "'"
                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()
                            Dim _item As New Item
                            _item.changePrice(itemcode, oldPrice, Val(sprice), "Mass price update")
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub btnUpdateInventory_Click(sender As Object, e As EventArgs) Handles btnUpdateInventory.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating stocks... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items
                            Dim itemcode As String = objXLWs.Range("A" & i).Value
                            Dim qty As String = objXLWs.Range("T" & i).Value

                            Dim conn As New MySqlConnection(Database.conString)
                            conn.Open()
                            Dim command As New MySqlCommand()
                            command.Connection = conn
                            command.CommandText = "UPDATE `inventorys` SET `qty`='" + qty + "' WHERE `item_code`='" + itemcode + "'"
                            command.Prepare()
                            command.ExecuteNonQuery()
                            conn.Close()
                            Dim stockCard As New StockCard
                            stockCard.qtyIn(Day.DAY, itemcode, Val(qty), Val(qty), "Stock adjustment, Mass update")
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnUpdateMaster_Click(sender As Object, e As EventArgs) Handles btnUpdateMaster.Click
        Cursor = Cursors.WaitCursor
        path = ""
        count = 0

        dlgOpenFile.ShowDialog()
        path = dlgOpenFile.FileName
        If validateFileFormat(path) = True Then
            If validateMasterFormat(path) = True Then
                count = getRecordCount(path)
                If validateMasterRecords(path) Then

                    Dim objXLApp As Excel.Application
                    Dim objXLWb As Excel.Workbook
                    Dim objXLWs As Excel.Worksheet

                    objXLApp = New Excel.Application
                    objXLApp.Workbooks.Open(path)
                    objXLWb = objXLApp.Workbooks(1)
                    objXLWs = objXLWb.Worksheets(1)

                    Try
                        prgBar.Value = 0
                        lblOperation.Text = "Updating... please wait"
                        For i As Integer = 2 To count
                            showProgress(i, count)
                            'upload items
                            Dim primaryBarcode As String = objXLWs.Range("A" & i).Value
                            Dim code As String = objXLWs.Range("B" & i).Value
                            Dim description As String = objXLWs.Range("C" & i).Value
                            Dim shortDescription As String = objXLWs.Range("D" & i).Value
                            Dim commonDescription As String = objXLWs.Range("E" & i).Value
                            Dim ingredients As String = objXLWs.Range("F" & i).Value
                            Dim packSize As String = objXLWs.Range("G" & i).Value
                            Dim standardUom As String = objXLWs.Range("H" & i).Value
                            Dim supplierCode As String = objXLWs.Range("I" & i).Value
                            Dim supplierName As String = objXLWs.Range("J" & i).Value
                            Dim departmentCode As String = objXLWs.Range("K" & i).Value
                            Dim departmentName As String = objXLWs.Range("L" & i).Value
                            Dim classCode As String = objXLWs.Range("M" & i).Value
                            Dim className As String = objXLWs.Range("N" & i).Value
                            Dim subClassCode As String = objXLWs.Range("O" & i).Value
                            Dim subClassName As String = objXLWs.Range("P" & i).Value
                            Dim costPriceVatIncl As String = objXLWs.Range("Q" & i).Value
                            Dim costPriceVatExcl As String = objXLWs.Range("R" & i).Value
                            Dim sellingPriceVatIncl As String = objXLWs.Range("S" & i).Value
                            Dim sellingPriceVatExcl As String = objXLWs.Range("T" & i).Value
                            Dim profitMargin As String = objXLWs.Range("U" & i).Value
                            Dim vat As String = objXLWs.Range("V" & i).Value
                            Dim discount As String = objXLWs.Range("W" & i).Value
                            Dim status As String = objXLWs.Range("X" & i).Value
                            Dim sellable As String = objXLWs.Range("Y" & i).Value
                            Dim returnable As String = objXLWs.Range("Z" & i).Value

                            Dim stock As String = objXLWs.Range("AA" & i).Value
                            Dim minimumInventory As String = objXLWs.Range("AB" & i).Value
                            Dim maximumInventory As String = objXLWs.Range("AC" & i).Value
                            Dim defaultReorderlevel As String = objXLWs.Range("AD" & i).Value
                            Dim defaultReorderQty As String = objXLWs.Range("AE" & i).Value

                            Dim product As Product = New Product
                            product.primaryBarcode = primaryBarcode
                            product.code = code
                            product.description = description
                            product.shortDescription = shortDescription
                            product.commonDescription = commonDescription
                            product.ingredients = ingredients
                            product.packSize = packSize
                            product.standardUom = standardUom
                            product.primarySupplier.code = supplierCode
                            product.primarySupplier.name = supplierName
                            product.department.code = departmentCode
                            product.department.name = departmentName
                            product.clas.code = classCode
                            product.clas.name = className
                            product.subClass.code = subClassCode
                            product.subClass.name = subClassName
                            product.costPriceVatIncl = costPriceVatIncl
                            product.costPriceVatExcl = costPriceVatExcl
                            product.sellingPriceVatIncl = sellingPriceVatIncl
                            product.sellingPriceVatExcl = sellingPriceVatExcl
                            product.profitMargin = profitMargin
                            product.vat = vat
                            product.discount = discount
                            product.status = status
                            product.sellable = sellable
                            product.returnable = returnable

                            product.stock = stock
                            product.minimumStock = minimumInventory
                            product.maximumStock = maximumInventory
                            product.defaultReorderLevel = defaultReorderlevel
                            product.defaultReorderQty = defaultReorderQty

                            Try
                                Web.put(product, "products/edit_by_code?code=" + code)
                            Catch ex As Exception

                            End Try
                        Next
                        lblOperation.Text = ""
                        MsgBox("Operation completed")
                        prgBar.Value = 0
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    objXLApp.Quit()
                Else
                    MsgBox("Operation failed. Incomplete records")
                    prgBar.Value = 0
                End If

            Else
                MsgBox("Invalid Format. The arrangement of the attributes is invalid")
            End If

        Else
            MsgBox("Invalid File Format. The input file should be in Exel(xlsl or xls) format")
        End If
        Cursor = Cursors.Default
    End Sub
    Private Function removeInvalidCharacters(value As String) As String
        Try
            value = value.Replace("'", "")
        Catch ex As Exception
            Return value
        End Try
        Return value
    End Function

    Private Sub btnGenerateItemMasterTemplate_Click(sender As Object, e As EventArgs) Handles btnGenerateItemMasterTemplate.Click
        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "PRIMARY_BARCODE"
        shXL.Cells(r, 2).Value = "CODE"
        shXL.Cells(r, 3).Value = "DESCRIPTION"
        shXL.Cells(r, 4).Value = "SHORT_DESCRIPTION"
        shXL.Cells(r, 5).Value = "COMMON_DESCRIPTION"
        shXL.Cells(r, 6).Value = "INGREDIENTS"
        shXL.Cells(r, 7).Value = "PACK_SIZE"
        shXL.Cells(r, 8).Value = "STANDARD_UOM"
        shXL.Cells(r, 9).Value = "SUPPLIER_CODE"
        shXL.Cells(r, 10).Value = "SUPPLIER_NAME"
        shXL.Cells(r, 11).Value = "DEPARTMENT_CODE"
        shXL.Cells(r, 12).Value = "DEPARTMENT_NAME"
        shXL.Cells(r, 13).Value = "CLASS_CODE"
        shXL.Cells(r, 14).Value = "CLASS_NAME"
        shXL.Cells(r, 15).Value = "SUB_CLASS_CODE"
        shXL.Cells(r, 16).Value = "SUB_CLASS_NAME"
        shXL.Cells(r, 17).Value = "COST_PRICE_VAT_INCL"
        shXL.Cells(r, 18).Value = "COST_PRICE_VAT_EXCL"
        shXL.Cells(r, 19).Value = "SELLING_PRICE_VAT_INCL"
        shXL.Cells(r, 20).Value = "SELLING_PRICE_VAT_EXCL"
        shXL.Cells(r, 21).Value = "PROFIT_MARGIN"
        shXL.Cells(r, 22).Value = "VAT"
        shXL.Cells(r, 23).Value = "DISCOUNT"
        shXL.Cells(r, 24).Value = "STATUS"
        shXL.Cells(r, 25).Value = "SELLABLE"
        shXL.Cells(r, 26).Value = "RETURNABLE"

        shXL.Cells(r, 27).Value = "STOCK"
        shXL.Cells(r, 28).Value = "MINIMUM_INVENTORY"
        shXL.Cells(r, 29).Value = "MAXIMUM_INVENTORY"
        shXL.Cells(r, 30).Value = "DEFAULT_REORDER_LEVEL"
        shXL.Cells(r, 31).Value = "DEFAULT_REORDER_QTY"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "AE1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "AE1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Product Master Template.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub btnDownloadMaster_Click(sender As Object, e As EventArgs) Handles btnDownloadMaster.Click
        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "PRIMARY_BARCODE"
        shXL.Cells(r, 2).Value = "CODE"
        shXL.Cells(r, 3).Value = "DESCRIPTION"
        shXL.Cells(r, 4).Value = "SHORT_DESCRIPTION"
        shXL.Cells(r, 5).Value = "COMMON_DESCRIPTION"
        shXL.Cells(r, 6).Value = "INGREDIENTS"
        shXL.Cells(r, 7).Value = "PACK_SIZE"
        shXL.Cells(r, 8).Value = "STANDARD_UOM"
        shXL.Cells(r, 9).Value = "SUPPLIER_CODE"
        shXL.Cells(r, 10).Value = "SUPPLIER_NAME"
        shXL.Cells(r, 11).Value = "DEPARTMENT_CODE"
        shXL.Cells(r, 12).Value = "DEPARTMENT_NAME"
        shXL.Cells(r, 13).Value = "CLASS_CODE"
        shXL.Cells(r, 14).Value = "CLASS_NAME"
        shXL.Cells(r, 15).Value = "SUB_CLASS_CODE"
        shXL.Cells(r, 16).Value = "SUB_CLASS_NAME"
        shXL.Cells(r, 17).Value = "COST_PRICE_VAT_INCL"
        shXL.Cells(r, 18).Value = "COST_PRICE_VAT_EXCL"
        shXL.Cells(r, 19).Value = "SELLING_PRICE_VAT_INCL"
        shXL.Cells(r, 20).Value = "SELLING_PRICE_VAT_EXCL"
        shXL.Cells(r, 21).Value = "PROFIT_MARGIN"
        shXL.Cells(r, 22).Value = "VAT"
        shXL.Cells(r, 23).Value = "DISCOUNT"
        shXL.Cells(r, 24).Value = "STATUS"
        shXL.Cells(r, 25).Value = "SELLABLE"
        shXL.Cells(r, 26).Value = "RETURNABLE"

        shXL.Cells(r, 27).Value = "STOCK"
        shXL.Cells(r, 28).Value = "MINIMUM_INVENTORY"
        shXL.Cells(r, 29).Value = "MAXIMUM_INVENTORY"
        shXL.Cells(r, 30).Value = "DEFAULT_REORDER_LEVEL"
        shXL.Cells(r, 31).Value = "DEFAULT_REORDER_QTY"


        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "AE1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With
        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "AE1")
        raXL.EntireColumn.AutoFit()
        Try

            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("products")
            Dim products As List(Of Product) = JsonConvert.DeserializeObject(Of List(Of Product))(response.ToString)
            For Each product In products
                lblOperation.Text = "Downloading... please wait"
                r = r + 1
                shXL.Cells(r, 1).Value = product.primaryBarcode
                shXL.Cells(r, 2).Value = product.code
                shXL.Cells(r, 3).Value = product.description
                shXL.Cells(r, 4).Value = product.shortDescription
                shXL.Cells(r, 5).Value = product.commonDescription
                shXL.Cells(r, 6).Value = product.ingredients
                shXL.Cells(r, 7).Value = product.packSize
                shXL.Cells(r, 8).Value = product.standardUom
                If Not IsNothing(product.primarySupplier) Then
                    shXL.Cells(r, 9).Value = product.primarySupplier.code
                    shXL.Cells(r, 10).Value = product.primarySupplier.name
                End If
                If Not IsNothing(product.department) Then
                    shXL.Cells(r, 11).Value = product.department.code
                    shXL.Cells(r, 12).Value = product.department.name
                End If
                If Not IsNothing(product.clas) Then
                    shXL.Cells(r, 13).Value = product.clas.code
                    shXL.Cells(r, 14).Value = product.clas.name
                End If
                If Not IsNothing(product.subClass) Then
                    shXL.Cells(r, 15).Value = product.subClass.code
                    shXL.Cells(r, 16).Value = product.subClass.name
                End If
                shXL.Cells(r, 17).Value = product.costPriceVatIncl
                shXL.Cells(r, 18).Value = product.costPriceVatExcl
                shXL.Cells(r, 19).Value = product.sellingPriceVatIncl
                shXL.Cells(r, 20).Value = product.sellingPriceVatExcl
                shXL.Cells(r, 21).Value = product.profitMargin
                shXL.Cells(r, 22).Value = product.vat
                shXL.Cells(r, 23).Value = product.discount
                shXL.Cells(r, 24).Value = product.status
                shXL.Cells(r, 25).Value = product.sellable
                shXL.Cells(r, 26).Value = product.returnable

                shXL.Cells(r, 27).Value = product.stock
                shXL.Cells(r, 28).Value = product.minimumStock
                shXL.Cells(r, 29).Value = product.maximumStock
                shXL.Cells(r, 30).Value = product.defaultReorderLevel
                shXL.Cells(r, 31).Value = product.defaultReorderQty
            Next
            lblOperation.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' AutoFit columns A:D.
        '  raXL = shXL.Range("A1", "AE1")
        '  raXL.EntireColumn.AutoFit()

        Dim strFileName As String = LSystem.saveToDesktop & "\Product Master.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try

        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
    End Sub

    Private Sub btnSupplierTemplate_Click(sender As Object, e As EventArgs) Handles btnSupplierTemplate.Click
        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "CODE"
        shXL.Cells(r, 2).Value = "NAME"
        shXL.Cells(r, 3).Value = "CONTACT_NAME"
        shXL.Cells(r, 4).Value = "TIN"
        shXL.Cells(r, 5).Value = "VRN"
        shXL.Cells(r, 6).Value = "STATUS"
        shXL.Cells(r, 7).Value = "TERMS_OF_CONTRACT"
        shXL.Cells(r, 8).Value = "PHYSICAL_ADDRESS"
        shXL.Cells(r, 9).Value = "POST_CODE"
        shXL.Cells(r, 10).Value = "POST_ADDRESS"
        shXL.Cells(r, 11).Value = "TELEPHONE"
        shXL.Cells(r, 12).Value = "MOBILE"
        shXL.Cells(r, 13).Value = "EMAIL"
        shXL.Cells(r, 14).Value = "FAX"
        shXL.Cells(r, 15).Value = "BANK_ACCOUNT_NAME"
        shXL.Cells(r, 16).Value = "BANK_ADDRESS"
        shXL.Cells(r, 17).Value = "BANK_POST_CODE"
        shXL.Cells(r, 18).Value = "BANK_NAME"
        shXL.Cells(r, 19).Value = "BANK_ACCOUNT_NO"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "S1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With


        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "S1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Supplier Master Template.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub btnSupplierMaster_Click(sender As Object, e As EventArgs) Handles btnSupplierMaster.Click
        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "CODE"
        shXL.Cells(r, 2).Value = "NAME"
        shXL.Cells(r, 3).Value = "CONTACT_NAME"
        shXL.Cells(r, 4).Value = "TIN"
        shXL.Cells(r, 5).Value = "VRN"
        shXL.Cells(r, 6).Value = "STATUS"
        shXL.Cells(r, 7).Value = "TERMS_OF_CONTRACT"
        shXL.Cells(r, 8).Value = "PHYSICAL_ADDRESS"
        shXL.Cells(r, 9).Value = "POST_CODE"
        shXL.Cells(r, 10).Value = "POST_ADDRESS"
        shXL.Cells(r, 11).Value = "TELEPHONE"
        shXL.Cells(r, 12).Value = "MOBILE"
        shXL.Cells(r, 13).Value = "EMAIL"
        shXL.Cells(r, 14).Value = "FAX"
        shXL.Cells(r, 15).Value = "BANK_ACCOUNT_NAME"
        shXL.Cells(r, 16).Value = "BANK_ADDRESS"
        shXL.Cells(r, 17).Value = "BANK_POST_CODE"
        shXL.Cells(r, 18).Value = "BANK_NAME"
        shXL.Cells(r, 19).Value = "BANK_ACCOUNT_NO"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "S1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "S1")
        raXL.EntireColumn.AutoFit()
        Try

            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("suppliers")
            Dim suppliers As List(Of Supplier) = JsonConvert.DeserializeObject(Of List(Of Supplier))(response.ToString)
            For Each supplier In suppliers
                lblOperation.Text = "Downloading... please wait"
                r = r + 1
                shXL.Cells(r, 1).Value = supplier.code
                shXL.Cells(r, 2).Value = supplier.name
                shXL.Cells(r, 3).Value = supplier.contactName
                shXL.Cells(r, 4).Value = supplier.tin
                shXL.Cells(r, 5).Value = supplier.vrn
                shXL.Cells(r, 6).Value = supplier.status
                shXL.Cells(r, 7).Value = supplier.termsOfContract
                shXL.Cells(r, 8).Value = supplier.physicalAddress
                shXL.Cells(r, 9).Value = supplier.postCode
                shXL.Cells(r, 10).Value = supplier.postAddress
                shXL.Cells(r, 11).Value = supplier.telephone
                shXL.Cells(r, 12).Value = supplier.mobile
                shXL.Cells(r, 13).Value = supplier.email
                shXL.Cells(r, 14).Value = supplier.fax
                shXL.Cells(r, 15).Value = supplier.bankAccountName
                shXL.Cells(r, 16).Value = supplier.bankPostAddress
                shXL.Cells(r, 17).Value = supplier.bankPostCode
                shXL.Cells(r, 18).Value = supplier.bankName
                shXL.Cells(r, 19).Value = supplier.bankAccountNo

            Next
            lblOperation.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "S1")
        raXL.EntireColumn.AutoFit()

        Dim strFileName As String = LSystem.saveToDesktop & "\Supplier Master.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try

        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
    End Sub

    Private Sub btnDownloadUnitTemplate_Click(sender As Object, e As EventArgs) Handles btnDownloadUnitTemplate.Click
        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1
        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "DEPARTMENT_CODE"
        shXL.Cells(r, 2).Value = "DEPARTMENT_NAME"
        shXL.Cells(r, 3).Value = "CLASS_CODE"
        shXL.Cells(r, 4).Value = "CLASS_NAME"
        shXL.Cells(r, 5).Value = "SUB_CLASS_CODE"
        shXL.Cells(r, 6).Value = "SUB_CLASS_NAME"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "F1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "F1")
        raXL.EntireColumn.AutoFit()
        Dim strFileName As String = LSystem.saveToDesktop & "\Units Master Template.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)

    End Sub

    Private Sub btnExportUnitsToExcel_Click(sender As Object, e As EventArgs) Handles btnExportUnitsToExcel.Click
        'to be reviewed later
        Exit Sub

        Cursor = Cursors.WaitCursor
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

        Dim r As Integer = 1

        ' Add table headers going cell by cell.
        shXL.Cells(r, 1).Value = "DEPARTMENT_CODE"
        shXL.Cells(r, 2).Value = "DEPARTMENT_NAME"
        shXL.Cells(r, 3).Value = "CLASS_CODE"
        shXL.Cells(r, 4).Value = "CLASS_NAME"
        shXL.Cells(r, 5).Value = "SUB_CLASS_CODE"
        shXL.Cells(r, 6).Value = "SUB_CLASS_NAME"

        ' Format A1:D1 as bold, vertical alignment = center.
        With shXL.Range("A1", "F1")
            .Font.Bold = True
            .VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        End With

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "F1")
        raXL.EntireColumn.AutoFit()
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("departments")
            Dim suppliers As List(Of Supplier) = JsonConvert.DeserializeObject(Of List(Of Supplier))(response.ToString)
            For Each supplier In suppliers
                lblOperation.Text = "Downloading... please wait"
                r = r + 1
                shXL.Cells(r, 1).Value = supplier.code
                shXL.Cells(r, 2).Value = supplier.name
                shXL.Cells(r, 3).Value = supplier.contactName
                shXL.Cells(r, 4).Value = supplier.tin
                shXL.Cells(r, 5).Value = supplier.vrn
                shXL.Cells(r, 6).Value = supplier.status
                shXL.Cells(r, 7).Value = supplier.termsOfContract
                shXL.Cells(r, 8).Value = supplier.physicalAddress
                shXL.Cells(r, 9).Value = supplier.postCode
                shXL.Cells(r, 10).Value = supplier.postAddress
                shXL.Cells(r, 11).Value = supplier.telephone
                shXL.Cells(r, 12).Value = supplier.mobile
                shXL.Cells(r, 13).Value = supplier.email
                shXL.Cells(r, 14).Value = supplier.fax
                shXL.Cells(r, 15).Value = supplier.bankAccountName
                shXL.Cells(r, 16).Value = supplier.bankPostAddress
                shXL.Cells(r, 17).Value = supplier.bankPostCode
                shXL.Cells(r, 18).Value = supplier.bankName
                shXL.Cells(r, 19).Value = supplier.bankAccountNo

            Next
            lblOperation.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' AutoFit columns A:D.
        raXL = shXL.Range("A1", "S1")
        raXL.EntireColumn.AutoFit()

        Dim strFileName As String = LSystem.saveToDesktop & "\Supplier Master.xls"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            Try
                'System.IO.File.Delete(strFileName)
            Catch ex As Exception
            End Try
        End If
        Try
            wbXl.Save()
        Catch ex As Exception

        End Try

        Cursor = Cursors.Default
        Exit Sub
Err_Handler:
        MsgBox(Err.Description, vbCritical, "Error: " & Err.Number)
    End Sub
End Class