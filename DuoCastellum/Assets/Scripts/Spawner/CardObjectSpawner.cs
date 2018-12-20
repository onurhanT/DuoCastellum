using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObjectSpawner : MonoBehaviour {
    public void SpawnMinion(CardData cardData)
    {
        GameObject minionPrefab = Resources.Load("Characters/Friend/" + cardData.Name) as GameObject;
        if (minionPrefab.GetComponent<EnemyController>() == null)
        {
            minionPrefab.AddComponent<EnemyController>();
        }
        EnemyController enemyController = minionPrefab.GetComponent<EnemyController>();
        enemyController.maxHealth = cardData.health;
        enemyController.health = cardData.health;
        enemyController.maxArmour = cardData.armour;
        enemyController.armour = cardData.armour;
        Instantiate(minionPrefab, this.transform.position, this.transform.rotation);
    }
}
