using UnityEngine;

[CreateAssetMenu(fileName = "PlasmaLostPenalty", menuName = "Challenges/Penalties/PlasmaLostPenalty", order = 3)]
public class PlasmaLostPenalty : Penalty
{
    public int plasmaToBeRemoved;
    public override void ApplyPenalty(IEntity entity)
    {
        (entity as Team).plasma -= this.plasmaToBeRemoved;
    }

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.PlasmaLostPenalty, this.plasmaToBeRemoved);
    }
}
