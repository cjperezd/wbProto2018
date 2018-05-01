using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Challenge", menuName = "Challenges/WeekChallenge", order = 2)]
public class WeekChallenge : Challenge {

    public int daysDuration;

    public override bool ChallengeHasEnded(DaysEnum actualDay)
    {
        return (int)this.startingDay + daysDuration > (int)actualDay;
    }
}
