namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class BandwidthInformation
    {
        public string Download { get; }
        public string Upload { get; }

        public BandwidthInformation(string download, string upload)
        {
            Download = download;
            Upload = upload;
        }
    }
}
