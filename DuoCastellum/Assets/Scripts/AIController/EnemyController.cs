using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    public RuntimeAnimatorController death;
    public float lookRadius = 132;
    public int health;
    public int damage;
    public EnemyController target_script;
    bool idle_con;
    bool can_attack;
    bool is_enemy_died;
    bool is_dead;

    // StateMachineBehaviour behaviour;

    // Use this for initialization
    void Start()
    {
        //behaviour = anim.GetBehaviour<KnightBehaviour>();
        setTarget();
        
        target_script = target.GetComponent<EnemyController>();
        is_dead = false;
        idle_con = false;
        can_attack = false;
        is_enemy_died = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            is_dead = false;
            setTarget();
            if (target == null)
            {
                idle_con = true; // stay at idle if there is no enemy
                anim.applyRootMotion = false;
                can_attack = false;
                is_enemy_died = true;
            }
            else
            {
                is_enemy_died = false;
                idle_con = false;
                target_script = target.GetComponent<EnemyController>();
                float distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance <= lookRadius)
                {

                    agent.SetDestination(target.transform.position);
                    if (distance <= agent.stoppingDistance)
                    {

                        anim.applyRootMotion = false;
                        can_attack = true;
                        FaceTarget();
                        if (target_script.health <= 0)
                        {
                            is_enemy_died = true;
                            setTarget();
                        }
                    }
                    else if (distance > agent.stoppingDistance)
                    {
                        can_attack = false;
                        FaceTarget();
                    }

                }
            }
        }
        else
        {
            is_dead = true;
            gameObject.tag = "DEATH";
            anim.runtimeAnimatorController = death;
            Destroy(gameObject, 5);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void setTarget()
    {
        if (this.gameObject.tag.Equals("player1"))
        {
            target = GameObject.FindWithTag("player2");
        }
        else if (this.gameObject.tag.Equals("player2"))
        {
            target = GameObject.FindWithTag("player1");
        }
        
    }

    public bool canAttack()
    {
        return can_attack;
    }
    public bool isEnemyDied()
    {
        return is_enemy_died;
    }

    public void attack()
    {
        target_script.takeDamage(damage);
        Debug.Log("attacked");
    }

    public void takeDamage(int damageTaken)
    {
        health = health - damageTaken;
    }

    public bool stayAtIdle()
    {
        return idle_con;
    }
    public bool isAtDeathState()
    {
        return is_dead;
    }

}
