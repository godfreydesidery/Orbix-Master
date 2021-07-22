Imports Devart.Data.MySql

Public Class frmTillPosition

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub frmTillPosition_Load(sender As Object, e As EventArgs) Handles Me.Shown

        dtgrdTillPosition.Rows.Clear()
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `sale`.`till_no` AS `till_no`,SUM(`sale`.`amount`) AS `amount`,SUM(`payment`.`cash`) AS `cash`,SUM(`payment`.`voucher`) AS `voucher`,SUM(`payment`.`cheque`)AS `cheque`,SUM(`payment`.`deposit`)AS `deposit`,SUM(`payment`.`loyalty`)AS `loyalty`,SUM(`payment`.`cr_card`) AS `cr_card`,SUM(`payment`.`cap`) AS `cap`,SUM(`payment`.`invoice`)AS `invoice`,SUM(`payment`.`cr_note`) AS `cr_note`, SUM(`payment`.`mobile`) AS `mobile` FROM `sale`,`payment` WHERE `sale`.`id`=`payment`.`sale_id` AND `sale`.`date`='" + Day.DAY + "' GROUP BY `sale`.`till_no`"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim tillNo As String = ""
            Dim total As Double = 0
            Dim cash As Double = 0
            Dim voucher As Double = 0
            Dim cheque As Double = 0
            Dim deposit As Double = 0
            Dim loyalty As Double = 0
            Dim CRCard As Double = 0
            Dim CAP As Double = 0
            Dim invoice As Double = 0
            Dim CRNote As Double = 0
            Dim mobile As Double = 0

            While reader.Read

                tillNo = reader.GetString("till_no")

                cash = Val(reader.GetString("cash"))
                voucher = Val(reader.GetString("voucher"))
                cheque = Val(reader.GetString("cheque"))
                deposit = Val(reader.GetString("deposit"))
                loyalty = Val(reader.GetString("loyalty"))
                CRCard = Val(reader.GetString("cr_card"))
                CAP = Val(reader.GetString("cap"))
                invoice = Val(reader.GetString("invoice"))
                CRNote = Val(reader.GetString("cr_note"))
                mobile = Val(reader.GetString("mobile"))

                total = cash + voucher + cheque + deposit + loyalty + CRCard + CAP + invoice + CRNote + mobile

                Dim dtgrdRow As New DataGridViewRow
                Dim dtgrdCell As DataGridViewCell


                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = tillNo
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(total.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(cash.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(voucher.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(cheque.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(deposit.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(loyalty.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(CRCard.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(CAP.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(invoice.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(CRNote.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdCell = New DataGridViewTextBoxCell()
                dtgrdCell.Value = LCurrency.displayValue(mobile.ToString)
                dtgrdRow.Cells.Add(dtgrdCell)

                dtgrdTillPosition.Rows.Add(dtgrdRow)
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub frmTillPosition_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class