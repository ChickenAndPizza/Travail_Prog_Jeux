using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
    public Image currentHealthBar;

    private float hitPoints = 100;
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
        float ratio = hitPoints / maxHitPoints;
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

    private void HealDamage(float heal)
    {
        hitPoints += heal;
        {
            hitPoints = 100;
        }
    }

    private void TakeDamage(float dmg)
    {
        hitPoints -= dmg;
        if (hitPoints < 0)
        {
            hitPoints = 0;
        }
    }

}
