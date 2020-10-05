using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public int Round = 1;
    int ZombiesinRound = 6;
    int ZombieCount = 6;
    public int playerHealth = 2;
    List<GameObject> spawnpoints;
    public GameObject spawnPrefab;
    public int points = 5000;
    public TextMeshProUGUI scorecounter;
    public TextMeshProUGUI health;

    private void Start()
    {
        
    }

    private void Update()
    {
        scorecounter.text = points.ToString();
        health.text = playerHealth.ToString();
        if (ZombieCount == 0)
        {

        }   
    }

    public void NextRound()
    {
        Round++;
        ZombiesinRound += 3;
    }
}
