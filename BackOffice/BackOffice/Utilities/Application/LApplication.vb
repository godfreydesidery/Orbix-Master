Imports System.Xml
Imports Devart
Imports Devart.Data.MySql

Public Class LApplication
    Public Shared Function getRemoteXMLFile(path As String)
        Dim document As New System.Xml.XmlDocument()
        ' Create a WebRequest to the remote site
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(path)

        ' NB! Use the following line ONLY if the website is protected
        'request.Credentials = New System.Net.NetworkCredential("username", "password")

        ' Call the remote site, and parse the data in a response object
        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        ' Check if the response is OK (status code 200)
        If response.StatusCode = System.Net.HttpStatusCode.OK Then

            ' Parse the contents from the response to a stream object
            Dim stream As System.IO.Stream = response.GetResponseStream()
            ' Create a reader for the stream object
            Dim reader As New System.IO.StreamReader(stream)
            ' Read from the stream object using the reader, put the contents in a string
            Dim contents As String = reader.ReadToEnd()
            ' Create a new, empty XML document

            'MsgBox(contents)

            ' Load the contents into the XML document
            document.LoadXml(contents)

            ' Now you have a XmlDocument object that contains the XML from the remote site, you can
            ' use the objects and methods in the System.Xml namespace to read the document

        Else
            ' If the call to the remote site fails, you'll have to handle this. There can be many reasons, ie. the 
            ' remote site does not respond (code 404) or your username and password were incorrect (code 401)
            '
            ' See the codes in the System.Net.HttpStatusCode enumerator 

            Throw New Exception("Could not retrieve document from the URL, response code: " & response.StatusCode)


        End If

        Return document
    End Function
    Public Shared systemAddress As String = ""
    Public Shared localAppDataDir As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & My.Application.Info.Title + "." + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
    'Public Shared localAppDataDir As String = "C:\" + My.Application.Info.Title + "." + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString
    Dim databaseAddress As String = ""
    Dim databasePassword As String = ""
    Dim databaseUserID As String = ""
    Dim databaseName As String = "rmsdb"
    Public Function getServerAddress() As String
        Dim address As String = ""

        Return address
    End Function
    Public Function loadSettings()
        Dim loaded As Boolean = False
        Dim address As String = ""
        Dim path As String = localAppDataDir + "\localSettings.xml"
        Dim document As XmlReader

        Try

            Dim computerName As String = ""
            Try
                computerName = My.Computer.Name.ToString
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Try
                If (IO.File.Exists(path)) Then
                    document = New XmlTextReader(path)
                    While (document.Read())
                        Dim type = document.NodeType
                        If (type = XmlNodeType.Element) Then
                            If (document.Name = "Address") Then
                                address = document.ReadInnerXml.ToString()
                                systemAddress = address
                            End If
                        End If
                    End While
                    document.Dispose()
                End If
            Catch ex As Exception
                Dim res As Integer = MsgBox("Could not load settings. Settings configurations not found. Configure System?", vbCritical + vbYesNo, "Missing Configurations")
                If res = DialogResult.Yes Then
                    frmServerSetup.ShowDialog()
                End If
                MsgBox("Could not load System. Application will close", vbCritical + vbOKOnly, "Error: Application")
                Application.Exit()
                End
            End Try

            Dim settings As New System.Xml.XmlDocument()

            Try

                settings = getRemoteXMLFile("http://" + address + "/rms/settings/setting_info.xml")

            Catch ex As System.Net.WebException
                Dim res As Integer = MsgBox("Settings configurations not found. Configure System?", vbCritical + vbYesNo, "Missing Configurations")
                If res = DialogResult.Yes Then
                    frmServerSetup.ShowDialog()
                Else
                    MsgBox("Could not load settings. Application will close.", vbExclamation + vbOKOnly, ex.Message.ToString)
                End If
                Application.Exit()
                End
            Catch ex As Exception
                Dim res As Integer = MsgBox("Settings configurations not found. Configure System?", vbCritical + vbYesNo, "Missing Configurations")
                If res = DialogResult.Yes Then
                    frmServerSetup.ShowDialog()
                Else
                    MsgBox("Could not load settings. Application will close.", vbExclamation + vbOKOnly, ex.Message.ToString)
                End If
                Application.Exit()
                End

            End Try

            'database infomation
            Try
                databaseName = settings.SelectSingleNode("Settings/Database/Name").InnerText.ToString
                databaseAddress = settings.SelectSingleNode("Settings/Database/Address").InnerText.ToString
                databaseUserID = settings.SelectSingleNode("Settings/Database/UserID").InnerText.ToString
                databasePassword = settings.SelectSingleNode("Settings/Database/Password").InnerText.ToString

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


            'load database

            Dim connectionString As String = ""
            connectionString = "server=" + databaseAddress + ";user id=" + databaseUserID + ";password=" + databasePassword + ";Database=" + databaseName + ";pooling=false"
            Database.conString = connectionString
            Dim con As New MySqlConnection(Database.conString)
            Dim isLoaded As Boolean = False
            Try
                isLoaded = True
                Try
                    con.Open()
                    con.Close()
                Catch ex As Exception
                    MsgBox("Could not connect to database: " + ex.Message.ToString)
                    isLoaded = False

                End Try

            Catch ex As Exception
                MsgBox(ex.Message)
                isLoaded = False
            End Try
            If isLoaded = False Then
                MsgBox("Could not load database. Application will close.", vbExclamation + vbOKOnly, "Database error")
                Application.Exit()
                End
            End If
            loaded = True

        Catch ex As Exception
            MsgBox("Connection error " + Database.conString + "   hjkk")

        End Try

        Return loaded
    End Function
End Class