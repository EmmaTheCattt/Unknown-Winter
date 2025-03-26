using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NoteScript : MonoBehaviour
{
    public Image noteGraphics;


    void Start()
    {
        noteGraphics.enabled = false;
    }

    private void OnTriggerEnter(Collider target)
    {
        bool click = Input.GetMouseButtonDown(1);

        if (target.CompareTag("Interact") && click)
        {
            Debug.Log("Clicked");
            noteGraphics.enabled = !noteGraphics.enabled;
        }
    }
}
