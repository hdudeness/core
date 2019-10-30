using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ScoreManagement score;
    public float angle;
    public float angleChange;

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
            score.scoreUpdate(1);
        }
    }
}
