using Nancy;

namespace BroadbandSpeedTests.Website
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = parameters => View["starter.html", new Foo {Name = "Jim", Age = 123}];
        }
    }

    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Get["/test"] = _ => new Foo { Name = "Bob", Age = 24 };
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}