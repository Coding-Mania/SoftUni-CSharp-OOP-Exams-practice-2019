namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    using Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }

        public ICollection<string> Items { get; private set; }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(null, ExceptionMessages.InvalidPlanetName);
                }

                this.name = value;
            }
        }

        public void ChangeItems(ICollection<string> items)
        {
            this.Items = items;
        }
    }
}
