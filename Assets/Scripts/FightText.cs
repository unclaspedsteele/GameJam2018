using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightText : MonoBehaviour {

    public GameObject BossName;
    public GameObject Fight;

    float timer;
	// Use this for initialization
	public void Setup () {
        BossName = transform.Find("BossName").gameObject;
        Fight = transform.Find("FightText").gameObject;

        BossName.GetComponent<Image>().fillAmount = 0;
        BossName.SetActive(true);
        Fight.GetComponent<Image>().fillAmount = 0;
        Fight.SetActive(false);
	}

    public IEnumerator StartFight() { //Takes 3.33 seconds

        for (float i = 0; i < 210; i++) {
            if (i < 70) {
                BossName.SetActive(true);
                Fight.SetActive(false);
                BossName.GetComponent<Image>().fillAmount = i / 70;
            }
            else if (i >= 100 && i < 170)
            {
                BossName.SetActive(false);
                Fight.SetActive(true);
                Fight.GetComponent<Image>().fillAmount = (i - 90) / 70;
            }
            yield return new WaitForSeconds(1 / 60);
        }
        Fight.SetActive(false);
    }
}
