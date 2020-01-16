using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public abstract class Dwarf : IDwarf
    {
        private const int DecreasesEnergyPoints = 10;
        private string name;
        private int energy;
        private ICollection<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                name = value;
            }
        }

        public int Energy
        {
            get => energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments.ToList().AsReadOnly();

        public void AddInstrument(IInstrument instrument) => this.instruments.Add(instrument);

        public virtual void Work() => this.Energy -= DecreasesEnergyPoints;
    }
}
