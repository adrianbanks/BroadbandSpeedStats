using System;

namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStatsParser
    {
        private readonly BandwidthInformationExtractor bandwidthInformationExtractor;

        public TrafficStatsParser(BandwidthInformationExtractor bandwidthInformationExtractor)
        {
            if (bandwidthInformationExtractor == null)
            {
                throw new ArgumentNullException(nameof(bandwidthInformationExtractor));
            }

            this.bandwidthInformationExtractor = bandwidthInformationExtractor;
        }

        public TrafficStats Parse(string soapResponse)
        {
            var bandwidthInformation = bandwidthInformationExtractor.ExtractBandwidthInformation(soapResponse);

            float download;

            if (!float.TryParse(bandwidthInformation.Download, out download))
            {
                return null;
            }

            float upload;

            if (!float.TryParse(bandwidthInformation.Upload, out upload))
            {
                return null;
            }

            return new TrafficStats(download, upload);
        }
    }
}
