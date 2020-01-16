public class RPG : Ammunition
{
    public const double InitialWeight = 17.1;
    private const int WearLevelPointMultiplier = 100;

    public RPG()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
