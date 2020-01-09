using System.IO;
using System.Net;

namespace Tests.Client
{
    public class WebClient
    {
        public WebClient()
        {
            
        }

        public string SendRequest(string request, string method)
        {
            WebRequest webRequest = WebRequest.Create(request);
            
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Method = method;
            
            WebResponse response = webRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string responseFromServer = streamReader.ReadToEnd();
            
            stream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}