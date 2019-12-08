using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public HealthManagement health;
    public Supernova nova;
    public BladeOrbit bladeOrbit;

    public void healthRestore() {
        health.updateCoreHealth(-10);
    }

    public void wall()
    {
        // Spawn an instance of the wall prefab.
    }
    
    public void supernova()
    {
        Supernova newNova = Instantiate(nova, new Vector3(0f, 0f, 0), Quaternion.identity);
    }


    public void orbitalBlades()
    {
        BladeOrbit newBladeOrbit = Instantiate(bladeOrbit, new Vector3(5f, 5f, 0), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
