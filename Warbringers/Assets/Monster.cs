using System;
using UnityEngine;

public enum MonsterRol
{
    Leader = 0,
    Attacker = 1,
    Defender = 2,
    Reserve = 3
}

public enum TrainningType
{
    NoTraining = 0,
    Light = 1,
    Medium = 2,
    Hard = 3
}

public delegate void ManageDeath(Monster monster);

[CreateAssetMenu(fileName = "Monster", menuName = "Entities/Monster", order = 2)]
public class Monster : ScriptableObject, IEntity
{
    public MonsterRol rol;
    public int level;
    public int attackPoints;
    public int defensePoints;
    public int totalLifePoints;
    public int actualLifePoints;
    public int marketValue;
    public int mantainCost;
    public int plasmaForSacrifice;
    public int experience;
    public bool alive = true;
    public TrainningType actualTrainning;

    public event ManageDeath OnMonsterDied;
    private int daysWithOutTrainning;
    private const int DaysToHeal = 2;

    private void Awake()
    {
        this.daysWithOutTrainning = 0;
    }

    public void GainExperience(int experiencePoints)
    {
        this.experience += experiencePoints;
        // TODO: en el futuro hay que chequear como evolucionan, por ahora, si superan mod 100 leveleo.
        if (this.experience % 100 == 0)
        {
            this.level++;
            this.attackPoints += 10;
            this.defensePoints += 10;
            this.totalLifePoints += 20;
        }
    }

    public void GetDamage(int damage)
    {
        this.actualLifePoints -= damage;
        if (this.actualLifePoints <= 0)
        {
            this.alive = false;
            this.OnMonsterDied(this);
        }
    }

    public string TeamRol
    {
        get
        {
            switch (this.rol)
            {
                case MonsterRol.Leader:
                    return GlobalVars.Leader;
                case MonsterRol.Attacker:
                    return GlobalVars.Attacker;
                case MonsterRol.Defender:
                    return GlobalVars.Defender;
                default:
                    return GlobalVars.Reserve;
            }
        }
    }

    public void ResolveTraining()
    {
        switch (this.actualTrainning)
        {
            case TrainningType.Light:
                this.GetDamage(TrainMonster.damageForLightTraining);
                if (this.alive)
                {
                    this.GainExperience(TrainMonster.experiencePointsForLightTranning);
                }
                break;

            case TrainningType.Medium:
                this.GetDamage(TrainMonster.damageForMediumTraining);
                if (this.alive)
                {
                    this.GainExperience(TrainMonster.experiencePointsForMediumTranning);
                }
                break;

            case TrainningType.Hard:
                this.GetDamage(TrainMonster.damageForHardTraining);
                if (this.alive)
                {
                    this.GainExperience(TrainMonster.experiencePointsForHardTranning);
                }
                break;
            default:
                this.daysWithOutTrainning++;
                break;
        }
    }

    public void ResolveHealing(bool hasFoughtToday)
    {
        if (!hasFoughtToday && this.daysWithOutTrainning >= Monster.DaysToHeal)
        {
            this.daysWithOutTrainning = 0;
            this.actualLifePoints = this.totalLifePoints;
        }
    }

    public bool MonsterHasRestedToday()
    {
        // TODO: agregar control de que no haya peleado cuando este el modelo de batallas.
        return this.daysWithOutTrainning > 0;
    }
}
