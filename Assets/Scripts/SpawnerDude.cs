﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnerDude : MonoBehaviour
{

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(RandomNavmeshLocation(50));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
