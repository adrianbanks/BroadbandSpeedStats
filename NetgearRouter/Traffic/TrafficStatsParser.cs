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

            if (bandwidthInformation == null)
            {
                return null;
            }

            float download;

            if (string.IsNullOrWhiteSpace(bandwidthInformation.Download)
                || !float.TryParse(bandwidthInformation.Download, out download))
            {
                return null;
            }

            float upload;

            if (string.IsNullOrWhiteSpace(bandwidthInformation.Upload)
                || !float.TryParse(bandwidthInformation.Upload, out upload))
            {
                return null;
            }

            return new TrafficStats(download, upload);
        }
    }
}
