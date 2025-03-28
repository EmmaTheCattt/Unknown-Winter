using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class NoteScript : InteractionScript
{
    public Image noteGraphics;
    private bool click;

    void Start()
    {
        noteGraphics.enabled = false;
    }

    private void Update()
    {
        bool click = Input.GetMouseButtonDown(1);
        if (click)
        {
            Debug.Log("Clicked");
        }
    }


    private void OnTriggerEnter(Collider player)
    {
        if (click)
        {
            Debug.Log("Clicked");
            noteGraphics.enabled = true;
        }
        else if(noteGraphics.enabled && click)
        {
            noteGraphics.enabled = false;
        }
    }

    
}
