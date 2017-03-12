namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStats
    {
        public float Download { get; }
        public float Upload { get; }

        public TrafficStats(float download, float upload)
        {
            Download = download;
            Upload = upload;
        }
    }
}
