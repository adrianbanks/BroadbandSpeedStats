namespace BroadbandStats.NetgearRouter.Traffic
{
    public interface IBandwidthInformationExtractor
    {
        BandwidthInformation ExtractBandwidthInformation(string soapResponse);
    }
}
