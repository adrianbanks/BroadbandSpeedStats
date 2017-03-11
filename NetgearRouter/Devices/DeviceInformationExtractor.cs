using System;
using System.IO;
using System.Xml.XPath;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class DeviceInformationExtractor : IDeviceInformationExtractor
    {
        public string ExtractDeviceInformation(string soapResponse)
        {
            try
            {
                var document = new XPathDocument(new StringReader(soapResponse));
                var navigator = document.CreateNavigator();
                var node = navigator.SelectSingleNode("//*/NewAttachDevice");
                return node?.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
