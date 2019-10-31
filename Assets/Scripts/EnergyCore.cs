using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCore : MonoBehaviour
{
    public GameManagement score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemyTriangle(Clone)")
        {
            score.scoreUpdate(1);
            Destroy(collision.gameObject);
            return;
        }


        if (collision.gameObject.name == "EnemyOctagonPurple(Clone)")
        {
            score.scoreUpdate(2);
            Destroy(collision.gameObject);
        }

    }
}
