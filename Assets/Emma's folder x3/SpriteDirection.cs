using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{

    public Camera Player_Cam;
    public GameObject Player;
    public GameObject Enemy;

    public Transform Target;
    public Transform Starting_point;

    public Vector3 Fixed_Target;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = this.gameObject;
        Starting_point = Enemy.transform;

        Player = GameObject.FindWithTag("Player");
        Target = Player.transform;

        Player_Cam = Player.GetComponentInChildren<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Fixed_Target = new Vector3(Target.position.x, Starting_point.position.y, Target.position.z);
        transform.LookAt(Fixed_Target);
    }
}
