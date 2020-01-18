namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Guns.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun gun)
        {
            if (!this.guns.Contains(gun))
            {
                this.guns.Add(gun);
            }
        }

        public IGun Find(string name) => this.guns.FirstOrDefault(g => g.Name == name);

        public bool Remove(IGun gun) => this.guns.Remove(gun);
    }
}
