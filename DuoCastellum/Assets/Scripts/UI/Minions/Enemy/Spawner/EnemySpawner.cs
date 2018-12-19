using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public ISpawnStrategy strategy;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;

    void Start()
    {
        this.strategy = new EasySpawner();
        InvokeRepeating("SpawnEnemies", spawnTime, spawnDelay);
    }

    public void SpawnEnemies()
    {
        EnemyMinion[] enemyWave = strategy.SpawnWave();
        foreach(EnemyMinion minion in enemyWave)
        {
            InstantiateEnemy(minion);
            Debug.Log("spawning");
        }
        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemies");
        }
    }

    private void InstantiateEnemy(EnemyMinion minion)
    {
        GameObject enemyMinion = Resources.Load(minion.GetName()) as GameObject;
        if (enemyMinion != null)
        {
            if (enemyMinion.GetComponent("MinionData") != null)
            {
                //enemyMinion.GetComponent<MinionData>().Clone(minion);
            }
            else
            {
                enemyMinion.AddComponent<MinionData>();
                enemyMinion.GetComponent<MinionData>().Clone(minion);
            }
            Instantiate(enemyMinion, this.transform.position, this.transform.rotation);
            Debug.Log("spawned");
        }
        else
        {
            Debug.Log("Can not spawn null...");
        }
    }
}
