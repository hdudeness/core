using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPinkHealthRestore : MonoBehaviour
{
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
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            EnemyTriangle enemy = collision.GetComponent<EnemyTriangle>();
            enemy.isNearbyHeartPink = true;
        }
        else if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            EnemyOctagonPurple enemy = collision.GetComponent<EnemyOctagonPurple>();
            enemy.isNearbyHeartPink = true;
        }
        else if (collision.gameObject.name == "EnemyCircleMaroon(Clone)")
        {
            EnemyCircleMaroon enemy = collision.GetComponent<EnemyCircleMaroon>();
            enemy.isNearbyHeartPink = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            EnemyTriangle enemy = collision.GetComponent<EnemyTriangle>();
            enemy.isNearbyHeartPink = false;
        }
        else if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            EnemyOctagonPurple enemy = collision.GetComponent<EnemyOctagonPurple>();
            enemy.isNearbyHeartPink = false;
        }
        else if (collision.gameObject.name == "EnemyCircleMaroon(Clone)")
        {
            EnemyCircleMaroon enemy = collision.GetComponent<EnemyCircleMaroon>();
            enemy.isNearbyHeartPink = false;
        }
    }
}
