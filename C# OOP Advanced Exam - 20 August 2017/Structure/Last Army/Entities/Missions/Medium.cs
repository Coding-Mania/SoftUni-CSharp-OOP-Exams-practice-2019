public class Medium : Mission
{
    private const string InitialName = "Capturing dangerous criminals";
    private const double InitialEndurance = 50;
    private const double InitialWearLevelDecrement = 50;

    public Medium(double scoreToComplete)
        : base(InitialName, InitialEndurance, scoreToComplete, InitialWearLevelDecrement)
    {
    }
}
