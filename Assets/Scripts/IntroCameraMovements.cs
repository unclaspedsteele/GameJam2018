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
    private float timer;
    private bool stage1;
    private bool stage2;
    private bool stage3;

    
    // Use this for initialization
    void Start () {
        stage1 = false;
        stage2 = false;
        stage3 = false;       
        timer = 0;
        TheCamera = GameObject.Find("Main Camera");
        cameraMovement = TheCamera.GetComponent<CameraMovement>();	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(start == true)
        {          
            if (timer == 0)
                stageOne();
            
            //Start the timer
            timer += Time.deltaTime;

            if(timer > 2.5)
            {
                stageTwo();
            }

            if(timer > 5)
            {
                stageThree();
            } 
            
            if(timer > 8)
            {              
                resetInto();               
            }
        }
         		
	}

    void stageOne()
    {
        if (stage1 == false)
        {
            stage1 = true;
            cameraMovement.lookAtLeft = true;                    
        }
        
    }

    void stageTwo()
    {
        if (stage2 == false)
        {
            stage2 = true;
            cameraMovement.lookAtRight = true;
        }      
    }

    void stageThree(){
        if( stage3 == false)
        {
            stage3 = true;
            cameraMovement.resetCamera = true;
        }   
    }

    void resetInto()
    {
        start = false;
        timer = 0f;
        stage1 = false;
        stage2 = false;
        stage3 = false;
    }
}
