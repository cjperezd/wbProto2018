using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrainningPanel : BaseMonsterPanel {

    public GameObject monsterData;
	// Use this for initialization
	void Start ()
    {
        foreach (Monster monster in UIManager.instance.team.allTeamMonsters)
        {
            GameObject createdData = Instantiate(monsterData, transform.position, transform.rotation);
            createdData.transform.SetParent(this.transform, false);
            TrainMonster trainMonsterScript = createdData.GetComponent<TrainMonster>();
            if (trainMonsterScript != null)
            {
                trainMonsterScript.monster = monster;
            }
        }

        this.SetAllMonstersLabels();
    }

    public override void SetAllMonstersLabels()
    {
        List<TrainMonster> monsterScripts = this.GetComponentsInChildren<TrainMonster>().ToList();
        foreach (TrainMonster monster in monsterScripts)
        {
            monster.SetMonsterLabels();
        }
    }
}
