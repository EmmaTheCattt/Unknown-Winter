using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerHealth : MonoBehaviour
{
    public float StartingHealth = 100f;
    public Slider slider;
    public Image FillImage;
    
    
    public Color FullHealthColor = Color.red;
    public Color ZeroHealthColor = Color.black;
    private float CurrentHealth;
    private bool Dead;

    private bool isInEnemyRange;

    private void OnEnable()
    {
        
        CurrentHealth = StartingHealth;
        Dead = false;
        SetHealthUI();
        
    }
    public void TakeDamage(float damage) 
    {
    CurrentHealth -= damage;
        SetHealthUI();
       
        if (CurrentHealth <= 0 && !Dead)
        { 
        OnDeath();
        }
    }

    private void SetHealthUI()
    {
        slider.value = CurrentHealth;
        FillImage.color = Color.Lerp(ZeroHealthColor,FullHealthColor,CurrentHealth / StartingHealth);

    }

    private void OnDeath() 
    { 
        Dead = true; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            isInEnemyRange = true;

            StartCoroutine(takeDamage(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isInEnemyRange = false;

            StopCoroutine(takeDamage(other));
        }
    }

    IEnumerator takeDamage(Collider other)
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        
        while (isInEnemyRange == true)
        {
            yield return wait;
            CurrentHealth = CurrentHealth - 20;
            SetHealthUI();
            Debug.Log(CurrentHealth);
        }
    }
}
