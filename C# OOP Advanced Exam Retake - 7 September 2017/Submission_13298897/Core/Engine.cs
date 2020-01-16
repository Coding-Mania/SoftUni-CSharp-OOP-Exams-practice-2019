using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private readonly IWriter writer;
    private readonly IReader reader;
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
    {
        this.writer = writer;
        this.reader = reader;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine()
                .Split();

            var result = this.commandInterpreter.ProcessCommand(input);

            this.writer.WriteLine(result);

            if (input[0] == "Shutdown")
            {
                return;
            }
        }
    }
}
