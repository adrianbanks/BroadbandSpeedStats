using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices
{
    [TestFixture]
    public sealed class DeviceParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ParsingShouldFailOnInvalidInput(string deviceInformation)
        {
            var parser = new DeviceParser();
            var device = parser.Parse(deviceInformation);
            device.ShouldBeSameAs(Device.Null);
        }

        [TestCase("1;")]
        [TestCase("1;192.168.1.2")]
        [TestCase("1;192.168.1.2;ANDROID-device")]
        [TestCase("1;192.168.1.2;ANDROID-device;00:00:00:00:00:00")]
        public void ParsingShouldFailWhenGivenIncompleteInformation(string deviceInformation)
        {
            var parser = new DeviceParser();
            var device = parser.Parse(deviceInformation);
            device.ShouldBeSameAs(Device.Null);
        }

        [Test]
        public void ParsingShouldParseTheCorrectInformation()
        {
            var parser = new DeviceParser();
            var device = parser.Parse("1;192.168.1.2;ANDROID-device;00:FF:00:FF:00:FF;wireless");
            device.Name.ShouldBe("ANDROID-device");
            device.IpAddress.ShouldBe("192.168.1.2");
            device.MacAddress.ShouldBe("00:FF:00:FF:00:FF");
            device.ConnectionType.ShouldBe("wireless");
        }
    }
}
