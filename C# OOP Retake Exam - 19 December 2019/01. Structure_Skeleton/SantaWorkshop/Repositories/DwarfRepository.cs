namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Dwarfs.Contracts;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.models.ToList().AsReadOnly();

        public void Add(IDwarf model) => this.models.Add(model);

        public IDwarf FindByName(string name) => this.Models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IDwarf model) => this.models.Remove(model);
    }
}
