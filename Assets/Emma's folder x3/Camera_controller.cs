using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public float aniX;
    public float aniY;
    public float aniZ;

    public Transform Orientation;
    public GameObject Animator;

    public float xRotation;
    public float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Animator = GameObject.FindGameObjectWithTag("Cam_animation");
        Orientation = GameObject.FindGameObjectWithTag("Orientation").transform;
        aniX = Animator.transform.rotation.eulerAngles.x;
        aniY = Animator.transform.rotation.eulerAngles.y;
        aniZ = Animator.transform.rotation.eulerAngles.z;

    }

    // Update is called once per frame
    void Update()
    {
        aniX = Animator.transform.rotation.eulerAngles.x;
        aniY = Animator.transform.rotation.eulerAngles.y;
        aniZ = Animator.transform.rotation.eulerAngles.z;

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation + aniX, yRotation + aniY, aniZ);
        Orientation.rotation = Quaternion.Euler(0, yRotation + aniY, aniY);
    }
}
