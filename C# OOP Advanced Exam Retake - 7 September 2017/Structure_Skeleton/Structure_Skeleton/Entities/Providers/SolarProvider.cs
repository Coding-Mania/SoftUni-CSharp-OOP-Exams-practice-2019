public class SolarProvider : Provider
{
    private const int DurabilityIncreasedPoint = 500;

    public SolarProvider(double energyOutput, int id) 
        : base(energyOutput, id)
    {
        this.Durability += DurabilityIncreasedPoint;
    }
}
