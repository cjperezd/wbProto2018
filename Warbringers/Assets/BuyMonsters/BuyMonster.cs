using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMonster : MonsterDataForPanel
{
    public void BuyMonsterForTeam()
    {
        UIManager.instance.team.BuyMonster(this.monster);
        // TODO: esto es solo para testear, no deberia romperse el panel asi nomas me parece
        Destroy(this.gameObject);
    }

    public override void SetMonsterLabels()
    {
        this.levelLabel.text = this.monster.level.ToString();
        this.attackPoints.text = this.monster.attackPoints.ToString();
        this.defensePoints.text = this.monster.defensePoints.ToString();
        this.totalLifePoints.text = this.monster.totalLifePoints.ToString();
        this.actualLifePoints.text = this.monster.actualLifePoints.ToString();
        this.mantainCost.text = this.monster.mantainCost.ToString();
        this.plasmaForSacrifice.text = this.monster.plasmaForSacrifice.ToString();
        this.experience.text = this.monster.experience.ToString();
        this.teamRol.text = this.monster.TeamRol;
    }
}
