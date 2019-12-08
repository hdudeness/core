using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector3 startingPosition;
    public Vector3 endingPosition;
    public float speed;
    private double distance;
    private float travelTime;
    float timeSinceSpawn = 0;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        distance = Math.Sqrt(transform.position.x * transform.position.x + transform.position.y * transform.position.y);
        travelTime = (float)distance / speed;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, timeSinceSpawn / travelTime);
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyBullet();
        }
    }
}
