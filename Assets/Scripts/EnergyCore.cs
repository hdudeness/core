using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    public GameManagement score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTriangle enemyTriangle = collision.GetComponent<EnemyTriangle>();
        if(enemyTriangle != null)
        {
            enemyTriangle.killEnemyTriangle();
            score.scoreUpdate(1);
        }
    }
}
