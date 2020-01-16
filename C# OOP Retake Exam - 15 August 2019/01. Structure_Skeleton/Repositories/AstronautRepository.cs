namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models.Astronauts.Contracts;
    using Repositories.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            if (!this.astronauts.Any(a => a.Name == model.Name))
            {
                this.astronauts.Add(model);
            }
        }

        public IAstronaut FindByName(string name)
            => this.Models.FirstOrDefault(a => a.Name == name);

        public bool Remove(IAstronaut model)
            => this.astronauts.Remove(model);
    }
}
