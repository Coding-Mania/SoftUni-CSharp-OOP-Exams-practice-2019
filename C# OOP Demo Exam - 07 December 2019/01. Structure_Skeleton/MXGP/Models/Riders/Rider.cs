namespace MXGP.Models.Riders
{
    using System;

    using Contracts;
    using Motorcycles.Contracts;
    using MXGP.Utilities.Messages;

    public class Rider : IRider
    {
        private const int MinNameChars = 5;
        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameChars)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameChars));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle is null)
            {
                throw new ArgumentNullException(null, string.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
