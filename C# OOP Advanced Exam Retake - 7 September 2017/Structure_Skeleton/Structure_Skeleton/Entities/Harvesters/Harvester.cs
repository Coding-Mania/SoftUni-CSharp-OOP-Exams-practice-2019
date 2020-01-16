using System;

public abstract class Harvester : IHarvester
{
    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = Constants.InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, nameof(Provider)));
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecreasedPoints;
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}