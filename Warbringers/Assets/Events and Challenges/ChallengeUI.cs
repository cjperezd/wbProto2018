using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeUI : MonoBehaviour
{
    public Text requirements;
    public Text rewards;
    public Text penalties;
    public Dropdown dropDown;

    private Challenge challenge;
    public void SetChallengeLabels(Challenge challenge)
    {
        this.challenge = challenge;
        string value = "";
        foreach (Requirement requirement in challenge.requirements)
        {
            value += requirement.description + ";";
        }

        this.requirements.text = string.Format(GlobalVars.Requirements, value);

        value = "";
        foreach (Reward reward in challenge.rewards)
        {
            value += reward.description + ";";
        }

        this.rewards.text = string.Format(GlobalVars.Rewards, value);

        value = "";
        foreach (Penalty penalty in challenge.penalties)
        {
            value += penalty.description + ";";
        }

        this.penalties.text = string.Format(GlobalVars.Penalties, value);
    }

    public void UpdateSelectableOptions()
    {
        this.dropDown.ClearOptions();
        List<string> dropDownOptions = new List<string>();
        foreach (Monster monster in this.GetFirstRequirement().GetMonstersFullfillingRequirement())
        {
            dropDownOptions.Add(monster.name);
        }

        this.dropDown.AddOptions(dropDownOptions);
    }

    public void ResolveChallenge()
    {
        this.SetSelectedMonster();
        this.challenge.VerifyRequirements();
    }

    private void Start()
    {
        // TODO: no seria necesario creo...
        this.dropDown.onValueChanged.AddListener(delegate
        {
            MonsterChanged(this.dropDown);
        });
    }

    private void MonsterChanged(Dropdown change)
    {
        this.SetSelectedMonster();
    }

    private void Update()
    {
        if (this.GetFirstRequirement().RequirementFulfilled())
        {
            this.UpdateSelectableOptions();
        }        
    }

    // TODO: esto esta mal pero por ahora estamos usando un solo requirement...
    private Requirement GetFirstRequirement()
    {
        return this.challenge.requirements[0];
    }

    private void SetSelectedMonster()
    {
        Monster selectedMonster = this.GetFirstRequirement().GetMonstersFullfillingRequirement()[this.dropDown.value];
        // TODO: esto esta permitiendo, por ahora, un solo monstruo por evento... ojo. 
        this.challenge.entitiesInChallenge.Clear();
        this.challenge.entitiesInChallenge.Add(selectedMonster);
    }
}
