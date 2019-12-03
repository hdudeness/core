using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public HealthManagement health;

    public void healthRestore() {
        health.updateCoreHealth(-10);
    }

    public void wall()
    {
        // Spawn an instance of the wall prefab.
    }
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
