using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[1];

        var id = int.Parse(args[2]);
        var oreOutput = double.Parse(args[3]);
        var energyReq = double.Parse(args[4]);

        Type clazz = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == type + "Harvester");

        IHarvester harvester = (IHarvester)Activator.CreateInstance(clazz, new object[] { id, oreOutput, energyReq });

        return harvester;
    }
}
