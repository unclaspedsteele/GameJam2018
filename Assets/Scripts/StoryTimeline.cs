using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryTimeline : MonoBehaviour {

    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject spaceBar;

    public S NextScene;

    int storyCounter;

	// Use this for initialization
	void Start () {
        Story2.SetActive(false);
        Story3.SetActive(false);
        spaceBar.SetActive(false);
        storyCounter = 1;
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 60; i++) {}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            storyCounter++;
            if (storyCounter == 2)
            {
                Story1.SetActive(false);
                Story2.SetActive(true);
            }
            else if (storyCounter == 3)
            {
                Story2.SetActive(false);
                Story3.SetActive(true);
            }
            else if (storyCounter > 3)
            {
                
            }


        }
    }
}
