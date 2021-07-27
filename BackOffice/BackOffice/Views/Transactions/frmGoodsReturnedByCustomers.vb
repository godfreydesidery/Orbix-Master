Imports Devart.Data.MySql

Public Class frmGoodsReturnedByCustomers

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Function clear()
        txtSearchBillNo.Text = ""
        txtBillNo.Text = ""
        txtBillDate.Text = ""
        txtTillNo.Text = ""
        Return vbNull
    End Function
    Public Function getBill(billNo As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `id`, `till_no`, `user_id`, `date`, `date_time`, `amount`, `discount`, `vat` FROM `sale` WHERE `id`='" + billNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtBillNo.Text = reader.GetString("id")
                txtTillNo.Text = reader.GetString("till_no")
                txtBillDate.Text = reader.GetString("date")
                txtBillAmount.Text = LCurrency.displayValue(reader.GetString("amount"))
                success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        If success = False Then
            MsgBox("No matching record.", vbOKOnly + vbCritical, "Error: Not found")
        End If
        Return success
    End Function
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        getBill(txtSearchBillNo.Text)
    End Sub

    Private Sub txtBillNo_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtSearchBillNo.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            getBill(txtSearchBillNo.Text)
        End If
    End Sub

    Private Sub dtgrdItemList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellContentClick

    End Sub
    Private Function getPrice(itemCode As String, billNo As String) As String
        Dim price As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT  `selling_price` FROM `sale_details` WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                price = reader.GetString("selling_price")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return price
    End Function
    Private Function getQuantityPurchased(itemCode As String, billNo As String) As String
        Dim totalqty As Double = 0
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `qty` FROM `sale_details` WHERE `item_code`='" + itemCode + "' AND `sale_id`='" + billNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                totalqty = totalqty + Val(reader.GetString("qty"))
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return totalqty.ToString
    End Function
    Private Function isExistInBill(itemCode As String) As Boolean
        Dim isExist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `sale_id`, `item_code`, `selling_price`, `discounted_price`, SUM(`qty`) AS `total_qty`, `amount`, `vat` FROM `sale_details` WHERE `item_code`='" + itemCode + "' GROUP BY `item_code`'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim qty As Double = 0
            Dim price As Double = 0

            Dim reader As MySqlDataReader = command.ExecuteReader()

            While reader.Read
                txtBillNo.Text = reader.GetString("id")
                txtTillNo.Text = reader.GetString("till_no")
                txtBillDate.Text = reader.GetString("date")
                txtBillAmount.Text = LCurrency.displayValue(reader.GetString("amount"))
                'success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            ' s'uccess = False
            MsgBox(ex.Message)
        End Try
        Return isExist
    End Function
    Private Function isExistInBillll(itemCode As String) As Boolean
        Dim isExist As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `sn`, `sale_id`, `item_code`, `selling_price`, `discounted_price`, SUM(`qty`) AS `total_qty`, `amount`, `vat` FROM `sale_details` WHERE `item_code`='" + itemCode + "' GROUP BY `item_code`'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                txtBillNo.Text = reader.GetString("id")
                txtTillNo.Text = reader.GetString("till_no")
                txtBillDate.Text = reader.GetString("date")
                txtBillAmount.Text = LCurrency.displayValue(reader.GetString("amount"))
                'success = True
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            'success = False
            MsgBox(ex.Message)
        End Try
        Return isExist
    End Function
    Private Function validateList() As Boolean
        Dim valid As Boolean = False
        For i As Integer = 0 To dtgrdItemList.RowCount - 2
            If Not dtgrdItemList.Item(1, i).Value > 0 Then
                valid = False
                Return valid
                Exit Function
            Else
                valid = True
            End If
        Next
        Return valid
    End Function
    Private Function refresh_()
        If dtgrdItemList.RowCount <= 1 Then
            btnConfirm.Enabled = False
        Else
            btnConfirm.Enabled = True
        End If
        Return vbNull
    End Function
    Private Sub dtgrdItemList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdItemList.CellEndEdit
        Dim row As Integer = e.RowIndex
        refresh_()
        If txtBillNo.Text = "" Then
            MsgBox("Enter Bill Number", vbOKOnly + vbCritical, "Error: Missing information")
            refresh_()
            clear()
            dtgrdItemList.Rows.Clear()
            Exit Sub
        End If
        Try
            If e.ColumnIndex = 0 Then
                'check if item has been entered twice
                For i As Integer = 0 To dtgrdItemList.RowCount - 2
                    If dtgrdItemList.Item(0, row).Value.ToString = dtgrdItemList.Item(0, i).Value.ToString And row <> i Then
                        MsgBox("Duplicate value entered. ", vbOKOnly + vbCritical, "Error: Duplicate value")
                        dtgrdItemList.Rows.Remove(dtgrdItemList.CurrentRow)
                        Exit Sub
                    End If
                Next
                'search item from sales list
                If getPrice(dtgrdItemList.Item(0, row).Value.ToString, txtBillNo.Text) <> "" Then
                    dtgrdItemList.Item(2, row).Value = getPrice(dtgrdItemList.Item(0, row).Value.ToString, txtBillNo.Text)
                    dtgrdItemList.Item(3, row).Value = (New Item).getItemLongDescription(dtgrdItemList.Item(0, row).Value.ToString)
                Else
                    MsgBox("Item not available in this bill", vbOKOnly + vbCritical, "Error: Not found")
                    dtgrdItemList.Rows.Remove(dtgrdItemList.CurrentRow)
                    Exit Sub
                End If
            End If
            If e.ColumnIndex = 1 Then
                Dim itemCode As String = dtgrdItemList.Item(0, row).Value
                Dim totalQtyPurchased As Double = Val(getQuantityPurchased(itemCode, txtBillNo.Text))
                Dim qtyReturned As Double = Val((dtgrdItemList.Item(1, row).Value))
                If totalQtyPurchased <> 0 Then
                    If qtyReturned <= totalQtyPurchased Then
                        If (New GoodsReturnedByCustomers).checkValid(txtBillNo.Text, itemCode, qtyReturned, totalQtyPurchased) = False Then
                            MsgBox("The item is invalid. All similar items under this bill have been returned", vbOKOnly + vbCritical, "Error: Invalid item")
                            dtgrdItemList.Rows.Remove(dtgrdItemList.CurrentRow)
                            Exit Sub
                        End If
                        'accept
                    Else
                        'reject
                        MsgBox("Quantity returned exceeds the quantity purhased.", vbOKOnly + vbCritical, "Error: Invalid quantity")
                        dtgrdItemList.Rows.Remove(dtgrdItemList.CurrentRow)
                        Exit Sub
                    End If
                Else
                    MsgBox("Item not available in this bill", vbOKOnly + vbCritical, "Error: Not found")
                    dtgrdItemList.Rows.Remove(dtgrdItemList.CurrentRow)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If txtBillNo.Text = "" Then
            MsgBox("Enter bill number", vbOKOnly + vbCritical, "Error: Missing information")
            refresh_()
            clear()
            dtgrdItemList.Rows.Clear()
            Exit Sub
        End If
        If validateList() = True Then
            'create credit note
            Dim crNote As New CreditNote
            Dim crNo As String = ""
            Dim creditNoteAmount As Double = 0
            For i As Integer = 0 To dtgrdItemList.RowCount - 2
                Dim itemCode As String = dtgrdItemList.Item(0, i).Value
                Dim qty As Double = Val(dtgrdItemList.Item(1, i).Value)
                Dim price As Double = Val(dtgrdItemList.Item(2, i).Value)
                creditNoteAmount = qty * price
            Next
            While True
                'create customer credit note
                crNo = crNote.createCustomerCreditNote(Day.DAY, txtBillNo.Text, creditNoteAmount.ToString, "REFUND DUE", "Goods returned by customer")
                If crNo <> "" Then
                    Exit While
                End If
            End While

            For i As Integer = 0 To dtgrdItemList.RowCount - 2
                Dim itemCode As String = dtgrdItemList.Item(0, i).Value
                Dim qty As Double = Val(dtgrdItemList.Item(1, i).Value)
                Dim price As Double = Val(dtgrdItemList.Item(2, i).Value)
                Dim goods As New GoodsReturnedByCustomers
                'update the inventory
                goods.returnItem(txtBillNo.Text, itemCode, qty, (New Item).getSaleId(txtBillNo.Text, itemCode))
                Dim inventory As New Inventory
                Dim stockCard As New StockCard
                stockCard.qtyIn(Day.DAY, itemCode, Val(qty), inventory.getInventory(itemCode), "Return by Customer, Bill no: " + txtBillNo.Text)
                'update cr note
                crNote.createCreditNoteParticulars(crNo, itemCode, price, qty)
            Next
            MsgBox("Items returned successifull. A customer Credit note with Credit note number " + crNo + " has been created.", vbOKOnly + vbInformation, "Success: Item return")
            dtgrdItemList.Rows.Clear()
            clear()
        Else
            MsgBox("List invalid")
        End If
    End Sub

    Private Sub frmGoodsReturnedByCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
        refresh_()
    End Sub

    Private Sub txtBillNo_TextChanged(sender As Object, e As EventArgs) Handles txtBillNo.TextChanged

    End Sub

    Private Sub txtSearchBillNo_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBillNo.TextChanged

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        clear()
        refresh_()
    End Sub
End Class