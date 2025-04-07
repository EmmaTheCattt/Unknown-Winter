using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class noteScript : MonoBehaviour
{
    public Image noteGraphic;
    private bool onTrigger;
    public GameObject noteText;
    


    private void Start()
    {
        noteGraphic.enabled = false;
        noteText.SetActive(false);
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && onTrigger)
        {
            Debug.Log("Interacted");
            noteGraphic.enabled = !noteGraphic.enabled;
            noteText.SetActive(true);
        }

        if (noteGraphic.enabled && !onTrigger)
        {
            noteGraphic.enabled = false;
            
        }

        if (noteGraphic.enabled == false)
        {
            noteText.SetActive(false);
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
