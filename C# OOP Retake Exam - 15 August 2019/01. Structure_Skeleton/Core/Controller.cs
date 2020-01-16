namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Astronauts.Contracts;
    using Models.Astronauts.Factory;
    using Models.Astronauts.Factory.Contracts;
    using Models.Mission;
    using Models.Planets;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronauts;
        private readonly IRepository<IPlanet> planets;
        private readonly IAstronautFactory astronautFactory;
        private readonly IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
            this.astronautFactory = new AstronautFactory();
            this.mission = new Mission();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            var astronaut = this.astronautFactory.GetAstronaut(type, astronautName);

            if (astronaut is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            if (!this.astronauts.Models.Contains(astronaut))
            {
                this.astronauts.Add(astronaut);
            }

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            planet.ChangeItems(items);

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronauts = this.astronauts.Models.ToList<IAstronaut>().FindAll(a => a.Oxygen >= 60);

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var planet = this.planets.FindByName(planetName);

            this.mission.Explore(planet, astronauts);
            this.exploredPlanetsCount++;

            var deadAstronauts = astronauts.FindAll(a => a.Oxygen == 0);

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in this.astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.Models.FirstOrDefault(a => a.Name == astronautName);

            if (astronaut is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
