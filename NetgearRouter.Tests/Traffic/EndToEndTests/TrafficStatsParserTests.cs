using BroadbandStats.NetgearRouter.Traffic;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Traffic.EndToEndTests
{
    [TestFixture]
    public sealed class TrafficStatsParserTests
    {
        [Test]
        public void TheSoapResponseIsParsedCorrectly()
        {
            var parser = new TrafficStatsParser();
            var trafficStats = parser.Parse(ExampleSoapResponse);
            trafficStats.Download.ShouldBe(3176);
            trafficStats.Upload.ShouldBe(284.44f);
        }

        private const string ExampleSoapResponse = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<soap-env:Envelope
        xmlns:soap-env=""http://schemas.xmlsoap.org/soap/envelope/""
        soap-env:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""
        >
<soap-env:Body>
    <m:GetTrafficMeterStaticsResponse
        xmlns:m=""urn:NETGEAT-ROUTER:service:DeviceConfig:1"">
        <NewTodayConnectionTime>--:--</NewTodayConnectionTime>
        <NewTodayUpload>284.44</NewTodayUpload>
        <NewTodayDownload>3176</NewTodayDownload>
        <NewYesterdayConnectionTime>--:--</NewYesterdayConnectionTime>
        <NewYesterdayUpload>348.93</NewYesterdayUpload>
        <NewYesterdayDownload>7639</NewYesterdayDownload>
        <NewWeekConnectionTime>--:--</NewWeekConnectionTime>
        <NewWeekUpload>2700/385.78</NewWeekUpload>
        <NewWeekDownload>32769/4681</NewWeekDownload>
        <NewMonthConnectionTime>--:--</NewMonthConnectionTime>
        <NewMonthUpload>3271/109.05</NewMonthUpload>
        <NewMonthDownload>38032/1267</NewMonthDownload>
        <NewLastMonthConnectionTime>--:--</NewLastMonthConnectionTime>
        <NewLastMonthUpload>9659/321.97</NewLastMonthUpload>
        <NewLastMonthDownload>103782/3459</NewLastMonthDownload>
    </m:GetTrafficMeterStaticsResponse>
    <ResponseCode>000</ResponseCode>
</soap-env:Body>
</soap-env:Envelope>";
    }
}
