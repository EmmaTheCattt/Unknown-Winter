using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;

public class noteScript : MonoBehaviour
{
    public Image noteGraphic;
    private bool onTrigger;


    private void Start()
    {
        noteGraphic.enabled = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && onTrigger)
        {
            Debug.Log("Interacted");
            noteGraphic.enabled = !noteGraphic.enabled;
        }

        if (noteGraphic.enabled && !onTrigger)
        {
            noteGraphic.enabled = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

}
