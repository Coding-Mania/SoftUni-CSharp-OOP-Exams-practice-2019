using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const int RegeneratePoints = 30;

    private const double OverallSkillMultiplyer = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        foreach (var wepon in weaponsAllowed)
        {
            this.Weapons[wepon] = null;
        }

        this.OverallSkill = (this.Age + this.Experience) * OverallSkillMultiplyer;
    }

    public override void Regenerate()
    {
        this.Endurance = this.Age + RegeneratePoints;
    }
}