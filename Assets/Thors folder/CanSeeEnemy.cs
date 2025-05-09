using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanSeeEnemy
{
    /*
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject Player;
    [SerializeField] private Camera playerCamera;
    */

    public CanSeeEnemy()
    { 
    }

    /*
    void Update()
    {
        if (isInCamera())
        {
            isVisible();
        }
        else
        {
            Debug.Log("Is not visible");
        }
    }
    */

    public bool isInCamera(Camera playerCamera, GameObject target)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCamera);
        //  So the line below checks if the center of the enemy is within the camera, therefore part of the enemy becomes visible before
        //  the code registers it. the 0 therefore has to be ajusted so the code registers the enemy earlier.  
        return planes.All(plane => plane.GetDistanceToPoint(target.transform.position) >= 0);
    }

    public bool isVisible(GameObject Player, GameObject target)
    {
        bool MonsterVisable = false;
        Vector3 playerDir = (Player.transform.position - target.transform.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(target.transform.position, playerDir, out hit, Mathf.Infinity))
        {
            if (hit.transform == Player.transform)
            {
                MonsterVisable = true;
                
            }
        }
        return MonsterVisable;
    }
}
