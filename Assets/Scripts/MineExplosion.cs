using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    // Explosion lifespan.
    private double timeLimit = 0.2;

    /* When an enemy is caught in the explosion, deal 20 damage.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Hit", 20);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0)
        {
            Destroy(gameObject);
        }
    }
}
