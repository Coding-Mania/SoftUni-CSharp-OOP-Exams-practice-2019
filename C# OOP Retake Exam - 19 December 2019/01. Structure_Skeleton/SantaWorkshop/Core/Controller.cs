using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDwarf> dwarfs;
        private readonly IRepository<IPresent> presents;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;

            switch (dwarfType)
            {
                case "HappyDwarf":
                    dwarf = new HappyDwarf(dwarfName);
                    break;
                case "SleepyDwarf":
                    dwarf = new SleepyDwarf(dwarfName);
                    break;
            }

            if (dwarf is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IDwarf dwarf = this.dwarfs.FindByName(dwarfName);

            if (dwarf is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            var instr = new Instrument(power);

            dwarf.AddInstrument(instr);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);

        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var present = new Present(presentName, energyRequired);

            this.presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            var present = this.presents.FindByName(presentName);

            IDwarf dwarf = this.dwarfs.Models.FirstOrDefault(d => d.Energy >= 50 && d.Instruments.Any(i => !i.IsBroken()));


            if (this.dwarfs.Models.Any(d => d.Instruments.Any(i => i.Power > 0)))
            {
                foreach (var item in this.dwarfs.Models)
                {
                    var instCount = GetCount(item);

                    if (item.Energy >= dwarf.Energy && instCount > GetCount(dwarf))
                    {
                        dwarf = item;
                    }
                }
            }
            else
            {
                dwarf = this.dwarfs.Models.FirstOrDefault(d => d.Energy >= 50 && d.Instruments.Any(i => !i.IsBroken()));
            }



            if (dwarf is null)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            if (!present.IsDone())
            {
                workshop.Craft(present, dwarf);
            }

            if (dwarf.Energy == 0)
            {
                this.dwarfs.Remove(dwarf);
            }

            var masage = present.IsDone() == true ? "done" : "not done";

            if (masage == "done")
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);

            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }

        private int GetCount(IDwarf item)
        {
            var counter = 0;

            foreach (var inst in item.Instruments)
            {
                if (!inst.IsBroken())
                {
                    counter++;
                }
            }

            return counter;
        }

        public string Report()
        {
            var craftedPresents = 0;

            foreach (var item in this.presents.Models)
            {
                if (item.EnergyRequired == 0)
                {
                    craftedPresents++;
                }
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{craftedPresents} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in this.dwarfs.Models)
            {
                var countInstruments = 0;

                foreach (var item in dwarf.Instruments)
                {
                    if (!item.IsBroken())
                    {
                        countInstruments++;
                    }
                }

                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments {countInstruments} not broken left");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
