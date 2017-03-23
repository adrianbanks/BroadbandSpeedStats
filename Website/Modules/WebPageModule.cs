using Nancy;
using Nancy.Responses;

namespace BroadbandStats.Website.Modules
{
    public class WebPageModule : NancyModule
    {
        public WebPageModule() : base("/")
        {
            Get["/"] = parameters => Response.AsRedirect("/speed/", RedirectResponse.RedirectType.Temporary);
        }
    }
}
