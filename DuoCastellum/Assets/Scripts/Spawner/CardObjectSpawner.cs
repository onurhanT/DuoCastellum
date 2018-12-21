using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObjectSpawner : MonoBehaviour {
    public void SpawnMinion(CardData cardData)
    {
        GameObject minionPrefab = Resources.Load("Characters/Card/" + cardData.Name) as GameObject;
        if (minionPrefab.GetComponent<EnemyController>() == null)
        {
            minionPrefab.AddComponent<EnemyController>();
        }
        EnemyController enemyController = minionPrefab.GetComponent<EnemyController>();
        if (minionPrefab.GetComponent<MinionData>())
        {
            minionPrefab.GetComponent<MinionData>().health = cardData.health;
            minionPrefab.GetComponent<MinionData>().damage = cardData.damage;
            minionPrefab.GetComponent<MinionData>().armour = cardData.armour;
        }
        else
        {
            minionPrefab.AddComponent<MinionData>();
            minionPrefab.GetComponent<MinionData>().health = cardData.health;
            minionPrefab.GetComponent<MinionData>().damage = cardData.damage;
            minionPrefab.GetComponent<MinionData>().armour = cardData.armour;
        }
        minionPrefab.tag = "player1";
        Instantiate(minionPrefab, this.transform.position, this.transform.rotation);
    }
}
