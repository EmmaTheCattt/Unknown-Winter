using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startmenuscript : MonoBehaviour
{
    public string Scene = "Level 1";
    public Button startbutton;
    public Button endbutton;

    public void Start()
    {
        startbutton.onClick.AddListener(Startbutton);
        endbutton.onClick.AddListener(Quit);
        
    }

    public void Startbutton()
    {
        SceneManager.LoadScene(Scene);
        
        
    
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {

    }
}
