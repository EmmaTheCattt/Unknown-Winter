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
    private GameObject Cameraholder;

    CanSeeEnemy canSeeEnemy = new CanSeeEnemy();

    public bool canSeeMe;
    public bool isInCamera = false;

    private void Awake()
    {
        weepingStateMachine = new WeepingStateMachine(this);
        Player = GameObject.FindGameObjectWithTag("Player");
        Cameraholder = GameObject.FindGameObjectWithTag("PlayerCam");
        playerCamera = Cameraholder.GetComponent<Camera>();
        
    }

    public void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        //playerCamera = Player.GetComponent<Camera>();
        weepingStateMachine.StartState(weepingStateMachine.startState);
    }

    private void Update()
    {
        if (canSeeEnemy.isInCamera(playerCamera, target))
        {
            isInCamera = true;
            canSeeMe = canSeeEnemy.isVisible(Player, target);

        }
        else
        {
            canSeeMe = false;
        }
        weepingStateMachine.Execute();
    }
}
