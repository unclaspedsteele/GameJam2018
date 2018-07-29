using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour {

    public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.fixedDeltaTime;
        if(timer >= 2f)
        {
            Destroy(gameObject);
        }
	}
}
