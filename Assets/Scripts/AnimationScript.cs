using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnimationScript : MonoBehaviour
{

    public float publicBPS;
    public float publicFPS;
    public float numberOfImages;
    int currentImage;
    float timer;
    float speed;
    float rentFrame;
    int currentImagenabled;
    //bool playingAnimation;
    Image playerMaterial;
    Sprite[] AnimationDefault = new Sprite[4];
    Sprite[] AnimationStill = new Sprite[4];
    Sprite[] AnimationDeath = new Sprite[4];
    Sprite[] AnimationJ = new Sprite[4];
    Sprite[] AnimationK = new Sprite[4];
    Sprite[] AnimationL = new Sprite[4];
    Sprite[] AnimationSemi = new Sprite[4];
    Sprite[] NextAnimation = new Sprite[4];

    globalVars globals;

    // Use this for initialization
    void Start()
    {
        //Get Player's Material for updating animation
        playerMaterial = GetComponent<Image>();
        globals = GameObject.Find("globals").GetComponent<globalVars>();
        speed = publicFPS / publicBPS; // Frame Rate divided by number of beats in one second divided by the number of images per animation

        currentImage = 0;
        timer = 0;
        //playingAnimation = false;

        AnimationStill[0] = Resources.Load<Sprite>("Animations/Idle01");
        AnimationStill[1] = AnimationStill[0];
        AnimationStill[2] = Resources.Load<Sprite>("Animations/Idle02");
                
        AnimationStill[3] = AnimationStill[1];

        AnimationDeath[0] = Resources.Load<Sprite>("Animations/Death01");
        AnimationDeath[1] = AnimationDeath[0];
        AnimationDeath[2] = Resources.Load<Sprite>("Animations/Death02");
        AnimationDeath[3] = AnimationDeath[1];

        AnimationDefault = AnimationStill;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.fixedDeltaTime;

        // If the user presses the corresponding button and is currently playing the default animation
        if (Input.GetKeyDown(KeyCode.J) && NextAnimation == AnimationDefault)
        {
            NextAnimation = AnimationJ;
            currentImage = 0;
            Debug.Log("J Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.K) && NextAnimation == AnimationDefault)
        {
            NextAnimation = AnimationK;
            currentImage = 0;
            Debug.Log("K Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.L) && NextAnimation == AnimationDefault)
        {
            NextAnimation = AnimationL;
            currentImage = 0;
            Debug.Log("L Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Semicolon) && NextAnimation == AnimationDefault)
        {
            NextAnimation = AnimationSemi;
            currentImage = 0;
            Debug.Log("; Pressed");
        }

        //Plays the next animation
        if (timer > 1 / publicBPS / numberOfImages)
        {
            timer = 0;
            playerMaterial.sprite = NextAnimation[currentImage];
            currentImage++;
            if (currentImage >= numberOfImages)
            {
                currentImage = 0;
                NextAnimation = AnimationDefault;
            }
        }

        if (globals.health <= 0)
        {
            AnimationDefault = AnimationDeath;
        }
    }
}