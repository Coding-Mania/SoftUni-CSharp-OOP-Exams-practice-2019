using System;

public abstract class Provider : IProvider
{
    private double durability;

    protected Provider(int iD, double energyOutput)
    {
        this.ID = iD;
        this.EnergyOutput = energyOutput;
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
                throw new Exception();
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecreased;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}\nDurability: {this.Durability}";
    }
}