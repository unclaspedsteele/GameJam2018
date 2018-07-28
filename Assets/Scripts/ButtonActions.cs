using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

    //Ends the game
    public void exitGame()
    {
        Debug.Log("Player wants to quit the game");
        Application.Quit();
    }

    //Loads the next scene
    public void playGame()
    {
        Debug.Log("Player wants to play the game");
    }

    public void playCredits()
    {
        Debug.Log("Player wants to see the credits");
    }
}
