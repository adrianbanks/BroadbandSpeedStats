namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStats
    {
        public Bandwidth Today { get; }
        public Bandwidth Yesterday { get; }
        public BandwidthWithAverages ThisWeek { get; }
        public BandwidthWithAverages ThisMonth { get; }
        public BandwidthWithAverages LastMonth { get; }

        public TrafficStats(Bandwidth today, Bandwidth yesterday, BandwidthWithAverages thisWeek, BandwidthWithAverages thisMonth, BandwidthWithAverages lastMonth)
        {
            Today = today;
            Yesterday = yesterday;
            ThisWeek = thisWeek;
            ThisMonth = thisMonth;
            LastMonth = lastMonth;
        }
    }

    public sealed class Bandwidth
    {
        public float Download { get; }
        public float Upload { get; }

        public Bandwidth(float download, float upload)
        {
            Download = download;
            Upload = upload;
        }
    }

    public sealed class BandwidthWithAverages
    {
        public BandwidthWithDailyAverage Download { get; }
        public BandwidthWithDailyAverage Upload { get; }

        public BandwidthWithAverages(BandwidthWithDailyAverage download, BandwidthWithDailyAverage upload)
        {
            Download = download;
            Upload = upload;
        }
    }

    public class BandwidthWithDailyAverage
    {
        public float Total { get; }
        public float DailyAverage { get; }

        public BandwidthWithDailyAverage(float total, float dailyAverage)
        {
            Total = total;
            DailyAverage = dailyAverage;
        }
    }
}
