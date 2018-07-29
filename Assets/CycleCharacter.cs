using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CycleCharacter : MonoBehaviour {

    int random;
    float rentFrame;
    int currentImage;
    int currentImagenabled;
    public float timer;
    public int numberOfImages;
    public Image playerMaterial;
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

    // Use this for initialization
    void Start () {
        random = 0;
        numberOfImages = 4;
        playerMaterial = GetComponent<Image>();
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

        NextAnimation = AnimationA;
        playerMaterial.sprite = NextAnimation[currentImage];
        currentImage = 0;


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        NextAnimation = AnimationA;
        currentImage = 0;
        random = Random.Range(0, 9);
        timer += Time.fixedDeltaTime;

        if(timer >= 1)
        {
            if (random == 1) //Jump
            {
                NextAnimation = AnimationA;
                currentImage = 0;

            }
            else if (random == 2) //Duck
            {
                NextAnimation = AnimationS;
                currentImage = 0;

            }
            else if (random == 3) //Jump
            {

                NextAnimation = AnimationD;
                currentImage = 0;

            }
            else if (random == 4) //Duck
            {
                NextAnimation = AnimationF;
                currentImage = 0;

            }
            else if (random == 5) //Punch
            {
                NextAnimation = AnimationJ;
                currentImage = 0;

            }
            else if (random == 6) //Kick
            {
                NextAnimation = AnimationK;
                currentImage = 0;

            }
            else if (random == 7) //Special
            {
                NextAnimation = AnimationL;
                currentImage = 0;

            }
            else if (random == 8) //Uppercut
            {
                NextAnimation = AnimationSemi;
                currentImage = 0;
            }

            playerMaterial.sprite = NextAnimation[currentImage];
            timer = 0;
        }
    }
}
