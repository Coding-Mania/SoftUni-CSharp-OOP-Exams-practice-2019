namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Races.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model) => this.races.Add(model);

        public IReadOnlyCollection<IRace> GetAll() => this.races.ToList().AsReadOnly();

        public IRace GetByName(string name) => this.races.FirstOrDefault(r => r.Name == name);

        public bool Remove(IRace model) => this.races.Remove(model);
    }
}
