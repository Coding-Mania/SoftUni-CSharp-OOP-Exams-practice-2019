using System.Collections.Generic;

public class SoldierController
{
    public static void TeamRegenerate(Dictionary<string, List<ISoldier>> army, string rankerType)
    {
        army[rankerType].ForEach(r => r.Regenerate());
    }

    public static bool DoWeHaveAllNeededWeaponsForTheMission(IWareHouse wearHouse, IArmy army)
    {
        foreach (var weapon in wearHouse.Ammunitions)
        {
            string weaponName = weapon.Key.Name;

            if (!army.Soldiers[0].Weapons.ContainsKey(weaponName))
            {
                return false;
            }

            if (army.Soldiers.Count > wearHouse.Ammunitions.Count)
            {
                return false;
            }
        }

        return true;
    }
}
