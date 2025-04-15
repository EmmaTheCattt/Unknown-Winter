using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class noteScript : MonoBehaviour
{
    public Image noteGraphic;
    public bool onTrigger;
    public GameObject noteText;
    public Image HandInteract;

    private void Awake()
    {
        onTrigger = false;
    }

    private void Start()
    {
        noteGraphic.enabled = false;
        noteText.SetActive(false);
        
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && onTrigger)
        {

            noteGraphic.enabled = !noteGraphic.enabled;
            noteText.SetActive(true);
            HandInteract.enabled = false;
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
        if (CompareTag("Interactable"))
        {
            onTrigger = true;
            Debug.Log("triggered");
        }
        else
        {
            onTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

}
