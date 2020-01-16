using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private IHarvesterFactory factory;
    private IList<IHarvester> harvesters;
    private IEnergyRepository energyRepository;

    public HarvesterController(IHarvesterFactory factory, IList<IHarvester> harvesters, IEnergyRepository energyRepository)
    {
        this.mode = Constants.DefaultMode;
        this.factory = factory;
        this.harvesters = harvesters;
        this.energyRepository = energyRepository;
    }

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        IList<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, this.mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        double minedOres = 0;

        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.OreOutput;
            }
        }

        if (this.mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        var result = string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);

        return result;
    }
}
