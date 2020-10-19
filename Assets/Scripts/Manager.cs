using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int Round = 1;
    int ZombiesinRound = 6; //How Many Zombies will Spawn this round
    public int ZombieCount = 0; //How Many Zombies are there right now
    public int DeadZombies = 0; //How many Zombies have died
    public int playerHealth = 2;
    public int MaxZombies; //How many zombies can there be max at one time
    public List<GameObject> spawnpoints;
    public GameObject spawnPrefab;
    public int points = 500;
    public TextMeshProUGUI scorecounter;
    public TextMeshProUGUI health;

    private void Start()
    {
        ZombieCount = 0;
        DeadZombies = 0;
    }

    private void Update()
    {
        if (ZombieCount < MaxZombies && ZombieCount + DeadZombies <= ZombiesinRound)
        {
            Instantiate(spawnPrefab, spawnpoints[Random.Range(0, spawnpoints.Count)].transform);
            ZombieCount++;
        }
        scorecounter.text = points.ToString();
        health.text = playerHealth.ToString();
        if (DeadZombies == ZombiesinRound)
        {
            Invoke("NextRound", 5f);
        }   
    }

    public void NextRound()
    {
        DeadZombies = 0;
        Round++;
        ZombiesinRound += 3;
        ZombieCount = ZombiesinRound;
    }
}
