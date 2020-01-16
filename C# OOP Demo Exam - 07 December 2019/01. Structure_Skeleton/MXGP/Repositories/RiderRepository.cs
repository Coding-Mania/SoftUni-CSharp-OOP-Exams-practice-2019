namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Riders.Contracts;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly ICollection<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider model) => this.riders.Add(model);

        public IReadOnlyCollection<IRider> GetAll() => riders.ToList().AsReadOnly();

        public IRider GetByName(string name) => this.riders.FirstOrDefault(r => r.Name == name);

        public bool Remove(IRider model) => this.riders.Remove(model);
    }
}
