using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 1f;

    public Rigidbody RB;
    public Camera Camera;
    public Animator Animator;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Camera = GetComponentInChildren<Camera>();
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {

        }
    }

    private void FixedUpdate()
    {
        
    }
}
