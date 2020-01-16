using System;

public abstract class Provider : IProvider
{
    private double durability;

    protected Provider(double energyOutput, int id)
    {
        this.EnergyOutput = energyOutput;
        this.ID = id;
        this.Durability = Constants.InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; private set; }

    public double Durability
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
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}