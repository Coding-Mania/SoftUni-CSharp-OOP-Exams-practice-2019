public class Easy : Mission
{
    private const string InitialName = "Suppression of civil rebellion";
    private const double InitialEndurance = 20;
    private const double InitialWearLevelDecrement = 30;

    public Easy(double scoreToComplete)
        : base(InitialName, InitialEndurance, scoreToComplete, InitialWearLevelDecrement)
    {
    }
}
