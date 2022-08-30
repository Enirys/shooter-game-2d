using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameManager gm;

    [SerializeField]
    private GameObject[] enemyPrefab;
    [SerializeField]
    private Transform[] spawnPoints;
    private float timeBtwSpawns;
    [SerializeField]
    private float startTimeBtwSpawns;
    [SerializeField]
    private float decreaseTime;
    [SerializeField]
    private float minTime;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gm.gameStarted)
        {
            if (timeBtwSpawns <= 0)
            {
                int randPos = Random.Range(0, spawnPoints.Length);
                int randEnemy = Random.Range(0, enemyPrefab.Length);

                Instantiate(enemyPrefab[randEnemy], spawnPoints[randPos].transform.position, Quaternion.identity);
                if (startTimeBtwSpawns >= minTime)
                {
                    startTimeBtwSpawns -= decreaseTime;
                }
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
        
    }
}
