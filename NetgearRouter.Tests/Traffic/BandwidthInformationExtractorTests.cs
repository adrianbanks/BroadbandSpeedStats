using BroadbandStats.NetgearRouter.Traffic;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Traffic
{
    [TestFixture]
    public sealed class BandwidthInformationExtractorTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase("gibberish")]
        public void ReturnsNullWhenGivenInvalidInput(string soapResponse)
        {
            var extractor = new BandwidthInformationExtractor();
            var deviceInformation = extractor.ExtractBandwidthInformation(soapResponse);
            deviceInformation.ShouldBeNull();
        }

        [TestCase("123", "321.10")]
        [TestCase("99.12", "12")]
        public void ShouldExtractBandwidthInformationCorrectly(string expectedDownload, string expedtedUpload)
        {
            var soapResponse = string.Format(SoapBoilerPlate, expectedDownload, expedtedUpload);
            var extractor = new BandwidthInformationExtractor();
            var bandwidthInformation = extractor.ExtractBandwidthInformation(soapResponse);
            bandwidthInformation.Download.ShouldBe(expectedDownload);
            bandwidthInformation.Upload.ShouldBe(expedtedUpload);
        }

        private const string SoapBoilerPlate = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<soap-env:Envelope
        xmlns:soap-env=""http://schemas.xmlsoap.org/soap/envelope/""
        soap-env:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""
        >
<soap-env:Body>
    <m:GetTrafficMeterStaticsResponse
        xmlns:m=""urn:NETGEAT-ROUTER:service:DeviceConfig:1"">
        <NewTodayDownload>{0}</NewTodayDownload>
        <NewTodayUpload>{1}</NewTodayUpload>
    </m:GetTrafficMeterStaticsResponse>
    <ResponseCode>000</ResponseCode>
</soap-env:Body>
</soap-env:Envelope>";
    }
}
