using UnityEngine;
using UnityEngine.UI;

public class DailyEventUI : MonoBehaviour {

    public DailyEvent dailyEvent;

    public Text day;
    public Text description;
    public Text penaltyText;
    public Text prizeText;

    // Use this for initialization
    void Start () {
        this.SetLabels();
	}

    #region Button Actions

    public void AcceptEvent()
    {
        // TODO: ver si el evento puede aceptarse o no, o si es obligatorio
    }

    public void DismisseEvent()
    {
        // TODO: ver si el evento puede aceptarse o no, o si es obligatorio
    }

    #endregion

    public void SetLabels()
    {
        this.day.text = this.dailyEvent.startingDay.ToString();
        this.description.text = this.dailyEvent.description;
        this.penaltyText.text = this.dailyEvent.GetPenaltiesText();
        this.prizeText.text = this.dailyEvent.GetRewardsText();
    }
}
