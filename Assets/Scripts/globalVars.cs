using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVars : MonoBehaviour {

    public int score;
    public int health;
    public int enemyHealth;
    public int sideSwitchCounter; //this will keep track of the number of misses the player has had in the last however many seconds
    public int sideSwitchCounterMax; //set this to the max number of misses before the player is switched to defence
    public int switchBackCounter;
    public int switchBackCounterMax; //set this to the number of notes you want the player to hit in order to go back on offense

    public float switchCountTimer; 
    public float switchCountTimerMax; //Set this to the amount of time you want to give the player to miss notes before a note miss is replaced
    public float timeToSwitch;

    public bool onOffense;
    public bool inTransition; //are we transitioning from offense to defense or visa versa? If so, this is true.

    // Use this for initialization
	void Start () {
        health = 100;
        onOffense = true;
        inTransition = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (inTransition == true)
        {
            timeToSwitch -= Time.fixedDeltaTime;
        }
        else
        {
            timeToSwitch = .7f;
        }

        if(timeToSwitch <= 0)
        {
            inTransition = false;
        }

        switchCountTimer -= Time.fixedDeltaTime;

        if (switchCountTimer <= 0)
        {
            sideSwitchCounter -= 1;
            switchCountTimer = switchCountTimerMax; 
        }

        if (sideSwitchCounter > sideSwitchCounterMax)
        {
            onOffense = false;
            inTransition = true;
            sideSwitchCounter = 0;
        }

        if(switchBackCounter > switchBackCounterMax)
        {
            onOffense = true;
            inTransition = true;
            switchBackCounter = 0;
        }

	}
}
