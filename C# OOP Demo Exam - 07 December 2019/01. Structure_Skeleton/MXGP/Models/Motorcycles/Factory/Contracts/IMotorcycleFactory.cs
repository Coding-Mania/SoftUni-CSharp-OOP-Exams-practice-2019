namespace MXGP.Models.Motorcycles.Factory.Contracts
{
    using Motorcycles.Contracts;

    public interface IMotorcycleFactory
    {
        IMotorcycle GetMotorcycle(string type, string model, int horsePower);
    }
}
