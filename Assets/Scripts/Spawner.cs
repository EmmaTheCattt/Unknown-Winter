using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject WeepingAngel;
    [SerializeField] GameObject Spawnpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(10f);
       
        yield return wait;
        Instantiate(WeepingAngel, Spawnpoint.transform);
        
        
        
    }
}
