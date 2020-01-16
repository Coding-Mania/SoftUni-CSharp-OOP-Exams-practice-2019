using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName);

        IAmmunition ammunition = Activator.CreateInstance<IAmmunition>();

        return ammunition;
    }
}