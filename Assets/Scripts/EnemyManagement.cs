using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManagement : MonoBehaviour
{
    public EnemyTriangle enemyTriangle;
    public EnemyOctagonPurple enemyOctagonPurple;
    public EnemyHeartPink enemyHeartPink;
    public EnergyCore energyCore;
    public Transform enemyPosition;
    public int spawnTime;
    public GameManagement gameData;
    private Boolean isEnemyOctagonPurpleSpawned = false;
    private bool isEnemyHeartPinkSpawned = false;
    public int enemyCount = 0; // Make private after testing
    public int enemyLimit = 30;

    private System.Random rand = new System.Random();

    IEnumerator EnemyTriangleProducer()
    {
        while (true)
        {
            int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen
            yield return new WaitForSeconds(spawnTime);
            if (direction == 1 && enemyCount <= 30)
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
            else if (enemyCount <= 30)
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
        }
    }

    IEnumerator EnemyOctagonPurpleProducer()
    {
        while (enemyCount < enemyLimit)
        {
            int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen
            yield return new WaitForSeconds(spawnTime * 2);

            if (direction == 1)
            {
                EnemyOctagonPurple newEnemy = Instantiate(enemyOctagonPurple, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
            else
            {
                EnemyOctagonPurple newEnemy = Instantiate(enemyOctagonPurple, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
        }
    }

    IEnumerator EnemyHeartPinkProducer()
    {
        while (enemyCount < enemyLimit)
        {
            
            yield return new WaitForSeconds(spawnTime * 2);
            int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen
            

            if (direction == 1)
            {
                EnemyHeartPink newEnemy = Instantiate(enemyHeartPink, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
            else
            {
                EnemyHeartPink newEnemy = Instantiate(enemyHeartPink, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyCount++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyTriangleProducer());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameData.level >= 2 && !isEnemyOctagonPurpleSpawned)
        {
            StartCoroutine(EnemyOctagonPurpleProducer());
            isEnemyOctagonPurpleSpawned = true;
        }

        if (gameData.level >= 3 && !isEnemyHeartPinkSpawned)
        {
            StartCoroutine(EnemyHeartPinkProducer());
            isEnemyHeartPinkSpawned = true;
        }
    }
}
