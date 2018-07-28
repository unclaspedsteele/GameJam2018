using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //Drag in these objects
    public GameObject leftTraget;
    public GameObject rightTarget;
    public GameObject TheCamera;

    //The number of frames to do the movements
    public float framesToMove;
    private int moveCount;
    
    //Triggering these action is a matter of changing the value of these bools (it auto switches off)
    public bool lookAtLeft;
    public bool lookAtRight;
    public bool resetCamera;

    //The speed of zooming in or out
    public float smoothSpeed;
    public float zoomOrtho;
    public float normalOrtho;

    //The camer's orthographic size
    private float targetOrtho;
    

    // Use this for initialization
    void Start () {
        lookAtLeft = false;
        lookAtRight = false;
        resetCamera = false;
        targetOrtho = Camera.main.orthographicSize;

        //The zoom speed
        smoothSpeed = 2.5f;

        //Zoom amount
        zoomOrtho = 3f;

        //No zoom
        normalOrtho = 5f;
}


    void Update()
    {
        if (leftTraget != null && lookAtLeft && moveCount<= framesToMove)
        {
            lookAtRight = false;
            Vector3 newCameraPosition = new Vector3(leftTraget.transform.position.x, leftTraget.transform.position.y, -5);
            iTween.MoveTo(TheCamera,newCameraPosition, 2.5f);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, zoomOrtho, smoothSpeed * Time.deltaTime);
            moveCount++;
        }

        if(rightTarget != null && lookAtRight && moveCount <= framesToMove)
        {
            lookAtLeft = false;
            Vector3 newCameraPosition = new Vector3(rightTarget.transform.position.x, rightTarget.transform.position.y, -5);
            iTween.MoveTo(TheCamera, newCameraPosition, 2.5f);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, zoomOrtho, smoothSpeed * Time.deltaTime);
            moveCount++;
        }

        if(resetCamera && moveCount <= framesToMove)
        {
            lookAtRight = false;
            lookAtLeft = false;
            Vector3 newCameraPosition = new Vector3(0,0, -5);
            iTween.MoveTo(TheCamera, newCameraPosition, 2.5f);
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, normalOrtho, smoothSpeed * Time.deltaTime);
            moveCount++;
        }

        //Resets the frame counter
        if(moveCount >= framesToMove)
        {
            lookAtLeft = false;
            lookAtRight = false;
            resetCamera = false;
            moveCount = 0;
        }


    }
}
