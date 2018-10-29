using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image currentHealthBar;

    public float currentHitPoints = 100;
    private float maxHitPoints = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float ratio = currentHitPoints / maxHitPoints;
        currentHealthBar.rectTransform.localScale = new Vector2(ratio, 1);
        if (ratio < 0.25f)
        {
            currentHealthBar.color = Color.red;
        }
        else
        {
            currentHealthBar.color = Color.green;
        }
    }

    public void HealDamage(float heal)
    {
        currentHitPoints += heal;
        if (currentHitPoints > maxHitPoints)
        {
            currentHitPoints = 100;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHitPoints -= dmg;
        if (currentHitPoints < 0)
        {
            currentHitPoints = 0;
        }
    }

}
