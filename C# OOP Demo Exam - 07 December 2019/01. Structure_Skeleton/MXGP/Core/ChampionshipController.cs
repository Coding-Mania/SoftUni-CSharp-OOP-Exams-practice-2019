namespace MXGP.Core
{
    using System;
    using System.Linq;
    using Contracts;
    using Models.Motorcycles.Contracts;
    using Models.Motorcycles.Factory;
    using Models.Motorcycles.Factory.Contracts;
    using Models.Races.Contracts;
    using Models.Riders;
    using Models.Riders.Contracts;
    using MXGP.Models.Races;
    using MXGP.Repositories.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int RaceParticipantCount = 3;
        private readonly IRepository<IMotorcycle> motorcycles;
        private readonly IRepository<IRace> races;
        private readonly IRepository<IRider> riders;
        private readonly IMotorcycleFactory motorcycleFactory;

        public ChampionshipController()
        {
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
            this.motorcycleFactory = new MotorcycleFactory();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = this.motorcycles.GetByName(motorcycleModel);

            if (motorcycle is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);
            this.motorcycles.Remove(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var rider = this.riders.GetByName(riderName);

            if (rider is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = this.motorcycles.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            motorcycle = this.motorcycleFactory.GetMotorcycle(type, model, horsePower);

            this.motorcycles.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            var race = this.races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var rider = this.riders.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            rider = new Rider(riderName);

            this.riders.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.races.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < RaceParticipantCount)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, RaceParticipantCount));
            }


            var laps = race.Laps;

            var riders = race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(laps)).ThenBy(r => r.NumberOfWins).ToList();

            riders[0].WinRace();

            var firstRider = riders[0];
            var secondRider = riders[1];
            var thirdRider = riders[2];

            var output = string.Format(OutputMessages.RiderFirstPosition, firstRider.Name, raceName) + Environment.NewLine +
                string.Format(OutputMessages.RiderSecondPosition, secondRider.Name, raceName) + Environment.NewLine +
                string.Format(OutputMessages.RiderThirdPosition, thirdRider.Name, raceName);

            this.races.Remove(race);

            return output;
        }
    }
}
