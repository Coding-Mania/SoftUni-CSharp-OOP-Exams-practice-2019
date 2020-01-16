public class SolarProvider : Provider
{
    private const int DurabilityIncreasedPoint = 500;

    public SolarProvider(int ID, double energyOutput)
        : base(ID, energyOutput)
    {
        this.Durability += DurabilityIncreasedPoint;
    }
}
