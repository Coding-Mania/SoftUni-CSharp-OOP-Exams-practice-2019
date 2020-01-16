namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                if (!gun.CanFire)
                {
                    continue;
                }

                var damagePoint = gun.Fire();

                foreach (var civilPlayer in civilPlayers)
                {
                    while (civilPlayer.IsAlive && damagePoint > 0)
                    {
                        civilPlayer.TakeLifePoints(damagePoint);
                        damagePoint = gun.Fire();
                    }

                    if (damagePoint == 0)
                    {
                        break;
                    }
                }
            }

            if (civilPlayers.Any(p => p.IsAlive))
            {
                foreach (var civilPlayer in civilPlayers)
                {
                    if (civilPlayer.IsAlive)
                    {

                        foreach (var gun in civilPlayer.GunRepository.Models)
                        {
                            if (!gun.CanFire)
                            {
                                continue;
                            }

                            var damagePoint = gun.Fire();

                            while (mainPlayer.IsAlive && damagePoint > 0)
                            {
                                mainPlayer.TakeLifePoints(damagePoint);
                                damagePoint = gun.Fire();
                            }
                        }
                    }
                }
            }
        }
    }
}