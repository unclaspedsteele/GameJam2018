using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTranscriber : MonoBehaviour {

    public float bps;
    public float noteCounter;
    public float totalTimeCounter;

    public GameObject noteBar; //Holds the prefab for the rhythm bars
    public GameObject spawnSpot;
    public GameObject[] bars = new GameObject[5000]; //Hopefully don't need more than 5000 bars, who knows
    public GameObject tempNoteBar;
    public GameObject tempNoteBarOld; //Originally was the second oldest bar created, changed to be used as a temp var to find the nearest bar to each note on creation
    public GameObject j;
    public GameObject k;
    public GameObject l;
    public GameObject sc;
    public GameObject jSpawn;
    public GameObject kSpawn;
    public GameObject lSpawn;
    public GameObject scSpawn;
    public GameObject tempj;
    public GameObject tempk;
    public GameObject templ;
    public GameObject tempsc;
    public GameObject song; //The gameobject that houses the audio source for the song
    public GameObject startSong; //GameObject used to show visually the beginning of the song

    public int totalNotes;

    public bool songStarted; //Has the song been started?

    // Use this for initialization

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Start () {
        songStarted = false;
        totalNotes = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        totalTimeCounter += Time.fixedDeltaTime;

        if (totalTimeCounter > 6 && songStarted == false)
        {
            song.SetActive(true);
            tempNoteBar = GameObject.Instantiate(startSong, spawnSpot.transform);
            bars[totalNotes] = tempNoteBar;
            totalNotes += 1;
            songStarted = true;
        }

        if (totalTimeCounter > 3)
        {
            
            noteCounter += Time.fixedDeltaTime;
            if ((noteCounter) >= 1 / bps)
            {
                tempNoteBar = GameObject.Instantiate(noteBar, spawnSpot.transform);
                if (tempNoteBar != null)
                {
                }
                bars[totalNotes] = tempNoteBar;
                totalNotes += 1;
                noteCounter = 0;
            }


            //Key inputs. Spawns corresponding game object then parents them to the correct note bar
            if (Input.GetKeyDown(KeyCode.J))
            {
                tempj = GameObject.Instantiate(j, jSpawn.transform);
                foreach (GameObject bar in bars)
                {
                    if (bar != null)
                    {
                        if (Vector3.Distance(tempj.transform.position, bar.transform.position) < Vector3.Distance(tempj.transform.position, tempNoteBarOld.transform.position))
                        {
                            tempNoteBarOld = bar;
                        }
                    }
                }
                tempj.gameObject.transform.parent = tempNoteBarOld.transform;
                tempj.gameObject.transform.position = new Vector3(-3f, tempNoteBarOld.transform.position.y, 0);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                tempk = GameObject.Instantiate(k, kSpawn.transform);
                foreach (GameObject bar in bars)
                {
                    if (bar != null)
                    {
                        if (Vector3.Distance(tempk.transform.position, bar.transform.position) < Vector3.Distance(tempk.transform.position, tempNoteBarOld.transform.position))
                        {
                            tempNoteBarOld = bar;
                        }
                    }
                }
                tempk.gameObject.transform.parent = tempNoteBarOld.transform;
                tempk.gameObject.transform.position = new Vector3(-1f, tempNoteBarOld.transform.position.y, 0);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                templ = GameObject.Instantiate(l, lSpawn.transform);
                foreach (GameObject bar in bars)
                {
                    if (bar != null)
                    {
                        if (Vector3.Distance(templ.transform.position, bar.transform.position) < Vector3.Distance(templ.transform.position, tempNoteBarOld.transform.position))
                        {
                            tempNoteBarOld = bar;
                        }
                    }
                }
                templ.gameObject.transform.parent = tempNoteBarOld.transform;
                templ.gameObject.transform.position = new Vector3(1f, tempNoteBarOld.transform.position.y, 0);
            }
            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                tempsc = GameObject.Instantiate(sc, scSpawn.transform);
                foreach (GameObject bar in bars)
                {
                    if (bar != null)
                    {
                        if (Vector3.Distance(tempsc.transform.position, bar.transform.position) < Vector3.Distance(tempsc.transform.position, tempNoteBarOld.transform.position))
                        {
                            tempNoteBarOld = bar;
                        }
                    }
                }
                tempsc.gameObject.transform.parent = tempNoteBarOld.transform;
                tempsc.gameObject.transform.position = new Vector3(3f, tempNoteBarOld.transform.position.y, 0);
            }

            foreach (GameObject obj in bars)
            {
                if (obj != null)
                    obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y - .1f, obj.transform.position.z);
            }
        }
    }
}
