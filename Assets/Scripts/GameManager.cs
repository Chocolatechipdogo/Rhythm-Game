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


    public Text scoreText;
  

    // Start is called before the first frame update
    void Start()
    {
        theInstance = this;
        scorePerNote = 100;
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

        currentScore += scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }

    // Function to be called when the note is missed
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
