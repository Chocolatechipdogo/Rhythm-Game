using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public SpriteRenderer buttonRender;
    public Sprite nonPressed;
    public Sprite pressed;

    public KeyCode buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        buttonRender.sprite = nonPressed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonPressed)) {
            buttonRender.sprite = pressed;
        }
        else if (Input.GetKeyUp(buttonPressed)) {
            buttonRender.sprite = nonPressed;
        }
    }
}
