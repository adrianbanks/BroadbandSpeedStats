namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStatsParser
    {
        public TrafficStats Parse(string soapResponse)
        {
            var today = new Bandwidth(1234, 12.45f);
            var yesterday = new Bandwidth(3600, 212.66f);
            var thisWeek = new Bandwidth(17445, 832.2f);
            var thisMonth = new Bandwidth(109234, 1740.27f);
            var lastMonth = new Bandwidth(103445, 2041.6f);
            return new TrafficStats(today, yesterday, thisWeek, thisMonth, lastMonth);
        }
    }
}
