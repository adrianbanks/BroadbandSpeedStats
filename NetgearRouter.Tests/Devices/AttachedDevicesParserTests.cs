using System.Linq;
using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices
{
    [TestFixture]
    public sealed class AttachedDevicesParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("gibberish")]
        public void ShouldFailWhenGivenInvalidInput(string soapResponse)
        {
            var parser = new AttachedDevicesParser(new DevicesParser(new DeviceParser()), new DeviceInformationExtractor());
            var attachedDevices = parser.Parse(soapResponse);
            attachedDevices.Count().ShouldBe(0);
        }

        [Test]
        public void ShouldParseDevicesCorrectly()
        {
            var parser = new AttachedDevicesParser(new DevicesParser(new DeviceParser()), new DeviceInformationExtractor());
            var attachedDevices = parser.Parse(ExampleSoapResponse);
            attachedDevices.Count().ShouldBe(4);
        }

        private const string ExampleSoapResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<soap-env:Envelope
        xmlns:soap-env=""http://schemas.xmlsoap.org/soap/envelope/""
        soap-env:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""
        >
<soap-env:Body>
    <m:GetAttachDeviceResponse
        xmlns:m=""urn:NETGEAT-ROUTER:service:DeviceInfo:1"">
        <NewAttachDevice>4@1;192.168.1.2;ANDROID-device;00:00:00:00:00:00;wireless@2;192.168.1.3;BOBS-IPHONE;12:34:56:78:90:AB;wireless@3;192.168.1.4;IPAD;BA:09:87:65:43:21;wireless@4;192.168.1.5;LAPTOP;FF:FF:FF:FF:FF:FF;wireless@</NewAttachDevice>
    </m:GetAttachDeviceResponse>
    <ResponseCode>000</ResponseCode>
</soap-env:Body>
</soap-env:Envelope>";
    }
}
