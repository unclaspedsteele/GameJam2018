using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key1Detector : MonoBehaviour {

    public LayerMask boop;

    public globalVars globals;

    public GameObject curKey;

    public bool hasHit;
    public bool j;
    public bool k;
    public bool l;
    public bool sc;
    public bool correctHit;
    public bool defKey;

    public float stupid;
    public float maxTime;

    public string tName;

    public KeyCode letter;

    // Use this for initialization
	void Start () {
        globals = GameObject.Find("globals").GetComponent<globalVars>();
        if (j)
        {
            tName = "jAttack";
            if (defKey == false)
                letter = KeyCode.J;
            else
                letter = KeyCode.A;
        }
        else if (k)
        {
            tName = "kAttack";
            if (defKey == false)
                letter = KeyCode.K;
            else
                letter = KeyCode.S;
        }
        else if (l)
        {
            tName = "lAttack";
            if (defKey == false)
                letter = KeyCode.L;
            else
                letter = KeyCode.D;
        }
        else if (sc)
        {
            tName = "scAttack";
            if (defKey == false)
                letter = KeyCode.Semicolon;
            else
                letter = KeyCode.F;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (stupid < maxTime)
        {
            stupid += Time.fixedDeltaTime;
        }
        if(stupid > maxTime && hasHit == true)
        {
            hasHit = false;
            correctHit = false;
            if(correctHit == false)
            {
                globals.sideSwitchCounter += 1;
                correctHit = true;
            }
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
            if (Input.GetKeyDown(letter) && globals.onOffense == true)
            {
                globals.score += 2;
                globals.enemyHealth -= 1;
                Destroy(curKey);
                correctHit = true;
                hasHit = false;
            }
            else if (Input.GetKeyDown(letter) && globals.onOffense == false)
            {
                globals.score += 1;
                globals.switchBackCounter += 1;
                Destroy(curKey);
                correctHit = true;
                hasHit = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(letter) && globals.onOffense == true)
            {
                globals.sideSwitchCounter += 1;
            }
            else if (Input.GetKeyDown(letter) && globals.onOffense == true)
            {
                globals.health -= 1;
            }
        }

    }

}
