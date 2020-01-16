public class Knife : Ammunition
{
    public const double InitialWeight = 0.4;
    private const int WearLevelPointMultiplier = 100;

    public Knife()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
