Imports Devart.Data.MySql
Imports Microsoft.Office.Interop

Public Class frmInjector
    Private Sub frmInjector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim file As String = "C:\dat.xlsx"
    Private Sub addItems()
        Try
            Dim objXLApp As Excel.Application
            Dim intLoopCounter As Integer
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet

            Dim count As Integer = 0


            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(file)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)
            Dim total As Integer = 100000
            lblItems.Text = "Out of " + total.ToString
            For intLoopCounter = 2 To total
                Dim itemcode As String = objXLWs.Range("A" & intLoopCounter).Value
                Dim scancode As String = objXLWs.Range("B" & intLoopCounter).Value
                Dim descr As String = objXLWs.Range("C" & intLoopCounter).Value
                Dim short_descr As String = objXLWs.Range("D" & intLoopCounter).Value
                Dim pck As String = objXLWs.Range("E" & intLoopCounter).Value
                Dim dept_id As String = objXLWs.Range("F" & intLoopCounter).Value
                Dim class_id As String = objXLWs.Range("G" & intLoopCounter).Value
                Dim sub_class_id As String = objXLWs.Range("H" & intLoopCounter).Value
                Dim supplier_code As String = objXLWs.Range("I" & intLoopCounter).Value
                Dim cost_price As String = objXLWs.Range("J" & intLoopCounter).Value
                Dim retail_price As String = objXLWs.Range("K" & intLoopCounter).Value
                Dim discount As String = objXLWs.Range("L" & intLoopCounter).Value
                Dim vat As String = objXLWs.Range("M" & intLoopCounter).Value
                Dim margin As String = objXLWs.Range("N" & intLoopCounter).Value
                Dim uom As String = objXLWs.Range("O" & intLoopCounter).Value
                Dim active As String = objXLWs.Range("P" & intLoopCounter).Value

                If itemcode = "" Then
                    Exit For
                End If

                Dim conn As New MySqlConnection(Database.conString)
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "INSERT IGNORE INTO `items`(`item_code`, `item_scan_code`,`item_long_description`, `item_description`, `pck`, `department_id`, `class_id`, `sub_class_id`, `supplier_id`, `unit_cost_price`, `retail_price`, `discount`, `vat`, `margin`, `standard_uom`) VALUES (@item_code,@item_scan_code,@item_long_description,@item_description,@pck,@department_id,@class_id,@sub_class_id,@supplier_id,@unit_cost_price,@retail_price,@discount,@vat,@margin,@standard_uom)"
                command.Prepare()
                command.Parameters.AddWithValue("@item_code", itemcode)
                command.Parameters.AddWithValue("@item_scan_code", scancode)
                command.Parameters.AddWithValue("@item_long_description", descr)
                command.Parameters.AddWithValue("@item_description", short_descr)
                command.Parameters.AddWithValue("@pck", pck)
                command.Parameters.AddWithValue("@department_id", dept_id)
                command.Parameters.AddWithValue("@class_id", class_id)
                command.Parameters.AddWithValue("@sub_class_id", sub_class_id)
                command.Parameters.AddWithValue("@supplier_id", (New Supplier).getSupplierID(supplier_code, ""))
                command.Parameters.AddWithValue("@unit_cost_price", cost_price)
                command.Parameters.AddWithValue("@retail_price", retail_price)
                command.Parameters.AddWithValue("@discount", discount)
                command.Parameters.AddWithValue("@vat", vat)
                command.Parameters.AddWithValue("@margin", margin)
                command.Parameters.AddWithValue("@standard_uom", uom)
                command.ExecuteNonQuery()
                conn.Close()
                If scancode <> "" Then
                    conn.Open()
                    command.Connection = conn
                    command.CommandText = "INSERT IGNORE INTO `bar_codes`(`item_scan_code`, `item_code`) VALUES (@item_scan_code,@item_code)"
                    command.Prepare()
                    command.Parameters.AddWithValue("@item_code", itemcode)
                    command.Parameters.AddWithValue("@item_scan_code", scancode)
                    command.ExecuteNonQuery()
                    conn.Close()
                End If
                conn.Open()
                command.Connection = conn
                command.CommandText = "INSERT IGNORE INTO `inventorys`(`item_code`) VALUES (@item_code)"
                command.Prepare()
                command.Parameters.AddWithValue("@item_code", itemcode)
                command.ExecuteNonQuery()
                conn.Close()

                txtItemcount.Text = intLoopCounter.ToString

            Next intLoopCounter
            objXLApp.Quit()
            MsgBox("complete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub updateStock()
        Try
            Dim objXLApp As Excel.Application
            Dim intLoopCounter As Integer
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet

            Dim count As Integer = 0


            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open("C:\stocks.xlsx")
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)
            Dim total As Integer = 100000
            lblItems.Text = "Out of " + total.ToString
            For intLoopCounter = 2 To total
                Dim itemcode As String = objXLWs.Range("A" & intLoopCounter).Value
                Dim qty As String = objXLWs.Range("C" & intLoopCounter).Value


                If itemcode = "" Then
                    Exit For
                End If

                Dim conn As New MySqlConnection(Database.conString)
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `inventorys` SET `qty`='" + qty + "' WHERE `item_code`='" + itemcode + "'"
                command.Prepare()

                command.ExecuteNonQuery()
                conn.Close()



                txtItemcount.Text = intLoopCounter.ToString

            Next intLoopCounter
            objXLApp.Quit()
            MsgBox("complete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub updatePrice()
        Try
            Dim objXLApp As Excel.Application
            Dim intLoopCounter As Integer
            Dim objXLWb As Excel.Workbook
            Dim objXLWs As Excel.Worksheet

            Dim count As Integer = 0


            objXLApp = New Excel.Application
            objXLApp.Workbooks.Open(file)
            objXLWb = objXLApp.Workbooks(1)
            objXLWs = objXLWb.Worksheets(1)
            Dim total As Integer = 100000
            lblItems.Text = "Out of " + total.ToString
            For intLoopCounter = 2 To total
                Dim itemcode As String = objXLWs.Range("A" & intLoopCounter).Value
                Dim scancode As String = objXLWs.Range("B" & intLoopCounter).Value
                Dim descr As String = objXLWs.Range("C" & intLoopCounter).Value
                Dim short_descr As String = objXLWs.Range("D" & intLoopCounter).Value
                Dim pck As String = objXLWs.Range("E" & intLoopCounter).Value
                Dim dept_id As String = objXLWs.Range("F" & intLoopCounter).Value
                Dim class_id As String = objXLWs.Range("G" & intLoopCounter).Value
                Dim sub_class_id As String = objXLWs.Range("H" & intLoopCounter).Value
                Dim supplier_id As String = objXLWs.Range("I" & intLoopCounter).Value
                Dim cost_price As String = objXLWs.Range("J" & intLoopCounter).Value
                Dim retail_price As String = objXLWs.Range("K" & intLoopCounter).Value
                Dim discount As String = objXLWs.Range("L" & intLoopCounter).Value
                Dim vat As String = objXLWs.Range("M" & intLoopCounter).Value
                Dim margin As String = objXLWs.Range("N" & intLoopCounter).Value
                Dim uom As String = objXLWs.Range("O" & intLoopCounter).Value
                Dim active As String = objXLWs.Range("P" & intLoopCounter).Value
                If itemcode = "" Then
                    Exit For
                End If
                Dim conn As New MySqlConnection(Database.conString)
                conn.Open()
                Dim command As New MySqlCommand()
                command.Connection = conn
                command.CommandText = "UPDATE `items` SET `unit_cost_price`='" + cost_price + "',`retail_price`='" + retail_price + "',`discount`='" + discount + "',`vat`='" + vat + "',`margin`='" + margin + "' WHERE `item_code`='" + itemcode + "'"
                command.Prepare()
                command.ExecuteNonQuery()
                conn.Close()

                txtinvCount.Text = intLoopCounter.ToString

            Next intLoopCounter
            objXLApp.Quit()
            MsgBox("complete")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub btnItems_Click(sender As Object, e As EventArgs) Handles btnItems.Click
        Dim res As Integer = MsgBox("Are you sure?", vbYesNo)
        If res = DialogResult.No Then
            Exit Sub
        End If
        addItems()

    End Sub

    Private Sub btnInv_Click(sender As Object, e As EventArgs) Handles btnInv.Click
        Dim res As Integer = MsgBox("Are you sure?", vbYesNo)
        If res = DialogResult.No Then
            Exit Sub
        End If
        updatePrice()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim res As Integer = MsgBox("Are you sure?", vbYesNo)
        If res = DialogResult.No Then
            Exit Sub
        End If
        updateStock()
    End Sub
End Class