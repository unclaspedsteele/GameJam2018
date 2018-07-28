using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    //Drag in these objects
    public GameObject leftTraget;
    public GameObject rightTarget;
    public GameObject TheCamera;

    //Drag in the music notes
    public GameObject musicNotes;
    public globalVars globals;

    //The number of frames to do the movements
    public float framesToMove;
    public int moveCount;
    
    //Triggering these action is a matter of changing the value of these bools (it auto switches off)
    public bool lookAtLeft;
    public bool lookAtRight;
    public bool resetCamera;

    //The speed of zooming in or out
    public float zoomSpeed;
    public float zoomOrtho;
    public float moveSpeed;
    public float normalOrtho;

    //The camer's orthographic size
    private float targetOrtho;

    //Locatioan of the music notes
    public Vector3 startMusicNotesPosition;
    public Vector3 musicNotesNewPosition;
    

    // Use this for initialization
    void Start () {
        lookAtLeft = false;
        lookAtRight = false;
        resetCamera = false;
        targetOrtho = TheCamera.GetComponent<Camera>().orthographicSize;
        zoomSpeed = 7f;
        zoomOrtho = 3f;
        moveSpeed = 5f;
        normalOrtho = 12.3f;

        globals = GameObject.Find("Globals").GetComponent<globalVars>();

        //The original location of the music notes
        startMusicNotesPosition = musicNotes.transform.position;
    }

    private void FixedUpdate()
    {
        if (globals.onOffense)
        {
            musicNotes.transform.position = new Vector3(startMusicNotesPosition.x, musicNotes.transform.position.y, musicNotes.transform.position.z);
        }
        else
        {
            musicNotes.transform.position = new Vector3(startMusicNotesPosition.x * -1f, musicNotes.transform.position.y, musicNotes.transform.position.z);
        }
    }
    void LateUpdate()
    {
        if (leftTraget != null && lookAtLeft && moveCount<= framesToMove)
        {
            lookAtRight = false;
            targetOrtho = TheCamera.GetComponent<Camera>().orthographicSize;
            Vector3 newCameraPosition = new Vector3(leftTraget.transform.position.x, leftTraget.transform.position.y, TheCamera.transform.position.z);
            iTween.MoveTo(TheCamera,newCameraPosition, moveSpeed);
            TheCamera.GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(targetOrtho, zoomOrtho, zoomSpeed * Time.deltaTime);

            //Moves the music grid back
            //musicNotes.transform.position = new Vector3(startMusicNotesPosition.x, musicNotes.transform.position.y, musicNotes.transform.position.z);


            moveCount++;
        }

        if(rightTarget != null && lookAtRight && moveCount <= framesToMove)
        {
            lookAtLeft = false;
            targetOrtho = TheCamera.GetComponent<Camera>().orthographicSize;
            Vector3 newCameraPosition = new Vector3(rightTarget.transform.position.x, rightTarget.transform.position.y, TheCamera.transform.position.z);
            iTween.MoveTo(TheCamera, newCameraPosition, moveSpeed);
            TheCamera.GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(targetOrtho, zoomOrtho, zoomSpeed * Time.deltaTime);

            //Moves the music grid back
            //musicNotes.transform.position = new Vector3(startMusicNotesPosition.x, musicNotes.transform.position.y, musicNotes.transform.position.z);


            moveCount++;
        }

        if(resetCamera && moveCount <= framesToMove)
        {
            lookAtRight = false;
            lookAtLeft = false;
            targetOrtho = TheCamera.GetComponent<Camera>().orthographicSize;
            Vector3 newCameraPosition = new Vector3(0,0,TheCamera.transform.position.z);
            iTween.MoveTo(TheCamera, newCameraPosition, zoomSpeed);
            TheCamera.GetComponent<Camera>().orthographicSize = Mathf.MoveTowards(targetOrtho, normalOrtho, zoomSpeed * Time.deltaTime);

            //Moves the music grid back while the camera moves
            //musicNotes.transform.position = new Vector3(startMusicNotesPosition.x, musicNotes.transform.position.y, musicNotes.transform.position.z);


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

    private void moveMusicNotesBack()
    {
        //Moves the music grid back
        musicNotesNewPosition = new Vector3(startMusicNotesPosition.x, musicNotes.transform.position.y, startMusicNotesPosition.z);
        iTween.MoveTo(musicNotes, musicNotesNewPosition, moveSpeed);
    }
}
