namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 125;
        private const int MinimumHorsepower = 50;
        private const int MaximumHorsepower = 69;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, InitialCubicCentimeters)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < MinimumHorsepower || value > MaximumHorsepower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
