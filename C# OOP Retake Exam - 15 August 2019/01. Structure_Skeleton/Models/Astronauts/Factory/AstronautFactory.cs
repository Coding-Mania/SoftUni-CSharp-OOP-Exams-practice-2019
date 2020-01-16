namespace SpaceStation.Models.Astronauts.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Astronauts.Contracts;

    public class AstronautFactory : IAstronautFactory
    {
        public IAstronaut GetAstronaut(string typeName, string name)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeName);

            IAstronaut astronaut = type is null ? null : (IAstronaut)Activator.CreateInstance(type, name);
            return astronaut;
        }
    }
}
