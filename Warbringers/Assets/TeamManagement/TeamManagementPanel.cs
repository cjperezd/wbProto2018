using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeamManagementPanel : BaseMonsterPanel {

    public GameObject teamManagementData;

    public void Start()
    {
        foreach (Monster monster in UIManager.instance.team.allTeamMonsters)
        {
            GameObject createdData = Instantiate(teamManagementData, transform.position, transform.rotation);
            createdData.transform.SetParent(this.transform, false);
            AdminMonster adminMonsterScript = createdData.GetComponent<AdminMonster>();
            if (adminMonsterScript != null)
            {
                adminMonsterScript.monster = monster;
            }
        }

        this.SetAllMonstersLabels();
    }

    public override void SetAllMonstersLabels()
    {
        List<AdminMonster> monsterScripts = this.GetComponentsInChildren<AdminMonster>().ToList();
        foreach (AdminMonster monster in monsterScripts)
        {
            monster.SetMonsterLabels();
        }
    }
}
