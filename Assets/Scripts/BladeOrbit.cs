using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeOrbit : MonoBehaviour
{

    private Vector2 center;
    private float angle;
    private float rotateSpeed = 1f;
    private float radius = 10f;
    private float TimeSinceSpawn = 0;
    private float timeLimit = 20f;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.position.y;
        center = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceSpawn += Time.deltaTime;
        angle += rotateSpeed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = center + offset;
        
        if(TimeSinceSpawn > timeLimit)
        {
            radius += 0.05f;
            if(radius > 10)
            {
                Destroy(gameObject);
            }
            
        }
        else if (radius > 3)
        {
            radius -= 0.1f;
        }
    }
}
