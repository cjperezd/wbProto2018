using UnityEngine;
using UnityEngine.UI;


public class AdminMonster : MonsterDataForPanel
{
    public Dropdown rolSelector;

    public override void SetMonsterLabels()
    {
        this.levelLabel.text = string.Format(GlobalVars.Level, this.monster.level.ToString());
        this.attackPoints.text = string.Format(GlobalVars.AttackPoints, this.monster.attackPoints.ToString());
        this.defensePoints.text = string.Format(GlobalVars.DefensePoints, this.monster.defensePoints.ToString());
        this.totalLifePoints.text = string.Format(GlobalVars.TotalLifePoints, this.monster.totalLifePoints.ToString());
        this.actualLifePoints.text = string.Format(GlobalVars.ActualLifePoints, this.monster.actualLifePoints.ToString());
        this.mantainCost.text = string.Format(GlobalVars.MaintainceCost, this.monster.mantainCost.ToString());
        this.plasmaForSacrifice.text = string.Format(GlobalVars.PlasmaForSacrifice, this.monster.plasmaForSacrifice.ToString());
        this.experience.text = string.Format(GlobalVars.Experience, this.monster.experience.ToString());
        this.monsterName.text = this.monster.name;


        // TODO: ver si se puede sacar este switch horrible por algo como lo que esta abajo.
        switch (this.monster.rol)
        {
            case MonsterRol.Leader:
                this.rolSelector.value = 0;
                break;
            case MonsterRol.Attacker:
                this.rolSelector.value = 1;
                break;
            case MonsterRol.Defender:
                this.rolSelector.value = 2;
                break;
            case MonsterRol.Reserve:
                this.rolSelector.value = 3;
                break;
        }

        UIManager.instance.team.OnMonsterRolChanged += MonsterRolHasChanged;
        this.AddRolSelectorListener();
    }

    private void MonsterRolHasChanged(Monster monster)
    {
        if (monster.name == this.monster.name)
        {
            this.rolSelector.value = (int)monster.rol;
            //switch (monster.rol)
            //{
            //    case MonsterRol.Leader:
            //        this.rolSelector.value = 0;
            //        break;
            //    case MonsterRol.Attacker:
            //        this.rolSelector.value = 1;
            //        break;
            //    case MonsterRol.Defender:
            //        this.rolSelector.value = 2;
            //        break;
            //    default:
            //        this.rolSelector.value = 3;
            //        break;
            //}
        }
    }

    private void RolChanged(Dropdown change)
    {
        switch (change.value)
        {
            case 0:
                UIManager.instance.ChangeTeamLeader(this.monster);

                break;
            case 1:
                UIManager.instance.ChangeTeamAttacker(this.monster);
                break;
            case 2:
                UIManager.instance.ChangeTeamDefender(this.monster);
                break;
        }
    }

    private void AddRolSelectorListener()
    {
        this.rolSelector.onValueChanged.AddListener(delegate
        {
            RolChanged(this.rolSelector);
        });
    }
}
