using System.IO;
using System.Net;
using System.Net.NetworkInformation;
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
    }
}