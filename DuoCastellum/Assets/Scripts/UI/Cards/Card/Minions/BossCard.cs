using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCard : MinionCard {

    public BossCard()
    {
        SetName("Boss");
        SetDescription("Spears shall be shaken,swords shall be splintered! A sword day...a red day...ere the sun rises!");
        SetManaCost(8);
        SetHealth(10);
        SetDamage(5);
        SetArmour(3);
    }
}
