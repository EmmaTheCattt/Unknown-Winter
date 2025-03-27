using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyBrain : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine => enemyStateMachine;

    //  Fields
    [Header("Player and Enemy reference")]
    [SerializeField] private GameObject player;
    public Transform playerTransform;
    [SerializeField] private GameObject enemy;

    [Header("Detection radius")]
    [SerializeField] private float detectionRange;

    [Header("Player detected")]
    public bool playerSpottet;

    [Header("Navigation meshes")]
    public NavMeshAgent agent;


    //  Class instances
    EnemyEyes Eyes = new EnemyEyes();

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMachine(this);
    }

    void Start()
    {
        //  Gets reference to player
        player = GameObject.FindGameObjectWithTag("Player");
        //  Starts Coroutine that checks if player is in view range
        //StartCoroutine(Eyes.LookRoutine(player, enemy, detectionRange));

        enemyStateMachine.StartState(enemyStateMachine.idleState);
    }


    void Update()
    {
        playerSpottet = Eyes.CanSeePlayer(player, enemy, detectionRange);
        enemyStateMachine.Execute();
    }
}
