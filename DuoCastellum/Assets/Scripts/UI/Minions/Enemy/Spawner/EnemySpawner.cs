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
        }
        if (stopSpawning)
        {
            CancelInvoke("SpawnEnemies");
        }
    }

    private void InstantiateEnemy(EnemyMinion minion)
    {
        GameObject enemyMinion = Resources.Load("Characters/Enemy/" + minion.GetName()) as GameObject;
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
            enemyMinion.tag = "player2";
            Instantiate(enemyMinion, this.transform.position, this.transform.rotation);
        }
        else
        {
            Debug.Log("Can not spawn null...");
        }
    }
}
