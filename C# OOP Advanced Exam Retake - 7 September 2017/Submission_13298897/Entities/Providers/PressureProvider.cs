public class PressureProvider : Provider
{
    private const int DurabilityDecreasedPoint = 300;
    private const double OutputMultipliedPoint = 2;

    public PressureProvider(int ID, double energyOutput)
        : base(ID, energyOutput)
    {
        this.Durability -= DurabilityDecreasedPoint;
        this.EnergyOutput *= OutputMultipliedPoint;
    }
}

