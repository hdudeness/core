using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnergyCore : MonoBehaviour
{
    public HealthManagement health;
    public GameManagement score;
    public AudioClip hitSound;
    public AudioSource hitSource;
    public EnemyManagement enemyManagement;
    // Start is called before the first frame update
    void Start()
    {
        hitSource = GetComponent<AudioSource>();
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            hitSource.Play();
            score.scoreUpdate(1);
            Destroy(collision.gameObject);
            health.updateCoreHealth(5);
            enemyManagement.enemyCount--;
        }
        else if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            hitSource.Play();
            score.scoreUpdate(2);
            Destroy(collision.gameObject);
            health.updateCoreHealth(20);
            enemyManagement.enemyCount--;
        }
        else if (collision.gameObject.name == "EnemyHeartPink(Clone)")
        {
            hitSource.Play();
            score.scoreUpdate(3);
            Destroy(collision.gameObject);
            health.updateCoreHealth(20);
            enemyManagement.enemyCount--;
        }
        else if (collision.gameObject.name == "EnemyCircleMaroon(Clone)")
        {
            hitSource.Play();
            EnemyCircleMaroon enemy = collision.GetComponent<EnemyCircleMaroon>();
            score.scoreUpdate(enemy.pointValue);
            Destroy(collision.gameObject);
            health.updateCoreHealth(25);
            enemyManagement.enemyCount--;
        }

    }
}
