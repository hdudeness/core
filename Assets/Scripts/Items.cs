using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public HealthManagement health;
    public Supernova nova;
    public WallItem wallItem;

    public void healthRestore() {
        health.updateCoreHealth(-10);
    }

    // Takes x, y, and angle coords from touch input
    public void wall()
    {
        WallItem newWall = Instantiate(wallItem, new Vector3(3f, 0f, 0), Quaternion.identity);
    }

    // Takes x, y coords from touch input
    public void mine()
    {

    }
    
    public void supernova()
    {
        Supernova newNova = Instantiate(nova, new Vector3(0f, 0f, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
