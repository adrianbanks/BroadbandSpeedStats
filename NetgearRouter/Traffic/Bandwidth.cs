namespace BroadbandStats.NetgearRouter.Traffic
{
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
}
