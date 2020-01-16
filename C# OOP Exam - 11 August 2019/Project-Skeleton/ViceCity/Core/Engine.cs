using ViceCity.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.IO.Contracts;
using ViceCity.IO;

namespace ViceCity.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private IController controller;

        public Engine()
        {
            this.reader = new Reader();
            this.writer = new Writer();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                var output = string.Empty;

                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        var name = input[1];

                        output = this.controller.AddPlayer(name);
                    }
                    else if (input[0] == "AddGun")
                    {
                        var type = input[1];
                        var name = input[2];

                        output = this.controller.AddGun(type, name);
                    }
                    else if (input[0] == "AddGunToPlayer")
                    {
                        var name = input[1];

                        output = this.controller.AddGunToPlayer(name);
                    }
                    else if (input[0] == "Fight")
                    {
                        output = this.controller.Fight();
                    }
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
