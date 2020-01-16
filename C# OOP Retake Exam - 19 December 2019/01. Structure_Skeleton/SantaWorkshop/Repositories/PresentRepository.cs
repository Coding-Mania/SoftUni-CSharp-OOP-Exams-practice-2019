namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Presents.Contracts;

    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.models.ToList().AsReadOnly();

        public void Add(IPresent model) => this.models.Add(model);

        public IPresent FindByName(string name) => this.Models.FirstOrDefault(m => m.Name == name);

        public bool Remove(IPresent model) => this.models.Remove(model);
    }
}
