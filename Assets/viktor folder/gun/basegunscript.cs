using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basegunscript : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float interval = 2;
    public float time = 0;

    private void Start()
    {
        time = interval;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && time >= interval)
        {
            time = 0;
            var flarebullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            flarebullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
