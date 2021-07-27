Imports System.IO
Imports System.Xml
Imports Devart.Data.MySql

Public Class LSystem
    Public GL_COMPANY_NAME As String = ""
    Public GL_COMPANY_CONTACT_NAME As String = ""
    Public GL_TIN As String = ""
    Public GL_VRN As String = ""

    Public GL_BANK_ACC_NAME As String = ""
    Public GL_BANK_ACC_ADDRESS As String = ""
    Public GL_BANK_POST_CODE As String = ""
    Public GL_BANK_NAME As String = ""
    Public GL_BANK_ACC_NO As String = ""

    Public GL_ADDRESS As String = ""
    Public GL_POST_CODE As String = ""
    Public GL_PHYSICAL_ADDRESS As String = ""
    Public GL_TELEPHONE As String = ""
    Public GL_MOBILE As String = ""
    Public GL_EMAIL As String = ""
    Public GL_FAX As String = ""
    Public LOGO As Byte() = New Byte() {}

    Private Function getRemoteXMLFile(path As String)
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
    Private Function checkServer(address As String) As Boolean
        Dim ok As Boolean = False
        '
        '
        ok = True

        Return ok
    End Function
    Private Function checkDatabase() As Boolean
        Dim ok As Boolean = False
        '
        Dim con As New MySqlConnection(Database.conString)
        Try
            con.Open()
            ok = True

        Catch ex As Exception
            ok = False
        End Try
        '
        Return ok
    End Function
    Public Function refreshSystem() As String
        Dim message As String = ""
        If checkServer(LApplication.systemAddress) = False Then
            message = "Server offline"
            Return message
            Exit Function
        End If
        If checkDatabase() = False Then
            message = "Database offline"
            Return message
            Exit Function
        End If
        Return message
    End Function
    Public Shared Function getRoot()
        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments & ".OrbitDocuments") Then
            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments & ".OrbitDocuments")
        End If
        Return My.Computer.FileSystem.SpecialDirectories.MyDocuments & ".OrbitDocuments".ToString
    End Function
    Public Shared Function saveToDesktop()
        If Not Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & ".OrbitDocuments") Then
            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & ".OrbitDocuments")
        End If
        Return My.Computer.FileSystem.SpecialDirectories.Desktop & ".OrbitDocuments".ToString
    End Function
End Class
