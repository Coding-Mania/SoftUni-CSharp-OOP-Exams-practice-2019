namespace ViceCity.Models.Guns.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IGun
    {
        string Name { get; }

        int BulletsPerBarrel { get; }

        int TotalBullets { get; }

        bool CanFire { get; }

        int Fire();
    }
}
