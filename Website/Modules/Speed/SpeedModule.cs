using Nancy;

namespace BroadbandStats.Website.Modules.Speed
{
    public class SpeedModule : NancyModule
    {
        public SpeedModule() : base("/speed")
        {
            Get["/"] = parameters => View["speed/dials.html"];
            Get["/day"] = parameters => View["speed/day.html"];
            Get["/week"] = parameters => View["speed/week.html"];
            Get["/month"] = parameters => View["speed/month.html"];
            Get["/year"] = parameters => View["speed/year.html"];
        }
    }
}
