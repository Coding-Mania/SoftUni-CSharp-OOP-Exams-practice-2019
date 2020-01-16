public class AutomaticMachine : Ammunition
{
    public const double InitialWeight = 6.3;
    private const int WearLevelPointMultiplier = 100;

    public AutomaticMachine()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
