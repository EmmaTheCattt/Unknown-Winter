using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class noteScript : MonoBehaviour, IInteractNew
{
    public Image noteGraphic;
    public bool onTrigger;
    public GameObject noteText;
    public AudioSource interactSound;

    public void OnInteract()
    {
        noteGraphic.enabled = !noteGraphic.enabled;
        noteText.SetActive(!noteText.activeSelf);
        interactSound.Play();
    }

    private void Start()
    {
        noteGraphic.enabled = false;
        noteText.SetActive(false);
        
    }
}
