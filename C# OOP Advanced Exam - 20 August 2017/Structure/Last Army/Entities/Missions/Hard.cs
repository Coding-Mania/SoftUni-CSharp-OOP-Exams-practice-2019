public class Hard : Mission
{
    private const string InitialName = "Disposal of terrorists";
    private const double InitialEndurance = 80;
    private const double InitialWearLevelDecrement = 70;

    public Hard(double scoreToComplete)
        : base(InitialName, InitialEndurance, scoreToComplete, InitialWearLevelDecrement)
    {
    }
}
