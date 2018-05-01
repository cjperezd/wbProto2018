using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DailyEventPanelUI : MonoBehaviour
{

    public GameObject eventData;

    public void SetUpDailyEventsUI()
    {
        //foreach (Day day in UIManager.instance.weekDays)
        //{
        foreach (Transform child in this.transform)
        {
            if (child.name != GlobalVars.Labels)
            {
                Destroy(child.gameObject);
            }
        }
        foreach (DailyEvent dailyEvent in UIManager.instance.ActualDay.events)
        {
            GameObject createdData = Instantiate(eventData, transform.position, transform.rotation);
            createdData.transform.SetParent(this.transform, false);
            DailyEventUI dailyEventScript = createdData.GetComponent<DailyEventUI>();
            if (dailyEventScript != null)
            {
                dailyEventScript.dailyEvent = dailyEvent;
            }
        }
        //}

        this.SetAllDailyEvents();
    }

    public void SetAllDailyEvents()
    {
        List<DailyEventUI> dailyEventsScripts = this.GetComponentsInChildren<DailyEventUI>().ToList();
        foreach (DailyEventUI dailyEvent in dailyEventsScripts)
        {
            dailyEvent.SetLabels();
        }
    }
}
