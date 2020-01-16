namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;

    using Astronauts.Contracts;
    using Planets;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            ICollection<string> newItem = new List<string>();

            foreach (var astronaut in astronauts)
            {
                foreach (var item in planet.Items)
                {
                    if (!astronaut.CanBreath)
                    {
                        newItem.Add(item);
                    }
                    else
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                    }
                }

                ((Planet)planet).ChangeItems(newItem);
                newItem = new List<string>();
            }
        }
    }
}
