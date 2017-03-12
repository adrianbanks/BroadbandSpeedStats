using System;
using System.IO;
using System.Xml.XPath;

namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class BandwidthInformationExtractor
    {
        public BandwidthInformation ExtractBandwidthInformation(string soapResponse)
        {
            try
            {
                var document = new XPathDocument(new StringReader(soapResponse));
                var navigator = document.CreateNavigator();
                var download = navigator.SelectSingleNode("//*/NewTodayDownload");
                var upload = navigator.SelectSingleNode("//*/NewTodayUpload");
                return new BandwidthInformation(download?.Value, upload?.Value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
