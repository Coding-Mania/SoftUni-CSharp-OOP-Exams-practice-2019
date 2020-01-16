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
        ICommand command = GetCommad(args);

        return command.Execute();
    }

    private ICommand GetCommad(IList<string> args)
    {
        var commmandName = args[0] + "Command";

        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commmandName);

        var parameterInfo = type
            .GetConstructors()
            .First()
            .GetParameters();

        object[] parameters = new object[parameterInfo.Length];

        for (int i = 0; i < parameterInfo.Length; i++)
        {
            var paramType = parameterInfo[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args;
            }
            else
            {
                var prop = this
                    .GetType()
                    .GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[i] = prop.GetValue(this);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(type, parameters);

        return command;
    }
}
