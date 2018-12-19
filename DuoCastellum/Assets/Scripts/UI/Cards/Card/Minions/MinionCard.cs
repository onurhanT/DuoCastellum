using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinionCard
{
    private string Name;
    private string description;
    private int manaCost;
    private int health;
    private int damage;
    private int armour;


    public void SetName(string name) { this.Name = name; }
    public string GetName() { return this.Name; }

    public void SetDescription(string description) { this.description = description; }
    public string GetDescription() { return this.description; }

    public void SetManaCost(int manaCost) { this.manaCost = manaCost; }
    public int GetManaCost() { return this.manaCost; }

    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return this.health; }

    public void SetDamage(int damage) { this.damage = damage; }
    public int GetDamage() { return this.damage; }

    public void SetArmour(int armour) { this.armour = armour; }
    public int GetArmour() { return this.armour; }
}
