using System.Collections.Generic;
using UnityEngine;

public class ChallengeContainerUI : MonoBehaviour {

    public List<ChallengeUI> challengesContainers;

    public void SetChallenges()
    {
        for (int i = 0; i < challengesContainers.Count; i++)
        {
            if (i < UIManager.instance.weekChallenges.Count)
            {
                this.challengesContainers[i].SetChallengeLabels(UIManager.instance.weekChallenges[i]);
                this.challengesContainers[i].gameObject.SetActive(true);
            }
            else
            {
                this.challengesContainers[i].gameObject.SetActive(false);
            }
        }
    }
}
