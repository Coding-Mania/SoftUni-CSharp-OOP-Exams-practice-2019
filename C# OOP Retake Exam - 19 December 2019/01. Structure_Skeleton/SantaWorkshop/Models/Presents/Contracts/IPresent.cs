namespace SantaWorkshop.Models.Presents.Contracts
{
    public interface IPresent
    {
        string Name { get; }

        int EnergyRequired { get; }

        void GetCrafted();

        bool IsDone();
    }
}
