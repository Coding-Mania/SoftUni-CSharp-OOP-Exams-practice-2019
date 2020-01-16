namespace ViceCity.Models.Guns.Factory.Contracts
{
    using ViceCity.Models.Guns.Contracts;

    public interface IGunFactory
    {
        IGun GetGun(string type, string name);
    }
}
