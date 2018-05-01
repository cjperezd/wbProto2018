using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurtiveHuntersOption : Requirement
{
    public Team team;
    public int gemsCost;

    public override bool RequirementFulfilled()
    {
        return team.gems >= this.gemsCost;
    }
}
