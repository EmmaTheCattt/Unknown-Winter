using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WeepingBrain : MonoBehaviour
{
    private WeepingStateMachine weepingStateMachine;
    public WeepingStateMachine WeepingStateMachine => weepingStateMachine;

    [SerializeField] private GameObject target;
    public GameObject Player;
    [SerializeField] private Camera playerCamera;
    public NavMeshAgent agent;

    CanSeeEnemy canSeeEnemy = new CanSeeEnemy();

    public bool canSeeMe;

    private void Awake()
    {
        weepingStateMachine = new WeepingStateMachine(this);
    }

    public void Start()
    {
        weepingStateMachine.StartState(weepingStateMachine.startState);
    }

    private void Update()
    {
        if (canSeeEnemy.isInCamera(playerCamera, target))
        {
            canSeeMe = canSeeEnemy.isVisible(Player, target);
        }
        else
        {
            canSeeMe = false;
        }
        weepingStateMachine.Execute();
    }
}
