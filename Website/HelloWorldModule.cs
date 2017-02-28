﻿using Nancy;

namespace BroadbandSpeedTests.Website
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = parameters => View["starter.html", new Foo {Name = "Jim", Age = 123}];
            Get["/today"] = parameters => View["today.html"];
        }
    }

    public class Foo
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}