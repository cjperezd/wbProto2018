using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterMustRest", menuName = "Challenges/Requirement/MonsterMustRest", order = 3)]
public class MonsterMustRest : Requirement
{
    public Monster monster;

    public override bool RequirementFulfilled()
    {
        return this.GetMonstersFullfillingRequirement().Count > 0 && UIManager.instance.hasModifiedTrainningsToday;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.MonsterMustRest);
    }

    public override List<Monster> GetMonstersFullfillingRequirement()
    {
        return UIManager.instance.team.allTeamMonsters.Where(x => x.MonsterHasRestedToday()).ToList();
    }
}
