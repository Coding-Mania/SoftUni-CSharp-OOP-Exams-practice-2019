public class NightVision : Ammunition
{
    public const double InitialWeight = 0.8;
    private const int WearLevelPointMultiplier = 100;

    public NightVision()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
