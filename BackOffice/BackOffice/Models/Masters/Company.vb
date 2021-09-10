Imports System.IO
Imports System.Xml
Imports Devart.Data.MySql
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Company
    Public Shared Property GL_ID As String = ""
    Public Shared Property GL_NAME As String = ""
    Public Shared Property GL_COMPANY_KEY As String = ""
    Public Shared Property GL_CONTACT_NAME As String = ""
    Public Shared Property GL_TIN As String = ""
    Public Shared Property GL_VRN As String = ""
    Public Shared Property GL_PHYSICAL_ADDRESS As String = ""
    Public Shared Property GL_POST_CODE As String = ""
    Public Shared Property GL_POST_ADDRESS As String = ""
    Public Shared Property GL_TELEPHONE As String = ""
    Public Shared Property GL_MOBILE As String = ""
    Public Shared Property GL_EMAIL As String = ""
    Public Shared Property GL_FAX As String = ""
    Public Shared Property GL_LOGO As Byte() = New Byte() {}
    Public Shared Property GL_BANK_ACCOUNT_NAME As String = ""
    Public Shared Property GL_BANK_ADDRESS As String = ""
    Public Shared Property GL_BANK_POST_CODE As String = ""
    Public Shared Property GL_BANK_NAME As String = ""
    Public Shared Property GL_BANK_ACCOUNT_NO As String = ""


    Public Property id As String = ""
    Public Property name As String = ""
    Public Property companyKey As String = ""
    Public Property contactName As String = ""
    Public Property tin As String = ""
    Public Property vrn As String = ""
    Public Property physicalAddress As String = ""
    Public Property postCode As String = ""
    Public Property postAddress As String = ""
    Public Property telephone As String = ""
    Public Property mobile As String = ""
    Public Property email As String = ""
    Public Property fax As String = ""
    Public Property logo As Byte() = New Byte() {}
    Public Property bankAccountName As String = ""
    Public Property bankAddress As String = ""
    Public Property bankPostCode As String = ""
    Public Property bankName As String = ""
    Public Property bankAccountNo As String = ""

    Public Shared Function saveCompanyDetails()
        Dim companyProfile As Company = New Company
        companyProfile.id = GL_ID
        companyProfile.name = GL_NAME
        companyProfile.companyKey = GL_COMPANY_KEY
        companyProfile.contactName = GL_CONTACT_NAME
        companyProfile.tin = GL_TIN
        companyProfile.vrn = GL_VRN
        companyProfile.physicalAddress = GL_PHYSICAL_ADDRESS
        companyProfile.postCode = GL_POST_CODE
        companyProfile.postAddress = GL_POST_ADDRESS
        companyProfile.telephone = GL_TELEPHONE
        companyProfile.mobile = GL_MOBILE
        companyProfile.email = GL_EMAIL
        companyProfile.fax = GL_FAX
        companyProfile.logo = GL_LOGO
        companyProfile.bankAccountName = GL_BANK_ACCOUNT_NAME
        companyProfile.bankAddress = GL_BANK_ADDRESS
        companyProfile.bankPostCode = GL_BANK_POST_CODE
        companyProfile.bankName = GL_BANK_NAME
        companyProfile.bankAccountNo = GL_BANK_ACCOUNT_NO

        ' If validateValues() = False Then
        'stop operation if the values are invalid
        'Exit Sub
        ' End If

        Dim response As Object = New Object
        Dim json As JObject = New JObject

        Try
            Dim success As Boolean = False

            response = Web.post(companyProfile, "company_profile/save")
            json = JObject.Parse(response)
            MsgBox("Company profile saved successifully", vbOKOnly, "Success: Profile saved.")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return vbNull
    End Function
    Public Shared Function loadCompanyDetails() As Boolean
        Try
            Dim response As Object = New Object
            Dim json As JObject = New JObject
            response = Web.get_("company_profile")
            json = JObject.Parse(response)
            GL_NAME = json.SelectToken("name")
            GL_CONTACT_NAME = json.SelectToken("contactName")
            GL_TIN = json.SelectToken("tin")
            GL_VRN = json.SelectToken("vrn")
            GL_BANK_ACCOUNT_NAME = json.SelectToken("bankAccountName")
            GL_BANK_ADDRESS = json.SelectToken("bankAddress")
            GL_BANK_POST_CODE = json.SelectToken("bankPostCode")
            GL_BANK_NAME = json.SelectToken("bankName")
            GL_BANK_ACCOUNT_NO = json.SelectToken("bankAccountNo")
            GL_POST_ADDRESS = json.SelectToken("postAddress")
            GL_POST_CODE = json.SelectToken("postCode")
            GL_PHYSICAL_ADDRESS = json.SelectToken("physicalAddress")
            GL_TELEPHONE = json.SelectToken("telephone")
            GL_MOBILE = json.SelectToken("mobile")
            GL_EMAIL = json.SelectToken("email")
            GL_FAX = json.SelectToken("fax")
            Try
                Dim logoArrayJson As JArray = json.SelectToken("logo")

                Dim logoSignedBytes As List(Of SByte) = New List(Of SByte)

                For i As Integer = 0 To logoArrayJson.Count - 1
                    logoSignedBytes.Add(logoArrayJson.Item(i).ToObject(Of SByte))
                Next

                Dim logoUnsignedBytes As List(Of Byte) = New List(Of Byte)

                For i As Integer = 0 To logoSignedBytes.Count - 1
                    logoUnsignedBytes.Add(CByte((logoSignedBytes.Item(i) And &HFF)))
                Next
                GL_LOGO = logoUnsignedBytes.ToArray
            Catch ex As Exception
                GL_LOGO = Nothing
            End Try
            Return True
        Catch ex As Newtonsoft.Json.JsonReaderException
            Return False
        End Try
        Return False
    End Function

    Private Function ObjectToByteArray(ByVal _Object As Object) As Byte()
        Try
            ' create new memory stream
            Dim _MemoryStream As New System.IO.MemoryStream()
            ' create new BinaryFormatter
            Dim _BinaryFormatter As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            ' Serializes an object, or graph of connected objects, to the given stream.
            _BinaryFormatter.Serialize(_MemoryStream, _Object)
            ' convert stream to byte array and return
            Return _MemoryStream.ToArray()
        Catch _Exception As Exception
            ' Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
        End Try
        ' Error occured, return null
        Return Nothing
    End Function
End Class
