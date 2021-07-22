Imports Devart.Data.MySql

Public Class frmViewSuppliers
    Dim itemCode As String = frmProductMaster.GLOBAL_ITEM_CODE
    Dim itemcode1 As String = frmProductInquiry.GLOBAL_ITEM_CODE
    Private Sub frmViewSuppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshList(itemCode, itemcode1)
    End Sub
    Private Sub refreshList(itemCode As String, itemCode1 As String)
        If itemCode = "" Then
            itemCode = itemCode1
        End If
        dtgrdSuppliers.Rows.Clear()

        txtItem.Text = "(" + itemCode + ")  " + (New Item).getItemLongDescription(itemCode)
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `supplier_item_id`, `supplier_id`, `item_code`, `service_description`, `vat_no`, `packing`, `cost_price_vat_incl`, `cost_price_vat_excl`, `terms_of_payment` FROM `supplier_item` WHERE `item_code`='" + itemCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim supplierCode As String = ""
            Dim supplierName As String = ""
            Dim costPriceVatIncl As String = ""
            Dim costPriceVatExcl As String = ""
            Dim packing As String = ""
            Dim terms As String = ""
            Dim vatNo As String = ""

            While reader.Read

                supplierCode = (New Supplier).getSupplierCode(reader.GetString("supplier_id"), "")
                supplierName = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")
                costPriceVatIncl = reader.GetString("cost_price_vat_incl")
                costPriceVatExcl = reader.GetString("cost_price_vat_excl")
                packing = reader.GetString("packing")
                vatNo = reader.GetString("vat_no")
                terms = reader.GetString("terms_of_payment")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierCode
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPriceVatIncl
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = costPriceVatExcl
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = packing
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = vatNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = terms
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdSuppliers.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnAssignProduct_Click(sender As Object, e As EventArgs) Handles btnAssignProduct.Click
        Dim sel As Integer = MsgBox("Are you sure you want to assign this item to the selected supplier?", vbYesNo + vbQuestion, "Assign Item to supplier")
        If sel = DialogResult.Yes Then
            'assign
            Try
                Dim conn As New MySqlConnection(Database.conString)
                Dim command As New MySqlCommand()
                Dim Query As String = "UPDATE `items` SET `supplier_id`=@supplier_id WHERE `item_code`='" + itemCode + "'"
                conn.Open()
                command.CommandText = Query
                command.Connection = conn
                command.CommandType = CommandType.Text
                command.Parameters.AddWithValue("@supplier_id", (New Supplier).getSupplierID(dtgrdSuppliers.Item(0, dtgrdSuppliers.CurrentRow.Index).Value.ToString, ""))
                command.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                MsgBox("Operation failed. Please select a supplier")
            End Try

        End If
    End Sub
End Class