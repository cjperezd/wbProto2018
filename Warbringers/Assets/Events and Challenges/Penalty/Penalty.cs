using UnityEngine;

public abstract class Penalty : ScriptableObject
{
    public string description
    {
        get
        {
            return this.DescriptionGetter();
        }
    }

    public abstract void ApplyPenalty(IEntity entity);
    public abstract string DescriptionGetter();
}
