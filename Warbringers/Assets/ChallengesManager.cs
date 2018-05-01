using System.Collections.Generic;
using UnityEngine;

public class ChallengesManager : MonoBehaviour
{
    public static ChallengesManager instance;
    public List<DailyEvent> dailyEvents;
    public List<WeekChallenge> challenges;

    public DailyEvent GetRandomDailyEvent(DaysEnum startingDay)
    {
        int position = Random.Range(0, this.dailyEvents.Count);
        DailyEvent dailyEvent = this.dailyEvents[position];
        dailyEvent.startingDay = startingDay;
        return dailyEvent;
    }

    public WeekChallenge GetRandomWeekChallenge()
    {
        int position = Random.Range(0, this.challenges.Count);
        return this.challenges[position];
    }

    private void Awake()
    {
        if (ChallengesManager.instance == null)
        {
            ChallengesManager.instance = this;
        }
    }
}
