Imports BackOffice
Imports Devart.Data.MySql

Public Class Item
    Inherits SubClass

    'Dim RECORD_MODE As Integer = 0 ' 0 save new, 1 save existing
    Public Shared GLOBAL_ITEM_CODE As String = ""

    Public GL_SUPPLIER_ID As String = ""


    Public GL_BAR_CODE As String = ""
    Public GL_ITEM_CODE As String = ""
    Public GL_SHORT_DESCR As String = ""
    Public GL_LONG_DESCR As String = ""
    Public GL_PCK As String = ""

    Public GL_COST_PRICE As Double = 0
    Public GL_RETAIL_PRICE As Double = 0
    Public GL_VAT As Double = 0

    Public GL_DISCOUNT As Double = 0
    Public GL_SUPPLIER As String = 0
    Public GL_MARGIN As Double = 0
    Public GL_STANDARD_UOM As String = ""
    Public GL_DEPARTMENT As String = ""
    Public GL_CLASS As String = ""
    Public GL_SUB_CLASS As String = ""
    Public GL_ACTIVE As String = ""

    Public Function getItemCode(barcode As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_code` FROM `items` WHERE `item_scan_code`='" + barcode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("department_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'added = False
        End Try
        Return id
    End Function
    Public Function getItemLongDescription(itemCode As String) As String
        Dim descr As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `item_long_description` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                descr = reader.GetString("item_long_description").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return descr
    End Function
    Public Function getItemUom(itemCode As String) As String
        Dim uom As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `standard_uom` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                uom = reader.GetString("standard_uom").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return uom
    End Function
    Public Function getItemPrice(itemCode As String) As String
        Dim price As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `retail_price` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                price = reader.GetString("retail_price")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return price
    End Function
    Public Function getItemCostPrice(itemCode As String) As String
        Dim price As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `unit_cost_price` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                price = reader.GetString("unit_cost_price")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return price
    End Function
    Public Function getVat(itemCode As String) As String
        Dim price As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `vat` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                price = reader.GetString("vat")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return price
    End Function
    Public Function addNewItem(special As Integer, barCode As String, itemCode As String, longDescr As String, shortDescr As String, pck As String, unitCostPrice As String, retailPrice As String, VAT As String, discount As String, supplier As String, margin As String, standardUOM As String, department As String, _class As String, subClasss As String) As Boolean
        Dim added As Boolean = False
        'local fields
        Dim deptID As String = ""
        Dim classID As String = ""
        Dim subClassID As String = ""
        Dim supplierID As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim reader As MySqlDataReader

            'get department id if present
            Dim deptQuery As String = "SELECT `department_id` FROM `department` WHERE `department_name`='" + department + "'"
            conn.Open()
            command.CommandText = deptQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                deptID = reader.GetString("department_id")
                Exit While
            End While
            conn.Close()

            'get class id if present
            Dim classQuery As String = "SELECT `class_id` FROM `class` WHERE `class_name`='" + _class + "'"
            conn.Open()
            command.CommandText = classQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                classID = reader.GetString("class_id")
                Exit While
            End While
            conn.Close()

            'get sub-class id if present
            Dim subClassQuery As String = "SELECT `sub_class_id` FROM `sub_class` WHERE `sub_class_name`='" + subClasss + "'"
            conn.Open()
            command.CommandText = subClassQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                subClassID = reader.GetString("sub_class_id")
                Exit While
            End While
            conn.Close()

            'get supplier id if present
            Dim suppQuery As String = "SELECT `supplier_id` FROM `supplier` WHERE `supplier_name`='" + supplier + "'"
            conn.Open()
            command.CommandText = suppQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                supplierID = reader.GetString("supplier_id")
                Exit While
            End While
            conn.Close()


            Try
                'add a new item
                Dim Query As String = "INSERT INTO `items`(`item_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`) VALUES (@item_code,@item_long_description,@item_description,@pck,@department_id,@class_id,@sub_class_id,@supplier_id,@unit_cost_price,@retail_price,@discount,@vat,@margin,@standard_uom)"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@item_code", itemCode)
                command.Parameters.AddWithValue("@item_long_description", longDescr)
                command.Parameters.AddWithValue("@item_description", shortDescr)
                command.Parameters.AddWithValue("@pck", pck)
                command.Parameters.AddWithValue("@department_id", deptID)
                command.Parameters.AddWithValue("@class_id", classID)
                command.Parameters.AddWithValue("@sub_class_id", subClassID)
                command.Parameters.AddWithValue("@supplier_id", (New Supplier).getSupplierID("", supplier))
                command.Parameters.AddWithValue("@unit_cost_price", unitCostPrice)
                command.Parameters.AddWithValue("@retail_price", retailPrice)
                command.Parameters.AddWithValue("@discount", discount)
                command.Parameters.AddWithValue("@vat", VAT)
                command.Parameters.AddWithValue("@margin", margin)
                command.Parameters.AddWithValue("@standard_uom", standardUOM)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Could not save record. Duplicate entry in item code", vbCritical + vbOKOnly, "Error")
                Exit Function
            End Try

            Try
                'add item to inventory table
                Dim invQuery As String = "INSERT INTO `inventorys`(`item_code`) VALUES (@item_code)"
                conn.Open()
                command.CommandText = invQuery
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@item_code", itemCode)
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Could not update inventory. Duplicate entry in item code", vbCritical + vbOKOnly, "Error")
                ' Exit Function
            End Try

            Try
                'create bar code
                If barCode <> "" And special = 0 Then
                    Dim codeQuery As String = "INSERT INTO `bar_codes`(`item_scan_code`,`item_code`) VALUES (@item_scan_code,@item_code)"
                    conn.Open()
                    command.CommandText = codeQuery
                    command.Connection = conn
                    command.CommandType = CommandType.Text
                    command.Parameters.AddWithValue("@item_scan_code", barCode)
                    command.Parameters.AddWithValue("@item_code", itemCode)
                    command.ExecuteNonQuery()
                    conn.Close()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Could not save barcode. Duplicate entry in barcode", vbCritical + vbOKOnly, "Error")
                'Exit Function
            End Try
            Item.GLOBAL_ITEM_CODE = itemCode
            added = True

        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Could not save record.", vbCritical + vbOKOnly, "Error")
        End Try
        Return added
#Disable Warning BC42353 ' Function 'addNewItem' doesn't return a value on all code paths. Are you missing a 'Return' statement?
    End Function
#Enable Warning BC42353 ' Function 'addNewItem' doesn't return a value on all code paths. Are you missing a 'Return' statement?
    Public Function getItems(descr As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            'Dim query As String = "SELECT `items`.`item_code`,`items`.`item_long_description`, `inventorys`.`item_code`FROM `items`,`inventorys` WHERE  `items`.`item_long_description` LIKE '%" + descr + "%' LIMIT 1,100"
            Dim query As String = "SELECT `item_long_description` FROM `items`"

            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            Try
                list.Clear()
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim itemreader As MySqlDataReader = command.ExecuteReader()
                If itemreader.HasRows = True Then
                    While itemreader.Read
                        list.Add(itemreader("item_long_description").ToString)
                    End While
                Else
                    Return list
                    Exit Function
                End If
            Catch ex As Devart.Data.MySql.MySqlException
                MsgBox(ex.Message)
                Return list
                Exit Function
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return list
    End Function
    Public Function getItems() As List(Of String)
        Dim list As New List(Of String)
        Try
            'Dim query As String = "SELECT `items`.`item_code`,`items`.`item_long_description`, `inventorys`.`item_code`FROM `items`,`inventorys` WHERE  `items`.`item_long_description` LIKE '%" + descr + "%' LIMIT 1,100"
            Dim query As String = "SELECT `item_long_description` FROM `items`"

            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            Try
                list.Clear()
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim itemreader As MySqlDataReader = command.ExecuteReader()
                If itemreader.HasRows = True Then
                    While itemreader.Read
                        list.Add(itemreader("item_long_description").ToString)
                    End While
                Else
                    Return list
                    Exit Function
                End If
            Catch ex As Devart.Data.MySql.MySqlException
                MsgBox(ex.Message)
                Return list
                Exit Function
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return list
    End Function
    Public Function getItems(descr As String, supplierId As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            'Dim query As String = "SELECT `items`.`item_code`,`items`.`item_long_description`, `inventorys`.`item_code`FROM `items`,`inventorys` WHERE  `items`.`item_long_description` LIKE '%" + descr + "%' LIMIT 1,100"
            Dim query As String = "SELECT `item_long_description` FROM `items` WHERE `supplier_id`='" + supplierId + "'"

            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            Try
                list.Clear()
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim itemreader As MySqlDataReader = command.ExecuteReader()
                If itemreader.HasRows = True Then
                    While itemreader.Read
                        list.Add(itemreader("item_long_description").ToString)
                    End While
                Else
                    Return list
                    Exit Function
                End If
            Catch ex As Devart.Data.MySql.MySqlException
                MsgBox(ex.Message)
                Return list
                Exit Function
            End Try

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return list
    End Function
    Public Function getBarCodes(itemCode As String) As List(Of String)
        Dim list As New List(Of String)
        Try
            Dim query As String = "SELECT `item_scan_code`, `item_code` FROM `bar_codes` WHERE `item_code`='" + itemCode + "'"
            Dim command As New MySqlCommand()
            Dim conn As New MySqlConnection(Database.conString)
            Try
                list.Clear()
                conn.Open()
                command.CommandText = query
                command.Connection = conn
                command.CommandType = CommandType.Text
                Dim itemreader As MySqlDataReader = command.ExecuteReader()
                If itemreader.HasRows = True Then
                    While itemreader.Read
                        list.Add(itemreader("item_scan_code").ToString)
                    End While
                Else
                    Return list
                    Exit Function
                End If
            Catch ex As Devart.Data.MySql.MySqlException
                MsgBox(ex.Message)
                Return list
                Exit Function
            End Try
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
        Return list
    End Function
    Public Function editItem(barCode As String, itemCode As String, longDescr As String, shortDescr As String, pck As String, unitCostPrice As String, retailPrice As String, VAT As String, discount As String, supplier As String, margin As String, standardUOM As String, department As String, _class As String, subClass As String) As Boolean
        Dim edited As Boolean = False
        'local fields
        Dim deptID As String = ""
        Dim classID As String = ""
        Dim subClassID As String = ""
        Dim supplierID As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim reader As MySqlDataReader
            'create bar code
            'Dim codeQuery As String = "INSERT INTO `bar_codes`(`item_scan_code`,`item_code`) VALUES (@item_scan_code,@item_code)"
            'conn.Open()
            'command.CommandText = codeQuery
            'command.Connection = conn
            'command.CommandType = CommandType.Text
            'command.Parameters.AddWithValue("@item_scan_code", barCode)
            'command.Parameters.AddWithValue("@item_code", itemCode)
            'command.ExecuteNonQuery()
            'conn.Close()

            'get department id if present

            Dim dept As New Department
            deptID = dept.getDepartmentID(department)

            'get class id if present
            Dim class_ As New Class_
            classID = class_.getClassID(_class)



            'get sub-class id if present

            Dim sub_class As New SubClass
            subClassID = sub_class.getSubClassID(subClass)



            'get supplier id if present
            Dim suppQuery As String = "SELECT `supplier_id` FROM `supplier` WHERE `supplier_name`='" + supplier + "'"
            conn.Open()
            command.CommandText = suppQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                supplierID = reader.GetString("supplier_id")
                Exit While
            End While
            conn.Close()

            Dim oldPrice As Double = (New Item).getItemPrice(itemCode)
            Dim Query As String = "UPDATE `items` SET `item_long_description`=@item_long_description,`item_description`=@item_description,`pck`=@pck,`department_id`=@department_id,`class_id`=@class_id,`sub_class_id`=@sub_class_id,`supplier_id`=@supplier_id,`unit_cost_price`=@unit_cost_price,`retail_price`=@retail_price,`discount`=@discount,`vat`=@vat,`margin`=@margin,`standard_uom`=@standard_uom WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = Query
            command.Connection = conn
            command.CommandType = CommandType.Text
            'command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@item_long_description", longDescr)
            command.Parameters.AddWithValue("@item_description", shortDescr)
            command.Parameters.AddWithValue("@pck", pck)
            command.Parameters.AddWithValue("@department_id", deptID)
            command.Parameters.AddWithValue("@class_id", classID)
            command.Parameters.AddWithValue("@sub_class_id", subClassID)
            command.Parameters.AddWithValue("@supplier_id", supplierID)
            command.Parameters.AddWithValue("@unit_cost_price", unitCostPrice)
            command.Parameters.AddWithValue("@retail_price", retailPrice)
            command.Parameters.AddWithValue("@discount", discount)
            command.Parameters.AddWithValue("@vat", VAT)
            command.Parameters.AddWithValue("@margin", margin)
            command.Parameters.AddWithValue("@standard_uom", standardUOM)
            command.ExecuteNonQuery()
            conn.Close()

            'add item to inventory table
            'Dim invQuery As String = "INSERT INTO `inventorys`(`item_code`) VALUES (@item_code)"
            'conn.Open()
            'command.CommandText = invQuery
            'command.Connection = conn
            'command.CommandType = CommandType.Text
            'command.Parameters.AddWithValue("@item_code", itemCode)
            'command.ExecuteNonQuery()
            'conn.Close()

            Item.GLOBAL_ITEM_CODE = itemCode

            Dim _item As New Item
            _item.changePrice(itemCode, oldPrice, retailPrice, "Mass change by user")
            edited = True

        Catch ex As Exception
            MsgBox("Could not save record", vbCritical + vbOKOnly, "Error")
        End Try
        Return edited
    End Function
    Public Function deleteItem(itemCode As String) As Boolean
        Dim deleted As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'delete department
            Dim codeQuery As String = "DELETE FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text

            command.ExecuteNonQuery()
            conn.Close()
            deleted = True
        Catch ex As Exception
            deleted = False
        End Try


        Return deleted
    End Function
    Public Function searchItem(itemCode As String) As Boolean
        Dim found As Boolean = False
        Try

            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim reader As MySqlDataReader

            Dim query As String = "SELECT `item_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`,`active` FROM `items` WHERE `item_code`='" + itemCode + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            reader = command.ExecuteReader
            While reader.Read
                Me.GL_ITEM_CODE = reader.GetString("item_code")
                Me.GL_SHORT_DESCR = reader.GetString("item_description")
                Me.GL_LONG_DESCR = reader.GetString("item_long_description")
                Me.GL_PCK = reader.GetString("pck")
                Me.GL_COST_PRICE = Val(reader.GetString("unit_cost_price"))
                Me.GL_RETAIL_PRICE = Val(reader.GetString("retail_price"))
                Me.GL_VAT = Val(reader.GetString("vat"))
                Me.GL_DISCOUNT = Val(reader.GetString("discount"))
                Me.GL_SUPPLIER_ID = reader.GetString("supplier_id")
                Me.GL_SUPPLIER = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")
                Me.GL_MARGIN = Val(reader.GetString("margin"))
                Me.GL_STANDARD_UOM = reader.GetString("standard_uom")
                Me.GL_DEPARTMENT = (New Department).getDepartmentName(reader.GetString("department_id"))
                Me.GL_CLASS = (New Class_).getClassName(reader.GetString("class_id"))
                Me.GL_SUB_CLASS = (New SubClass).getSubClassName(reader.GetString("sub_class_id"))
                Me.GL_ACTIVE = reader.GetString("active")
                found = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try

        Return found
    End Function

    Public Function getItemCode(barCode As String, descr As String) As String
        Dim code As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = ""
            If barCode <> "" Then
                query = "SELECT  `item_code` FROM `bar_codes` WHERE `item_scan_code`='" + barCode + "'"
            Else
                query = "SELECT  `item_code`  FROM `items` WHERE `item_long_description`='" + descr + "'"
            End If
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                code = reader.GetString("item_code")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return code
    End Function
    Public Function getSupplierId(supplierCode As String, supplierName As String, itemCode As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `supplier_id` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("supplier_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return id
    End Function
    Public Function getUom(itemCode As String) As String
        Dim uom As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `standard_uom` FROM `items` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                uom = reader.GetString("standard_uom")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return uom
    End Function

    Public Function getSaleId(billNo As String, itemCode As String) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `sale_id` FROM `sale_details` WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("sale_id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return id
    End Function

    Public Function isExist(itemCode As String) As Boolean
        Dim exist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `item_code` FROM `items` WHERE `item_code`='" + itemCode + "'"

            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                exist = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return exist
    End Function
    Public Function getStock(itemCode As String)
        Dim stock As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `qty` FROM `inventorys` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                stock = reader.GetString("qty")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return stock
    End Function
    Public Function getBarCodesString(itemCode As String)
        Dim barcodes As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim query As String = "SELECT `item_scan_code` FROM `bar_codes` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                barcodes = barcodes + reader.GetString("item_scan_code") + "   "
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return barcodes
    End Function
    Public Function changePrice(itemCode As String, oldPrice As Double, newPrice As Double, reason As String)
        Dim changed As Boolean = False
        If oldPrice <> newPrice Then
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Try
                'add a new item
                Dim Query As String = "INSERT INTO `price_history`(`date`,  `item_code`, `old_price`, `new_price`, `user_id`, `reason`) VALUES (@date,@item_code,@old_price,@new_price,@user_id,@reason)"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@date", Day.DAY)
                command.Parameters.AddWithValue("@item_code", itemCode)
                command.Parameters.AddWithValue("@old_price", oldPrice)
                command.Parameters.AddWithValue("@new_price", newPrice)
                command.Parameters.AddWithValue("@user_id", User.CURRENT_USER_ID)
                command.Parameters.AddWithValue("@reason", reason)
                command.ExecuteNonQuery()
                conn.Close()
                changed = True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Return changed
    End Function




End Class
