using System;
using System.IO;
using System.Xml.XPath;

namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStatsParser
    {
        public TrafficStats Parse(string soapResponse)
        {
            var bandwidthInformation = ExtractBandwidthInformation(soapResponse);

            float download;

            if (!float.TryParse(bandwidthInformation.Item1, out download))
            {
                return null;
            }

            float upload;

            if (!float.TryParse(bandwidthInformation.Item2, out upload))
            {
                return null;
            }

            return new TrafficStats(download, upload);
        }

        private Tuple<string, string> ExtractBandwidthInformation(string soapResponse)
        {
            try
            {
                var document = new XPathDocument(new StringReader(soapResponse));
                var navigator = document.CreateNavigator();
                var download = navigator.SelectSingleNode("//*/NewTodayDownload");
                var upload = navigator.SelectSingleNode("//*/NewTodayUpload");
                return Tuple.Create(download?.Value, upload?.Value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
