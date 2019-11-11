using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSecondsRealtime(5);

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * Time.fixedUnscaledDeltaTime * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Shield shield = collision.GetComponent<Shield>();
        //if () ;

        EnemyTriangle enemyTriangle = collision.GetComponent<EnemyTriangle>();
        if (enemyTriangle != null)
        {
            enemyTriangle.Hit(damage);
            Destroy(gameObject);
        }

        EnemyOctagonPurple enemyOctagonPurple = collision.GetComponent<EnemyOctagonPurple>();
        if (enemyOctagonPurple != null)
        {
            enemyOctagonPurple.Hit(damage);
            Destroy(gameObject);
        }

        EnemyHeartPink enemyHeartPink = collision.GetComponent<EnemyHeartPink>();
        if (enemyHeartPink != null)
        {
            enemyHeartPink.Hit(damage);
            Destroy(gameObject);
        }
    }
}
