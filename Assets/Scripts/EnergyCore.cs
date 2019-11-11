using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnergyCore : MonoBehaviour
{
    public HealthManagement health;
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
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            Destroy(collision.gameObject);
            health.updateCoreHealth(5); // In the future pull damage from enemy type. 
            return;                      // For now just leave it defined here.
        }


        if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            Destroy(collision.gameObject);
            health.updateCoreHealth(20);
        }

        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {
            health.updateCoreHealth(5);
            enemyBullet.DestroyBullet();
        }

    }
}
