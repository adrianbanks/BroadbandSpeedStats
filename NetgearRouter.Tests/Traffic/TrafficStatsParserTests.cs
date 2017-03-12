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
    }
}
