using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineItem : MonoBehaviour
{
    public GameObject MineExplosion;
    
    // When enemy enters activation radius
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Spawn the explosion
        Instantiate(MineExplosion, gameObject.transform.position, Quaternion.identity);

        // Despawn the mine
        Destroy(gameObject);
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
