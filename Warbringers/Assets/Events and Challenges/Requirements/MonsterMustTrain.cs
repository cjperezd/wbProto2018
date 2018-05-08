using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterMustTrain", menuName = "Challenges/Requirement/MonsterMustTrain", order = 4)]
public class MonsterMustTrain : Requirement
{
    public Monster monster;
    public TrainningType trainningType;

    public override bool RequirementFulfilled()
    {
        return this.GetMonstersFullfillingRequirement().Count > 0 && UIManager.instance.hasModifiedTrainningsToday;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.MonsterMustTrain, this.trainningType.ToString());
    }

    public override List<Monster> GetMonstersFullfillingRequirement()
    {
        return UIManager.instance.team.allTeamMonsters.Where(x => x.actualTrainning == this.trainningType).ToList(); 
    }
}
