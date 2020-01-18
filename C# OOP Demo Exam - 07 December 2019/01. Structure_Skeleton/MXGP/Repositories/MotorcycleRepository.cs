namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Motorcycles.Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly ICollection<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model) => this.motorcycles.Add(model);

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles.ToList().AsReadOnly();

        public IMotorcycle GetByName(string model) => this.motorcycles.FirstOrDefault(m => m.Model == model);

        public bool Remove(IMotorcycle model) => this.motorcycles.Remove(model);
    }
}
