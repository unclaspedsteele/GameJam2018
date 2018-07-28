using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AnimationScript : MonoBehaviour
{

    public float publicBPM;
    public float publicFPS;
    public int numberOfImages;
    float bps;
    int currentImage;
    float timer;
    float rentFrame;
    int currentImagenabled;
    Image playerMaterial;
    Sprite[] AnimationDefault;
    Sprite[] AnimationStill;
    Sprite[] AnimationDeath;
    Sprite[] AnimationA;
    Sprite[] AnimationS;
    Sprite[] AnimationD;
    Sprite[] AnimationF;
    Sprite[] AnimationJ;
    Sprite[] AnimationK;
    Sprite[] AnimationL;
    Sprite[] AnimationSemi;
    Sprite[] NextAnimation;
    Vector3[] positions;
    Vector3[] DefaultPositions;

    globalVars globals;

    // Use this for initialization
    void Start()
    {
        //Get Player's Material for updating animation
        playerMaterial = GetComponent<Image>();
        globals = GameObject.Find("Globals").GetComponent<globalVars>();

        currentImage = 0;
        timer = 0;
        bps = publicBPM / 60;

        AnimationDefault = new Sprite[numberOfImages];
        AnimationStill = new Sprite[numberOfImages];
        AnimationDeath = new Sprite[numberOfImages];
        AnimationA = new Sprite[numberOfImages];
        AnimationS = new Sprite[numberOfImages];
        AnimationD = new Sprite[numberOfImages];
        AnimationF = new Sprite[numberOfImages];
        AnimationJ = new Sprite[numberOfImages];
        AnimationK = new Sprite[numberOfImages];
        AnimationL = new Sprite[numberOfImages];
        AnimationSemi = new Sprite[numberOfImages];
        positions = new Vector3[numberOfImages];
        positions = new Vector3[numberOfImages];

        AnimationStill[0] = Resources.Load<Sprite>("Animations/Idle02");
        AnimationStill[1] = AnimationStill[0];
        AnimationStill[2] = AnimationStill[0];
        AnimationStill[3] = AnimationStill[0];

        AnimationDeath[0] = Resources.Load<Sprite>("Animations/Death02");
        AnimationDeath[1] = AnimationDeath[0];
        AnimationDeath[2] = AnimationDeath[0];
        AnimationDeath[3] = AnimationDeath[0];

        AnimationA[0] = Resources.Load<Sprite>("Animations/Jump02");
        AnimationA[1] = AnimationA[0];
        AnimationA[2] = AnimationA[0];
        AnimationA[3] = AnimationA[0];
        AnimationD = AnimationA;

        AnimationS[0] = Resources.Load<Sprite>("Animations/Duck02");
        AnimationS[1] = AnimationS[0];
        AnimationS[2] = AnimationS[0];
        AnimationS[3] = AnimationS[0];
        AnimationF = AnimationS;

        AnimationJ[0] = Resources.Load<Sprite>("Animations/Punch02");
        AnimationJ[1] = AnimationJ[0];
        AnimationJ[2] = AnimationJ[0];
        AnimationJ[3] = AnimationJ[0];

        AnimationK[0] = Resources.Load<Sprite>("Animations/Kick02");
        AnimationK[1] = AnimationK[0];
        AnimationK[2] = AnimationK[0];
        AnimationK[3] = AnimationK[0];

        AnimationL[0] = Resources.Load<Sprite>("Animations/Special02");
        AnimationL[1] = AnimationL[0];
        AnimationL[2] = AnimationL[0];
        AnimationL[3] = AnimationL[0];

        AnimationSemi[0] = Resources.Load<Sprite>("Animations/Upper02");
        AnimationSemi[1] = AnimationSemi[0];
        AnimationSemi[2] = AnimationSemi[0];
        AnimationSemi[3] = AnimationSemi[0];

        AnimationDefault = AnimationStill;
        NextAnimation = AnimationDefault;

        DefaultPositions = new[] { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.fixedDeltaTime;

        if (NextAnimation == AnimationDefault)
        {
            // If the user presses the corresponding button and is currently playing the default animation
            if (Input.GetKeyDown(KeyCode.A)) //Jump
            {
                NextAnimation = AnimationA;
                positions = new [] {new Vector3(0, 25, 0), new Vector3(0, 25, 0), new Vector3(0, -25, 0), new Vector3(0, -25, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.S)) //Duck
            {
                NextAnimation = AnimationS;
                positions = new[] { new Vector3(0, -15, 0), new Vector3(0, -15, 0), new Vector3(0, 15, 0), new Vector3(0, 15, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D)) //Jump
            {

                NextAnimation = AnimationD;
                positions = new[] { new Vector3(0, 15, 0), new Vector3(0, 15, 0), new Vector3(0, -15, 0), new Vector3(0, -15, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.F)) //Duck
            {
                NextAnimation = AnimationF;
                positions = new[] { new Vector3(0, -5, 0), new Vector3(0, -5, 0), new Vector3(0, 5, 0), new Vector3(0, 5, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.J)) //Punch
            {
                NextAnimation = AnimationJ;
                positions = new[] { new Vector3(15, 0, 0), new Vector3(15, 0, 0), new Vector3(-15, 0, 0), new Vector3(-15, 0, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.K)) //Kick
            {
                NextAnimation = AnimationK;
                positions = new[] { new Vector3(15, 0, 0), new Vector3(15, 0, 0), new Vector3(-15, 0, 0), new Vector3(-15, 0, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.L)) //Special
            {
                NextAnimation = AnimationL;
                positions = new[] { new Vector3(15, 0, 0), new Vector3(15, 0, 0), new Vector3(-15, 0, 0), new Vector3(-15, 0, 0) };
                currentImage = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Semicolon)) //Uppercut
            {
                NextAnimation = AnimationSemi;
                positions = new[] { new Vector3(15, 0, 0), new Vector3(15, 0, 0), new Vector3(-15, 0, 0), new Vector3(-15, 0, 0) };
                currentImage = 0;
            }

        }


        //Plays the next animation
        if (timer > 1 / bps / numberOfImages) {
            timer = 0;
            playerMaterial.sprite = NextAnimation[currentImage];
            playerMaterial.rectTransform.localPosition += positions[currentImage];
            currentImage++;
            if (currentImage >= numberOfImages) {
                currentImage = 0;
                NextAnimation = AnimationDefault;
                positions = DefaultPositions;
            }
        }

        if (globals.health <= 0) {
            AnimationDefault = AnimationDeath;
        }
    }
}