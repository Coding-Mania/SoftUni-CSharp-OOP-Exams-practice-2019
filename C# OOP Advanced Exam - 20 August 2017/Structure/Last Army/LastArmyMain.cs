﻿using System;
using System.Text;

public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        var engine = new Engine(reader, writer);

        engine.Run();
    }
}