using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MonsterForExperiments", menuName = "Challenges/Requirement/MonsterForExperiments", order = 2)]
public class MonsterForExperiments : Requirement
{
    public override bool RequirementFulfilled()
    {
        // TODO: ver que deberia hacer esto.
        return true;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.MonsterForExperiments);
    }

    public override List<Monster> GetMonstersFullfillingRequirement()
    {
        return UIManager.instance.team.allTeamMonsters;
    }
}
