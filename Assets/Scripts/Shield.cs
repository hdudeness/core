using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{
    public GameManagement gameData;
    public static float angle;
    public float angleChange;
    public EnemyManagement enemyManagement;

    public Transform bulletSpawnPoint;
    public Bullet bulletPrefab;
    public GameObject tripleShot;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;
    private static bool tripleShotFlag;
    private float tripleShotTimer = 0;
    public float tripleShotDuration;
    private float angleOffSet = (float)22.5;

    // Start is called before the first frame update
    void Start()
    {
        tripleShotFlag = false;
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tripleShotFlag)
        {
            tripleShot.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            tripleShot.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (tripleShotFlag && tripleShotTimer < tripleShotDuration)
        {
            tripleShotTimer += Time.deltaTime;
        }
        else if (tripleShotFlag)
        {
            tripleShotFlag = false;
            tripleShotTimer = 0;
        }
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

        //Oxtagon doesn't exist
        /*
        EnemyOctagonPurple enemyOxtagonPurple = collision.GetComponent<EnemyOctagonPurple>();
        if (enemyOxtagonPurple != null)
        {
            gameData.scoreUpdate(enemyOxtagonPurple.pointValue);
            enemyOxtagonPurple.killEnemyOxtagonPurple();
            enemyManagement.enemyOctagonPurpleCount--;
            return;
        }
        */

        EnemyHeartPink enemyHeartPink = collision.GetComponent<EnemyHeartPink>();
        if (enemyHeartPink != null)
        {
            gameData.scoreUpdate(enemyHeartPink.pointValue);
            enemyHeartPink.killEnemy();
            enemyManagement.enemyHeartPinkCount--;
            return;
        }

        EnemyCircleMaroon enemyCircleMaroon = collision.GetComponent<EnemyCircleMaroon>();
        if (enemyCircleMaroon != null)
        {
            gameData.scoreUpdate(enemyCircleMaroon.pointValue);
            enemyCircleMaroon.killEnemy();
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
        if (tripleShotFlag)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint2.position, Quaternion.Euler(0, 0, angle + angleOffSet));
            Instantiate(bulletPrefab, bulletSpawnPoint3.position, Quaternion.Euler(0, 0, angle - angleOffSet));
        }
    }

    public static void ActivateTripleShot()
    {
        tripleShotFlag = true;
    }

}
