using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var harvesters = new List<IHarvester>();
        var providers = new List<IProvider>();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IProviderFactory providerFactory = new ProviderFactory();

        var energyRepository = new EnergyRepository();

        IHarvesterController harvesterController = new HarvesterController(harvesters, harvesterFactory, energyRepository);
        IProviderController providerController = new ProviderController(providers, energyRepository, providerFactory);

        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        Engine engine = new Engine(writer, reader, commandInterpreter);

        engine.Run();
    }
}