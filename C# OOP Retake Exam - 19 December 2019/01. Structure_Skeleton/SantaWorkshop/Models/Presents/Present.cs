namespace SantaWorkshop.Models.Presents
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public class Present : IPresent
    {
        private const int DecreasesEnergyPoints = 10;
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.energyRequired = value;
            }
        }

        public void GetCrafted() => this.EnergyRequired -= DecreasesEnergyPoints;

        public bool IsDone() => this.EnergyRequired == 0;
    }
}
