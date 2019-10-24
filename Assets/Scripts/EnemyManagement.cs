using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManagement : MonoBehaviour
{
    public EnemyTriangle enemyTriangle;
    public EnergyCore energyCore;
    public Transform enemyPosition;

    private System.Random rand = new System.Random();

    IEnumerator EnemyTriangleProducer()
    {
        while (true)
        {
            int direction = rand.Next(1, 3);
            yield return new WaitForSeconds(1);

            if(direction == 1)
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(5, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
            }
            else
            {
                EnemyTriangle newEnemy = Instantiate(enemyTriangle, new Vector3(-5, rand.Next(0, 7), 0), Quaternion.identity);
                newEnemy.endingPosition = energyCore.transform.position;
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
    }
}
