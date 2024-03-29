﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircleMaroon : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float speed;
    private double distance;
    private float travelTime;
    public int health;
    public int damage;
    public int pointValue;
    public SpriteRenderer healthBar;
    private float maxHealth;
    float timeSinceSpawn = 0;
    public GameManagement score;
    public EnemyManagement enemyManagement;
    public AudioClip explosion;
    public float movementTime = 20;
    public bool isNearbyHeartPink = false;
    private double healingCooldown = 0.5;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
        maxHealth = health;
        startingPosition = transform.position;
        distance = Math.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        travelTime = (float)distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        healingCooldown -= Time.deltaTime;
        if (isNearbyHeartPink)
        {
            if (healingCooldown <= 0)
            {
                if (health < (int)maxHealth)
                {
                    health += 4;
                    healingCooldown = 0.5;
                }
            }
        }

        healthBar.size = new Vector2(6 * (health / maxHealth), healthBar.size.y);
        timeSinceSpawn += Time.deltaTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, timeSinceSpawn / travelTime);

        float normalTime = timeSinceSpawn / movementTime;
        float sineTime = normalTime * Mathf.PI * 6;
        float sinVal = Mathf.Sin(sineTime);
        transform.position = new Vector3(transform.position.x, sinVal*3);

    }


    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
            enemyManagement.enemyCircleMaroonCount--;
            score.scoreUpdate(pointValue);
        }
    }

    public void killEnemy()
    {
        AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 0, -10));
        Destroy(gameObject);
    }
}
