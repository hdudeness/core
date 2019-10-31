using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameManagement gameData;
    public float angle;
    public float angleChange;

    public Transform bulletSpawnPoint;

    public Bullet bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateLeft()
    {
        angle += angleChange;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void RotateRight()
    {
        angle -= angleChange;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyTriangle enemyTriangle = collision.GetComponent<EnemyTriangle>();
        if (enemyTriangle != null)
        {
            enemyTriangle.killEnemyTriangle();
            gameData.scoreUpdate(1);
        }
    }

    public void FireBullet()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, angle-45));
    }
}
