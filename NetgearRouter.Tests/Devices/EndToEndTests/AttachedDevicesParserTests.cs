using System.Linq;
using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices.EndToEndTests
{
    [TestFixture]
    public sealed class AttachedDevicesParserTests
    {
        public void TheSoapResponseIsParsedCorrectly()
        {
            var parser = new AttachedDevicesParser(new DevicesParser(new DeviceParser()), new DeviceInformationExtractor());
            var devices = parser.Parse(ExampleSoapResponse).ToArray();

            devices.Length.ShouldBe(4);

            var device1 = devices[0];
            device1.Name.ShouldBe("ANDROID-device");
            device1.IpAddress.ShouldBe("192.168.1.2");
            device1.MacAddress.ShouldBe("00:00:00:00:00:00");
            device1.ConnectionType.ShouldBe("wireless");

            var device2 = devices[1];
            device2.Name.ShouldBe("BOBS-IPHONE");
            device2.IpAddress.ShouldBe("192.168.1.3");
            device2.MacAddress.ShouldBe("12:34:56:78:90:AB");
            device2.ConnectionType.ShouldBe("wireless");

            var device3 = devices[2];
            device3.Name.ShouldBe("IPAD");
            device3.IpAddress.ShouldBe("192.168.1.4");
            device3.MacAddress.ShouldBe("BA:09:87:65:43:21");
            device3.ConnectionType.ShouldBe("wireless");

            var device4 = devices[3];
            device4.Name.ShouldBe("LAPTOP");
            device4.IpAddress.ShouldBe("192.168.1.5");
            device4.MacAddress.ShouldBe("FF:FF:FF:FF:FF:FF");
            device4.ConnectionType.ShouldBe("wireless");
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
