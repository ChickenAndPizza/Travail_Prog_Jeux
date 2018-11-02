using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, Attackable
{
    public Image currentHealthBar;

    private float currentHitPoints;
    private float maxHitPoints = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
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
        if (ratio < 0.25f)
        {
            currentHealthBar.color = Color.red;
        }
        else if (ratio < 0.5f && ratio >=.25f)
        {
            currentHealthBar.color = Color.yellow;
        }
        else
        {
            currentHealthBar.color = Color.green;
        }
    }

    public void Attacked(int damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints < 0)
        {
            currentHitPoints = 0;
        }
        GetComponentInParent<PlayerStats>().health = currentHitPoints;
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
