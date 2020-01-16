public class MachineGun : Ammunition
{
    public const double InitialWeight = 10.6;
    private const int WearLevelPointMultiplier = 100;

    public MachineGun()
        : base(InitialWeight)
    {
        this.WearLevel = InitialWeight * WearLevelPointMultiplier;
    }
}
