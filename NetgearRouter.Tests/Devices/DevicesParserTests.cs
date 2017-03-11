using System.Linq;
using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices
{
    [TestFixture]
    public sealed class DevicesParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ParsingShouldFailOnInvalidInput(string devicesInformation)
        {
            var parser = new DevicesParser();
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(0);
        }

        [TestCase("3@")]
        [TestCase("3@device1")]
        [TestCase("3@device1@device2")]
        public void ParsingShouldFailWhenGivenIncompleteInformation(string devicesInformation)
        {
            var parser = new DevicesParser();
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(0);
        }

        [TestCase("0@@", 0)]
        [TestCase("1@device1@", 1)]
        [TestCase("2@device1@device2@", 2)]
        [TestCase("3@device1@device2@device3@", 3)]
        public void ParsingShouldReturnTheCorrectNumberOfDevices(string devicesInformation, int expectedNumberOfDevices)
        {
            var parser = new DevicesParser();
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(expectedNumberOfDevices);
        }

        private const string ExampleInformation = "4@1;192.168.1.2;ANDROID-device;00:00:00:00:00:00;wireless@2;192.168.1.3;BOBS-IPHONE;12:34:56:78:90:AB;wireless@3;192.168.1.4;IPAD;BA:09:87:65:43:21;wireless@4;192.168.1.5;LAPTOP;FF:FF:FF:FF:FF:FF;wireless@";
    }
}
