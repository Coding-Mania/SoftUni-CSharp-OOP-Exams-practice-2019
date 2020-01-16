
using System.Collections.Generic;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, 
        IHarvesterController harvesterController, 
        IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        throw new System.NotImplementedException();
    }
}
