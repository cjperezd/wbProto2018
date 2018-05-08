using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public List<Day> weekDays;
    public Team team;
    public GameObject teamManagementPanel;
    public GameObject mainPanel;
    public GameObject buyMonsterstPanel;
    public GameObject trainMonsterstPanel;
    public DailyEventPanelUI dailyEventPanelUI;
    public ChallengeContainerUI challengeContainerUI;

    public List<Monster> monstersSale;
    public List<WeekChallenge> weekChallenges;
    // TODO: this will change for a progress bar in the future.
    public Text weekDay;

    [HideInInspector]
    public bool hasModifiedTrainningsToday;

    private int dayCounter;
    private int maxNumberOfChallengesAllowed = 3;

    public Day ActualDay
    {
        get
        {
            return this.weekDays[this.dayCounter];
        }
    }

    private void Awake()
    {
        if (UIManager.instance == null)
        {
            UIManager.instance = this;
        }
        this.InitDays();
        this.dayCounter = 0;
        this.weekChallenges = new List<WeekChallenge>();
    }

    // Use this for initialization
    void Start()
    {
        this.SetActualDayEvents();
        this.UpdateDayText();
        this.SetUpWeekChallenges();
    }

    private void SetUpWeekChallenges()
    {
        this.weekChallenges.Clear();
        for (int i = 0; i < 3; i++)
        {
            WeekChallenge challenge = ChallengesManager.instance.GetRandomWeekChallenge();
            this.weekChallenges.Add(challenge);
        }

        this.challengeContainerUI.SetChallenges();
    }

    public void NextDay()
    {
        this.weekDays[this.dayCounter].hasPassedThisWeek = true;
        this.dayCounter++;
        this.team.ResolveMonstersTraining();
        if (this.dayCounter == this.weekDays.Count)
        {
            this.dayCounter = 0;
            this.SetUpWeekChallenges();
        }

        this.SetActualDayEvents();
        this.UpdateDayText();
        this.hasModifiedTrainningsToday = false;
    }

    private void SetActualDayEvents()
    {
        this.weekDays[this.dayCounter].GenerateNewEvents();
        this.dailyEventPanelUI.SetUpDailyEventsUI();
    }

    #region Panels

    public void ShowTeamManagementPanel()
    {
        this.teamManagementPanel.SetActive(true);
        this.mainPanel.SetActive(false);
        TeamManagementPanel manageMonsters = this.teamManagementPanel.GetComponentInChildren<TeamManagementPanel>();

        if (manageMonsters)
        {
            manageMonsters.SetAllMonstersLabels();
        }
    }

    public void HideTeamManagementPanel()
    {
        this.teamManagementPanel.SetActive(false);
        this.mainPanel.SetActive(true);
    }

    public void ShowBuyMonstersPanel()
    {
        this.buyMonsterstPanel.SetActive(true);
        this.mainPanel.SetActive(false);
        BuyMonstersPanel buyingMonsters = this.buyMonsterstPanel.GetComponentInChildren<BuyMonstersPanel>();

        if (buyingMonsters)
        {
            buyingMonsters.SetAllMonstersLabels();
        }
    }

    public void HideBuyMonstersPanel()
    {
        this.buyMonsterstPanel.SetActive(false);
        this.mainPanel.SetActive(true);
    }

    public void ShowTrainMonstersPanel()
    {
        this.trainMonsterstPanel.SetActive(true);
        this.mainPanel.SetActive(false);
        TrainningPanel trainigMonsters = this.trainMonsterstPanel.GetComponentInChildren<TrainningPanel>();

        if (trainigMonsters)
        {
            trainigMonsters.SetAllMonstersLabels();
        }
    }

    public void HideTrainMonstersPanel()
    {
        this.trainMonsterstPanel.SetActive(false);
        this.mainPanel.SetActive(true);

        this.hasModifiedTrainningsToday = true;
    }

    public void ApplyMonstersTrainning()
    {
        // TODO: esto no tendria mas razon de ser, al igual que su respectivo boton.
        this.HideTrainMonstersPanel();
    }

    #endregion

    #region TeamChanges

    public void ChangeTeamLeader(Monster newLeader)
    {
        this.team.ChangeTeamLeader(newLeader);
    }

    public void ChangeTeamAttacker(Monster newAttacker)
    {
        this.team.ChangeTeamAttacker(newAttacker);
    }

    public void ChangeTeamDefender(Monster newDefender)
    {
        this.team.ChangeTeamDefender(newDefender);
    }

    #endregion

    private void InitDays()
    {
        this.weekDays = new List<Day>();
        this.weekDays.Add(new Day(DaysEnum.Monday));
        this.weekDays.Add(new Day(DaysEnum.Tuesday));
        this.weekDays.Add(new Day(DaysEnum.Wednesday));
        this.weekDays.Add(new Day(DaysEnum.Thursday));
        this.weekDays.Add(new Day(DaysEnum.Friday));
        this.weekDays.Add(new Day(DaysEnum.Saturday));
        this.weekDays.Add(new Day(DaysEnum.Sunday));
    }

    private void UpdateDayText()
    {
        this.weekDay.text = string.Format(GlobalVars.WeekDay, this.weekDays[this.dayCounter].dayOfWeek);
    }
}
