using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void Ctor_ShouldSetCorrect()
        {
            Assert.AreEqual(0, this.raceEntry.Counter);
        }

        [Test]
        public void Add_ShouldworkCorrect()
        {
            var motor = new UnitMotorcycle("Model", 120, 1000);

            this.raceEntry.AddRider(new UnitRider("Name", motor));

            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWithNullDriver()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationExceptionWithExistDriver()
        {
            var motor = new UnitMotorcycle("Model", 120, 1000);

            var driver = new UnitRider("Name", motor);

            this.raceEntry.AddRider(driver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(driver));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldWorkCorrect()
        {
            var motor1 = new UnitMotorcycle("Model", 100, 1000);
            var motor2 = new UnitMotorcycle("Model2", 80, 1000);
            var motor3 = new UnitMotorcycle("Model3", 50, 1000);


            var driver1 = new UnitRider("Name", motor1);
            var driver2 = new UnitRider("Name2", motor2);
            var driver3 = new UnitRider("Name3", motor3);

            this.raceEntry.AddRider(driver1);
            this.raceEntry.AddRider(driver2);
            this.raceEntry.AddRider(driver3);
            
            var expected = 76;

            Assert.AreEqual(expected, (int)this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldTrowInvalidOperationExceptionWithLowerRidersCount()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }
        //CalculateAverageHorsePower,lower riders then 2, correct
    }
}