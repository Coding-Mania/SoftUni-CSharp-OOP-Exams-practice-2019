namespace SantaWorkshop.Models.Workshops
{
    using System.Linq;

    using Dwarfs.Contracts;
    using Presents.Contracts;
    using Workshops.Contracts;

    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            var instrument = dwarf.Instruments.FirstOrDefault(i => !i.IsBroken());

            if (dwarf.Energy > 0 && instrument != null)
            {
                while (present.EnergyRequired > 0 && dwarf.Energy > 0 && instrument != null && !instrument.IsBroken())
                {
                    present.GetCrafted();
                    dwarf.Work();
                    instrument.Use();

                    if (instrument.IsBroken())
                    {
                        instrument = dwarf.Instruments.FirstOrDefault(i => !i.IsBroken());
                    }
                }
            }
        }
    }
}
