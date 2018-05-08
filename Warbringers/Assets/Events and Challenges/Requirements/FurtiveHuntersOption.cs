using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurtiveHuntersOption", menuName = "Challenges/Requirement/FurtiveHuntersOption", order = 1)]
public class FurtiveHuntersOption : Requirement
{
    public Team team;
    public int gemsCost;

    public override bool RequirementFulfilled()
    {
        return team.gems >= this.gemsCost;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.FurtiveHuntersOption, this.gemsCost);
    }

    public override List<Monster> GetMonstersFullfillingRequirement()
    {
        // este no necesita, a priori, ninguna entidad.
        return new List<Monster>();
    }
}
