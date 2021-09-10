Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmTillPosition

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub

    Private Sub frmTillPosition_Load(sender As Object, e As EventArgs) Handles Me.Shown

        dtgrdTillPosition.Rows.Clear()
        Dim list As New List(Of Till)
        Dim response As Object = New Object
        Dim json As JObject = New JObject
        Try
            response = Web.get_("till_positions")
            list = JsonConvert.DeserializeObject(Of List(Of Till))(response.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        For Each till As Till In list

            Dim total As Double = till.cash + till.voucher + till.cheque + till.deposit + till.loyalty + till.crCard + till.cap + till.invoice + till.crNote + till.mobile + till.other

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = till.no
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(total.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.cash.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.voucher.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.cheque.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.deposit.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.loyalty.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.crCard.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.cap.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.invoice.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.crNote.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.mobile.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = LCurrency.displayValue(till.other.ToString)
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdTillPosition.Rows.Add(dtgrdRow)
        Next
    End Sub
End Class