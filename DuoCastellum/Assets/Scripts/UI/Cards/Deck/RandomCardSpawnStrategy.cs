using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCardSpawnStrategy : ICardSpawnStrategy {
    public MinionCard SpawnCard()
    {
        CardFactory cardFactory = new CardFactory();
        int randNum = Random.Range(1, 10);
        if (randNum >= 1 && randNum < 6)
        {
            return cardFactory.MakeCard("Warrior");
        }
        else if (randNum >= 6 && randNum < 10)
        {
            return cardFactory.MakeCard("Puppet");
        }
        else
        {
            return cardFactory.MakeCard("Boss");
        }
    }
}
