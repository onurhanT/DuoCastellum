using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour, IController
{
    private int maxHealth;
    private int health;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        health = (int)player.GetComponent<Player>().GetHealth();
    }

    public void TakeDamage(int damage)
    {
        if(health <= 0)
        {
            if (CompareTag("player1"))
            {
                //YOU LOSE
            }
            else
            {
                //YOU WIN
            }
        }
        else
        {
            if (player.GetComponent<Player>())
            {
                player.GetComponent<Player>().TakeDamage(damage);
                this.health = (int)player.GetComponent<Player>().GetHealth();
            }
            else
            {
                player.GetComponent<EnemyPlayer>().TakeDamage(damage);
                this.health = (int)player.GetComponent<EnemyPlayer>().GetHealth();
            } 
        }

    }

    public int GetHealth() { return this.health; }
}
