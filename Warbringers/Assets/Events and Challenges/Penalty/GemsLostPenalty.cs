using UnityEngine;

[CreateAssetMenu(fileName = "GemsLostPenalty", menuName = "Challenges/Penalties/GemsLostPenalty", order = 1)]
public class GemsLostPenalty : Penalty
{
    public int gemsToBeRemoved;
    public override void ApplyPenalty(IEntity entity)
    {
        (entity as Team).gems -= this.gemsToBeRemoved;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.GemsLostPenalty, this.gemsToBeRemoved);
    }
}
