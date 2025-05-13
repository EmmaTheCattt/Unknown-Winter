using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class basegunscript : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public GameObject Player;
    public TextMeshProUGUI Ammo_text;
    public Image Ammo_ui;

    public Image[] UI_bullets;

    public float bulletSpeed = 10;
    public float interval = 2;
    public float time = 2;

    public int Ammo_Amount_max = 6;
    public int Bullet_Amount = 6;
    public AudioSource flareSound;

    private void Start()
    {
        time = interval;
        Bullet_Amount = Ammo_Amount_max;
        Update_Bullet_count(0);
    }

    private void Update_Bullet_count(int bullet)
    {
        Bullet_Amount -= bullet;

        if (Bullet_Amount < 0)
        {
            Bullet_Amount = 0;
        }
        Ammo_text.text = Bullet_Amount.ToString() + "/" + Ammo_Amount_max.ToString();

        if (Ammo_Amount_max != Bullet_Amount)
        {
            UI_bullets[Bullet_Amount].enabled = false;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && time >= interval && Bullet_Amount > 0)
        {
            time = 0;
            Update_Bullet_count(1);
            var flarebullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            flarebullet.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z);
            flarebullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            flareSound.Play();
        }

        Update_Bullet_count(0);
    }
}
