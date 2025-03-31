using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flarebullet : MonoBehaviour
{
    public Rigidbody RB;
    public Collider Col;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            BulletLand();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletLand();
    }

    private void BulletLand()
    {
        RB.velocity = new Vector3(0, 0, 0);
        RB.useGravity = false;
        Col.enabled = false;
    }
}
