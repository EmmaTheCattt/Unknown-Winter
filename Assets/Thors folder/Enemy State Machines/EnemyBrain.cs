using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyBrain : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    public EnemyStateMachine EnemyStateMachine => enemyStateMachine;
    //private GameObject Monster;
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


    public AudioSource Chasemusic;


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
        playerTransform = player.transform;
        enemyStateMachine.StartState(enemyStateMachine.idleState);

        //AudioSource Chasemusic = enemy.GetComponent<AudioSource>();
        //Monster = GameObject.FindGameObjectWithTag("Enemy");
    }


    void Update()
    {
        playerSpottet = Eyes.CanSeePlayer(player, enemy, detectionRange);
        enemyStateMachine.Execute();
        //Chasetime();
    }


    public void Chasetime()
    {
        Chasemusic.Play();
    }

    public void ChaseOver()
    { 
        Chasemusic.Pause();
    }
}
