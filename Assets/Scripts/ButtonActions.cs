using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject SongSelectionPanel;
    public Dropdown songDropBox;
    private int dropDownIndex;

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
        SceneManager.LoadScene("Credits");
    }

    public void startLevel()
    {
        Debug.Log("Begin playing the level");
        dropDownIndex = songDropBox.value;

        if(dropDownIndex == 0)
        {
            //Incorrect choice, do nothing!
        }
        else if(dropDownIndex == 1)
        {
            //Go to level1
            SceneManager.LoadScene("Story");
        }
        else if(dropDownIndex == 2)
        {
            //Go to level2
            SceneManager.LoadScene("Level1");
        }
        else if(dropDownIndex == 3)
        {
            //Go to level3
            SceneManager.LoadScene("Spice");
        }
        else if(dropDownIndex == 4)
        {
            //GO to level4
            SceneManager.LoadScene("DragonForce");
        }
        
    }
}
