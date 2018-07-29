using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject jSmoke;
    public GameObject kSmoke;
    public GameObject lSmoke;
    public GameObject scSmoke;

    public GameObject DefenseText;
    public GameObject OffenseText;
    bool TextSwitch;
    bool TextShow;
    float timer;

    public globalVars globals;

    public int numNotes = 0;

    public float moveSpeed;
    public float totTime;

    public bool startedTransition;

    Renderer note_renderer;

    // Use this for initialization
    void Awake()
    {
        startedTransition = false;
        globals = GameObject.Find("Globals").GetComponent<globalVars>();
        jnotes = GameObject.FindGameObjectsWithTag("jAttack");
        knotes = GameObject.FindGameObjectsWithTag("kAttack");
        lnotes = GameObject.FindGameObjectsWithTag("lAttack");
        scnotes = GameObject.FindGameObjectsWithTag("scAttack");

        numNotes = jnotes.Length + knotes.Length + lnotes.Length + scnotes.Length;

        globals.numNotes = numNotes;

        DefenseText.GetComponent<Image>().fillAmount = 0;
        OffenseText.GetComponent<Image>().fillAmount = 0;
        TextSwitch = false;
        TextShow = false;
        timer = 0;
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
            DestroyNotesOnScreen();
            if (startedTransition == false)
            {
                startedTransition = true;
                testcounter += 1;
                mySongBars.transform.position = new Vector3(mySongBars.transform.position.x * -1, mySongBars.transform.position.y - .2f, mySongBars.transform.position.z);
                TextShow = true;
                TextSwitch = !TextSwitch;
            }

        }

        if(globals.inTransition == false)
        {
            startedTransition = false;
        }

        if (TextShow)
        {
            GameObject Text;
            if (TextSwitch)
            {
                Text = DefenseText;
            }
            else
            {
                Text = OffenseText;
            }
            Text.SetActive(true);

            timer += Time.fixedDeltaTime;

            if (timer <= 1.5)
            {
                Text.GetComponent<Image>().fillAmount = timer;
            }

            else if (timer >= 2 && timer <= 2.5)
            {
                Text.GetComponent<Image>().fillOrigin = 1;
                Text.GetComponent<Image>().fillAmount = 2 - timer;
            }
            else if (timer > 3)
            {
                Text.GetComponent<Image>().fillOrigin = 0;
                Text.SetActive(false);
                TextShow = false;
                timer = 0;
            }
        }
    }

    public void DestroyNotesOnScreen()
    {

        for (int i = 0; i < jnotes.Length; i++)
        {
            if (jnotes[i] != null)
            {
                note_renderer = jnotes[i].GetComponent<Renderer>();
                if (note_renderer.isVisible == true)
                {
                    numNotes--;
                    GameObject clone = Instantiate(jSmoke, jnotes[i].transform);
                    clone.transform.parent = null;
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
                    GameObject clone = Instantiate(kSmoke, knotes[i].transform);
                    clone.transform.parent = null;
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
                    GameObject clone = Instantiate(lSmoke, lnotes[i].transform);
                    clone.transform.parent = null;
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
                    GameObject clone = Instantiate(scSmoke, scnotes[i].transform);
                    clone.transform.parent = null;
                    Destroy(scnotes[i]);
                }
            }
        }
    }
}
