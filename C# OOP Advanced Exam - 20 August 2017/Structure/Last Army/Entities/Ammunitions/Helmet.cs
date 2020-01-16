public class Helmet : Ammunition
{
    public const double InitialWeight = 2.3;
    private const int WearLevelPointMultiplier = 100;

    public Helmet()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
