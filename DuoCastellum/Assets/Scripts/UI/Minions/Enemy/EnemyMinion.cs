using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMinion {
    private string prefabName;
    private int health;
    private int damage;
    private int armour;

    public void SetName(string name) { this.prefabName = name;  }
    public string GetName() { return this.prefabName; }

    public void SetHealth(int health) { this.health = health; }
    public int GetHealth() { return this.health; }

    public void SetDamage(int damage) { this.damage = damage; }
    public int GetDamage() { return this.damage; }

    public void SetArmour(int armour) { this.armour = armour; }
    public int GetArmour() { return this.armour; }
}
