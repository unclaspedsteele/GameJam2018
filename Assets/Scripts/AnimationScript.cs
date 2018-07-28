using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

    public Material Red;
    public Material Green;
    public Material Blue;
    public Material Yellow;
    public Material Black;
    public Material White;

    public globalVars globalVariables;

    public float publicBPS;
    public float publicFPS;
    public float numberOfImages;
    int currentImage;
    float timer;
    float speed;
    float rentFrame;
    int currentImagenabled;
    //bool playingAnimation;
    MeshRenderer playerMaterial;
    Material[] AnimationDefault = new Material[4];
    Material[] AnimationStill = new Material[4];
    Material[] AnimationDeath = new Material[4];
    Material[] AnimationJ = new Material[4];
    Material[] AnimationK = new Material[4];
    Material[] AnimationL = new Material[4];
    Material[] AnimationSemi = new Material[4];
    Material[] NextAnimation = new Material[4];

    // Use this for initialization
    void Start() {
        //Get Player's Material for updating animation
        playerMaterial = GetComponent<MeshRenderer>();
        globalVariables = GameObject.Find("globals").GetComponent<globalVars>();

        speed = publicFPS / publicBPS; // Frame Rate divided by number of beats in one second divided by the number of images per animation

        currentImage = 0;
        timer = 0;
        //playingAnimation = false;

        AnimationStill[0] = Black;
        AnimationStill[1] = White;
        AnimationStill[2] = Black;
        AnimationStill[3] = White;

        AnimationDeath[0] = Black;
        AnimationDeath[1] = Red;
        AnimationDeath[2] = Black;
        AnimationDeath[3] = Red;

        AnimationJ[0] = Red;
        AnimationJ[1] = Green;
        AnimationJ[2] = Blue;
        AnimationJ[3] = Yellow;

        AnimationK[0]= Green;
        AnimationK[1] = Red;
        AnimationK[2] = Yellow;
        AnimationK[3] = Blue;

        AnimationL[0] = Blue;
        AnimationL[1] = Yellow;
        AnimationL[2] = Green;
        AnimationL[3] = Red;

        AnimationSemi[0] = Yellow;
        AnimationSemi[1] = Blue;
        AnimationSemi[2] = Red;
        AnimationSemi[3] = Green;

        AnimationDefault = AnimationStill;
	}

    // Update is called once per frame
    void FixedUpdate() {

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
            playerMaterial.material = NextAnimation[currentImage];
            currentImage++;
            if (currentImage >= numberOfImages)
            {
                currentImage = 0;
                NextAnimation = AnimationDefault;
            }
        }

        if (globalVariables.enemyHealth <= 0) {
            AnimationDefault = AnimationDeath;
        }
	}
}
