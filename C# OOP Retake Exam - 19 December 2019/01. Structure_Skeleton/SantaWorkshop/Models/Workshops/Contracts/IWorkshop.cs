namespace SantaWorkshop.Models.Workshops.Contracts
{
    using Dwarfs.Contracts;
    using Presents.Contracts;

    public interface IWorkshop
    {
        void Craft(IPresent present, IDwarf dwarf);
    }
}
