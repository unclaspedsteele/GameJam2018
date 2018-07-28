using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key1Detector : MonoBehaviour {

    public LayerMask boop;

    public globalVars globalVars;

    public GameObject curKey;

    public bool hasHit;
    public bool j;
    public bool k;
    public bool l;
    public bool sc;

    public float stupid;
    public float maxTime;

    public string tName;
    public KeyCode letter;

    // Use this for initialization
	void Start () {
        globalVars = GameObject.Find("globals").GetComponent<globalVars>();
        if (j)
        {
            tName = "jAttack";
            letter = KeyCode.J;
        }
        else if (k)
        {
            tName = "kAttack";
            letter = KeyCode.K;
        }
        else if (l)
        {
            tName = "lAttack";
            letter = KeyCode.L;
        }
        else if (sc)
        {
            tName = "scAttack";
            letter = KeyCode.Semicolon;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        stupid += Time.fixedDeltaTime;
        if(stupid > maxTime)
        {
            hasHit = false;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 1f))
        {
            if (hit.collider.gameObject.transform.tag == tName)
            {
                stupid = 0;
                hasHit = true;
                curKey = hit.collider.gameObject;
            }
        }


        if (hasHit == true)
        {
            if (Input.GetKeyDown(letter))
            {
                globalVars.score += 1;
                Destroy(curKey);
                hasHit = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(letter))
            {
                globalVars.health -= 1;
            }
        }

    }

}
