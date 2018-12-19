using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory{
    public MinionCard MakeCard(string name)
    {
        if (string.Equals(name, "Warrior"))
        {
            return new WarriorCard();
        }else if (string.Equals(name, "Boss"))
        {
            return new BossCard();
        }else if (string.Equals(name, "Puppet"))
        {
            return new PuppetCard();
        }else
        {
            Debug.Log("Nothing created...");
            return null;
        }
    }
}
