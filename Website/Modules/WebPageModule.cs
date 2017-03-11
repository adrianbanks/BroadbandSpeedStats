using Nancy;

namespace BroadbandStats.Website.Modules
{
    public class WebPageModule : NancyModule
    {
        public WebPageModule()
        {
            Get["/"] = parameters => View["starter.html"];
            Get["/day"] = parameters => View["day.html"];
            Get["/week"] = parameters => View["week.html"];
            Get["/month"] = parameters => View["month.html"];
            Get["/year"] = parameters => View["year.html"];
        }
    }
}
