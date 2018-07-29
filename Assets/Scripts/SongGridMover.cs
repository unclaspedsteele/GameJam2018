using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongGridMover : MonoBehaviour {

    public Vector3 songGridPosition;

	// Use this for initialization
	void Start () {
        //Sets the initial position of the grid
        songGridPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
	}
}
