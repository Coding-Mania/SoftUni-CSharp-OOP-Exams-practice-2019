namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader
                    .ReadLine()
                    .Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                var output = string.Empty;

                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        var type = input[1];
                        var astronautName = input[2];

                        output = this.controller.AddAstronaut(type, astronautName);
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        var name = input[1];
                        var items = input.Skip(2).ToArray();

                        output = this.controller.AddPlanet(name, items);
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        var name = input[1];

                        output = this.controller.RetireAstronaut(name);
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        var name = input[1];

                        output = this.controller.ExplorePlanet(name);
                    }
                    else if (input[0] == "Report")
                    {
                        output = this.controller.Report();
                    }
                }
                catch (TargetInvocationException tie)
                {
                    output = tie.InnerException.Message;
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }

                this.writer.WriteLine(output);
            }
        }
    }
}
