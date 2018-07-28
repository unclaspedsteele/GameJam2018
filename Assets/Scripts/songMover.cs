using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songMover : MonoBehaviour
{

    public int testcounter;
    public int timeTillStart;
    public int timeTillMove;


    public GameObject[] jnotes;
    public GameObject[] knotes;
    public GameObject[] lnotes;
    public GameObject[] scnotes;
    public GameObject musicSource;
    public GameObject mySongBars;

    public globalVars globals;

    public int numNotes = 0;

    public float moveSpeed;
    public float totTime;

    public bool startedTransition;

    Renderer note_renderer;

    // Use this for initialization
    void Start()
    {
        startedTransition = false;
        globals = GameObject.Find("globals").GetComponent<globalVars>();
        jnotes = GameObject.FindGameObjectsWithTag("jAttack");
        knotes = GameObject.FindGameObjectsWithTag("kAttack");
        lnotes = GameObject.FindGameObjectsWithTag("lAttack");
        scnotes = GameObject.FindGameObjectsWithTag("scAttack");

        numNotes = jnotes.Length + knotes.Length + lnotes.Length + scnotes.Length;

        globals.numNotes = numNotes;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totTime += Time.fixedDeltaTime;

        if(totTime > timeTillMove)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed, transform.position.z);
        }

        if (totTime > timeTillStart)
        {
            musicSource.SetActive(true);
        }

        

        if (globals.inTransition)
        {
            if (startedTransition == false)
            {
                startedTransition = true;
                testcounter += 1;
                mySongBars.transform.position = new Vector3(mySongBars.transform.position.x * -1, mySongBars.transform.position.y, mySongBars.transform.position.z);
            }
            DestroyNotesOnScreen();
        }

        if(globals.inTransition == false)
        {
            startedTransition = false;
        }
    }

    void DestroyNotesOnScreen()
    {

        for (int i = 0; i < jnotes.Length; i++)
        {
            if (jnotes[i] != null)
            {
                note_renderer = jnotes[i].GetComponent<Renderer>();
                if (note_renderer.isVisible == true)
                {
                    numNotes--;
                    Destroy(jnotes[i]);
                }
            }
        }
        for (int i = 0; i < knotes.Length; i++)
        {
            if (knotes[i] != null)
            {
                note_renderer = knotes[i].GetComponent<Renderer>();
                if (note_renderer.isVisible == true)
                {
                    numNotes--;
                    Destroy(knotes[i]);
                }
            }
        }
        for (int i = 0; i < lnotes.Length; i++)
        {
            if (lnotes[i] != null)
            {
                note_renderer = lnotes[i].GetComponent<Renderer>();
                if (note_renderer.isVisible == true)
                {
                    numNotes--;
                    Destroy(lnotes[i]);
                }
            }
        }
        for (int i = 0; i < scnotes.Length; i++)
        {
            if (scnotes[i] != null)
            {
                note_renderer = scnotes[i].GetComponent<Renderer>();
                if (note_renderer.isVisible == true)
                {
                    numNotes--;
                    Destroy(scnotes[i]);
                }
            }
        }
    }
}
