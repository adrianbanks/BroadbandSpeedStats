using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.XPath;

namespace BroadbandStats.NetgearRouter.Devices
{
    public sealed class AttachedDevicesParser
    {
        public IEnumerable<Device> Parse(string soapResponse)
        {
            if (string.IsNullOrWhiteSpace(soapResponse))
            {
                return Enumerable.Empty<Device>();
            }

            var deviceInformation = ExtractDeviceInformation(soapResponse);
            var devicesParser = new DevicesParser();
            return devicesParser.Parse(deviceInformation);
        }

        private string ExtractDeviceInformation(string soapResponse)
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
