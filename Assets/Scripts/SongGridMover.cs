using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongGridMover : MonoBehaviour {

    public GameObject songGrid;
    public Vector3 songGridPosition;

	// Use this for initialization
	void Start () {
        songGridPosition = songGrid.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        songGrid.transform.position = new Vector3(songGrid.transform.position.x, songGrid.transform.position.y - .1f, songGrid.transform.position.z);
	}
}
