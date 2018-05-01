using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterDataForPanel : MonoBehaviour {

    public Monster monster;

    public Text levelLabel;
    public Text attackPoints;
    public Text defensePoints;
    public Text totalLifePoints;
    public Text actualLifePoints;
    public Text mantainCost;
    public Text plasmaForSacrifice;
    public Text experience;
    public Text teamRol;
    public Text monsterName;

    public abstract void SetMonsterLabels();
}
