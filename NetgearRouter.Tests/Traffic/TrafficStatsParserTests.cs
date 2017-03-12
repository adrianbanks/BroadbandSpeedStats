using BroadbandStats.NetgearRouter.Traffic;
using NUnit.Framework;
using Shouldly;

namespace NetgearRouter.Tests.Traffic
{
    [TestFixture]
    public sealed class TrafficStatsParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ShouldFailWhenGivenInvalidInput(string soapResponse)
        {
            var parser = new TrafficStatsParser(new BandwidthInformationExtractor());
            var trafficStats = parser.Parse(soapResponse);
            trafficStats.ShouldBeNull();
        }

        [TestCase(null, null)]
        [TestCase(null, "123.45")]
        [TestCase("123.45", null)]
        [TestCase("invalid", "123.45")]
        [TestCase("123.45", "invalid")]
        public void ShouldReturnNullWhenBothStatsCannotBeParsed(string download, string upload)
        {
            var parser = new TrafficStatsParser(new FakeBandwidthInformationExtractor(download, upload));
            var trafficStats = parser.Parse("doesn't matter");
            trafficStats.ShouldBeNull();
        }

        [Test]
        public void ShouldParseTrafficStatsCorrectly()
        {
            var parser = new TrafficStatsParser(new FakeBandwidthInformationExtractor("1234.56", "987.63"));
            var trafficStats = parser.Parse("doesn't matter");
            trafficStats.Download.ShouldBe(1234.56f);
            trafficStats.Upload.ShouldBe(987.63f);
        }

        private sealed class FakeBandwidthInformationExtractor : IBandwidthInformationExtractor
        {
            private readonly string download;
            private readonly string upload;

            public FakeBandwidthInformationExtractor(string download, string upload)
            {
                this.download = download;
                this.upload = upload;
            }

            public BandwidthInformation ExtractBandwidthInformation(string soapResponse)
            {
                return new BandwidthInformation(download, upload);
            }
        }
    }
}
