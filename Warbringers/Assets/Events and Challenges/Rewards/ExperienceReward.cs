using UnityEngine;

[CreateAssetMenu(fileName = "ExperienceReward", menuName = "Challenges/Rewars/ExperienceReward", order = 1)]
public class ExperienceReward : Reward
{
    public int experience;
    public Monster monster;

    public override string DescriptionGetter()
    {
        return string.Format(GlobalVars.ExperienceReward, this.experience);
    }

    public override void GiveReward(IEntity entity)
    {
        (entity as Monster).GainExperience(this.experience);
    }
}
