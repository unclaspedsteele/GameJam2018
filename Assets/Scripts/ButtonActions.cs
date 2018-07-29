using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject SongSelectionPanel;
    public Dropdown songDropBox;

	// Use this for initialization
	void Start () {
        MainMenuPanel = GameObject.Find("Main Menu Panel");
        SongSelectionPanel = GameObject.Find("Song Selection");
        SongSelectionPanel.SetActive(false);
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
        Debug.Log("Player wants to select a song!");
        MainMenuPanel.SetActive(false);
        SongSelectionPanel.SetActive(true);
        

    }

    public void playCredits()
    {
        Debug.Log("Player wants to see the credits");
    }

    public void startLevel()
    {
        Debug.Log("Begin playing the level");
        
    }
}
