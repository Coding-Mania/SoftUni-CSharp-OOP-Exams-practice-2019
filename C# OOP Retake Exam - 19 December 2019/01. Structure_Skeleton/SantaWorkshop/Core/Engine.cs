namespace SantaWorkshop.Core
{
    using System;

    using Contracts;
    using IO;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

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
                string[] input = this.reader.ReadLine().Split();

                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }

                try
                {
                    string result = string.Empty;

                    if (input[0] == "AddDwarf")
                    {
                        string dwarfType = input[1];
                        string dwarfName = input[2];

                        result = this.controller.AddDwarf(dwarfType, dwarfName);
                    }
                    else if (input[0] == "AddPresent")
                    {
                        string presentName = input[1];
                        int energyRequired = int.Parse(input[2]);

                        result = this.controller.AddPresent(presentName, energyRequired);
                    }
                    else if (input[0] == "AddInstrumentToDwarf")
                    {
                        string dwarfname = input[1];
                        int power = int.Parse(input[2]);

                        result = this.controller.AddInstrumentToDwarf(dwarfname, power);
                    }
                    else if (input[0] == "CraftPresent")
                    {
                        string presentName = input[1];

                        result = this.controller.CraftPresent(presentName);
                    }
                    else if (input[0] == "Report")
                    {
                        result = this.controller.Report();
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
