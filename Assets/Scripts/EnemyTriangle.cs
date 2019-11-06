using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTriangle : MonoBehaviour
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
    public GameManagement score;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        maxHealth = health;
        startingPosition = transform.position;
        distance = Math.Sqrt(transform.position.x* transform.position.x + transform.position.y* transform.position.y);
        travelTime = (float)distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.size = new Vector2(26 * (health / maxHealth), healthBar.size.y);
        timeSinceSpawn += Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, timeSinceSpawn / travelTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void BulletHit()
    {
        // TODO: Later pull damage from source
        health -= damgePerBullet;
        if(health <= 0)
        {
            killEnemyTriangle();
            score.scoreUpdate(1);
        }
    }

    public void killEnemyTriangle()
    {
        Destroy(gameObject);
    }
}
