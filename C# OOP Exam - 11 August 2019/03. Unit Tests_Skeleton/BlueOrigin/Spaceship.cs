namespace BlueOrigin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Spaceship
    {
        private readonly ICollection<Astronaut> astronauts;
        private int capacity;
        private string name;

        public Spaceship(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.astronauts = new List<Astronaut>();
        }

        public int Count
            => this.astronauts.Count;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid spaceship name!");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid capacity!");
                }

                this.capacity = value;
            }
        }

        public void Add(Astronaut astronaut)
        {
            if (this.astronauts.Count == this.capacity)
            {
                throw new InvalidOperationException("Spaceship is full!");
            }

            bool astronautExists = this.astronauts.Any(x => x.Name == astronaut.Name);

            if (astronautExists)
            {
                throw new InvalidOperationException($"Astronaut {astronaut.Name} is already in!");
            }

            this.astronauts.Add(astronaut);
        }

        public bool Remove(string astronautName)
        {
            var astronaut = this.astronauts.FirstOrDefault(x => x.Name == astronautName);

            bool isRemove = this.astronauts.Remove(astronaut);

            return isRemove;
        }
    }
}
