using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItem : MonoBehaviour
{
    // Wall has a 30 second lifespan.
    private double timeLimit = 30.0;

    /* When an enemy collides with the wall they should be damaged for 5 points.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Hit", 5);
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
