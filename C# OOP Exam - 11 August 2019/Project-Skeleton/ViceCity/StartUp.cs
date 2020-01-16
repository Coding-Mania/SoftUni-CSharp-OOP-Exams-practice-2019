namespace ViceCity
{
    using Core;
    using Core.Contracts;

    public static class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
