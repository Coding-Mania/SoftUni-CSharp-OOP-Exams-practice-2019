namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using MXGP.Models.Riders.Contracts;
    using Utilities.Messages;

    public class Race : IRace
    {
        private const int MinLaps = 1;
        private const int MinNameLenght = 5;
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameLenght)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MinNameLenght));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < MinLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.ToList().AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider is null)
            {
                throw new ArgumentNullException(null, string.Format(ExceptionMessages.RiderInvalid));
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if (this.riders.Contains(rider))
            {
                throw new ArgumentNullException(null, string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
