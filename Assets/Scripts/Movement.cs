using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    private float movespeed = 1f;
    public float WalkSpeed = 1f;
    public float SprintSpeed = 2f;
    public bool walking = false;
    public bool Running = false;
    public float GroundDrag;

    [Header("Broken leg")]
    //broken leg.
    public bool leg_broken = true;
    private float Leg_push = 0f;
    public float weak_leg_push = 11.5f;
    public float Strong_leg_push = 15.5f;

    private float Leg_push_time = 0.1f;
    public float weak_leg_push_time = 0.3f;
    public float Strong_leg_push_time = 0.3f;

    private float move_wait_time = 1f;
    public float move_wait_time_slow = 1.5f;
    public float move_wait_time_quick = 1.5f;

    [Header("Ground Check")]
    public float height;
    public LayerMask Ground;
    public bool grounded;
    public float Flying_speed = 10f;


    [Header("Other")]
    public Rigidbody rb;

    public Transform Orientation;
    public GameObject Cam_animation;
    public Animator Animator;

    public float horizontalInput;
    public float verticalInput;
    public AudioSource walkSound;


    Vector3 moveDirection;
    Vector3 Vel;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Orientation = GameObject.FindGameObjectWithTag("Orientation").transform;
        Cam_animation = GameObject.FindGameObjectWithTag("Cam_animation");
        Animator = Cam_animation.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        grounded = Physics.Raycast(transform.position, Vector3.down, height * 0.5f, Ground);

        if (grounded)
        {
            rb.drag = GroundDrag;
            
        }
        else
        {
            rb.drag = 0;
        }
        
        MyInput();
        animationReset();
        SpeedControl();
    }

    private void animationReset()
    {
        if (Vel.sqrMagnitude == 0)
        {
            walking = false;
            Animator.SetBool("Walk", walking);
        }
    }
    private void Animation_check()
    {

        Vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (Vel.sqrMagnitude >= 0.4 && grounded == true)
        {
            walking = true;
            //Debug.Log(rb.velocity);
            
        }
        else
        {
            walking = false;
            //Debug.Log(rb.velocity);
        }

        if (Vel.sqrMagnitude >= 0.1 && Input.GetKey(KeyCode.LeftShift) && grounded == true)
        {
            Animator.speed = 2;
        }
        else
        {
            Animator.speed = 1;
        }

        Animator.SetBool("Walk", walking);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && grounded == true)
        {
            movespeed = SprintSpeed;
            Leg_push = Strong_leg_push;
            Leg_push_time = Strong_leg_push_time;
            move_wait_time = move_wait_time_quick;
        }
        else
        {
            movespeed = WalkSpeed;
            Leg_push = weak_leg_push;
            Leg_push_time = weak_leg_push_time;
            move_wait_time = move_wait_time_slow;
        }
    }

    void MovePlayer()
    {
        walkSound.Play();
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        //Brokenleg(leg_broken);

        rb.AddForce(moveDirection.normalized * movespeed, ForceMode.Force);
    }

    void Brokenleg(bool Broken)
    {
        if (Broken == true)
        {
            Invoke("BrokenMove", move_wait_time);
        }
    }

    void BrokenMove()
    {
        rb.AddForce(moveDirection.normalized * Leg_push, ForceMode.Force);
        Animation_check();
        Invoke("CancelInvoke", Leg_push_time);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > Flying_speed && grounded == false)
        {
            Vector3 limitedvel = flatVel.normalized * Flying_speed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }

        if (flatVel.magnitude > SprintSpeed && grounded == true)
        {
            Vector3 limitedvel = flatVel.normalized * SprintSpeed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }
    }
}
