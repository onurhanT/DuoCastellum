using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyMinion
{
    public EnemyBoss()
    {
        SetName("Boss");
        SetHealth(20);
        SetDamage(6);
        SetArmour(7);
    }
}
