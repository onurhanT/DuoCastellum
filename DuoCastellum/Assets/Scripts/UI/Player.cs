using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public static float maxHealth = 30;
    public static float maxMana = 10;
    public Slider healthBar;
    public Slider manaBar;
    public float manaTime;
    public float manaAmount;
    private float health;
    private float mana;
    
	void Start () {
        this.health = maxHealth;
        this.mana = 0;
        healthBar.value = CalculateHealth();
        manaBar.value = CalculateMana();;
        InvokeRepeating("GainMana", manaTime, manaTime);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(5);
        }
        healthBar.value = CalculateHealth();
        manaBar.value = CalculateMana();
    }

    private void GainMana()
    {
        GainMana(this.manaAmount);
    }
	
    public void TakeDamage(int damage) {
        this.health -= damage;
    }
    public void ReduceMana(float manaCost) { this.mana -= manaCost; }
    public void Heal(float healAmount)
    {
        float tempHealth = this.health + healAmount;
        if (tempHealth >= maxMana)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += healAmount;
        }
    }
    public void GainMana(float manaAmount)
    {
        float tempMana = this.mana + manaAmount;
        if (tempMana >= maxMana)
        {
            this.mana = maxMana;
        }
        else
        {
            this.mana += manaAmount;
        }
    }
    public float CalculateHealth() { return health / maxHealth; }
    public float CalculateMana() { return mana / maxMana; }
    public bool CanDrawCard(int mana) { return this.mana >= mana; }
}