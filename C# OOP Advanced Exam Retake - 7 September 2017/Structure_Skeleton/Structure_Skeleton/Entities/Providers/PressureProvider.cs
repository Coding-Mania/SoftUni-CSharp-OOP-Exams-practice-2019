public class PressureProvider : Provider
{
    private const int DurabilityIncreasedPoint = 300;
    private const int EnergyOutputMultiplied = 2;

    public PressureProvider(double energyOutput, int id) 
        : base(energyOutput, id)
    {
        this.Durability += DurabilityIncreasedPoint;
        this.EnergyOutput *= EnergyOutputMultiplied;
    }
}
