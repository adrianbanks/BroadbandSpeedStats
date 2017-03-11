﻿using System.Linq;
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
            var parser = new DevicesParser(new FakeDeviceParser());
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(0);
        }

        [TestCase("3@")]
        [TestCase("3@device1")]
        [TestCase("3@device1@device2")]
        public void ParsingShouldFailWhenGivenIncompleteInformation(string devicesInformation)
        {
            var parser = new DevicesParser(new FakeDeviceParser());
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(0);
        }

        [TestCase("0@@", 0)]
        [TestCase("1@device1@", 1)]
        [TestCase("2@device1@device2@", 2)]
        [TestCase("3@device1@device2@device3@", 3)]
        public void ParsingShouldReturnTheCorrectNumberOfDevices(string devicesInformation, int expectedNumberOfDevices)
        {
            var parser = new DevicesParser(new FakeDeviceParser());
            var devices = parser.Parse(devicesInformation);
            devices.Count().ShouldBe(expectedNumberOfDevices);
        }

        private sealed class FakeDeviceParser : IDeviceParser
        {
            public Device Parse(string deviceInformation)
            {
                return new Device("name", "ip address", "mac address", "connection type");
            }
        }
    }
}
