namespace MXGP.Core
{
    using System;

    using Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IChampionshipController championshipController;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {

            while (true)
            {
                var input = this.reader.ReadLine().Split();

                var command = input[0];
                var output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "CreateRider":
                            var name = input[1];
                            output = this.championshipController.CreateRider(name);
                            break;
                        case "CreateMotorcycle":
                            var type = input[1];
                            var model = input[2];
                            var horsepower = int.Parse(input[3]);
                            output = this.championshipController.CreateMotorcycle(type, model, horsepower);
                            break;
                        case "AddMotorcycleToRider":
                            var rider = input[1];
                            var motorcycle = input[2];
                            output = this.championshipController.AddMotorcycleToRider(rider, motorcycle);
                            break;
                        case "AddRiderToRace":
                            var race = input[1];
                            var riderName = input[2];
                            output = this.championshipController.AddRiderToRace(race, riderName);
                            break;
                        case "CreateRace":
                            var raceName = input[1];
                            var laps = int.Parse(input[2]);
                            output = this.championshipController.CreateRace(raceName, laps);
                            break;
                        case "StartRace":
                            raceName = input[1];
                            output = this.championshipController.StartRace(raceName);
                            break;
                        case "End":
                            return;
                        default:
                            break;
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
