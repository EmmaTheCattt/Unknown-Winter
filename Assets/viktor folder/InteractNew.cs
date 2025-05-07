using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractPlayerNew : MonoBehaviour
{
    public GameObject Note;

    public void OnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out var hit))
        {
            var interactable = hit.collider.gameObject.GetComponent<IInteractNew>();

            if (interactable != null)
            {
                interactable.OnInteract();
            }
            else
            {
                Debug.LogError("Interactable Not Found");
            }
        }
    }
}
