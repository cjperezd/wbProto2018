using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMustTrain : Requirement
{
    public Monster monster;
    public TrainningType trainningType;

    public override bool RequirementFulfilled()
    {
        return monster.actualTrainning == this.trainningType;
    }
}
