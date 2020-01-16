using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = CreateCommand(args);

        return command.Execute();
    }

    private ICommand CreateCommand(IList<string> args)
    {
        var commandName = args[0];

        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(c => c.Name == commandName);

        var parameterInfos = type.GetConstructors()
            .First()
            .GetParameters();

        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            var paramType = parameterInfos[i]
                .ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args;
            }
            else
            {
                var paramInfo = this.GetType()
                    .GetRuntimeProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = paramInfo.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(type, parameters);

        return command;
    }
}
