using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using MockServer;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateServer()
        {
            var ping = new Ping();

            var reply = ping.Send(new IPAddress(new byte[] { 127, 0, 0, 1}), 3000);

            Assert.AreEqual(reply.Status, IPStatus.Success);
        }


        [Test]
        public void TestMessage()
        {
            Server server = new Server();
            server.Start();

            Assert.AreEqual(true, server.IsStart);
            WebRequest webRequest = WebRequest.Create("http://localhost:8080/test");
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = webRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string responseFromServer = streamReader.ReadToEnd();
            Assert.AreEqual("\"abcdefg\"", responseFromServer);

            stream.Close();
            response.Close();
            server.Stop();
        }
    }
}