using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCameraMovements : MonoBehaviour {

    public CameraMovement cameraMovement;
    public GameObject TheCamera;

    //The amount of time between each stage
    public float breakTime;


    //When true, the intro will start
    public bool start;

    public float timer;

    private bool stage1;
    private bool stage2;
    private bool stage3;

	// Use this for initialization
	void Start () {
        stage1 = false;
        stage2 = false;
        stage3 = false;
        TheCamera = GameObject.Find("Main Camera");
        cameraMovement = TheCamera.GetComponent<CameraMovement>();	

	}
	
	// Update is called once per frame
	void FixedUpdate () {


        
        

		
	}

    void stageOne(){
        cameraMovement.lookAtLeft = true;
    }

    void stageTwo(){
        cameraMovement.lookAtRight = true;
    }

    void stageThree(){
        cameraMovement.lookAtRight = true;
    }
}
