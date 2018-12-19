using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArcher : EnemyMinion
{
    public EnemyArcher()
    {
        SetName("Archer");
        SetHealth(6);
        SetDamage(7);
        SetArmour(1);
    }
}

