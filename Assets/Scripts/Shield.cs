using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{
    public GameManagement gameData;
    public float angle;
    public float angleChange;
    public EnemyManagement enemyManagement;

    public Transform bulletSpawnPoint;

    public Bullet bulletPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateLeft()
    {
        angle += angleChange;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void RotateRight()
    {
        angle -= angleChange;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTriangle enemyTriangle = collision.GetComponent<EnemyTriangle>();
        if (enemyTriangle != null)
        {
            enemyTriangle.killEnemyTriangle();
            gameData.scoreUpdate(enemyTriangle.pointValue);
            enemyManagement.enemyTriangleCount--;
            return;
        }

        EnemyOctagonPurple enemyOxtagonPurple = collision.GetComponent<EnemyOctagonPurple>();
        if (enemyOxtagonPurple != null)
        {
            gameData.scoreUpdate(enemyOxtagonPurple.pointValue);
            Destroy(collision.gameObject);
            enemyManagement.enemyOctagonPurpleCount--;
            return;
        }

        EnemyHeartPink enemyHeartPink = collision.GetComponent<EnemyHeartPink>();
        if (enemyHeartPink != null)
        {
            gameData.scoreUpdate(enemyHeartPink.pointValue);
            Destroy(collision.gameObject);
            enemyManagement.enemyHeartPinkCount--;
            return;
        }

        EnemyCircleMaroon enemyCircleMaroon = collision.GetComponent<EnemyCircleMaroon>();
        if (enemyCircleMaroon != null)
        {
            gameData.scoreUpdate(enemyCircleMaroon.pointValue);
            Destroy(collision.gameObject);
            enemyManagement.enemyCircleMaroonCount--;
            return;
        }

        EnemyOctagonPurple enemyOctagonPurple = collision.GetComponent<EnemyOctagonPurple>();
        if (enemyOctagonPurple != null)
        {
            enemyOctagonPurple.killEnemy();
            gameData.scoreUpdate(2);
        }

        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {
            enemyBullet.DestroyBullet();
        }
    }

    public void FireBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, angle));
        
    }

    

}
