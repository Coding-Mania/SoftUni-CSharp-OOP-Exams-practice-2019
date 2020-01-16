namespace ViceCity.Models.Guns.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Guns.Contracts;

    public class GunFactory : IGunFactory
    {
        public IGun GetGun(string typeName, string name)
        {
            var type = Assembly
              .GetCallingAssembly()
              .GetTypes()
              .FirstOrDefault(t => t.Name == typeName);

            IGun gun = type == null ? null : (IGun)Activator.CreateInstance(type, name);

            return gun;
        }
    }
}
