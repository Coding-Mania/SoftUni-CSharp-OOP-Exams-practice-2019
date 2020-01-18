using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public RegisterCommand(
        IList<string> arguments,
        IHarvesterController harvesterController,
        IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var entityType = this.Arguments[1];

        string result;

        if (entityType == typeof(Harvester).Name)
        {
            result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else
        {
            result = this.providerController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}
