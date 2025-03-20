using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float StartingHealth = 100f;
    public Slider slider;
    public Image FillImage;
    
    
    public Color FullHealthColor = Color.red;
    public Color ZeroHealthColor = Color.black;
    private float CurrentHealth;
    private bool Dead;

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
            CurrentHealth = CurrentHealth - 20;
            SetHealthUI();
            Debug.Log(CurrentHealth);

        }
    }
}
