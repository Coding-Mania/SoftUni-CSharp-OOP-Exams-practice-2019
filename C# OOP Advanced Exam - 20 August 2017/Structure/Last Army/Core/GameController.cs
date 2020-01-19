using System.Text;

public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IAmmunitionFactory ammunitionFactory;
    private IMissionFactory missionFactory;

    public GameController()
    {
        this.army = new Army();
        this.wearHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wearHouse);
        this.soldierFactory = new SoldierFactory();
        this.ammunitionFactory = new AmmunitionFactory();
        this.missionFactory = new MissionFactory();
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            int age = 0;
            int experience = 0;
            double endurance = 0d;

            string type;
            string name;
            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = int.Parse(data[4]);
                endurance = double.Parse(data[5]);
            }

            var soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

            this.army.AddSoldier(soldier);
        }
        else if (data[0].Equals("WearHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.AddAmmunitions(this.ammunitionFactory.CreateAmmunition(name), number);
        }
        else if (data[0].Equals("Mission"))
        {
            var level = data[1];
            var point = double.Parse(data[2]);

            var mission = this.missionFactory.CreateMission(level, point);

            this.missionController.PerformMission(mission);
        }
    }

    public string RequestResult(StringBuilder result)
    {
        Output.GiveOutput(result, this.army, this.wearHouse, this.missionController.Missions.Count);

        return result.ToString().TrimEnd();
    }

    private void AddAmmunitions(IAmmunition ammunition, int value)
    {
        if (!this.wearHouse.Ammunitions.ContainsKey(ammunition))
        {
            this.wearHouse.Ammunitions.Add(ammunition, value);
        }
        else
        {
            this.wearHouse.Ammunitions[ammunition] += value;
        }
    }
}
