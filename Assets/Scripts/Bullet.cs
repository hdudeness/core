using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public EnemyManagement enemyManagement;
    public AudioClip hitSound;
    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(shootSound, new Vector3(0, 0, -5));
        StartCoroutine(DestroyAfterTime());
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSecondsRealtime(5);

        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Shield shield = collision.GetComponent<Shield>();
        //if () 
        EnemyTriangle enemyTriangle = collision.GetComponent<EnemyTriangle>();
        if (enemyTriangle != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, -5));
            enemyTriangle.Hit(damage);
            Destroy(gameObject);
            return;
        }

        EnemyOctagonPurple enemyOctagonPurple = collision.GetComponent<EnemyOctagonPurple>();
        if (enemyOctagonPurple != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, -5));
            enemyOctagonPurple.Hit(damage);
            Destroy(gameObject);
            return;
        }

        EnemyHeartPink enemyHeartPink = collision.GetComponent<EnemyHeartPink>();
        if (enemyHeartPink != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, -5));
            enemyHeartPink.Hit(damage);
            Destroy(gameObject);
            return;
        }

        EnemyCircleMaroon enemyCircleMaroon = collision.GetComponent<EnemyCircleMaroon>();
        if (enemyCircleMaroon != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, new Vector3(0, 0, -5));
            enemyCircleMaroon.Hit(damage);
            Destroy(gameObject);
            return;
        }
    }
}
