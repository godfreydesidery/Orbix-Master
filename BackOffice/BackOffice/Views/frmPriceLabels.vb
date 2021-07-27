Imports System.IO

Public Class frmPriceLabels
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Dispose()
    End Sub
    Private Sub clear()
        txtBarCode.Text = ""
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtNoOfLabels.Text = ""
        txtPrice.Text = ""
    End Sub
    Private Sub lock()
        txtBarCode.ReadOnly = True
        txtItemCode.ReadOnly = True
        txtDescription.ReadOnly = True
    End Sub
    Private Sub unlock()
        txtBarCode.ReadOnly = False
        txtItemCode.ReadOnly = False
        txtDescription.ReadOnly = False
    End Sub
    Private Function validateItems() As Boolean
        Dim valid As Boolean = True
        If Not IsNumeric(txtNoOfLabels.Text) Or Val(txtNoOfLabels.Text) <= 0 Or Val(txtNoOfLabels.Text) > 50 Then
            valid = False
            MsgBox("Invalid number of labels. Please enter a valid number. No of labels should be between 1 and 50.", vbOKOnly + vbExclamation, "Error: Invalid entry")
            txtNoOfLabels.Text = ""
            txtNoOfLabels.Focus()
        End If
        Return valid
    End Function
    Private Sub frmPriceLabels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clear()
    End Sub
    Private Function searchByBarcode(barcode As String) As Boolean
        Dim found As Boolean = False
        Dim itemCode As String = (New Item).getItemCode(barcode, "")
        If (New Item).isExist(itemCode) = False Then
            Return found
            Exit Function
        End If
        If itemCode <> "" Then
            found = True
            lock()
            btnAdd.Enabled = True
            txtItemCode.Text = itemCode
            txtDescription.Text = (New Item).getItemLongDescription(itemCode)
            txtPrice.Text = LCurrency.displayValue((New Item).getItemPrice(itemCode))
        End If
        Return found
    End Function
    Private Function searchByDescription(descr As String) As Boolean
        Dim found As Boolean = False
        Dim itemCode As String = (New Item).getItemCode("", descr)
        If itemCode <> "" Then
            found = True
            lock()
            btnAdd.Enabled = True
            txtItemCode.Text = itemCode
            txtPrice.Text = LCurrency.displayValue((New Item).getItemPrice(itemCode))
        End If
        Return found
    End Function
    Private Function searchByItemCode(itemCode As String) As Boolean
        Dim found As Boolean = False
        If (New Item).searchItem(itemCode) = True Then
            found = True
            lock()
            btnAdd.Enabled = True
            txtDescription.Text = (New Item).getItemLongDescription(itemCode)
            txtPrice.Text = LCurrency.displayValue((New Item).getItemPrice(itemCode))
        End If
        Return found
    End Function

    Private Sub txtBarCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtBarCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If searchByBarcode(txtBarCode.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub
    Private Sub txtItemCode_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtItemCode.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If searchByItemCode(txtItemCode.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub
    Private Sub txtDescription_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txtDescription.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If searchByDescription(txtDescription.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtBarCode.ReadOnly = True Or txtItemCode.ReadOnly = True Or txtDescription.ReadOnly = True Then
            clear()
            unlock()
            Exit Sub
        End If
        If txtBarCode.Text <> "" Then
            If searchByBarcode(txtBarCode.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
                clear()
            End If
            Exit Sub
        End If
        If txtItemCode.Text <> "" Then
            If searchByItemCode(txtItemCode.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
                clear()
            End If
            Exit Sub
        End If
        If txtDescription.Text <> "" Then
            If searchByDescription(txtDescription.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
                clear()
            End If
            Exit Sub
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'add
        If validateItems() = True Then
            Dim barCode As String = txtBarCode.Text
            Dim itemCode As String = txtItemCode.Text
            Dim description As String = txtDescription.Text
            Dim noOfLabels As String = txtNoOfLabels.Text
            Dim price As String = txtPrice.Text

            Dim dtgrdRow As New DataGridViewRow
            Dim dtgrdCell As DataGridViewCell

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = barCode
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = itemCode
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = description
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = noOfLabels
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdCell = New DataGridViewTextBoxCell()
            dtgrdCell.Value = price
            dtgrdRow.Cells.Add(dtgrdCell)

            dtgrdLabelList.Rows.Add(dtgrdRow)



            btnAdd.Enabled = False
        End If

    End Sub

    Private Sub txtBarCode_TextChanged(sender As Object, e As EventArgs) Handles txtBarCode.TextChanged

    End Sub

    Private Sub txtBarCode_Enter(sender As Object, e As KeyEventArgs) Handles txtBarCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If searchByBarcode(txtBarCode.Text) = True Then
            Else
                MsgBox("Requested item could not be found", vbOKOnly + vbCritical, "Error: Not found")
            End If
        End If
    End Sub

    Private Sub btnPrintLabels_Click(sender As Object, e As EventArgs) Handles btnPrintLabels.Click
        If dtgrdLabelList.RowCount = 0 Then
            MsgBox("Could not print an empty List", vbOKOnly + vbCritical, "Error: List empty")
            Exit Sub
        End If
        Dim descr As String = ""
        Dim price As String = ""

        Dim rows As Integer = 0

        Dim fileName As String = "Price Labels"
        Dim strFile As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & fileName & ".doc"
        Dim sw As StreamWriter
        Try
            If (Not File.Exists(strFile)) Then
                sw = File.CreateText(strFile)
            Else
                File.WriteAllText(strFile, "")
                sw = File.AppendText(strFile)
            End If

            For i As Integer = 0 To dtgrdLabelList.RowCount - 1

                descr = dtgrdLabelList.Item(2, i).Value
                price = "     " + dtgrdLabelList.Item(4, i).Value + "/="

                rows = Math.Ceiling((Val(dtgrdLabelList.Item(3, i).Value)))


                For j As Integer = descr.Length To 90
                    descr = descr + " "
                Next
                For j As Integer = price.Length To 90
                    price = price + " "
                Next
                For j As Integer = 1 To rows
                    sw.WriteLine(descr)
                    sw.WriteLine(price)
                    sw.WriteLine()
                Next
            Next
            sw.Close()

            Dim Proc As New Process
            Proc.StartInfo.FileName = strFile
            ' Proc.StartInfo.Verb = "Print"
            Proc.Start()
            Proc.Close()
            System.Diagnostics.Process.Start(strFile)
        Catch ex As IOException
            MsgBox("Error printing document.")
        End Try

    End Sub

    Private Sub dtgrdLabelList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgrdLabelList.CellDoubleClick
        dtgrdLabelList.Rows.RemoveAt(dtgrdLabelList.CurrentRow.Index)
        clear()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub txtDescription_MouseClick(sender As Object, e As MouseEventArgs) Handles txtDescription.MouseClick
        Dim list As New List(Of String)
        Dim mySource As New AutoCompleteStringCollection
        Dim item As New Item
        list = item.getItems(txtDescription.Text)
        mySource.AddRange(list.ToArray)
        txtDescription.AutoCompleteCustomSource = mySource
        txtDescription.AutoCompleteMode = AutoCompleteMode.Suggest
        txtDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub txtDescription_Paint(sender As Object, e As PaintEventArgs) Handles txtDescription.Paint

    End Sub

    'Private Sub txtDescription_MouseEnter(sender As Object, e As EventArgs) Handles txtDescription.MouseEnter
    '    Dim list As New List(Of String)
    '    Dim mySource As New AutoCompleteStringCollection
    '    Dim item As New Item
    '    list = item.getItems(txtDescription.Text)
    '    mySource.AddRange(list.ToArray)
    '    txtDescription.AutoCompleteCustomSource = mySource
    '    txtDescription.AutoCompleteMode = AutoCompleteMode.Suggest
    '    txtDescription.AutoCompleteSource = AutoCompleteSource.CustomSource
    'End Sub
End Class