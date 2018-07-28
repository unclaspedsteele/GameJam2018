using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalVars : MonoBehaviour {

    public int score;
    public int health;
    public int enemyHealth;
    public int sideSwitchCounter;

    public bool onOffense;

    // Use this for initialization
	void Start () {
        health = 100;
        onOffense = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
