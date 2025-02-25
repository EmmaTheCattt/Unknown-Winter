using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform CameraPosition;
    public GameObject Player;

    public Vector3 Cam_pos_height;
    public float height = 0.1f;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        CameraPosition = Player.transform;
        Cam_pos_height = new Vector3(0, height, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraPosition.position + Cam_pos_height;
    }
}
