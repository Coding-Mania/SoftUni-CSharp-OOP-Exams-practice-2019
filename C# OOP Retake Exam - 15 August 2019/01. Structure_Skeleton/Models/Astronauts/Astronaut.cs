namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;
    using Bags;
    using Contracts;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private const int OxygenDecreasedPoints = 10;

        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(null, ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen = this.Oxygen - OxygenDecreasedPoints < 0 ? 0 : this.Oxygen - OxygenDecreasedPoints;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine($"Bag items: {(this.Bag.Items.Count == 0 ? "none" : string.Join(", ", this.Bag.Items))}");

            return sb.ToString().TrimEnd();
        }
    }
}
