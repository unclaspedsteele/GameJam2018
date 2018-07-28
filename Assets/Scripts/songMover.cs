using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songMover : MonoBehaviour
{
    public GameObject[] jnotes;
    public GameObject[] knotes;
    public GameObject[] lnotes;
    public GameObject[] scnotes;

    public int numNotes = 0;
    Renderer note_renderer;

    // Use this for initialization
    void Start()
    {
        jnotes = GameObject.FindGameObjectsWithTag("jAttack");
        knotes = GameObject.FindGameObjectsWithTag("kAttack");
        lnotes = GameObject.FindGameObjectsWithTag("lAttack");
        scnotes = GameObject.FindGameObjectsWithTag("scAttack");

        numNotes = jnotes.Length + knotes.Length + lnotes.Length + scnotes.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            DestroyNotesOnScreen();
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
