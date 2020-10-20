using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ZStates { IDLE, WALK, RUN, ATTACK, DIE }

public class Zombie : MonoBehaviour
{
    int health = 5;
    int damage = 1;
    bool inAnimation, notstartedDie;
    public ZStates currentState;
    public GameObject target;
    public Animator ani;
    public NavMeshAgent agent;
    public Manager man;
    public GameObject hitbox;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        man = target.GetComponent<Manager>();
        currentState = ZStates.IDLE;
        inAnimation = false;
        hitbox.SetActive(false);
        notstartedDie = true;
        man = target.GetComponent<Manager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!inAnimation)
        {
            currentState = setState();
        }
        if (health <= 0 && notstartedDie)
        {
            ResetBools();
            currentState = ZStates.DIE;
            inAnimation = true;
            StartCoroutine("die");
        }
        else
        {
            if (currentState == ZStates.IDLE)
            {
                ResetBools();
                agent.ResetPath();
                ani.SetTrigger("ReturnToIdle");
            }
            else if (currentState == ZStates.ATTACK && !inAnimation)
            {
                ResetBools();
                inAnimation = true;
                StartCoroutine("attack");
            }
            else
            {
                agent.SetDestination(target.transform.position);
                if (currentState == ZStates.WALK)
                {
                    if (!ani.GetBool("IsWalking"))
                    {
                        ani.SetBool("IsWalking", true);
                    }
                }
                else if (currentState == ZStates.RUN)
                {
                    ani.SetBool("IsWalking", true);
                }
            }
        }

    }

    ZStates setState()
    {
        if (!inAnimation)
        {
            if (health <= 0)
            {
                return ZStates.DIE;
            }
            else
            {
                if (!target)
                {
                    return ZStates.IDLE;
                }
                else
                {
                    if (Vector3.Distance(gameObject.transform.position, target.transform.position) < 4.0f)
                    {
                        return ZStates.ATTACK;
                    }
                    else
                    {
                        if (man.Round <= 5)
                        {
                            agent.speed = 1f;
                            return ZStates.WALK;
                        }
                        else
                        {
                            agent.speed = 3f;
                            return ZStates.RUN;
                        }
                    }
                }
            }
        }
        return ZStates.IDLE;
    }
    IEnumerator attack()
    {
        agent.isStopped = true;
        ani.SetTrigger("Attack");
        yield return new WaitForSeconds(0.25f);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        hitbox.SetActive(false);
        inAnimation = false;
        agent.isStopped = false;
        yield return null;
    }
    IEnumerator die()
    {
        man.points += 100;
        man.DeadZombies++;
        man.ZombieCount--;
        Debug.Log("ded");
        notstartedDie = false;
        agent.isStopped = true;
        ani.SetTrigger("Dead");
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
        yield return null;
    }
    void ResetBools()
    {
        ani.SetBool("IsWalking", false);
        ani.SetBool("IsRunning", false);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
        health -= damage;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Manager>())
        {
            other.GetComponent<Manager>().TakeDamage(damage);
        }
    }
}
