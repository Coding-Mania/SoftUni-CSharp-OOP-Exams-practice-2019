using System.Collections.Generic;

    public static class AmmunitionsController
    {
        private static List<string> weaponsForRemoval = new List<string>();

        public static void DecreaseAmmunitionsWearLevel(IMission mission, Dictionary<string, List<IAmmunition>> wearHouse)
        {
            string weaponName = string.Empty;

            foreach (var weapon in wearHouse.Keys)
            {
                weaponName = weapon;
                foreach (var ammunition in wearHouse[weaponName])
                {
                    if (weaponName.Equals(ammunition.Name))
                    {
                        ammunition.DecreaseWearLevel(ammunition.WearLevel);
                    }
                }
            }
        }

        public static void ThrowAnyWeaponsWithZeroWearLevel(Dictionary<string, List<IAmmunition>> wearHouse)
        {
            foreach (var type in wearHouse)
            {
                foreach (var weapon in type.Value)
                {
                    if (weapon.WearLevel == 0)
                    {
                        weaponsForRemoval.Add(type.Key);
                    }
                }
            }

            for (int i = 0; i < weaponsForRemoval.Count; i++)
            {
                wearHouse.Remove(weaponsForRemoval[i]);
            }
            weaponsForRemoval.Clear();
        }
    }