using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode responseKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(responseKey)) {
            if (canBePressed) {
                gameObject.SetActive(false);

                GameManager.theInstance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf != false)
        {
            canBePressed = false;

            GameManager.theInstance.NoteMissed();
        }

    }
}
