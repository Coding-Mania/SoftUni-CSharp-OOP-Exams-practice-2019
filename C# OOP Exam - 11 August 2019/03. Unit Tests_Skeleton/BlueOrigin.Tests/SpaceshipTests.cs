namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        private const string Name = "Pesho";
        private const int Capacity = 10;

        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship(Name, Capacity);
        }

        [Test]
        public void Ctor_ShouldSetCorrectValue()
        {
            var expectedName =Name;
            var expectedCapacity = Capacity;
            var expectedAstronauts = 0;

            var actulalName = this.spaceship.Name;
            var actulalCapacity = this.spaceship.Capacity;
            var actulalAstronauts = this.spaceship.Count;

            Assert.AreEqual(expectedName, actulalName);
            Assert.AreEqual(expectedCapacity, actulalCapacity);
            Assert.AreEqual(expectedAstronauts, actulalAstronauts);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void InvalidName_ShouldThrowArgumentNullException(string input)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(input, Capacity));
        }

        [Test]
        public void InvalidCapacity_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship(Name, -1));
        }

        [Test]
        public void Add_ShouldWorkCorrect()
        {
            var astronaut = new Astronaut("Gosho", 50);

            this.spaceship.Add(astronaut);

            var expected = 1;
            var actual = this.spaceship.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhithFullSpaceship()
        {
            var spaceship = new Spaceship(Name, 0);

            var astronaut = new Astronaut("Gosho", 50);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void Add_ShouldThrowInvalidOperationException_WhithAlredyExist()
        {
            var astronaut = new Astronaut("Gosho", 50);

            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut));
        }

        [Test]
        public void Remove_ShouldReturnTrue()
        {
            var astronaut = new Astronaut("Gosho", 50);

            this.spaceship.Add(astronaut);

            Assert.IsTrue(spaceship.Remove("Gosho"));
        }

        [Test]
        public void Remove_ShouldReturnFalse()
        {
            var astronaut = new Astronaut("Gosho", 50);

            this.spaceship.Add(astronaut);

            Assert.IsFalse(spaceship.Remove("Pesho"));
        }
    }
}