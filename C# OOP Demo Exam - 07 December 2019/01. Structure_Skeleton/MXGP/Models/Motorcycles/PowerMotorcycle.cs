namespace MXGP.Models.Motorcycles
{
    using System;

    using Utilities.Messages;

    public class PowerMotorcycle : Motorcycle
    {
        private const double InitialCubicCentimeters = 450;
        private const int MinimumHorsepower = 70;
        private const int MaximumHorsepower = 100;
        private int horsePower;


        public PowerMotorcycle(string model, int horsePower)
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
