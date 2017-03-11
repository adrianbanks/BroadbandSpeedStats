using System.Collections.Generic;
using System.Linq;
using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices
{
    [TestFixture]
    public class FilteredDevicesParserTests
    {
        [Test]
        public void ParsingShouldIgnoreAnyDevicesThatFailedToParse()
        {
            var parser = new FilteredDevicesParser(new FakeDevicesParser());
            var devices = parser.Parse("2@gibberish@id2;ipAddress2;name2;macAddress2;connectionType2@");
            devices.Count().ShouldBe(1);
        }

        private sealed class FakeDevicesParser : IDevicesParser
        {
            public IEnumerable<Device> Parse(string devicesInformation)
            {
                return new[]
                {
                    new Device("name", "ip address", "mac address", "connection type"),
                    Device.Null
                };
            }
        }
    }
}
