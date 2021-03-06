﻿using System;
using System.Collections.Generic;
using System.Linq;

public class ProviderController : IProviderController
{
    private readonly List<IProvider> providers;
    private readonly IEnergyRepository energyRepository;
    private readonly IProviderFactory factory;

    public ProviderController(List<IProvider> providers, IEnergyRepository energyRepository, IProviderFactory factory)
    {
        this.providers = providers;
        this.energyRepository = energyRepository;
        this.factory = factory;
    }

    public double TotalEnergyProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.providers.AsReadOnly();

    public string Register(IList<string> arguments)
    {
        var provider = this.factory.GenerateProvider(arguments);
        this.providers.Add(provider);
        return string.Format(Constants.SuccessfullRegistration, provider.GetType().Name);
    }

    public string Produce()
    {
        double energyProduced = this.providers.Select(n => n.Produce()).Sum();
        this.energyRepository.StoreEnergy(energyProduced);
        this.TotalEnergyProduced += energyProduced;
        List<IProvider> reminder = new List<IProvider>();

        foreach (var provider in this.providers)
        {
            try
            {
                provider.Broke();
            }
            catch (Exception)
            {
                reminder.Add(provider);
            }
        }

        foreach (var entity in reminder)
        {
            this.providers.Remove(entity);
        }

        return string.Format(Constants.EnergyOutputToday, energyProduced);
    }

    public string Repair(double val)
    {
        foreach (var provider in this.providers)
        {
            provider.Repair(val);
        }

        return string.Format(Constants.ProvidersRepaired, val);
    }
}