using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetCard : MinionCard {

    public PuppetCard()
    {
        SetName("Puppet");
        SetDescription("Hurraay...");
        SetManaCost(2);
        SetHealth(4);
        SetDamage(2);
        SetArmour(1);
    }
}
