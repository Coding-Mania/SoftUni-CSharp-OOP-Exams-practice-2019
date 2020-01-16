namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Models.Guns.Contracts;
    using Models.Guns.Factory;
    using Models.Guns.Factory.Contracts;
    using Models.Neghbourhoods;
    using Models.Neghbourhoods.Contracts;
    using Models.Players;
    using Models.Players.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly List<IPlayer> players;
        private readonly Queue<IGun> guns;
        private readonly IGunFactory gunFactory;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.players = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.gunFactory = new GunFactory();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            var gun = this.gunFactory.GetGun(type, name);

            if (gun is null)
            {
                return string.Format(OutputMessages.InvalidGun);
            }

            this.guns.Enqueue(gun);

            return string.Format(OutputMessages.AddGun, name, type);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.guns.Count == 0)
            {
                return OutputMessages.NoGuns;
            }

            var gun = this.guns.Dequeue();

            if (name == "Vercetti")
            {

                this.mainPlayer.GunRepository.Add(gun);

                return string.Format(OutputMessages.AddGunToPlayerVercetti, gun.Name);
            }

            var player = this.players.FirstOrDefault(p => p.Name == name);

            if (player is null)
            {
                return string.Format(OutputMessages.AddGunToPlayerWhitNoExistingPlayer);
            }

            player.GunRepository.Add(gun);

            return string.Format(OutputMessages.AddGunToPlayerSuccessfully, gun.Name, player.Name);
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);

            this.players.Add(player);

            return string.Format(OutputMessages.AddPlayer, name);
        }

        public string Fight()
        {

            if (this.mainPlayer.GunRepository.Models.Any(g => g.CanFire)
                || this.players.Any(p => p.GunRepository.Models.Any(g => g.CanFire)))
            {
                this.neighbourhood.Action(this.mainPlayer, this.players);

                var sb = new StringBuilder();

                var deadCivilPlayers = this.players.FindAll(p => !p.IsAlive).Count;
                var civilPlayersCount = this.players.FindAll(p => p.IsAlive).Count;

                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivilPlayers} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayersCount}!");

                this.players.RemoveAll(p => !p.IsAlive);

                return sb.ToString().TrimEnd();
            }

            return "Everything is okay!";
        }
    }
}
