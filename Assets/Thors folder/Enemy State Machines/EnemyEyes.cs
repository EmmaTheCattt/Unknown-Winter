using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes
{
    public EnemyEyes()
    {
    }

    public IEnumerator LookRoutine(GameObject player, GameObject enemy, float detectionRange)
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            CanSeePlayer(player, enemy, detectionRange);
            Debug.Log("COROUTINE");
        }
    }

    public bool CanSeePlayer(GameObject player, GameObject enemy, float detectionRange)
    {
        bool playerInRange = false;
        bool playerNotHidden = false;
        bool playerSpottet = false;

        if (Vector3.Distance(enemy.transform.position, player.transform.position) < detectionRange)
        {
            playerInRange = true;
            Debug.Log("PLAYER IN RANGE!!!!");
        }
        else
        {
            Debug.Log("PLAYER NOT! IN RANGE!!!");
        }

        RaycastHit hit;
        if (Physics.Raycast(enemy.transform.position, (player.transform.position - enemy.transform.position), out hit, (detectionRange + 5)))
        {
            if (hit.transform == player.transform)
            {
                playerNotHidden = true;
                Debug.Log("PLAYER NOT HIDDEN!!!!");
            }
        }
        else
        {
            Debug.Log("PLAYER HIDDEN!!!!!");
        }
        if ((playerInRange && playerNotHidden) == true)
        {
            playerSpottet = true;
            Debug.Log("PLAYER SPOTTET");
        }

        return playerSpottet;
    }
}
