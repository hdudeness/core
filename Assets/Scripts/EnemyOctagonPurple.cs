using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOctagonPurple : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float speed;
    private double distance;
    private float travelTime;
    public int health;
    public int pointValue;
    public SpriteRenderer healthBar;
    private float maxHealth;
    float timeSinceSpawn = 0;
    public GameManagement score;
    public EnemyManagement enemyManagement;

    public Transform bulletSpawn;
    public EnemyBullet enemyBulletPrefab;
    public int fireSpeed;

    IEnumerator EnemyFire()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireSpeed);

            EnemyBullet enemyBullet = Instantiate(enemyBulletPrefab, bulletSpawn.position, Quaternion.identity);
            enemyBullet.endingPosition = endingPosition;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
        maxHealth = health;
        startingPosition = transform.position;
        distance = Math.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        travelTime = (float)distance / speed;
        StartCoroutine(EnemyFire());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.size = new Vector2(5 * (health / maxHealth), healthBar.size.y);
        timeSinceSpawn += Time.deltaTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, timeSinceSpawn / travelTime);

    }


    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
            score.scoreUpdate(pointValue);
        }
    }

    public void killEnemy()
    {
        enemyManagement.enemyCount--;
        Destroy(gameObject);
    }
}
