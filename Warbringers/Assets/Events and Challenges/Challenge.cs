using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Challenge : ScriptableObject
{
    public DaysEnum startingDay;

    public string description;
    public List<Requirement> requirements = new List<Requirement>();
    public List<Reward> rewards = new List<Reward>();
    public List<Penalty> penalties = new List<Penalty>();
    public List<IEntity> entitiesInChallenge = new List<IEntity>();

    // TODO: esto se cambia con las tareas a realizar ahora.
    public void VerifyRequirements()
    {
        bool passedAllRequirements = true;
        foreach (Requirement requirement in this.requirements)
        {
            if (!requirement.RequirementFulfilled())
            {
                passedAllRequirements = false;
                break;
            }
        }

        // TODO: esto se cambia con las tareas a realizar ahora.
        if (passedAllRequirements)
        {
            this.GiveRewards();
        }
        else
        {
            this.ApplyNegativeEffects();
        }
    }

    public string GetPenaltiesText()
    {
        string penaltiesText = "";
        foreach (Penalty penalty in this.penalties)
        {
            penaltiesText += penalty.description + ';';
        }

        return penaltiesText;
    }

    public string GetRewardsText()
    {
        string rewardText = "";
        foreach (Reward reward in this.rewards)
        {
            rewardText += reward.description + ';';
        }

        return rewardText;
    }

    private void ApplyNegativeEffects()
    {
        foreach (Penalty penalty in this.penalties)
        {
            foreach (IEntity entity in this.entitiesInChallenge)
            {
                penalty.ApplyPenalty(entity);
            }
        }
    }

    private void GiveRewards()
    {
        foreach (Reward reward in this.rewards)
        {
            foreach (IEntity entity in this.entitiesInChallenge)
            {
                reward.GiveReward(entity);
            }
        }
    }

    // TODO: creo que esto no iria mas.
    public abstract bool ChallengeHasEnded(DaysEnum actualDay);
}
