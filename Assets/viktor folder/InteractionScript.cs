using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;



public class InteractionScript : MonoBehaviour
{
    public Image pickUpIcon;
    public bool inView = false;
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
            
            pickUpIcon.enabled = true;
            inView = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        pickUpIcon.enabled = false;
        inView = false;
    }

}

