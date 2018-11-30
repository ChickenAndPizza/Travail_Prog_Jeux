﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour, Attackable
{
    public Image currentHealthBar;

    private float currentHitPoints;
    private float maxHitPoints = 100;
    public float shakeAmount = 0.1f;
    public float shakeLength = 0.1f;
    private CameraShake camShake;

    private void Start()
    {
        UpdateHealthBar();
        camShake = GameObject.FindObjectOfType<CameraShake>().GetComponent<CameraShake>();

    }

    private void Update()
    { 
        if(SceneManager.GetActiveScene().name != "FirstScene")
        {
            Image healthPicture = GameObject.FindGameObjectWithTag("CurrentHealth").GetComponent<Image>();
            if (healthPicture != null)
            {
                currentHealthBar = healthPicture;
            }
        }
       
        currentHitPoints = GetComponentInParent<PlayerStats>().health;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = currentHitPoints / maxHitPoints;
        if (currentHealthBar != null)
        {
            currentHealthBar.rectTransform.localScale = new Vector2(ratio, 1);
        }
        if (ratio < 0.25f && currentHealthBar != null)
        {
            currentHealthBar.color = Color.red;
        }
        else if (ratio < 0.5f && ratio >=.25f && currentHealthBar != null)
        {
            currentHealthBar.color = Color.yellow;
        }
        else if (currentHealthBar != null)
        {
            currentHealthBar.color = Color.green;
        }
    }

    public void Attacked(int damage)
    {
        damage -= GetComponentInParent<PlayerStats>().defense;
        currentHitPoints -= damage;
        if (currentHitPoints < 0)
        {
            currentHitPoints = 0;
        }
        GetComponentInParent<PlayerStats>().health = currentHitPoints;
        camShake.Shake(shakeAmount,shakeLength);
        if(currentHitPoints <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GetComponentInParent<PlayerStats>().health = maxHitPoints;


        }
    }

    public void Heal(int healPower)
    {
        currentHitPoints += healPower;
        if (currentHitPoints > maxHitPoints)
        {
            currentHitPoints = 100;
        }
        GetComponentInParent<PlayerStats>().health = currentHitPoints;
    }
}
