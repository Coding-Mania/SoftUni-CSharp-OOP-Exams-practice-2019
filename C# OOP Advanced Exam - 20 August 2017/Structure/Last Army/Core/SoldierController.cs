using System.Collections.Generic;

public class SoldierController
{

    public static void TeamRegenerate(Dictionary<string, List<ISoldier>> army, string rankerType)
    {
        army[rankerType].ForEach(r => r.Regenerate());
    }


    public static bool DoWeHaveAllNeededWeaponsForTheMission(IWareHouse wearHouse,
       IArmy army)
    {
        foreach (var weapon in wearHouse.Ammunitions)
        {
            string weaponName = weapon.Key.Name;


            //проверка дали оръжието което се иска от нас, нищо че го има в склада войника е обучен да го използва
            if (!army.Soldiers[0].Weapons.ContainsKey(weaponName))
            {
                return false;
            }
            // проверяваме дали броя оръжия които имаме отговаря на броя на хората в екипа
            if (army.Soldiers.Count > wearHouse.Ammunitions.Count)
            {
                return false;
            }
        }

        return true;
    }
}
