using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionData : MonoBehaviour {
    public string prefabName;
    public int health;
    public int damage;
    public int armour;
    
    public void Clone(EnemyMinion minion)
    {
        this.prefabName = minion.GetName();
        this.health = minion.GetHealth();
        this.damage = minion.GetDamage();
        this.armour = minion.GetArmour();
    }
}
