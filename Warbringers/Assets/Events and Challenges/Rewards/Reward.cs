using UnityEngine;

public abstract class Reward : ScriptableObject
{
    public string name;
    public string description
    {
        get
        {
            return this.DescriptionGetter();
        }
    }

    public abstract void GiveReward(IEntity entity);
    public abstract string DescriptionGetter();

    // TODO: otros requerimientos son: 
    // 3) combate clandestino.
}
