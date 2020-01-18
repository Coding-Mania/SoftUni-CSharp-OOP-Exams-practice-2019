using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    private readonly IHarvesterController harvesterController;
    private readonly IProviderController providerController;

    public DayCommand(
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
        var result = this.providerController.Produce() + "\n" + this.harvesterController.Produce();

        return result;
    }
}
