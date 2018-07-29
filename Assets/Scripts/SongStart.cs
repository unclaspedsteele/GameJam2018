using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongStart : MonoBehaviour {

    public GameObject Song;
    float timer;
    FightText ft;
    songMover sm;

	// Use this for initialization
	void Start () {
        timer = 0;
        ft = GameObject.Find("Canvas").GetComponent<FightText>();
        Song.SetActive(false);
        sm = Song.GetComponent<songMover>();
        sm.timeTillMove = 2;
        sm.timeTillStart = sm.timeTillMove + 3;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if (timer >= 5.9 && timer <= 6.1) {
            ft.Setup();
            ft.StartCoroutine("StartFight");
        }

        if (timer >= 9.6) {
            Song.SetActive(true);
        }

	}
}
