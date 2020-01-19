using System;
using System.Text;

public class Engine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reder, IWriter writer)
    {
        this.reader = reder;
        this.writer = writer;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var gameController = new GameController();
        var result = new StringBuilder();

        while (!input.Equals("Enough! Pull back!"))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                result.AppendLine(arg.Message);
            }

            input = this.reader.ReadLine();
        }

        gameController.RequestResult(result);
        this.writer.WriteLine(result.ToString());
    }
}
