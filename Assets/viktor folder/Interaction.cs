using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Interaction : MoveCamera
{
    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Interactable"))
        {
            Debug.Log("In View");
        }
    }
    public void Update()
    {
        transform.position = CameraPosition.position + Cam_pos_height;
    }
}

