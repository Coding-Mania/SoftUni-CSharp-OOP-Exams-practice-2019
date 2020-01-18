public class SolarProvider : Provider
{
    private const int DurabilityIncreasedPoint = 500;

    public SolarProvider(int iD, double energyOutput)
        : base(iD, energyOutput)
    {
        this.Durability += DurabilityIncreasedPoint;
    }
}
