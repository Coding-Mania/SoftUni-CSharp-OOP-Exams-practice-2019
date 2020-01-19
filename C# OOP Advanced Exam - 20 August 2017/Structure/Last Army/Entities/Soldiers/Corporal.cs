using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMultiplyer = 2.5;

    private readonly IList<string> weaponsAllowed = new List<string>
    {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife"
    };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        foreach (var wepon in this.weaponsAllowed)
        {
            this.Weapons[wepon] = null;
        }

        this.OverallSkill = (this.Age + this.Experience) * OverallSkillMultiplyer;
    }
}
