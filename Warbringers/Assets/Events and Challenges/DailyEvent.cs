using UnityEngine;

[CreateAssetMenu(fileName = "DailyEvent", menuName = "Challenges/DailyEvent", order = 1)]
public class DailyEvent : Challenge
{
    public override bool ChallengeHasEnded(DaysEnum actualDay)
    {
        return ((int)this.startingDay + 1 == (int)actualDay); 
    }
}
