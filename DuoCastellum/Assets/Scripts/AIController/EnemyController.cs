using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IController
{
    public GameObject target;
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    public RuntimeAnimatorController death;
    public float lookRadius = 132;
    public int health;
    public int damage;
    public int armour;
    public IController target_script;
    bool idle_con;
    bool can_attack;
    bool is_enemy_died;
    bool is_dead;

    // StateMachineBehaviour behaviour;
    // Use this for initialization
    void Start()
    {
        //behaviour = anim.GetBehaviour<KnightBehaviour>();
        FillData(gameObject.GetComponent<MinionData>());
        SetTarget();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        is_dead = false;
        idle_con = false;
        can_attack = false;
        is_enemy_died = false;

    }

    private void FillData(MinionData minionData)
    {
        this.health = minionData.health;
        this.damage = minionData.damage;
        this.armour = minionData.armour;
    }
    // Update is called once per frame
    void Update()
    {
        if(health > 0)
        {
            is_dead = false;
            SetTarget();
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
                if (target.GetComponent<EnemyController>())
                {
                    target_script = target.GetComponent<EnemyController>();
                }
                else
                {
                    target_script = target.GetComponent<BaseController>();
                }
                
                float distance = Vector3.Distance(target.transform.position, transform.position);
                if (distance <= lookRadius)
                {
                    agent.SetDestination(target.transform.position);
                    if (distance <= agent.stoppingDistance)
                    {

                        anim.applyRootMotion = false;
                        can_attack = true;
                        FaceTarget();
                        if (target_script.GetHealth() <= 0)
                        {
                            is_enemy_died = true;
                            SetTarget();
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

    public void SetTarget()
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

    public bool CanAttack()
    {
        return can_attack;
    }
    public bool IsEnemyDied()
    {
        return is_enemy_died;
    }

    public void Attack()
    {
        target_script.TakeDamage(damage);
        Debug.Log("attacked");
    }

    public bool StayAtIdle()
    {
        return idle_con;
    }
    public bool IsAtDeathState()
    {
        return is_dead;
    }

    public void TakeDamage(int damage)
    {
        if (this.armour >= damage)
        {
            this.armour -= damage;
        }
        else
        {
            this.armour = 0;
            damage -= armour;
            this.health -= damage;
        }
    }
    public int GetHealth()
    {
        return this.health;
    }
}
