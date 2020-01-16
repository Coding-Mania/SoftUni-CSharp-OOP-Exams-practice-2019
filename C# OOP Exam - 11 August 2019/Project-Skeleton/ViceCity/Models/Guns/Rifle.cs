namespace ViceCity.Models.Guns
{
    using System;

    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int Shoots = 5;

        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            this.BulletsPerBarrel = this.BulletsPerBarrel - Shoots < 0 ? 0 : this.BulletsPerBarrel - Shoots;

            if (this.BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel = this.TotalBullets - InitialBulletsPerBarrel < 0 ? this.TotalBullets : InitialBulletsPerBarrel;
                this.TotalBullets = this.TotalBullets - this.BulletsPerBarrel < 0 ? 0 : this.TotalBullets - this.BulletsPerBarrel;
            }

            if (this.BulletsPerBarrel > 0)
            {
                return Shoots;
            }
            else
            {
                return 0;
            }
        }
    }
}
