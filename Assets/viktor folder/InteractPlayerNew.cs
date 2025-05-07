using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractNew : MonoBehaviour
{
    Ray ray = new();
    public Image HandInteract;
    public Camera Camera;

    public void Awake()
    {
        HandInteract.enabled = false;
    }

    public void Update()
    {
        OnClick();
    }

    public void OnClick()
    {
        ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out var hit) && Input.GetMouseButtonDown(1))
        {
            // When LMouse is clicked - this runs
            
            var interactable = hit.collider.gameObject.GetComponent<IInteractNew>();

            if (interactable != null)
            {
                // Interactable is found and script is run
                interactable.OnInteract();
                HandInteract.enabled = false;
            }
            else
            {
                Debug.Log("Interactable Not Found");
            }
        }
        else if (Physics.Raycast(ray, out hit) && !Input.GetMouseButtonDown(1))
        {
            var interactable = hit.collider.gameObject.GetComponent<IInteractNew>();

            if (interactable != null)
            {
                // Hovering over Object
                HandInteract.enabled = true;

            }
            else
            {
                Debug.Log("Interactable Not Found");
                HandInteract.enabled = false;
                
            }
        }
        else
        {
            Debug.Log("Nothing was clicked");
            HandInteract.enabled = false;
        }
    }
}
