Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
'Namespace Examples.System.Net
Public Class Nett
    Public Shared Function connect1()
        Dim postData As Product = New Product
        postData.id = 1
        postData.code = "sdfghjk"
        postData.primaryBarcode = "sdfghjk"
        postData.description = "test Description"

        Dim tempCokie As New CookieContainer
        Dim encoding As New UTF8Encoding
        Dim byteData() As Byte = encoding.GetBytes(JsonConvert.SerializeObject(postData, Formatting.Indented))


        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("http://127.0.0.1:8080/items/test"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.CookieContainer = tempCokie
        postReq.ContentType = "application/json"
        postReq.Referer = "http://127.0.0.1:8080"
        '  postReq .UserAgent =""
        postReq.ContentLength = byteData.Length

        Dim postReqstream As Stream = postReq.GetRequestStream
        postReqstream.Write(byteData, 0, byteData.Length)
        postReqstream.Close()

        Try
            Dim postResponse As HttpWebResponse

            postResponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
            tempCokie.Add(postResponse.Cookies)

            Dim postRequestReader As New StreamReader(postResponse.GetResponseStream())

            MsgBox(postRequestReader.ReadToEnd)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return vbNull
    End Function
End Class

'End Namespace
