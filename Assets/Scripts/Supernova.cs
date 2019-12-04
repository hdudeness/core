using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supernova : MonoBehaviour
{
    private float timer = 0f;
    private float scaleRate = 0.1f;
    private EnemyManagement enemyManagement;

    // Start is called before the first frame update
    void Start()
    {
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        
        if(timer > 1)
        {
            Destroy(gameObject);
        }
        transform.localScale += new Vector3(scaleRate, scaleRate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyTriangleCount--;
        }
        else if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyOctagonPurpleCount--;
        }
        else if (collision.gameObject.name == "EnemyHeartPink(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyHeartPinkCount--;
        }
        else if (collision.gameObject.name == "EnemyCircleMaroon(Clone)")
        {
            Destroy(collision.gameObject);
            enemyManagement.enemyCircleMaroonCount--;
        }

        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        if (enemyBullet != null)
        {
            enemyBullet.DestroyBullet();
        }

    }
}
