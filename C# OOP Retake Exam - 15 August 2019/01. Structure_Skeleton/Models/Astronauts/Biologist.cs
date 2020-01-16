namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int OxygenDecreasedPoints = 5;
        private const double InitialOxygen = 70;

        public Biologist(string name)
            : base(name, InitialOxygen)
        {
        }

        public override void Breath()
        {
            this.Oxygen = this.Oxygen - OxygenDecreasedPoints < 0 ? 0 : this.Oxygen - OxygenDecreasedPoints;
        }
    }
}
