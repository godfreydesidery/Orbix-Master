Imports Devart.Data.MySql

Public Class frmLPO
    Private Function refreshList(supplierId As String, startDate As String, endDate As String, status_ As String)
        dtgrdLPO.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            If supplierId <> "" And startDate <> "" And endDate <> "" And status_ <> "" Then
                query = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE (`order_date`BETWEEN '" + startDate + "' AND '" + endDate + "') AND `supplier_id`='" + supplierId + "' AND `status`='" + status_ + "'"
            ElseIf supplierId <> "" And startDate <> "" And endDate <> "" Then
                query = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE (`order_date`BETWEEN '" + startDate + "' AND '" + endDate + "') AND `supplier_id`='" + supplierId + "'"
            ElseIf startDate <> "" And endDate <> "" And status_ <> "" Then
                query = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE (`order_date`BETWEEN '" + startDate + "' AND '" + endDate + "') AND `status`='" + status_ + "'"
            ElseIf supplierId <> "" And status_ <> "" Then
                query = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `supplier_id`='" + supplierId + "' AND `status`='" + status_ + "'"
            Else
                query = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `status`='PENDING' OR `status`='PRINTED' OR `status`='REPRINTED'"
            End If
            Dim codeQuery As String = "SELECT `order_id`, `order_no`, `order_date`, `validity_period`, `valid_until`, `supplier_id`, `status`, `user_id` FROM `orders` WHERE `status`='PENDING' OR `status`='PRINTED' OR `status`='REPRINTED'"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()

            Dim orderNo As String = ""
            Dim supplierName As String = ""
            Dim dateCreated As String = ""
            Dim validUpTo As String = ""
            Dim validityPeriod As String = ""
            Dim status As String = ""
            Dim userId As String = ""

            While reader.Read

                orderNo = reader.GetString("order_no")
                supplierName = (New Supplier).getSupplierName(reader.GetString("supplier_id"), "")
                dateCreated = reader.GetString("order_date")
                validUpTo = reader.GetString("valid_until")
                validityPeriod = reader.GetString("validity_period")
                status = reader.GetString("status")
                userId = reader.GetString("user_id")

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = orderNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = supplierName
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = dateCreated
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = validUpTo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = validityPeriod
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = status
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdLPO.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return vbNull
    End Function
    Private Sub frmLPO_Load(sender As Object, e As EventArgs) Handles Me.Shown
        refreshList((New Supplier).getSupplierID("", cmbSupplier.Text), dateStart.Text, dateEnd.Text, cmbStatus.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub frmLPO_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection(Database.conString)
        Try
            Dim suppcommand As New MySqlCommand()
            Dim supplierQuery As String = "SELECT `supplier_id`, `supplier_name` FROM `supplier`"
            conn.Open()
            suppcommand.CommandText = supplierQuery
            suppcommand.Connection = conn
            suppcommand.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = suppcommand.ExecuteReader
            cmbSupplier.Items.Clear()
            cmbSupplier.Items.Add("")
            If reader.HasRows Then
                While reader.Read
                    cmbSupplier.Items.Add(reader.GetString("supplier_name"))
                End While
            End If
            conn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmbView.Click
        refreshList((New Supplier).getSupplierID("", cmbSupplier.Text), dateStart.Text, dateEnd.Text, cmbStatus.Text)
    End Sub

    Private Sub dtgrdLPO_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdLPO.CellContentClick

    End Sub
End Class