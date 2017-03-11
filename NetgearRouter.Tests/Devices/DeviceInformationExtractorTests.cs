using System.Linq;
using BroadbandStats.NetgearRouter.Devices;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Devices
{
    [TestFixture]
    public sealed class DeviceInformationExtractorTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("gibberish")]
        public void ReturnsNullWhenGivenInvalidInput(string soapResponse)
        {
            var extractor = new DeviceInformationExtractor();
            var deviceInformation = extractor.ExtractDeviceInformation(soapResponse);
            deviceInformation.ShouldBeNull();
        }

        [TestCase("1@device1@")]
        [TestCase("2@device1@device2@")]
        public void ShouldExtractDeviceInformationCorrectly(string expeectedDeviceInformation)
        {
            var soapResponse = string.Format(SoapBoilerPlate, expeectedDeviceInformation);
            var extractor = new DeviceInformationExtractor();
            var deviceInformation = extractor.ExtractDeviceInformation(soapResponse);
            deviceInformation.ShouldBe(expeectedDeviceInformation);
        }

        private const string SoapBoilerPlate = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<soap-env:Envelope
        xmlns:soap-env=""http://schemas.xmlsoap.org/soap/envelope/""
        soap-env:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""
        >
<soap-env:Body>
    <m:GetAttachDeviceResponse
        xmlns:m=""urn:NETGEAT-ROUTER:service:DeviceInfo:1"">
        <NewAttachDevice>{0}</NewAttachDevice>
    </m:GetAttachDeviceResponse>
    <ResponseCode>000</ResponseCode>
</soap-env:Body>
</soap-env:Envelope>";
    }
}
