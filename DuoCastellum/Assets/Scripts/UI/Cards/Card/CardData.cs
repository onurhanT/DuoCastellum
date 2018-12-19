using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {
    public string Name;
    public string description;
    public int manaCost;
    public int health;
    public int damage;
    public int armour;

    public void Clone(MinionCard minion)
    {
        Name = minion.GetName();
        description = minion.GetDescription();
        manaCost = minion.GetManaCost();
        health = minion.GetHealth();
        damage = minion.GetDamage();
        armour = minion.GetArmour();
    }
}
