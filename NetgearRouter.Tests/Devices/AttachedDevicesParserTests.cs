using System.Collections.Generic;
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
        public void ShouldFailWhenGivenInvalidInput(string soapResponse)
        {
            var parser = new AttachedDevicesParser(new DevicesParser(new DeviceParser()), new DeviceInformationExtractor());
            var attachedDevices = parser.Parse(soapResponse);
            attachedDevices.Count().ShouldBe(0);
        }

        [Test]
        public void ShouldParseDevicesCorrectly()
        {
            var parser = new AttachedDevicesParser(new FakeDevicesParser(), new FakeDeviceInformationExtractor());
            var attachedDevices = parser.Parse("example soap response");
            attachedDevices.Count().ShouldBe(4);
        }

        private sealed class FakeDevicesParser : IDevicesParser
        {
            public IEnumerable<Device> Parse(string devicesInformation)
            {
                return devicesInformation == "example device information" ? new Device[4] : new Device[0];
            }
        }

        private sealed class FakeDeviceInformationExtractor : IDeviceInformationExtractor
        {
            public string ExtractDeviceInformation(string soapResponse)
            {
                return soapResponse == "example soap response" ? "example device information" : null;
            }
        }
    }
}
