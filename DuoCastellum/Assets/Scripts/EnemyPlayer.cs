using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlayer : MonoBehaviour, IPlayer
{
    public float maxHealth = 100;
    public Slider healthBar;
    private float health;

    void Start()
    {
        this.health = maxHealth;
        healthBar.value = CalculateHealth();
    }

    public float CalculateHealth() { return health / maxHealth; }

    public float GetHealth() { return this.health; }

    public void TakeDamage(int damage)
    {
        if(this.health - damage <= 0)
        {
            this.health = 0;
        }
        else
        {
            this.health -= damage;
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.value = CalculateHealth();
    }
}
