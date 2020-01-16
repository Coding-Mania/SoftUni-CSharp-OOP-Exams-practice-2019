namespace SpaceStation.Models.Astronauts.Factory.Contracts
{
    using Astronauts.Contracts;

    public interface IAstronautFactory
    {
        IAstronaut GetAstronaut(string typeName, string name);
    }
}
