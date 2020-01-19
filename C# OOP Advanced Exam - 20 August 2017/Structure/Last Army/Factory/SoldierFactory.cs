using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var type = Assembly.GetCallingAssembly()
           .GetTypes()
           .FirstOrDefault(t => t.Name == soldierTypeName);

        ISoldier soldier = (ISoldier)Activator.CreateInstance(type, name, age, experience, endurance);

        return soldier;
    }
}