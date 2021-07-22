Imports System.Windows.Forms
Imports Devart.Data.MySql
Imports Microsoft.PointOfService.PosPrinter
Imports POS.Devices
Imports Microsoft.PointOfService

Public Class frmMain

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Dim barCode As String = ""
    Dim itemCode As String = ""
    Dim description As String = ""
    Dim longDescription As String = ""
    Dim pck As String = ""
    Dim price As String = ""
    Dim vat As String = ""
    Dim discount As String = ""
    Dim qty As String = ""
    Dim amount As String = ""
    Dim void As Boolean = False
    Dim allowVoid As Boolean = False
    Dim seq As Integer = 0


    Private Function openCashDrawer()
        Dim isOpen As Boolean = False
        Try
            'Dim cashDrawer As New OPOSCashDrawer

            Dim deviceInfo As DeviceInfo
            Dim posExplorer As New PosExplorer
            Dim strLogicalName As String = ""
            Dim ppdi As Microsoft.PointOfService.DeviceInfo = posExplorer.GetDevice(DeviceType.CashDrawer, strLogicalName)

            Dim P As Microsoft.PointOfService.CashDrawer = posExplorer.CreateInstance(ppdi)
            deviceInfo = posExplorer.GetDevice(DeviceType.CashDrawer, strLogicalName)
            P = posExplorer.CreateInstance(deviceInfo)
            P.OpenDrawer()

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation + vbOKOnly, "Error: Cash Drawer")
        End Try
        Return isOpen
    End Function
    Private Function add(barCode As String, itemCode As String, descr As String, pck As String, price As String, vat As String, disc As String, qty As String, amount As String, shortDescr As String)

        Dim dtgrdRow As New DataGridViewRow
        Dim dtgrdCell As DataGridViewCell

        dtgrdViewItemList.EndEdit()

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = barCode
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = itemCode.ToString
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = descr.ToString
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = pck.ToString
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = price
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = vat
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = disc
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = qty
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdCell = New DataGridViewTextBoxCell()
        dtgrdCell.Value = amount
        dtgrdRow.Cells.Add(dtgrdCell)

        dtgrdViewItemList.Rows.Add(dtgrdRow)
        Return vbNull
    End Function

    Private Sub dtgrdViewItemList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdViewItemList.CellEndEdit
        Dim qty As Integer = 0
        Dim sn As String = ""
        Try
            qty = Val(dtgrdViewItemList.Item(7, e.RowIndex).Value)
            sn = dtgrdViewItemList.Item(11, e.RowIndex).Value.ToString
        Catch ex As Exception

        End Try

        If Val(dtgrdViewItemList.Item(7, e.RowIndex).Value) >= 0 And Val(dtgrdViewItemList.Item(7, e.RowIndex).Value) <= 1000 Then
            If qty > 0 Then
                updateQty(qty, sn)
            Else
                updateQty("0", sn)
            End If
            calculateValues()
        Else
            MsgBox("Invalid quantity value. Quantity value should be between 1 and 1000", vbOKOnly + vbCritical, "Error: Invalid entry")
            dtgrdViewItemList.Item(7, e.RowIndex).Value = 1
            calculateValues()
        End If
        Try
            If dtgrdViewItemList.CurrentCell.ColumnIndex = 2 Then
                'search() 'do further research
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If msg.WParam.ToInt32() = Keys.Enter Then
            dtgrdViewItemList.EndEdit()
            search()
            Return True
            Exit Function
        End If
        ' Return MyBase.ProcessCmdKey(msg, keyData)
        Return False
    End Function

    Private Sub search()
        Try
            Dim row As Integer = dtgrdViewItemList.CurrentCell.RowIndex
            Dim col As Integer = dtgrdViewItemList.CurrentCell.ColumnIndex
            If col = 0 And row = dtgrdViewItemList.RowCount - 2 Then
                'search item
                'add item to list
                Dim value As String = ""
                Dim search As Boolean = True
                Try
                    value = dtgrdViewItemList.Rows(row).Cells(col).Value.ToString
                    If value = "" Or value = "0" Then
                        search = False
                        Exit Sub
                    End If
                Catch ex As Exception
                    search = False
                End Try
                If search = True Then
                    Dim found As Boolean = searchByBarcode(value, 1)
                    If found = True Then
                        'item found
                        If SaleSequence.multiple = True Then
                            For i As Integer = 0 To 7
                                'SendKeys.Send("{right}")
                            Next
                        Else
                            'SendKeys.Send("{down}")
                        End If
                    ElseIf found = False Then
                        MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                    End If

                End If
            ElseIf col = 7 And row = dtgrdViewItemList.RowCount - 2 Then
                For i As Integer = 0 To 6
                    ' SendKeys.Send("{left}")
                Next
                ' SendKeys.Send("{down}")
            End If
            If col = 1 And row = dtgrdViewItemList.RowCount - 2 Then
                'search item
                'add item to list
                Dim value As String = ""
                Dim search As Boolean = True
                Try
                    value = dtgrdViewItemList.Rows(row).Cells(col).Value.ToString
                    If value = "" Or value = "0" Then
                        search = False
                        Exit Sub
                    End If
                Catch ex As Exception
                    search = False
                End Try
                If search = True Then
                    Dim found As Boolean = searchByItemCode(value, 1)
                    If found = True Then
                        'item found
                        If SaleSequence.multiple = True Then
                            For i As Integer = 0 To 6
                                ' SendKeys.Send("{right}")
                            Next
                        Else
                            ' SendKeys.Send("{down}")
                            'SendKeys.Send("{left}")
                        End If
                    ElseIf found = False Then
                        MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                    End If

                End If
            ElseIf col = 7 And row = dtgrdViewItemList.RowCount - 2 Then
                For i As Integer = 0 To 6
                    'SendKeys.Send("{left}")
                Next
                ' SendKeys.Send("{down}")
            End If
            If col = 2 And row = dtgrdViewItemList.RowCount - 2 Then
                'search item
                'add item to list
                Dim value As String = ""
                Dim search As Boolean = True
                Try
                    value = dtgrdViewItemList.Rows(row).Cells(col).Value.ToString
                    If value = "" Then
                        search = False
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.StackTrace)
                    search = False
                End Try
                If search = True Then
                    Dim found As Boolean = searchByDescription(value, 1)
                    If found = True Then
                        'item found
                        If SaleSequence.multiple = True Then
                            For i As Integer = 0 To 4
                                ' SendKeys.Send("{right}")
                            Next
                        Else
                            ' SendKeys.Send("{down}")
                            ' SendKeys.Send("{left}")
                            'SendKeys.Send("{left}")
                        End If
                    ElseIf found = False Then
                        MsgBox("Item not found", vbOKOnly + vbExclamation, "Error: Not found")
                    End If

                End If
            ElseIf col = 7 And row = dtgrdViewItemList.RowCount - 2 Then
                For i As Integer = 0 To 6
                    '  SendKeys.Send("{left}")
                Next
                ' SendKeys.Send("{down}")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' refreshList()
        ' dtgrdViewItemList.Select()
    End Sub

    Private Function searchByBarcode(barCode As String, q As Integer)

        Dim found As Boolean = False
        Dim query As String = "SELECT `items`.`item_code`, `bar_codes`.`item_scan_code`, `items`.`item_description`,`items`.`item_long_description`,`items`.`pck`, `items`.`retail_price`,`items`.`discount`,`items`.`vat`,`inventorys`.`item_code` FROM `items`,`inventorys`,`bar_codes` WHERE `items`.`item_code`=`inventorys`.`item_code` AND `bar_codes`.`item_scan_code` =@item_scan_code AND `bar_codes`.`item_code`=`items`.`item_code`"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@item_scan_code", barCode)
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try

        Dim reader As MySqlDataReader = command.ExecuteReader()
        Dim no As Integer = 0
        Dim row As Integer = 0
        Try
            row = dtgrdViewItemList.CurrentCell.RowIndex
        Catch ex As Exception
            dtgrdViewItemList.Rows.Add()
            row = dtgrdViewItemList.CurrentCell.RowIndex
        End Try
        Try
            If reader.HasRows = True Then
                While reader.Read
                    barCode = reader.GetString("item_scan_code")
                    itemCode = reader.GetString("item_code")
                    description = reader.GetString("item_description")
                    longDescription = reader.GetString("item_long_description")
                    pck = reader.GetString("pck")
                    price = reader.GetString("retail_price")
                    discount = reader.GetString("discount")
                    vat = reader.GetString("vat")
                    qty = q
                    price = (Val(price)) * (1 - Val(discount) / 100)
                    amount = (Val(qty) * price) * (1 - Val(discount) / 100)

                    found = True

                    If barCode = "" Then
                        found = False
                        loadCart(Till.TILLNO)
                    End If
                    If found = True Then
                        If addInList(itemCode, barCode) = True Then
                            loadCart(Till.TILLNO)
                        Else
                            dtgrdViewItemList.Item(0, row).Value = barCode
                            dtgrdViewItemList.Item(1, row).Value = itemCode
                            dtgrdViewItemList.Item(2, row).Value = longDescription
                            dtgrdViewItemList.Item(4, row).Value = LCurrency.displayValue(price.ToString)
                            dtgrdViewItemList.Item(5, row).Value = LCurrency.displayValue(vat.ToString)
                            dtgrdViewItemList.Item(6, row).Value = LCurrency.displayValue(discount.ToString)
                            dtgrdViewItemList.Item(7, row).Value = qty
                            dtgrdViewItemList.Item(8, row).Value = LCurrency.displayValue(amount.ToString)
                            dtgrdViewItemList.Item(10, row).Value = description

                            dtgrdViewItemList.Item(0, row).ReadOnly = True
                            dtgrdViewItemList.Item(1, row).ReadOnly = True
                            dtgrdViewItemList.Item(2, row).ReadOnly = True

                            seq = seq + 1
                            AddToCart(Format(Now, "mm/dd/yy hh:mm:ss") + (New Random).Next(0, 1000).ToString + Till.TILLNO + seq.ToString, Till.TILLNO, dtgrdViewItemList.Item(0, row).Value, dtgrdViewItemList.Item(1, row).Value, dtgrdViewItemList.Item(2, row).Value, dtgrdViewItemList.Item(4, row).Value, dtgrdViewItemList.Item(5, row).Value, dtgrdViewItemList.Item(6, row).Value, dtgrdViewItemList.Item(7, row).Value, dtgrdViewItemList.Item(8, row).Value, dtgrdViewItemList.Item(10, row).Value)
                        End If

                        If dtgrdViewItemList.RowCount > 1 Then
                            If dtgrdViewItemList.Item(7, row - 1).Value > 1 Then
                                SaleSequence.multiple = True
                            Else
                                SaleSequence.multiple = False
                            End If
                        End If
                    Else
                        loadCart(Till.TILLNO)
                    End If
                    Exit While
                End While
            Else
                dtgrdViewItemList.Item(0, row).Value = ""
                dtgrdViewItemList.Item(1, row).Value = ""
                dtgrdViewItemList.Item(2, row).Value = ""
                dtgrdViewItemList.Item(4, row).Value = ""
                dtgrdViewItemList.Item(5, row).Value = ""
                dtgrdViewItemList.Item(6, row).Value = ""
                dtgrdViewItemList.Item(7, row).Value = ""
                dtgrdViewItemList.Item(8, row).Value = ""

                dtgrdViewItemList.EndEdit()
                refreshList()
                calculateValues()
            End If
        Catch ex As Exception

        End Try

        'refreshList()
        'calculateValues()
        loadCart(Till.TILLNO)
        Return found
    End Function
    Private Function searchByDescription(longDescr As String, q As Integer)

        Dim found As Boolean = False
        Dim query As String = "SELECT `sn`, `item_code`, `item_scan_code`, `item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`, `active` FROM `items` WHERE `item_long_description`='" + longDescr + "'"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try

        Dim reader As MySqlDataReader = command.ExecuteReader()
        Dim no As Integer = 0
        Dim row As Integer = 0
        Try
            row = dtgrdViewItemList.CurrentCell.RowIndex
        Catch ex As Exception
            dtgrdViewItemList.Rows.Add()
            row = dtgrdViewItemList.CurrentCell.RowIndex
        End Try
        Try
            If reader.HasRows = True Then
                While reader.Read
                    'barCode = reader.GetString("item_scan_code")
                    itemCode = reader.GetString("item_code")
                    description = reader.GetString("item_description")
                    longDescription = reader.GetString("item_long_description")
                    pck = reader.GetString("pck")
                    price = reader.GetString("retail_price")
                    discount = reader.GetString("discount")
                    vat = reader.GetString("vat")
                    qty = q
                    price = (Val(price)) * (1 - Val(discount) / 100)
                    amount = (Val(qty) * price) * (1 - Val(discount) / 100)

                    found = True
                    If found = True Then

                        If addInList(itemCode, "") = True Then
                            loadCart(Till.TILLNO)
                        Else

                            dtgrdViewItemList.Item(0, row).Value = barCode
                            dtgrdViewItemList.Item(1, row).Value = itemCode
                            dtgrdViewItemList.Item(2, row).Value = longDescription
                            dtgrdViewItemList.Item(4, row).Value = LCurrency.displayValue(price.ToString)
                            dtgrdViewItemList.Item(5, row).Value = LCurrency.displayValue(vat.ToString)
                            dtgrdViewItemList.Item(6, row).Value = LCurrency.displayValue(discount.ToString)
                            dtgrdViewItemList.Item(7, row).Value = qty
                            dtgrdViewItemList.Item(8, row).Value = LCurrency.displayValue(amount.ToString)
                            dtgrdViewItemList.Item(10, row).Value = description
                            dtgrdViewItemList.Item(0, row).ReadOnly = True
                            dtgrdViewItemList.Item(1, row).ReadOnly = True
                            dtgrdViewItemList.Item(2, row).ReadOnly = True

                            seq = seq + 1
                            AddToCart(Format(Now, "mm/dd/yy hh:mm:ss") + (New Random).Next(0, 1000).ToString + Till.TILLNO + seq.ToString, Till.TILLNO, dtgrdViewItemList.Item(0, row).Value, dtgrdViewItemList.Item(1, row).Value, dtgrdViewItemList.Item(2, row).Value, dtgrdViewItemList.Item(4, row).Value, dtgrdViewItemList.Item(5, row).Value, dtgrdViewItemList.Item(6, row).Value, dtgrdViewItemList.Item(7, row).Value, dtgrdViewItemList.Item(8, row).Value, dtgrdViewItemList.Item(10, row).Value)

                        End If

                        If dtgrdViewItemList.RowCount > 1 Then
                            If dtgrdViewItemList.Item(7, row - 1).Value > 1 Then
                                SaleSequence.multiple = True
                            Else
                                SaleSequence.multiple = False
                            End If
                        End If
                    Else
                        loadCart(Till.TILLNO)
                    End If
                    Exit While
                End While
            Else
                dtgrdViewItemList.Item(0, row).Value = ""
                dtgrdViewItemList.Item(1, row).Value = ""
                dtgrdViewItemList.Item(2, row).Value = ""
                dtgrdViewItemList.Item(4, row).Value = ""
                dtgrdViewItemList.Item(5, row).Value = ""
                dtgrdViewItemList.Item(6, row).Value = ""
                dtgrdViewItemList.Item(7, row).Value = ""
                dtgrdViewItemList.Item(8, row).Value = ""

                dtgrdViewItemList.EndEdit()
                refreshList()
                calculateValues()
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)

        End Try

        'refreshList()
        'calculateValues()
        loadCart(Till.TILLNO)
        Return found
    End Function
    Private Function searchByItemCode(itemCode As String, q As Integer)

        Dim found As Boolean = False
        Dim query As String = "SELECT `items`.`item_code`, `items`.`item_description`,`items`.`item_long_description`,`items`.`pck`, `items`.`retail_price`,`items`.`discount`,`items`.`vat`,`inventorys`.`item_code` FROM `items`,`inventorys` WHERE `items`.`item_code`=`inventorys`.`item_code` AND `items`.`item_code` =@item_code"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@item_code", itemCode)
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try
        Dim reader As MySqlDataReader = command.ExecuteReader()
        Dim no As Integer = 0
        Dim row As Integer = 0
        Try
            row = dtgrdViewItemList.CurrentCell.RowIndex
        Catch ex As Exception
            dtgrdViewItemList.Rows.Add()
            row = dtgrdViewItemList.CurrentCell.RowIndex
        End Try
        Try
            If reader.HasRows = True Then
                While reader.Read
                    'barCode = reader.GetString("item_scan_code")
                    itemCode = reader.GetString("item_code")
                    description = reader.GetString("item_description")
                    longDescription = reader.GetString("item_long_description")
                    pck = reader.GetString("pck")
                    price = reader.GetString("retail_price")
                    discount = reader.GetString("discount")
                    vat = reader.GetString("vat")
                    qty = q
                    price = (Val(price)) * (1 - Val(discount) / 100)
                    amount = (Val(qty) * price) * (1 - Val(discount) / 100)

                    found = True

                    If found = True Then

                        If addInList(itemCode, "") = True Then
                            loadCart(Till.TILLNO)
                        Else

                            dtgrdViewItemList.Item(0, row).Value = barCode
                            dtgrdViewItemList.Item(1, row).Value = itemCode
                            dtgrdViewItemList.Item(2, row).Value = longDescription
                            dtgrdViewItemList.Item(4, row).Value = LCurrency.displayValue(price.ToString)
                            dtgrdViewItemList.Item(5, row).Value = LCurrency.displayValue(vat.ToString)
                            dtgrdViewItemList.Item(6, row).Value = LCurrency.displayValue(discount.ToString)
                            dtgrdViewItemList.Item(7, row).Value = qty
                            dtgrdViewItemList.Item(8, row).Value = LCurrency.displayValue(amount.ToString)
                            dtgrdViewItemList.Item(10, row).Value = description

                            dtgrdViewItemList.Item(0, row).ReadOnly = True
                            dtgrdViewItemList.Item(1, row).ReadOnly = True
                            dtgrdViewItemList.Item(2, row).ReadOnly = True

                            seq = seq + 1
                            AddToCart(Format(Now, "mm/dd/yy hh:mm:ss") + (New Random).Next(0, 1000).ToString + Till.TILLNO + seq.ToString, Till.TILLNO, dtgrdViewItemList.Item(0, row).Value, dtgrdViewItemList.Item(1, row).Value, dtgrdViewItemList.Item(2, row).Value, dtgrdViewItemList.Item(4, row).Value, dtgrdViewItemList.Item(5, row).Value, dtgrdViewItemList.Item(6, row).Value, dtgrdViewItemList.Item(7, row).Value, dtgrdViewItemList.Item(8, row).Value, dtgrdViewItemList.Item(10, row).Value)

                        End If

                        If dtgrdViewItemList.RowCount > 1 Then
                            If dtgrdViewItemList.Item(7, row - 1).Value > 1 Then
                                SaleSequence.multiple = True
                            Else
                                SaleSequence.multiple = False
                            End If
                        End If
                    Else
                        loadCart(Till.TILLNO)
                    End If
                    Exit While
                End While
            Else
                dtgrdViewItemList.Item(0, row).Value = ""
                dtgrdViewItemList.Item(1, row).Value = ""
                dtgrdViewItemList.Item(2, row).Value = ""
                dtgrdViewItemList.Item(4, row).Value = ""
                dtgrdViewItemList.Item(5, row).Value = ""
                dtgrdViewItemList.Item(6, row).Value = ""
                dtgrdViewItemList.Item(7, row).Value = ""
                dtgrdViewItemList.Item(8, row).Value = ""

                dtgrdViewItemList.EndEdit()
                'refreshList()
                'calculateValues()
                loadCart(Till.TILLNO)
            End If
        Catch ex As Exception
            ' MsgBox(ex.StackTrace)
        End Try

        'refreshList()
        'calculateValues()
        loadCart(Till.TILLNO)
        Return found
    End Function
    Private Function refreshList()
        If dtgrdViewItemList.RowCount > 0 Then
            Dim max As Integer = dtgrdViewItemList.RowCount - 2
            For i As Integer = max To 0 Step -1
                If dtgrdViewItemList.Item(1, i).Value = "" Or Val(dtgrdViewItemList.Item(7, i).Value) <= 0 Then
                    ' dtgrdViewItemList.Rows.RemoveAt(i)
                End If
            Next
        End If
        Try
            dtgrdViewItemList.EndEdit()
            If voidRow > -1 Then
                dtgrdViewItemList.Item(9, voidRow).Value = False
                If dtgrdViewItemList.Item(9, voidRow).Value = True Then
                    dtgrdViewItemList.Item(9, voidRow).Value = False
                Else
                    dtgrdViewItemList.Item(9, voidRow).Value = True
                End If
            End If
            voidRow = -1
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return vbNull
    End Function
    Dim allow As Boolean = False
    Private Function calculateValues()
        'If dtgrdViewItemList.RowCount > 0 Then
        '    Dim max As Integer = dtgrdViewItemList.RowCount - 2
        '    For i As Integer = max To 0 Step -1
        '        If dtgrdViewItemList.Item(1, i).Value = "" Or Val(dtgrdViewItemList.Item(7, i).Value) <= 0 Then
        '            dtgrdViewItemList.Rows.RemoveAt(i)
        '        End If
        '    Next
        'End If
        Try
            dtgrdViewItemList.EndEdit()
            Dim _total As Double = 0
            Dim _vat As Double = 0
            Dim _discount As Double = 0
            Dim _grandTotal As Double = 0
            Dim rows As Integer = dtgrdViewItemList.RowCount
            For i As Integer = 0 To rows - 2

                Dim price As Double = Val(LCurrency.getValue(dtgrdViewItemList.Item(4, i).Value))
                Dim vat As Double = Val(LCurrency.getValue(dtgrdViewItemList.Item(5, i).Value))
                Dim discount As Double = Val(LCurrency.getValue(dtgrdViewItemList.Item(6, i).Value))
                Dim qty As Integer = Val(dtgrdViewItemList.Item(7, i).Value)

                Dim amount As Double = price * qty * (1 - discount / 100)
                dtgrdViewItemList.Item(8, i).Value = LCurrency.displayValue(amount.ToString)


                If dtgrdViewItemList.Item(9, i).Value = False Then
                    _total = _total + Val(LCurrency.getValue(dtgrdViewItemList.Item(8, i).Value.ToString))
                    _vat = _vat + ((Val(LCurrency.getValue(dtgrdViewItemList.Item(5, i).Value.ToString)))) * Val(LCurrency.getValue(dtgrdViewItemList.Item(8, i).Value.ToString) / (100 + Val(LCurrency.getValue(dtgrdViewItemList.Item(5, i).Value.ToString))))


                    Dim discountedPrice As Double = Val(LCurrency.getValue(price)) * (1 - Val(discount) / 100)

                    _discount = _discount + ((price - discountedPrice) * qty)

                    '_discount = _discount + (Val(LCurrency.getValue(dtgrdViewItemList.Item(6, i).Value.ToString)) / 100) * Val(LCurrency.getValue(dtgrdViewItemList.Item(8, i).Value.ToString))
                End If
            Next
            _grandTotal = _total
            txtTotal.Text = LCurrency.displayValue(_total)
            txtDiscount.Text = LCurrency.displayValue(_discount)
            txtVAT.Text = LCurrency.displayValue(_vat)
            txtGrandTotal.Text = LCurrency.displayValue(_grandTotal)
        Catch ex As Exception
            'MsgBox(ex.StackTrace)
        End Try

        Return vbNull
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        refreshList()
        calculateValues()
    End Sub
    Dim voidRow As Integer = -1
    Private Sub dtgrdViewItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdViewItemList.CellContentClick
        Dim row As Integer = -1
        Dim col As Integer = -1

        Try
            row = dtgrdViewItemList.CurrentRow.Index
            col = dtgrdViewItemList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try

        dtgrdViewItemList.EndEdit()

        If dtgrdViewItemList.CurrentCell.ColumnIndex = 9 Then
            Dim sn As String = dtgrdViewItemList.Item(11, dtgrdViewItemList.CurrentCell.RowIndex).Value
            loadCart(Till.TILLNO)
            Dim void As Boolean = checkVoid(Till.TILLNO, sn)
            If allowVoid = False Then


                If User.authorize("VOID") Then
                    'manager and chief cashier can void directly without entering passswords
                    allowVoid = True
                Else
                    frmAllow.ShowDialog()
                    If frmAllow.allowed = True Then
                        allowVoid = True
                    End If
                End If

            End If

            If allowVoid = True Then
                If void = True Then
                    unvoid(Till.TILLNO, sn)
                Else
                    _void(Till.TILLNO, sn)
                End If
            End If
            loadCart(Till.TILLNO)
        End If

        refreshList()
        calculateValues()
    End Sub
    Dim discountDialog As frmDiscount
    Private Sub dtgrdViewItemList_CellClick1(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdViewItemList.CellClick
        Dim row As Integer = -1
        Dim col As Integer = -1
        Dim amount = 0
        Dim item As String = ""
        Dim unitPrice As String = ""

        Try
            row = dtgrdViewItemList.CurrentRow.Index
            col = dtgrdViewItemList.CurrentCell.ColumnIndex
            amount = Val(LCurrency.getValue(dtgrdViewItemList.Item(4, row).Value.ToString))
            item = "(" + dtgrdViewItemList.Item(1, row).Value.ToString + ")  " + dtgrdViewItemList.Item(2, row).Value.ToString
            unitPrice = dtgrdViewItemList.Item(4, row).Value.ToString

        Catch ex As Exception
            row = -1
        End Try

        dtgrdViewItemList.EndEdit()

        If dtgrdViewItemList.CurrentCell.ColumnIndex = 6 Then
            Dim sn As String = dtgrdViewItemList.Item(11, dtgrdViewItemList.CurrentCell.RowIndex).Value
            loadCart(Till.TILLNO)

            'process discount

            If User.authorize("DISCOUNT") = True Then

                discountDialog = New frmDiscount()
                discountDialog.lblItem.Text = item
                discountDialog.lblUnitPrice.Text = "Unit Price " + unitPrice
                discountDialog.ShowDialog()
                If discountDialog.DialogResult = Windows.Forms.DialogResult.OK Then
                    Dim discount As String = discountDialog.txtDiscount.Text
                    If Val(discount) <= amount Then

                        Dim discPercentage = (Val(discount) / amount) * 100

                        updateDiscount(Till.TILLNO, sn, discPercentage.ToString)

                    Else
                        MsgBox("Invalid Discount Amount. Discount should be less than Unit Price", vbOKOnly + vbCritical, "Invalid Amount")

                    End If
                    discountDialog.Dispose()

                Else
                    discountDialog.Dispose()
                End If
            Else
                MsgBox("Operation denied!", vbOKOnly + vbExclamation)
            End If

            loadCart(Till.TILLNO)
        End If

        refreshList()
        calculateValues()
    End Sub
    Private Sub updateDiscount(tillNo As String, sn As String, disc As String)
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "UPDATE `cart` SET `discount`='" + disc + "' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            Exit Sub
        End Try
    End Sub
    Dim dialog As frmSearchItem
    Private Function setDetails()
        Dim barCode As String = dialog.txtBarCode.Text
        Dim itemCode As String = dialog.txtItemCode.Text
        Dim description As String = dialog.txtDescription.Text
        Dim pck As String = dialog.txtPck.Text
        Dim price As String = dialog.txtPrice.Text
        Dim vat As String = dialog.txtVAT.Text
        Dim discount As String = dialog.txtDiscount.Text
        Dim qty As String = dialog.txtQty.Text
        Dim amount As String = dialog.txtAmount.Text
        Dim shortDescr As String = dialog.txtShortDescription.Text

        add(barCode, itemCode, description, pck, price, vat, discount, qty, amount, shortDescr)

        Return vbNull
    End Function
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles tlstrpBarcode.Click
        Dim cont As Boolean = True
        Try
            While cont = True
                dialog = New frmSearchItem()
                dialog.lblSearchBy.Text = "Bar Code"
                dialog.ShowDialog()
                If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
                    setDetails()
                    dialog.Dispose()
                Else
                    dialog.Dispose()
                    cont = False
                End If
                calculateValues()
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles tlsrpItemcode.Click
        Dim cont As Boolean = True
        Try
            While cont = True
                dialog = New frmSearchItem()
                dialog.Text = "Search Item by Item Code"
                dialog.lblSearchBy.Text = "Item Code"
                dialog.ShowDialog()
                If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
                    setDetails()
                    dialog.Dispose()
                Else
                    dialog.Dispose()
                    cont = False
                End If
                calculateValues()
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles tlstrDescription.Click
        'Dim cont As Boolean = True
        'While cont = True
        '    Try
        '        dialog = New frmSearchItem()
        '        dialog.Text = "Search Item by Description"
        '        dialog.lblSearchBy.Text = "Description"
        '        dialog.ShowDialog(Me)
        '        If dialog.DialogResult = Windows.Forms.DialogResult.OK Then
        '            setDetails()
        '            dialog.Dispose()
        '        Else
        '            dialog.Dispose()
        '            cont = False
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    calculateValues()
        'End While

        Dim control As TextBox = DirectCast(dtgrdViewItemList.EditingControl, TextBox)

        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(control.Text)
        mySource.AddRange(list.ToArray)
        control.AutoCompleteCustomSource = mySource
        control.AutoCompleteMode = AutoCompleteMode.Suggest
        control.AutoCompleteSource = AutoCompleteSource.CustomSource


    End Sub

    Private TILL_NO As String = ""
    Private RECEIPT_NO As Integer = 0
    Private totalTaxReturns As Double = 0
    Private Function recordSale(receiptNo As String)
        Dim recorded As Boolean = False
        Dim tillNO As String = Till.TILLNO
        Dim dayDate As String = Day.systemDate
        Dim dateTime As DateTime = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Dim total As Double = LCurrency.getValue(txtTotal.Text)
        Dim discount As Double = LCurrency.getValue(txtDiscount.Text)
        Dim vat As Double = LCurrency.getValue(txtVAT.Text)
        Dim amount As Double = LCurrency.getValue(txtGrandTotal.Text)


        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `sale`( `till_no`,`user_id`,`date`, `date_time`, `amount`, `discount`, `vat`,`tax_return`) VALUES (@till_no,@user_id,@date,@date_time,@amount,@discount,@vat,@tax_return)"
            command.Prepare()
            command.Parameters.AddWithValue("@till_no", tillNO)
            command.Parameters.AddWithValue("@user_id", User.USER_ID)
            command.Parameters.AddWithValue("@date_time", dateTime)
            command.Parameters.AddWithValue("@date", dayDate)
            command.Parameters.AddWithValue("@amount", amount)
            command.Parameters.AddWithValue("@discount", discount)
            command.Parameters.AddWithValue("@vat", vat)
            command.Parameters.AddWithValue("@tax_return", totalTaxReturns)
            command.ExecuteNonQuery()
            Dim sn As String = command.InsertId.ToString
            recorded = True
            saleId = "BL" + command.InsertId.ToString

            conn.Close()
            conn.Open()
            command.CommandText = "UPDATE `sale` SET `id`='" + saleId + "' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            recorded = True
            conn.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `receipt`( `bill_no`, `till_no`, `receipt_no`, `date`) VALUES (@id,@till_no,@receipt_no,@date)"
            command.Prepare()
            command.Parameters.AddWithValue("@id", saleId)
            command.Parameters.AddWithValue("@till_no", tillNO)
            command.Parameters.AddWithValue("@receipt_no", receiptNo)
            command.Parameters.AddWithValue("@date", dayDate)
            command.ExecuteNonQuery()
            recorded = True
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Return vbNull
            Exit Function
        End Try
        Return recorded
    End Function
    Private Function isAllVoid()
        Dim allVoid As Boolean = True
        For i As Integer = 0 To dtgrdViewItemList.RowCount - 2
            If dtgrdViewItemList.Item(9, i).Value = False Then
                allVoid = False
            End If
        Next
        Return allVoid
    End Function
    Private Function recordSaleDetails(salesId As String)
        Dim recorded As Boolean = False
        totalTaxReturns = 0

        For i As Integer = 0 To dtgrdViewItemList.RowCount - 2
            If dtgrdViewItemList.Item(9, i).Value = False Then

                Dim barCode As String = dtgrdViewItemList.Item(0, i).Value
                Dim itemCode As String = dtgrdViewItemList.Item(1, i).Value
                Dim description As String = dtgrdViewItemList.Item(2, i).Value
                Dim price As String = dtgrdViewItemList.Item(4, i).Value
                Dim vat As String = dtgrdViewItemList.Item(5, i).Value
                Dim discount As String = dtgrdViewItemList.Item(6, i).Value
                Dim qty As String = dtgrdViewItemList.Item(7, i).Value
                Dim amount As String = dtgrdViewItemList.Item(8, i).Value
                Dim discountedPrice As Double = Val(LCurrency.getValue(price)) * (1 - Val(discount) / 100)
                Dim actualVat As Double = Val(qty) * discountedPrice * Val(vat) / 100
                Dim taxReturn As Double = Val(qty) * (discountedPrice - Item.getCostPrice(itemCode)) * Val(vat) / 100
                totalTaxReturns = totalTaxReturns + taxReturn

                'sql for recording sales
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()

                Try
                    conn.Open()
                    command.Connection = conn
                    command.CommandText = "INSERT INTO `sale_details`(`sale_id`, `item_code`, `selling_price`, `discounted_price`, `qty`, `amount`, `vat`,`tax_return`) VALUES (@sale_id,@item_code,@selling_price,@discounted_price,@qty,@amount,@vat,@tax_return)"
                    command.Prepare()
                    command.Parameters.AddWithValue("@sale_id", salesId)
                    command.Parameters.AddWithValue("@item_code", itemCode)
                    command.Parameters.AddWithValue("@selling_price", LCurrency.getValue(price))
                    command.Parameters.AddWithValue("@discounted_price", discountedPrice)
                    command.Parameters.AddWithValue("@qty", Val(qty))
                    command.Parameters.AddWithValue("@amount", LCurrency.getValue(amount))
                    command.Parameters.AddWithValue("@vat", actualVat)
                    command.Parameters.AddWithValue("@tax_return", taxReturn)
                    command.ExecuteNonQuery()
                    conn.Close()
                    recorded = True
                Catch ex As Devart.Data.MySql.MySqlException
                    LError.databaseConnection()
                    recorded = False
                    Return vbNull
                    Exit Function
                End Try
            End If
        Next

        Dim conn2 As New MySqlConnection(Database.conString)
        Try
            conn2.Open()
            Dim command2 As New MySqlCommand()
            command2.Connection = conn2
            command2.CommandText = "UPDATE `sale` SET `tax_return`='" + totalTaxReturns.ToString + "' WHERE `id`='" + saleId + "'"
            command2.Prepare()
            command2.ExecuteNonQuery()
            conn2.Close()
        Catch ex As Devart.Data.MySql.MySqlException
            MsgBox(ex.Message)
            Return vbNull
            Exit Function
        End Try
        Return recorded
    End Function
    Private Function updateInventory(ref As String)
        For i As Integer = 0 To dtgrdViewItemList.RowCount - 2
            If dtgrdViewItemList.Item(9, i).Value = False Then
                Dim itemCode As String = dtgrdViewItemList.Item(1, i).Value
                Dim qty As String = dtgrdViewItemList.Item(7, i).Value
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
                    stockCard.qtyOut(Day.systemDate, itemCode, qty, inventory.getInventory(itemCode), "Product Sale, " + ref)
                Catch ex As Devart.Data.MySql.MySqlException
                    LError.databaseConnection()
                    Return vbNull
                    Exit Function
                End Try
            End If
        Next
        Return vbNull
    End Function

    Private Function printReceipt(tillNo As String, receiptNo As String, date_ As String, TIN As String, VRN As String, cash As String, balance As String)
        Dim printed As Boolean = False
        Dim size As Integer = -1
        For i As Integer = 0 To dtgrdViewItemList.RowCount - 2
            If dtgrdViewItemList.Item(9, i).Value = False Then
                size = size + 1
            End If
        Next
        Dim itemCode(size) As String
        Dim descr(size) As String
        Dim qty(size) As String
        Dim price(size) As String
        Dim tax(size) As String
        Dim amount(size) As String
        Dim subTotal As String = txtTotal.Text
        Dim totalVat As String = txtVAT.Text
        Dim total As String = txtGrandTotal.Text
        Dim discount As String = txtDiscount.Text
        Dim count As Integer = 0

        For i As Integer = 0 To dtgrdViewItemList.RowCount - 2
            If dtgrdViewItemList.Item(9, i).Value = False Then
                itemCode(count) = dtgrdViewItemList.Item(1, i).Value
                'descr(count) = dtgrdViewItemList.Item(10, i).Value
                descr(count) = (New Item).getShortDescription(itemCode(count))
                qty(count) = dtgrdViewItemList.Item(7, i).Value
                price(count) = dtgrdViewItemList.Item(4, i).Value
                tax(count) = dtgrdViewItemList.Item(5, i).Value
                amount(count) = dtgrdViewItemList.Item(8, i).Value
                count = count + 1
            End If
        Next
        If PointOfSale.printReceipt(tillNo, receiptNo, date_, TIN, VRN, itemCode, descr, qty, price, tax, amount, subTotal, totalVat, total, cash, balance) = True Then
            printed = True
        End If
        Return printed
    End Function
    Dim saleId As String = ""
    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        refreshList()
        calculateValues()
        If dtgrdViewItemList.RowCount > 0 And isAllVoid() = False Then
            frmPayPoint.txtTotal.Text = FormatNumber(txtGrandTotal.Text, 2, , , TriState.True)
            frmPayPoint.ShowDialog(Me)
            If frmPayPoint.DialogResult = Windows.Forms.DialogResult.Cancel Then
                calculateValues()
            Else
                Dim cashReceived As String = frmPayPoint.cashReceived
                Dim balance As String = frmPayPoint.balance
                Dim tillNo As String = Till.TILLNO
                Dim date_ As String = Day.systemDate
                Dim receiptNo As String = RECEIPT_NO.ToString
                Dim TIN As String = Company.TIN
                Dim VRN As String = Company.VRN

                'If PointOfSale.posPrinterEnabled = True Then
                If printReceipt(tillNo, receiptNo, date_, TIN, VRN, cashReceived, balance) = True Then
                    ''
                Else
                    MsgBox("Payment cancelled", vbOKOnly + vbInformation, "Cancelled")
                    Exit Sub
                End If

                If recordSale(RECEIPT_NO.ToString) Then
                    Payment.commitPayment(saleId)
                    Dim bill As New Bill
                    bill.createBill(saleId, LCurrency.getValue(txtGrandTotal.Text), "DR", "COMPLETED", Day.systemDate, "Customer purchase")
                    RECEIPT_NO = RECEIPT_NO + 1

                    'record sales details with the specified sale id
                    If Not recordSaleDetails(saleId) = True Then
                        Exit Sub
                    End If
                    frmPayPoint.updateTill()
                    Dim ref As String = "TillNo: " + tillNo + " Date: " + date_ + " ReceiptNo: " + receiptNo
                    updateInventory(ref)
                    dtgrdViewItemList.Rows.Clear()

                    Dim conn As New MySqlConnection(Database.conString)
                    Try
                        conn.Open()
                        Dim command As New MySqlCommand()
                        command.Connection = conn
                        command.CommandText = "UPDATE `cart` SET `till_no`='DIRTYVALUE' WHERE `till_no`='" + Till.TILLNO + "'"
                        command.Prepare()
                        command.ExecuteNonQuery()
                        conn.Close()
                    Catch ex As Exception
                        MsgBox(ex.StackTrace)
                        Exit Sub
                    End Try
                    loadCart(Till.TILLNO)
                    Do While dtgrdViewItemList.RowCount > 1
                        emptyCart(Till.TILLNO)
                        loadCart(Till.TILLNO)
                    Loop
                    For i As Integer = 1 To 3
                        If emptyCart(Till.TILLNO) = True Then
                            Exit For
                        End If
                    Next

                    calculateValues()
                            allowVoid = False
                        Else
                            MsgBox("Payment could not be completed", vbCritical + vbOKOnly, "Error: NO connection")
                End If
            End If
        End If
    End Sub
    Private Function addInList(icode As String, barcode As String)
        Dim updated As Boolean = False
        Dim sn As String = ""
        Try
            For i As Integer = 0 To dtgrdViewItemList.RowCount - 3
                If dtgrdViewItemList.Item(1, i).Value.ToString = icode And dtgrdViewItemList.Item(9, i).Value = False Then
                    sn = dtgrdViewItemList.Item(11, i).Value.ToString
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try

        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "UPDATE `cart` SET `qty`=qty+1 WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            conn.Close()
            If sn <> "" Then
                updated = True
            End If
        Catch ex As Exception

            Return updated
            Exit Function
        End Try
        If barcode <> "" Then
            Try
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `cart` SET `bar_code`='" + barcode + "' WHERE `sn`='" + sn + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception

            End Try
        End If
        Return updated
    End Function
    Private Function updateQty(qty As Integer, sn As String)
        Dim updated As Boolean = False

        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "UPDATE `cart` SET `qty`='" + qty.ToString + "' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            conn.Close()
            If sn <> "" Then
                updated = True
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return updated
            Exit Function
        End Try

        Return updated
    End Function
    Private Sub tpsLock_Click(sender As Object, e As EventArgs) Handles tpsLock.Click
        frmLock.ShowDialog()
    End Sub
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RECEIPT_NO = (New Receipt).makeReceipt(Till.TILLNO, Day.systemDate)
        loadCart(Till.TILLNO)
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tspStatus.Text = tspStatus.Text + "Logged in"
        tspUser.Text = tspUser.Text + User.FIRST_NAME + " " + User.LAST_NAME
        tspLogginTime.Text = tspLogginTime.Text + User.LOGIN_TIME
        tpsSystDate.Text = tpsSystDate.Text + Day.systemDate
        If User.authorize("SELLING") Then
            dtgrdViewItemList.Enabled = True
            tlsrpItemcode.Enabled = True
            tlstrDescription.Enabled = True
            tlstrpBarcode.Enabled = True
            btnPay.Enabled = True

        End If
        Dim item As New Item
        longList = item.getItemDescriptions()
    End Sub
    Private Function loadUser(role As String)

        Return vbNull
    End Function
    Private Sub FloatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FloatToolStripMenuItem.Click

        If User.authorize("FLOAT MANAGEMENT") Then
            frmFloat.ShowDialog()
        Else
            MsgBox("Access denied")
        End If

    End Sub

    Private Sub PickUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickUpToolStripMenuItem.Click

        If User.authorize("CASH PICK UP") Then
            frmCashPickUp.ShowDialog()
        Else
            MsgBox("Access denied")
        End If

    End Sub

    Private Sub PettyCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PettyCashToolStripMenuItem.Click

        If User.authorize("PETTY CASH MANAGEMENT") Then
            frmPettyCash.ShowDialog()
        Else
            MsgBox("Access denied")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQuantity.Click
        frmNumInput.Text = "Enter Quantity"
        Dim qty As String = ""
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            col = dtgrdViewItemList.CurrentCell.ColumnIndex
            row = dtgrdViewItemList.CurrentRow.Index
        Catch ex As Exception
            row = -1
        End Try
        If row < 0 Then
            MsgBox("Select item to change Quantity", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        If col <> 7 Then
            MsgBox("Point to the Quantity value to be changed", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        refreshList()
        If dtgrdViewItemList.RowCount > 1 Then
            frmNumInput.ShowDialog(Me)
        Else
            Exit Sub
        End If

        If frmNumInput.DialogResult = Windows.Forms.DialogResult.OK Then
            qty = frmNumInput.txtValue.Text
            If IsNumeric(qty.ToString) And Val(qty.ToString) Mod 1 = 0 And Val(qty) > 0 And row >= 0 Then
                dtgrdViewItemList.Item(7, row).Value = qty.ToString
                calculateValues()
            Else
                MsgBox("Invalid Quantity. Quantity should be a whole number ie. 1,2,3,...", vbExclamation + vbOKOnly, "Error: Invalid Entry")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        frmNumInput.Text = "Enter Discount 0%-100%"
        Dim disc As String = ""
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            col = dtgrdViewItemList.CurrentCell.ColumnIndex
            row = dtgrdViewItemList.CurrentRow.Index
        Catch ex As Exception
            row = -1
        End Try
        If row < 0 Then
            MsgBox("Select item to change Discount", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        If col <> 6 Then
            MsgBox("Point to the Discount value to be changed", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        refreshList()
        If dtgrdViewItemList.RowCount > 1 Then
            frmNumInput.ShowDialog(Me)
        Else
            Exit Sub
        End If

        If frmNumInput.DialogResult = Windows.Forms.DialogResult.OK Then
            disc = frmNumInput.txtValue.Text
            If IsNumeric(disc.ToString) And Val(disc.ToString) >= 0 And Val(disc.ToString) <= 100 And row >= 0 Then
                frmAllow.ShowDialog()
                If frmAllow.allowed = True Then
                    dtgrdViewItemList.Item(6, row).Value = LCurrency.displayValue(disc.ToString)
                    calculateValues()
                Else
                    Return
                End If
            Else
                MsgBox("Invalid Value. Discount should be in percentage value between 0 and 100", vbExclamation + vbOKOnly, "Error: Invalid Entry")
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnPrice.Click
        frmNumInput.Text = "Enter Price"
        Dim price As String = ""
        Dim row As Integer = -1
        Dim col As Integer = -1
        Try
            row = dtgrdViewItemList.CurrentRow.Index
            col = dtgrdViewItemList.CurrentCell.ColumnIndex
        Catch ex As Exception
            row = -1
        End Try
        If row < 0 Then
            MsgBox("Select item to change Price", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        If col <> 4 Then
            MsgBox("Point to the Price value to be changed", vbExclamation + vbOKOnly, "Error: No Selection")
            Return
        End If
        refreshList()
        If dtgrdViewItemList.RowCount > 1 Then
            frmNumInput.ShowDialog(Me)
        Else
            Exit Sub
        End If
        If frmNumInput.DialogResult = Windows.Forms.DialogResult.OK Then
            price = frmNumInput.txtValue.Text
            If IsNumeric(price.ToString) And row >= 0 Then
                frmAllow.ShowDialog()
                If frmAllow.allowed = True Then
                    dtgrdViewItemList.Item(4, row).Value = LCurrency.displayValue(price.ToString)
                    calculateValues()
                Else
                    Return
                End If
            Else
                MsgBox("Invalid Value. Price should be a number ie.200, 1000, 3500.00 etc", vbExclamation + vbOKOnly, "Error: Invalid Entry")
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmAllow.ShowDialog()
        If frmAllow.allowed = True Then
            Try
                dtgrdViewItemList.Rows.RemoveAt(dtgrdViewItemList.CurrentRow.Index)
            Catch ex As Exception
                MsgBox("No item selected", vbOKOnly + vbExclamation, "Error: No selection")
            End Try
            calculateValues()
        Else
            Return
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmAllow.ShowDialog()
        If frmAllow.allowed = True Then
            If dtgrdViewItemList.RowCount < 2 Then
                MsgBox("List empty!", vbOKOnly + vbExclamation, "Error: List empty")
                Exit Sub
            End If
            Try
                Dim res As Integer = MsgBox("Clear item list? This can not be undone. Proceed any way?", vbYesNo + vbQuestion, "Clear List")
                If res = 6 Then
                    dtgrdViewItemList.Rows.Clear()
                    calculateValues()
                End If
            Catch ex As Exception
                '
            End Try
        Else
            Return
        End If
    End Sub

    Private Sub XReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XReportToolStripMenuItem.Click
        frmXReport.ShowDialog()
    End Sub

    Private Sub ZReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZReportToolStripMenuItem.Click
        frmZReport.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        openCashDrawer()
    End Sub

    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmFiscalPrinter.ShowDialog()
    End Sub

    Private Sub PrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrinterToolStripMenuItem.Click
        frmPrinters.ShowDialog()
    End Sub

    Private Sub StatusStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip.ItemClicked

    End Sub

    Private Sub ToolStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Protected Overridable Function place(key As String)
        Try
            Dim row As Integer = dtgrdViewItemList.CurrentCell.RowIndex
            Dim col As Integer = dtgrdViewItemList.CurrentCell.ColumnIndex
            If dtgrdViewItemList.CurrentCell.ColumnIndex = 0 Or dtgrdViewItemList.CurrentCell.ColumnIndex = 1 Or dtgrdViewItemList.CurrentCell.ColumnIndex = 2 Or dtgrdViewItemList.CurrentCell.ColumnIndex = 7 Then

                dtgrdViewItemList.Select()
                dtgrdViewItemList.CurrentCell = dtgrdViewItemList.Item(col, row)
                'Dim control As TextBox = DirectCast(dtgrdViewItemList.EditingControl, TextBox)
                Dim control As TextBox = DirectCast(dtgrdViewItemList.EditingControl, TextBox)
                control.SelectionStart = dtgrdViewItemList.CurrentCell.Value.ToString.Length
                control.SelectionLength = 0
                SendKeys.Send(key)
            Else
                dtgrdViewItemList.Select()
                dtgrdViewItemList.CurrentCell = dtgrdViewItemList.Item(col, row)
                SendKeys.Send(key)
            End If
        Catch ex As Exception
            'MsgBox(ex.StackTrace)
            Try
                SendKeys.Send(key)
            Catch ex2 As Exception
                MsgBox(ex.StackTrace)
            End Try

        End Try
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


    Dim _listBox As ListBox
    Dim _isAdded As Boolean
    Dim _values As String()
    Dim _formerValue As String = String.Empty


    Private Sub dtgrdViewItemList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdViewItemList.CellClick
        Try
            If dtgrdViewItemList.CurrentCell.ColumnIndex = 2 Then
                Dim control As New TextBox

                control = DirectCast(dtgrdViewItemList.EditingControl, TextBox)
                Dim list As New List(Of String)
                Dim mySource As New AutoCompleteStringCollection
                Dim item As New Item
                list = item.getItems(control.Text)
                mySource.AddRange(list.ToArray)
                control.AutoCompleteCustomSource = mySource
                control.AutoCompleteMode = AutoCompleteMode.Suggest
                control.AutoCompleteSource = AutoCompleteSource.CustomSource

                'Dim control As New ComboBox
                'Control = DirectCast(dtgrdViewItemList.EditingControl, ComboBox)
                'shortList.Clear()
                'Control.Items.Clear()
                'Control.DroppedDown = True
                'For Each text As String In longList
                'Dim formattedText As String = text.ToUpper()
                'If formattedText.Contains(control.Text.ToUpper()) Then
                'shortList.Add(text)
                'End If
                ' Next
                'Control.Items.AddRange(shortList.ToArray())
                'Control.SelectionStart = control.Text.Length
                ' Cursor.Current = Cursors.Default




            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Dim longList As New List(Of String)
    Dim shortList As New List(Of String)


    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        pnlKeyBoard.Visible = False
    End Sub

    Private Sub btnCaps_Click(sender As Object, e As EventArgs) Handles btnCaps.Click
        If btnCaps.Text = "CAPS-ON" Then
            btnCaps.Text = "CAPS-OFF"
        ElseIf btnCaps.Text = "CAPS-OFF" Then
            btnCaps.Text = "CAPS-ON"
        Else
            btnCaps.Text = "CAPS-OFF"
        End If
    End Sub
    Private Sub placeAlpha(key As String)
        If btnCaps.Text = "CAPS-ON" Then
            place(key.ToUpper)
        Else
            place(key.ToLower)
        End If
    End Sub
    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        placeAlpha("Q")
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        placeAlpha("W")
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        placeAlpha("E")
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        placeAlpha("R")
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        placeAlpha("T")
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        placeAlpha("Y")
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        placeAlpha("U")
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        placeAlpha("I")
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        placeAlpha("O")
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        placeAlpha("P")
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        placeAlpha("A")
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        placeAlpha("S")
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        placeAlpha("D")
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        placeAlpha("F")
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        placeAlpha("G")
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        placeAlpha("H")
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        placeAlpha("J")
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        placeAlpha("K")
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        placeAlpha("L")
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        placeAlpha("Z")
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        placeAlpha("X")
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        placeAlpha("C")
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        placeAlpha("V")
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        placeAlpha("B")
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        placeAlpha("N")
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        placeAlpha("M")
    End Sub

    Private Sub btnPoint_Click(sender As Object, e As EventArgs) Handles btnPoint.Click
        placeAlpha(".")
    End Sub

    Private Sub btnSpace_Click(sender As Object, e As EventArgs) Handles btnSpace.Click
        placeAlpha(" ")
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        place("~")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        place("{BACKSPACE}")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        place("{UP}")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        place("{LEFT}")
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        place("{RIGHT}")
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        place("{DOWN}")
    End Sub

    Private Sub btnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click
        place("1")
    End Sub

    Private Sub btnTwo_Click(sender As Object, e As EventArgs) Handles btnTwo.Click
        place("2")
    End Sub

    Private Sub btnThree_Click(sender As Object, e As EventArgs) Handles btnThree.Click
        place("3")
    End Sub

    Private Sub btnFour_Click(sender As Object, e As EventArgs) Handles btnFour.Click
        place("4")
    End Sub

    Private Sub btnFive_Click(sender As Object, e As EventArgs) Handles btnFive.Click
        place("5")
    End Sub

    Private Sub btnSix_Click(sender As Object, e As EventArgs) Handles btnSix.Click
        place("6")
    End Sub

    Private Sub btnSeven_Click(sender As Object, e As EventArgs) Handles btnSeven.Click
        place("7")
    End Sub

    Private Sub btnEight_Click(sender As Object, e As EventArgs) Handles btnEight.Click
        place("8")
    End Sub

    Private Sub btnNine_Click(sender As Object, e As EventArgs) Handles btnNine.Click
        place("9")
    End Sub

    Private Sub btnZero_Click(sender As Object, e As EventArgs) Handles btnZero.Click
        place("0")
    End Sub



    Private Sub dtgrdViewItemList_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgrdViewItemList.KeyPress

    End Sub

    Private Sub dtgrdViewItemList_Leave(sender As Object, e As EventArgs) Handles dtgrdViewItemList.Leave

    End Sub

    Private Sub dtgrdViewItemList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdViewItemList.CellLeave

    End Sub
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private osk As String = "C:\Windows\System32\osk.exe"
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click

        'Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'End Sub
    End Sub
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
    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click
        startOSK()
    End Sub

    'Private Sub dtgrdViewItemList_CellDoubleClick(sender As Object, e As DataGridViewCellCancelEventArgs)
    '    If dtgrdViewItemList.CurrentCell.ColumnIndex = 2 Then

    '        Dim list As New List(Of String)
    '        Dim mySource As New AutoCompleteStringCollection
    '        If Me.Text = "Search Item by Description" Then
    '            'If txtSearch.Text.Length > 1 Then
    '            Try
    '                Dim query As String = "SELECT `items`.`item_code`,`items`.`item_long_description`, `inventorys`.`item_code`FROM `items`,`inventorys` WHERE `items`.`item_code`=`inventorys`.`item_code`" ' AND `items`.`item_long_description` LIKE '%" + txtSearch.Text + "%' LIMIT 1,10000"
    '                Dim command As New MySqlCommand()
    '                Dim conn As New MySqlConnection(Database.conString)
    '                Try
    '                    conn.Open()
    '                    command.CommandText = query
    '                    command.Connection = conn
    '                    command.CommandType = CommandType.Text
    '                    Dim itemreader As MySqlDataReader = command.ExecuteReader()
    '                    If itemreader.HasRows = True Then
    '                        While itemreader.Read
    '                            list.Add(itemreader("item_long_description").ToString)
    '                        End While
    '                    Else
    '                        Exit Sub
    '                    End If
    '                    Dim text As TextBox = TryCast(dtgrdViewItemList.CurrentCell.Value, TextBox)

    '                    mySource.AddRange(list.ToArray)
    '                    dtgrdViewItemList.CurrentCell.Value.AutoCompleteCustomSource = mySource
    '                    dtgrdViewItemList.CurrentCell.Value.AutoCompleteMode = AutoCompleteMode.Append
    '                    dtgrdViewItemList.CurrentCell.Value.AutoCompleteSource = AutoCompleteSource.CustomSource
    '                Catch ex As Devart.Data.MySql.MySqlException
    '                    LError.databaseConnection()
    '                    Exit Sub
    '                End Try
    '            Catch ex As Exception
    '                MsgBox(ex.Message.ToString)
    '            End Try
    '        End If

    '    End If
    'End Sub

    Private Sub AddToCart(sn As String, tillNo As String, barcode As String, itemCode As String, description As String, price As String, vat As String, discount As String, qty As String, amount As String, shortDescr As String)

        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "INSERT INTO `cart`(`till_no`, `bar_code`, `item_code`, `description`, `price`, `vat`, `discount`, `qty`, `amount`, `sn`, `short_description`) VALUES (@till_no,@bar_code,@item_code,@description,@price,@vat,@discount,@qty,@amount,@sn,@short_description)"
            command.Prepare()
            command.Parameters.AddWithValue("@till_no", tillNo)
            command.Parameters.AddWithValue("@bar_code", barcode)
            command.Parameters.AddWithValue("@item_code", itemCode)
            command.Parameters.AddWithValue("@description", description)
            command.Parameters.AddWithValue("@price", price)
            command.Parameters.AddWithValue("@vat", vat)
            command.Parameters.AddWithValue("@discount", discount)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@amount", amount)
            command.Parameters.AddWithValue("@sn", sn)
            command.Parameters.AddWithValue("@short_description", shortDescr)

            command.ExecuteNonQuery()
        Catch ex As Devart.Data.MySql.MySqlException
            LError.databaseConnection()
            Exit Sub
        End Try

    End Sub
    Private Function checkVoid(tillNo As String, sn As String)
        Dim isVoid As Boolean = False

        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `void` FROM `cart` WHERE `till_no`='" + tillNo + "' AND `sn`='" + sn + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                If reader.GetString("void").ToString.Equals("YES") Then
                    isVoid = True
                End If
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try

        Return isVoid
    End Function
    Private Sub _void(tillNo As String, sn As String)
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "UPDATE `cart` SET `void`='YES' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            Exit Sub
        End Try
    End Sub
    Private Sub unvoid(tillNo As String, sn As String)
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            Dim command As New MySqlCommand()
            command.Connection = conn
            command.CommandText = "UPDATE `cart` SET `void`='NO' WHERE `sn`='" + sn + "'"
            command.Prepare()
            command.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            Exit Sub
        End Try
    End Sub
    Private Sub loadCart(tillNo As String)
        dtgrdViewItemList.Rows.Clear()
        Dim query As String = "SELECT `bar_code`, `item_code`, `description`, `price`, `vat`, `discount`, `qty`, `amount`, `sn`, `void`, `short_description` FROM `cart` WHERE `till_no`='" + tillNo + "'"
        Dim command As New MySqlCommand()
        Dim conn As New MySqlConnection(Database.conString)
        Try
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
        Catch ex As MySqlException
            LError.databaseConnection()
            Exit Sub
        End Try

        Dim reader As MySqlDataReader = command.ExecuteReader()
        Try
            If reader.HasRows = True Then
                Dim i As Integer = 0
                While reader.Read
                    Dim barcode As String = reader.GetString("bar_code")
                    Dim itemcode As String = reader.GetString("item_code")
                    Dim description As String = reader.GetString("description")
                    Dim price As String = reader.GetString("price")
                    Dim vat As String = reader.GetString("vat")
                    Dim discount As String = reader.GetString("discount")
                    Dim qty As String = reader.GetString("qty")
                    Dim amount As String = reader.GetString("amount")
                    Dim sn As String = reader.GetString("sn")
                    Dim void As String = reader.GetString("void")
                    Dim shortDescr As String = reader.GetString("short_description")

                    Dim dtgrdRow As New DataGridViewRow
                    Dim dtgrdCell As DataGridViewCell

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = barcode
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = itemcode
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = description
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = ""
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = price
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = vat
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = discount
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = qty
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = amount
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewCheckBoxCell()
                    If void = "YES" Then
                        dtgrdCell.Value = True
                    Else
                        dtgrdCell.Value = False
                    End If
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = shortDescr
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdCell = New DataGridViewTextBoxCell()
                    dtgrdCell.Value = sn
                    dtgrdRow.Cells.Add(dtgrdCell)

                    dtgrdViewItemList.Rows.Add(dtgrdRow)

                    dtgrdViewItemList.Item(0, i).ReadOnly = True
                    dtgrdViewItemList.Item(1, i).ReadOnly = True
                    dtgrdViewItemList.Item(2, i).ReadOnly = True

                    i = i + 1

                End While
            Else

            End If
            refreshList()
            calculateValues()
            dtgrdViewItemList.CurrentCell = dtgrdViewItemList(0, dtgrdViewItemList.RowCount - 1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Function emptyCart(tillNo As String)
        Dim emptied As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "DELETE FROM `cart` WHERE `till_no`='DIRTYVALUE' OR `till_no`='" + tillNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.ExecuteNonQuery()
            emptied = True
            conn.Close()
        Catch ex As Exception
            emptied = False
            MsgBox(ex.ToString)
        End Try
        Return emptied
    End Function
    Dim order As frmOrder
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            order = New frmOrder()
            order.ShowDialog(Me)
            If order.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim size As Integer = frmOrder.length
                Dim bcodes(size) As String
                Dim icodes(size) As String
                Dim qtys(size) As Integer
                For i As Integer = 0 To size - 1
                    bcodes(i) = frmOrder.barcodes(i)
                    icodes(i) = frmOrder.itemcodes(i)
                    qtys(i) = frmOrder.quantitys(i)
                    If (bcodes(i)) <> "" Then
                        searchByBarcode(bcodes(i), qtys(i))
                    Else
                        searchByItemCode(icodes(i), qtys(i))
                    End If
                Next
                order.Dispose()
            Else
                order.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        If frmOrder.showAgain = True Then
            order = New frmOrder()
            order.ShowDialog(Me)
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
