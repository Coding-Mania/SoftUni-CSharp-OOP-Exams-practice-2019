using System.Collections.Generic;

public interface IWareHouse
{
    Dictionary<IAmmunition, int> Ammunitions { get; set; }

    void EquipArmy(IArmy army);
}
