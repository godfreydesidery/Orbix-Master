Imports Devart.Data.MySql

Public Class Material
    Public Function getDescription(materialCode As String) As String
        Dim descr As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `description` FROM `materials` WHERE `material_code`='" + materialCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                descr = reader.GetString("description").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return descr
    End Function
    Public Function getMaterialCode(description As String) As String
        Dim materialCode As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `material_code` FROM `materials` WHERE `description`='" + description + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                materialCode = reader.GetString("material_code").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return materialCode
    End Function

    Public Function getMaterialCategoryId(materialCode As String) As String
        Dim categoryId As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `category_id` FROM `materials` WHERE `material_code`='" + materialCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                categoryId = reader.GetString("category_id").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return categoryId
    End Function
    Public Function getUom(materialCode As String) As String
        Dim uom As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT `uom` FROM `materials` WHERE `material_code`='" + materialCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                uom = reader.GetString("uom").ToString
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try
        Return uom
    End Function
    Public Function getMaterials() As List(Of String)
        Dim list As New List(Of String)
        Try
            Dim query As String = "SELECT `description` FROM `materials`"

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
                        list.Add(itemreader("description").ToString)
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

    Public Function getStock(materialCode As String) As String
        Dim value As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `qty` FROM `materials` WHERE `material_code`='" + materialCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                value = reader.GetString("qty")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return value
    End Function
    Public Function getPrice(materialCode As String) As String
        Dim value As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            'create bar code
            Dim codeQuery As String = "SELECT  `price` FROM `materials` WHERE `material_code`='" + materialCode + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                value = reader.GetString("price")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return value
    End Function

    Public Function getCategoryIdByCategoryName(name) As String
        Dim id As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `id` FROM `material_categories` WHERE `category_name`='" + name + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                id = reader.GetString("id")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return id
    End Function


    Public Function getCategoryNameByCategoryId(id As String) As String
        Dim name As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `category_name` FROM `material_categories` WHERE `id`='" + id + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                name = reader.GetString("category_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return name
    End Function
    Public Function getCategoryNameByCategoryNo(categoryNo As String) As String
        Dim name As String = ""
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim codeQuery As String = "SELECT `category_name` FROM `material_categories` WHERE `category_no`='" + categoryNo + "'"
            conn.Open()
            command.CommandText = codeQuery
            command.Connection = conn
            command.CommandType = CommandType.Text
            Dim reader As MySqlDataReader = command.ExecuteReader()
            While reader.Read
                name = reader.GetString("category_name")
                Exit While
            End While
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return name
    End Function

    Public Function registerUsage(date_ As String, materialCode As String, price As Double, qty As Double, balance As Double, reference As String) As Boolean
        Dim success As Boolean = False
        Try
            Dim conn As New MySqlConnection(Database.conString)
            Dim command As New MySqlCommand()
            Dim query As String = ""
            query = "INSERT INTO `material_usage`(`date`,`material_code`, `price`, `qty`,`balance`,`reference`) VALUES (@date,@material_code,@price,@qty,@balance,@reference)"
            conn.Open()
            command.CommandText = query
            command.Connection = conn
            command.CommandType = CommandType.Text
            command.Parameters.AddWithValue("@date", date_)
            command.Parameters.AddWithValue("@material_code", materialCode)
            command.Parameters.AddWithValue("@price", price)
            command.Parameters.AddWithValue("@qty", qty)
            command.Parameters.AddWithValue("@balance", balance)
            command.Parameters.AddWithValue("@reference", reference)
            command.ExecuteNonQuery()
            conn.Close()
            success = True
        Catch ex As Exception
            success = False
            MsgBox(ex.Message)
        End Try
        Return success
    End Function
    Public Function getMaterialNames() As List(Of String)
        Dim list As New List(Of String)
        Try
            'Dim query As String = "SELECT `items`.`item_code`,`items`.`item_long_description`, `inventorys`.`item_code`FROM `items`,`inventorys` WHERE  `items`.`item_long_description` LIKE '%" + descr + "%' LIMIT 1,100"
            Dim query As String = "SELECT `description` FROM `materials`"

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
                        list.Add(itemreader("description").ToString)
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
End Class
