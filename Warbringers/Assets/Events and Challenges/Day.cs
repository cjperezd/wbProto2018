using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DaysEnum
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public class Day
{
    public DaysEnum dayOfWeek;
    public List<DailyEvent> events;
    public bool hasPassedThisWeek;

    public Day(DaysEnum day)
    {
        this.dayOfWeek = day;
        this.hasPassedThisWeek = false;
        this.events = new List<DailyEvent>();
        // this.GenerateNewEvents();
    }

    public void GenerateNewEvents()
    {
        this.events.Clear();
        // Random.Range(1, 3) we will get results from 1 to 2
        // TODO: para probar, por ahora es uno solo x dia
        //DailyEvent dailyEvent = ChallengesManager.instance.dailyEvents[(int)this.dayOfWeek];
        //dailyEvent.startingDay = this.dayOfWeek;
        //dailyEvent.name = this.dayOfWeek.ToString() + (int)this.dayOfWeek;
        //this.events.Add(dailyEvent);


        // TODO: despues, la logica seria con esto:
        int numberOfEvents = UnityEngine.Random.Range(1, 4);
        for (int i = 1; i <= numberOfEvents; i++)
        {
            //DailyEvent dailyEvent = ChallengesManager.instance.dailyEvents[(int)this.dayOfWeek];
            //dailyEvent.startingDay = this.dayOfWeek;
            //dailyEvent.name = this.dayOfWeek.ToString() + (int)this.dayOfWeek;

            this.events.Add(ChallengesManager.instance.GetRandomDailyEvent(this.dayOfWeek));
        }
    }
}