using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorCard : MinionCard {

    public WarriorCard() { 
        SetName("Warrior");
        SetDescription("Forth, and fear no darkness! Arise! Arise, Riders of Theoden! ");
        SetManaCost(4);
        SetHealth(5);
        SetDamage(3);
        SetArmour(2);
    }
}
