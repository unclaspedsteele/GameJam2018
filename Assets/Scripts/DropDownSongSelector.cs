using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DropDownSongSelector : MonoBehaviour {

    public Dropdown dropDownSongs;
    public GameObject SkrillexScary;
    public GameObject SpiceSong;
    public GameObject DragonForce;
    public GameObject HBFS;
    private int dropDownIndex;

    private Vector3 originalSkrillexScaryPos;
    private Vector3 originalSpicePos;
    private Vector3 originalDragonForcePos;
    private Vector3 originalHBFS;

	// Use this for initialization
	void Start () {
        originalSkrillexScaryPos = new Vector3(SkrillexScary.transform.position.x, 738.2f, SkrillexScary.transform.position.z);
        originalSpicePos = new Vector3(SpiceSong.transform.position.x, 359.47f, SpiceSong.transform.position.z);
        originalDragonForcePos = new Vector3(DragonForce.transform.position.x, 2667.2f, DragonForce.transform.position.z);
        originalHBFS = new Vector3(HBFS.transform.position.x, 657.17f, HBFS.transform.position.z);
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
        {
            SkrillexScary.SetActive(true);
            SpiceSong.SetActive(false);
            DragonForce.SetActive(false);
            HBFS.SetActive(false);
            SkrillexScary.transform.position = originalSkrillexScaryPos;
        }         
        else if (dropDownIndex == 2)
        {
            SpiceSong.SetActive(true);
            SkrillexScary.SetActive(false);
            DragonForce.SetActive(false);
            HBFS.SetActive(false);
            SpiceSong.transform.position = originalSpicePos;
        }
        else if (dropDownIndex == 3)
        {
            SpiceSong.SetActive(false);
            SkrillexScary.SetActive(false);
            DragonForce.SetActive(true);
            HBFS.SetActive(false);
            DragonForce.transform.position = originalDragonForcePos;
        }
        else if(dropDownIndex == 4)
        {
            SpiceSong.SetActive(false);
            SkrillexScary.SetActive(false);
            DragonForce.SetActive(false);
            HBFS.SetActive(true);
            HBFS.transform.position = originalHBFS;
        }
           

        
    }
}
