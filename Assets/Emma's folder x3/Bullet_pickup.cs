using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet_pickup : MonoBehaviour, IInteractNew
{

    public basegunscript gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.FindGameObjectWithTag("PlayerCam").GetComponent<basegunscript>();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        gun.Bullet_Amount = gun.Ammo_Amount_max;
        Destroy(gameObject);
    }
}
