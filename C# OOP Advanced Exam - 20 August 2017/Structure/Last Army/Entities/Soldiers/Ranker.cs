using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMultiplyer = 1.5;

    private readonly IList<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
        };

    public Ranker(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        foreach (var wepon in weaponsAllowed)
        {
            this.Weapons[wepon] = null;
        }

        this.OverallSkill = (this.Age + this.Experience) * OverallSkillMultiplyer;
    }
}
