using System;
using System.Linq;
using System.Text;

    public static class Output
    {
        public static void GiveOutput(StringBuilder result, IArmy army, IWareHouse wearHouse, int missionQueueCount)
        {
            var orderedArmy = army.Soldiers.OrderBy(s => s.OverallSkill);
            int totalAmmunitions = 0;

            foreach (var soldier in orderedArmy)
            {
                result.Append(soldier.ToString());
                result.AppendLine($"Average experience: {soldier.Experience:F2}");
                result.AppendLine($"Average power: {soldier.OverallSkill:F2}");
                result.Append("Soldiers: ");

                result.Append($"{soldier.Name} {soldier.Age}, ");

                result.Remove(result.Length - 2, 2);
                result.AppendLine(Environment.NewLine);
            }

            var orderedWearHouse = wearHouse.Ammunitions.OrderBy(w => w.Key.WearLevel).ToDictionary(k => k.Key, v => v.Value);
            result.AppendLine("Weapons:");

            foreach (var weapon in orderedWearHouse.Keys)
            {
                result.AppendLine(weapon.ToString());
                totalAmmunitions += orderedWearHouse[weapon];
            }

            result.AppendLine($"Ammunitions left in total: {totalAmmunitions}");
            result.AppendLine($"Missions left in Queue: {missionQueueCount}");
        }
    }
