using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    public WareHouse()
    {
        this.Ammunitions = new Dictionary<IAmmunition, int>();
    }

    public Dictionary<IAmmunition, int> Ammunitions { get; set; }

    public void EquipArmy(IArmy army)
    {
        throw new System.NotImplementedException();
    }
}
