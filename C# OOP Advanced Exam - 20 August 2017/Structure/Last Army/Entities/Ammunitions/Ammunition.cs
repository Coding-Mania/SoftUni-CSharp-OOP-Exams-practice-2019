public abstract class Ammunition : IAmmunition
{
    protected Ammunition(double weight)
    {
        this.Weight = weight;
    }

    public string Name => this.GetType().Name;

    public double Weight { get; private set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
