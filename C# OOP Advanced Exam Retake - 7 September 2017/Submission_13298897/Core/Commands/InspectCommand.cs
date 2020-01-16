using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[1]);

        IEntity entity = ((ProviderController)this.providerController).Entities.FirstOrDefault(e => e.ID == id);

        if (entity is null)
        {
            entity = ((HarvesterController)this.harvesterController).Entities.FirstOrDefault(e => e.ID == id);
        }
        if (entity is null)
        {
            return string.Format(Constants.EntityNotFound, this.Arguments[1]);
        }

        return entity.ToString();
    }
}

