using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuyMonstersPanel : BaseMonsterPanel {

    public GameObject buyMonsterData;

    void Start()
    {
        foreach (Monster monster in UIManager.instance.monstersSale)
        {
            GameObject createdData = Instantiate(buyMonsterData, transform.position, transform.rotation);
            createdData.transform.SetParent(this.transform, false);
            BuyMonster buyMonsterScript = createdData.GetComponent<BuyMonster>();
            if (buyMonsterScript != null)
            {
                buyMonsterScript.monster = monster;
            }
        }

        this.SetAllMonstersLabels();
    }

    public override void SetAllMonstersLabels()
    {
        List<BuyMonster> monsterScripts = this.GetComponentsInChildren<BuyMonster>().ToList();
        foreach (BuyMonster monster in monsterScripts)
        {
            monster.SetMonsterLabels();
        }
    }
}
