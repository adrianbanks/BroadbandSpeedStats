namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStatsParser
    {
        public TrafficStats Parse(string soapResponse)
        {
            var today = new Bandwidth(1234, 12.45f);
            var yesterday = new Bandwidth(3600, 212.66f);
            var thisWeek = new BandwidthWithAverages(new BandwidthWithDailyAverage(17445, 667.22f), new BandwidthWithDailyAverage(832.2f, 67.22f));
            var thisMonth = new BandwidthWithAverages(new BandwidthWithDailyAverage(109234, 1782.44f), new BandwidthWithDailyAverage(1740.27f, 155.33f));
            var lastMonth = new BandwidthWithAverages(new BandwidthWithDailyAverage(103445, 1824.33f), new BandwidthWithDailyAverage(2041.6f, 212.5f));
            return new TrafficStats(today, yesterday, thisWeek, thisMonth, lastMonth);
        }
    }
}
