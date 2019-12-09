using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedShield : MonoBehaviour
{
    private Shield shield;
    private EnemyManagement enemyManagement;

    // Start is called before the first frame update
    void Start()
    {
        shield = GameObject.Find("Shield").GetComponent<Shield>();
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, shield.angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyTriangleCount--;
        }
        else if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyOctagonPurpleCount--;
        }
        else if (collision.gameObject.name == "EnemyHeartPink(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyHeartPinkCount--;
        }
        else if (collision.gameObject.name == "EnemyCircleMaroon(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyCircleMaroonCount--;
        }

        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {
            enemyBullet.DestroyBullet();
        }

    }

}
