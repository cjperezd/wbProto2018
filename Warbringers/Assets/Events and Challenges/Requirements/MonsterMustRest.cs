using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMustRest : Requirement
{
    public Monster monster;

    public override bool RequirementFulfilled()
    {
        return monster.MonsterHasRestedToday();
    }
}
