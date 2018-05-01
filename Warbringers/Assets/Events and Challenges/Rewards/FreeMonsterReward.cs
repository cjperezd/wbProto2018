using UnityEngine;

[CreateAssetMenu(fileName = "FreeMonsterReward", menuName = "Challenges/Rewars/FreeMonsterReward", order = 2)]
public class FreeMonsterReward : Reward
{
    public Monster freeMonster;

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.FreeMonsterReward, this.freeMonster.name);
    }

    public override void GiveReward(IEntity entity)
    {
        (entity as Team).allTeamMonsters.Add(this.freeMonster);
    }
}
