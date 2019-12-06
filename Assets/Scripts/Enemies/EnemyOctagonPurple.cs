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
    public GameManagement score;
    public EnemyManagement enemyManagement;
    public AudioClip explosion;

    public Transform bulletSpawn;
    public EnemyBullet enemyBulletPrefab;
    public int fireSpeed;

    //Used for moving around the core
    private float rotateSpeed = .1f;
    private float Radius = 15f;
    private Vector2 center;
    private float angle;

    public bool isNearbyHeartPink = false;

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
        angle = transform.position.y;
        center = new Vector2(0f, 0f);
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
        if (isNearbyHeartPink)
        {
            if (health < (int)maxHealth)
            {
                health += 1;
            }
        }

        healthBar.size = new Vector2(5 * (health / maxHealth), healthBar.size.y);
        angle += rotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = center + offset;
        if(Radius > 4)
        {
            Radius -= 0.01f;
        }
       

    }


    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
            enemyManagement.enemyOctagonPurpleCount--;
            score.scoreUpdate(pointValue);
        }
    }

    public void killEnemy()
    {
        AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 0, -10));
        Destroy(gameObject);
    }

    public void UpdateSpeed(float factor)
    {
        speed = speed * factor;
    }

}
