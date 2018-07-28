using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DropDownSongSelector : MonoBehaviour {

    public Dropdown dropDownSongs;
    public GameObject Skrillex;
    private int dropDownIndex;

	// Use this for initialization
	void Start () {
        dropDownSongs = GetComponent<Dropdown>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //0 is nothing
    //1 is Skrillex
    public void activateSong()
    {
        dropDownIndex = dropDownSongs.value;
        if (dropDownIndex == 1)
            Skrillex.SetActive(true);
        
    }
}
