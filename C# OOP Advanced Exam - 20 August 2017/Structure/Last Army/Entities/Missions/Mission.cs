public abstract class Mission : IMission
{
    protected Mission(string name, double enduranceRequired, double scoreToComplete, double wearLevelDecrement)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public string Name { get; private set; }

    public double EnduranceRequired { get; private set; }

    public double ScoreToComplete { get; private set; }

    public double WearLevelDecrement { get; private set; }
}
