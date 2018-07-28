using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RealWorldTime : MonoBehaviour {

    public GameObject timeText;
    public Text timestr;

	// Use this for initialization
	void Start () {
        timestr = timeText.GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
        timestr.text = System.DateTime.Now.ToLongTimeString();
		
	}
}
