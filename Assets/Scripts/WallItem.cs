using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallItem : MonoBehaviour
{
    /* When an enemy collides with the wall, for the entire duration
     * that they stick inside of the wall, their speed should be halved.
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("UpdateSpeed", .5);
        }
    }

    /* When an enemy exits the wall fully restore the speed.
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("UpdateSpeed", 2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
