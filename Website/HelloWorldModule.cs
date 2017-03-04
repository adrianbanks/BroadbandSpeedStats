﻿using Nancy;

namespace BroadbandSpeedTests.Website
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
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