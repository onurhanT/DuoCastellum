using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : EnemyMinion
{
    public EnemyWarrior()
    {
        SetName("Warrior");
        SetHealth(10);
        SetDamage(5);
        SetArmour(3);
    }
}
