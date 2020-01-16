namespace SantaWorkshop.Models.Instruments
{
    using Contracts;

    public class Instrument : IInstrument
    {
        private const int DecreasesEnergyPoints = 10;

        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get => this.power;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken() => this.Power == 0;

        public void Use() => this.Power -= DecreasesEnergyPoints;
    }
}
