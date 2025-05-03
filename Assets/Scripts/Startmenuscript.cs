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
        /*startbutton.onClick.AddListener(Startbutton);

        if(endbutton != null)
        {
        endbutton.onClick.AddListener(Quit);

        }*/
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
    }

    public void Startbutton()
    {

        Debug.Log("button has been pressed");
        SceneManager.LoadScene(Scene);
        
        
    
        
    }
    public void Quit()
    {
        Application.Quit();
    }

    
}
