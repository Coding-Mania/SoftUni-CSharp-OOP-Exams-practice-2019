namespace ViceCity.Models.Guns
{
    using System;

    using Contracts;
    using ViceCity.Utilities.Messages;

    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.GunName);
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.GunBulletsPerBarrel);
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.GunTotalBullets);
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.totalBullets > 0 || this.BulletsPerBarrel > 0;

        public abstract int Fire();
    }
}
