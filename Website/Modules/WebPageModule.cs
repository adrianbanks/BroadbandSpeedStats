using Nancy;

namespace BroadbandSpeedTests.Website.Modules
{
    public class WebPageModule : NancyModule
    {
        public WebPageModule()
        {
            var model = new Foo { Name = "Jim", Age = 123 };
            Get["/"] = parameters => View["starter.html", model];
            Get["/day"] = parameters => View["day.html", model];
            Get["/week"] = parameters => View["week.html", model];
            Get["/month"] = parameters => View["month.html", model];
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}