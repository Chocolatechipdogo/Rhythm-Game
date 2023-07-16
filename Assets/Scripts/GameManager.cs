using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //stores the music used in the scene
    public AudioSource theMusic;

    //creates the bool that controls whether or not the level will start
    public bool startPlaying;

    //stores the current BeatScroller being used
    public BeatScroller theBS;

    public static GameManager theInstance;


    //holds the score
    public int currentScore;

    // holds the amount the score needs to increase per note pressed
    public int scorePerNote;

    //holds the muliplier the player has currently
    public int currentMultiplier;
    //keeps the tally of notes hit to activate the next multipier
    public int multiplierTracker;
    // record of the threshes that the note hit combo has to reach to get the muliplier to increase
    public int[] comboThreshold;

    public Text scoreText;

    public Text multiplierText;


  

    // Start is called before the first frame update
    void Start()
    {
        theInstance = this;
        scorePerNote = 100;
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
        currentMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        /* at the end of this if the game should have started if it hasn't started and the player has pressed a key to interact. this will cause the music to play and
        the bools that are in charge of flagging to start are set to true.
        */
    }

    // function to be called when a note is hit
    // increases score and currently has logs for debugging purposes 
    public void NoteHit()
    {
        Debug.Log("Hit on time");

        multiplierTracker++;
        
        if( multiplierTracker == comboThreshold[currentMultiplier - 1])
        {
            currentMultiplier++;
            multiplierText.text = "Multiplier: x" + currentMultiplier;
        }
        else if(multiplierTracker == comboThreshold[currentMultiplier - 1])
        {
            currentMultiplier++;
            multiplierText.text = "Multiplier: x" + currentMultiplier;
        }
        else if(multiplierTracker == comboThreshold[currentMultiplier - 1])
        {
            currentMultiplier ++;
            multiplierText.text = "Multiplier: x" + currentMultiplier;
        }

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        //multiplierTracker++;
        
    }

    // Function to be called when the note is missed
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        multiplierTracker = 0;
        currentMultiplier = 1;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }
}
