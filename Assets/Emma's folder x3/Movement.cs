using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    public float movespeed = 1f;
    public bool walking = false;
    public float GroundDrag;

    [Header("Broken leg")]
    //broken leg.
    public bool leg_broken = true;
    public float Leg_push = 0f;
    public float Leg_push_time = 0.1f;
    public float move_wait_time = 1f;

    [Header("Ground Check")]
    public float height;
    public LayerMask Ground;
    public bool grounded;


    [Header("Other")]
    public Rigidbody rb;

    public Transform Orientation;
    public GameObject Cam_animation;
    public Animator Animator;

    public float horizontalInput;
    public float verticalInput;

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
        Animation_check();

        Animator.SetBool("Walk", walking);

    }

    private void Animation_check()
    {
        Vel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (Vel != Vector3.zero)
        {
            walking = true;
            Debug.Log(rb.velocity);
        }
        else
        {
            walking = false;
            Debug.Log(rb.velocity);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        Brokenleg(leg_broken);

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
        //CancelInvoke("BrokenMove");
        Invoke("CancelInvoke", Leg_push_time);
    }
}
