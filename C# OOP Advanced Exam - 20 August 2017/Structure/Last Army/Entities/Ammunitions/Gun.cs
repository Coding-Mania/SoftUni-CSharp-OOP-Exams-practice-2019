public class Gun : Ammunition
{
    public const double InitialWeight = 1.4;
    private const int WearLevelPointMultiplier = 100;

    public Gun()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
