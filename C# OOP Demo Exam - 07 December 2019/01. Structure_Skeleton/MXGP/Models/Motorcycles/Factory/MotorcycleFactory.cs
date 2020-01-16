namespace MXGP.Models.Motorcycles.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Motorcycles.Contracts;

    public class MotorcycleFactory : IMotorcycleFactory
    {
        public IMotorcycle GetMotorcycle(string typeName, string model, int horsePower)
        {
            var fullName = typeName + "Motorcycle";

            try
            {
                var type = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == fullName);

                IMotorcycle motorcycle = Activator.CreateInstance(type, model, horsePower) as IMotorcycle;

                return motorcycle;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
