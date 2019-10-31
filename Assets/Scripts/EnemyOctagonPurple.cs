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
    public int damgePerBullet;
    public SpriteRenderer healthBar;
    private float maxHealth;
    float timeSinceSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        startingPosition = transform.position;
        distance = Math.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        travelTime = (float)distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.size = new Vector2(5 * (health / maxHealth), healthBar.size.y);
        timeSinceSpawn += Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, timeSinceSpawn / travelTime);

    }


    public void BulletHit()
    {
        health -= damgePerBullet;
        if (health <= 0)
        {
            killEnemy();
        }
    }

    public void killEnemy()
    {
        Destroy(gameObject);
    }
}
