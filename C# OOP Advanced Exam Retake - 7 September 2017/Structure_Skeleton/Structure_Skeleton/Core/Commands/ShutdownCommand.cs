using System.Text;

public class ShutdownCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public ShutdownCommand(IHarvesterController harvesterController, IProviderController providerController)
        : base(null)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {this.providerController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {this.harvesterController.OreProduced}");

        return sb.ToString();
    }
}
