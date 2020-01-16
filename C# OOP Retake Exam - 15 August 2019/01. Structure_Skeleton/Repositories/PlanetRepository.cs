namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Planets;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void Add(IPlanet model)
        {
            if (!this.planets.Any(a => a.Name == model.Name))
            {
                this.planets.Add(model);
            }
        }

        public IPlanet FindByName(string name)
            => this.Models.FirstOrDefault(a => a.Name == name);

        public bool Remove(IPlanet model)
            => this.planets.Remove(model);
    }
}
