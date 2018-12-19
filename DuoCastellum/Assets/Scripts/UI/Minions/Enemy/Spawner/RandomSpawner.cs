using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : ISpawnStrategy
{
    //Wave holds the tag name of type of the enemies that can be created
    private string[] wave = { "Warrior", "Archer", "Boss"};
    public EnemyMinion[] SpawnWave()
    {
        EnemyMinionFactory minionFactory = new EnemyMinionFactory();
        int length = Random.Range(1, 4);
        EnemyMinion[] listOfWave = new EnemyMinion[length];
        for (int i = 0; i < length; i++)
        {
            int randNum = Random.Range(1, 10);
            if(randNum >= 1 && randNum < 6)
            {
                listOfWave[i] = minionFactory.MakeEnemyMinion(wave[0]);
            }
            else if(randNum >= 6 && randNum < 10)
            {
                listOfWave[i] = minionFactory.MakeEnemyMinion(wave[1]);
            }
            else
            {
                listOfWave[i] = minionFactory.MakeEnemyMinion(wave[2]);
            }
        }
        return listOfWave;
    }
}
