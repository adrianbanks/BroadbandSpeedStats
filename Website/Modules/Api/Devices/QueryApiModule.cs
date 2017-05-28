using System;
using BroadbandStats.Database.Queries;
using Nancy;

namespace BroadbandStats.Website.Modules.Api.Devices
{
    public class QueryApiModule : NancyModule
    {
        public QueryApiModule(QueryRepository queryRepository) : base("/api/devices")
        {
            if (queryRepository == null)
            {
                throw new ArgumentNullException(nameof(queryRepository));
            }

            Get["/CurrentlyAttachedDevices"] = _ => queryRepository.GetCurrentlyAttachedDevices();
        }
    }
}
