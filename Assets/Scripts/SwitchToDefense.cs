using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToDefense : MonoBehaviour {

    public globalVars globals;

    public bool once;

    //public GameObject[] J;
    //public GameObject[] K;
    //public GameObject[] L;
    //public GameObject[] SC;

    public Material j;
    public Material k;
    public Material l;
    public Material sc;

    public Texture jt;
    public Texture kt;
    public Texture lt;
    public Texture sct;

    public Texture at;
    public Texture st;
    public Texture dt;
    public Texture ft;

    // Use this for initialization
    void Start () {
        once = true;
        globals = GameObject.Find("Globals").GetComponent<globalVars>();
        //J = GameObject.FindGameObjectsWithTag("jAttack");
        //K = GameObject.FindGameObjectsWithTag("kAttack");
        //L = GameObject.FindGameObjectsWithTag("lAttack");
        //SC = GameObject.FindGameObjectsWithTag("scAttack");

    }

    // Update is called once per frame
    void Update () {
        if (!globals.onOffense)
        {
            j.mainTexture = at;
            k.mainTexture = st;
            l.mainTexture = dt;
            sc.mainTexture = ft;
            once = false;
        }
        else
        {
                once = true;
                j.mainTexture = jt;
                k.mainTexture = kt;
                l.mainTexture = lt;
                sc.mainTexture = sct;
        }
	}
}
