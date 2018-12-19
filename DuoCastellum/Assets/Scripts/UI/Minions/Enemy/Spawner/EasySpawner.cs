using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySpawner : ISpawnStrategy{

    //Wave holds the tag name of type of the enemies that will be created
    private string[] wave = { "Warrior", "Warrior", "Archer"};
    public EnemyMinion[] SpawnWave()
    {
        EnemyMinionFactory minionFactory = new EnemyMinionFactory();
        EnemyMinion[] listOfWave = new EnemyMinion[wave.Length];
        for (int i = 0; i < wave.Length; i++)
        {
            Debug.Log(wave[i]);
            listOfWave[i] = minionFactory.MakeEnemyMinion(wave[i]);
        }
        return listOfWave;
    }
}
