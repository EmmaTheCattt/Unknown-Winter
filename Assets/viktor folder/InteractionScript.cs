using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;



public class InteractionScript : MonoBehaviour
{
    public Image pickUpIcon;
    
    public GameObject player;

    void Start()
    {
        pickUpIcon.enabled = false;
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Interactable"))
        {
            Debug.Log("Something");
            pickUpIcon.enabled = true;

        }
        else
        {
            pickUpIcon.enabled = false;

        }
    }

    
}

