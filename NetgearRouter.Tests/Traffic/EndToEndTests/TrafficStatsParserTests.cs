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

            var today = trafficStats.Today;
            today.Download.ShouldBe(3176);
            today.Upload.ShouldBe(284.44f);

            var yesterday = trafficStats.Yesterday;
            yesterday.Download.ShouldBe(7639);
            yesterday.Upload.ShouldBe(348.93f);

            var thisWeek = trafficStats.ThisWeek;
            thisWeek.Download.Total.ShouldBe(32769);
            thisWeek.Download.DailyAverage.ShouldBe(32769);
            thisWeek.Upload.Total.ShouldBe(2700);
            thisWeek.Upload.DailyAverage.ShouldBe(385.78f);

            var thisMonth = trafficStats.ThisMonth;
            thisMonth.Download.Total.ShouldBe(38032);
            thisMonth.Download.DailyAverage.ShouldBe(1267);
            thisMonth.Upload.Total.ShouldBe(3271);
            thisMonth.Upload.DailyAverage.ShouldBe(109.05f);

            var lastMonth = trafficStats.LastMonth;
            lastMonth.Download.Total.ShouldBe(38032);
            lastMonth.Download.DailyAverage.ShouldBe(1267);
            lastMonth.Upload.Total.ShouldBe(3271);
            lastMonth.Upload.DailyAverage.ShouldBe(109.05f);
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
