using Nancy;

namespace BroadbandSpeedTests.Website
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            var model = new Foo { Name = "Jim", Age = 123 };
            Get["/"] = parameters => View["starter.html", model];
            Get["/today"] = parameters => View["today.html", model];
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}