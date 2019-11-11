using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManagement : MonoBehaviour
{
    public EnemyTriangle enemyTriangle;
    public EnemyOctagonPurple enemyOctagonPurple;
    public EnemyHeartPink enemyHeartPink;
    public EnemyCircleMaroon enemyCircleMaroon;
    public EnergyCore energyCore;
    public Transform enemyPosition;
    public int spawnTime;
    public GameManagement gameData;
    private Boolean isEnemyOctagonPurpleSpawned = false;
    private bool isEnemyHeartPinkSpawned = false;
    private bool isEnemyCircleMaroonSpawned = false;
    public int enemyTriangleCount = 0; // Make private after testing
    public int enemyTriangleLimit = 20;
    public int enemyOctagonPurpleCount = 0;
    public int enemyOctagonPurpleLimit = 5;
    public int enemyHeartPinkCount = 0;
    public int enemyHeartPinkLimit = 5;
    public int enemyCircleMaroonCount = 0;
    public int enemyCircleMaroonLimit = 2;

    private System.Random rand = new System.Random();

    IEnumerator EnemyTriangleProducer()
    {
        while (true)
        {
            int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen
            yield return new WaitForSeconds(spawnTime);
            if (direction == 1 && enemyTriangleCount < enemyTriangleLimit)
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyTriangleCount++;
            }
            else if (enemyTriangleCount < enemyTriangleLimit)
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
                enemyTriangleCount++;
            }
        }
    }

    IEnumerator EnemyOctagonPurpleProducer()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(spawnTime);
            if (enemyOctagonPurpleCount < enemyOctagonPurpleLimit)
            {
                int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen
                if (direction == 1)
                {
                    EnemyOctagonPurple newEnemy = Instantiate(enemyOctagonPurple, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyOctagonPurpleCount++;
                }
                else
                {
                    EnemyOctagonPurple newEnemy = Instantiate(enemyOctagonPurple, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyOctagonPurpleCount++;
                }
            }
        }
    }

    IEnumerator EnemyHeartPinkProducer()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (enemyHeartPinkCount < enemyHeartPinkLimit)
            {
                int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen


                if (direction == 1)
                {
                    EnemyHeartPink newEnemy = Instantiate(enemyHeartPink, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyHeartPinkCount++;
                }
                else
                {
                    EnemyHeartPink newEnemy = Instantiate(enemyHeartPink, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyHeartPinkCount++;
                }
            }
        }
    }

    IEnumerator EnemyCircleMaroonProducer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (enemyCircleMaroonCount < enemyCircleMaroonLimit)
            {
                int direction = rand.Next(1, 3);    //Enemy will be spawned in the left or the right of the screen


                if (direction == 1)
                {
                    EnemyCircleMaroon newEnemy = Instantiate(enemyCircleMaroon, new Vector3(10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyCircleMaroonCount++;
                }
                else
                {
                    EnemyCircleMaroon newEnemy = Instantiate(enemyCircleMaroon, new Vector3(-10, rand.Next(0, 7), 0), Quaternion.identity);
                    newEnemy.endingPosition = energyCore.transform.position;
                    enemyCircleMaroonCount++;
                }
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
            enemyTriangleLimit = 25;
            StartCoroutine(EnemyOctagonPurpleProducer());
            isEnemyOctagonPurpleSpawned = true;
        }

        if (gameData.level >= 3 && !isEnemyHeartPinkSpawned)
        {
            enemyTriangleLimit = 20;
            enemyOctagonPurpleLimit = 5;
            StartCoroutine(EnemyHeartPinkProducer());
            isEnemyHeartPinkSpawned = true;
        }

        if (gameData.level >= 4 && !isEnemyCircleMaroonSpawned)
        {
            enemyTriangleLimit = 15;
            enemyOctagonPurpleLimit = 5;
            enemyHeartPinkLimit = 3;
            StartCoroutine(EnemyCircleMaroonProducer());
            isEnemyCircleMaroonSpawned = true;
        }
    }
}
