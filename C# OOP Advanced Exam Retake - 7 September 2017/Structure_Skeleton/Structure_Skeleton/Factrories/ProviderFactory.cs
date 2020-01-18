using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        int id = int.Parse(args[2]);
        string type = args[1];
        double energyOutput = double.Parse(args[3]);

        Type clazz = Assembly
            .GetExecutingAssembly()
            .GetTypes().FirstOrDefault(t => t.Name == type + "Provider");

        IProvider provider = (IProvider)Activator.CreateInstance(clazz, new object[] { id, energyOutput });

        return provider;
    }
}