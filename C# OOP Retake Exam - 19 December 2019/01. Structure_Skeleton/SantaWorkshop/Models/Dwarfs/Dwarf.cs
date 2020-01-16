namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Instruments.Contracts;
    using Utilities.Messages;

    public abstract class Dwarf : IDwarf
    {
        private const int DecreasesEnergyPoints = 10;
        private readonly ICollection<IInstrument> instruments;
        private string name;
        private int energy;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments.ToList().AsReadOnly();

        public void AddInstrument(IInstrument instrument) => this.instruments.Add(instrument);

        public virtual void Work() => this.Energy -= DecreasesEnergyPoints;
    }
}
