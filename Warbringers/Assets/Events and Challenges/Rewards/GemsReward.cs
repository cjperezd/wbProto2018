using UnityEngine;

[CreateAssetMenu(fileName = "GemsReward", menuName = "Challenges/Rewars/GemsReward", order = 3)]
public class GemsReward : Reward
{
    public int gems;

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.GemsReward, this.gems);
    }

    public override void GiveReward(IEntity entity)
    {
        (entity as Team).gems += this.gems;
    }
}
