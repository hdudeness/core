using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedShield : MonoBehaviour
{
    private Shield shield;
    private EnemyManagement enemyManagement;
    private float timer = 0f;
    private float timeLimit = 30f;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.position.z);
        transform.rotation = GameObject.Find("Shield").transform.rotation;
        //Debug.Log(GameObject.Find("Shield").transform.position.z);
        shield = GameObject.Find("Shield").GetComponent<Shield>();
        enemyManagement = GameObject.Find("EnemyManagement").GetComponent<EnemyManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.Euler(0, 0, shield.angle);
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
