using UnityEngine;

[CreateAssetMenu(fileName = "PlasmaReward", menuName = "Challenges/Rewars/PlasmaReward", order = 4)]
public class PlasmaReward : Reward
{
    public int plasma;

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.GemsReward, this.plasma);
    }

    public override void GiveReward(IEntity entity)
    {
        (entity as Team).plasma += this.plasma;
    }
}
