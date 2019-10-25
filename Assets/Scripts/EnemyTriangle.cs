using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTriangle : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float travelTime;
    public int health;
    public int damgePerBullet;
    public SpriteRenderer healthBar;
    private float maxHealth;
    float timeSinceSpawn;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        startingPosition = transform.position;
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
        health -= damgePerBullet;
        if(health <= 0)
        {
            killEnemyTriangle();
        }
    }

    public void killEnemyTriangle()
    {
        Destroy(gameObject);
    }
}
