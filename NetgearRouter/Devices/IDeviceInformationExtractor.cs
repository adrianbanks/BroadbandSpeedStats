namespace BroadbandStats.NetgearRouter.Devices
{
    public interface IDeviceInformationExtractor
    {
        string ExtractDeviceInformation(string soapResponse);
    }
}
