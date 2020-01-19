using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int RegeneratePoints = 10;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set
        {
            this.endurance = Math.Min(100, value);
        }
    }

    public double OverallSkill { get; protected set; }

    public IDictionary<string, IAmmunition> Weapons { get; protected set; }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) > 0;
    }

    public virtual void Regenerate()
    {
        this.Endurance = this.Age + RegeneratePoints;
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}