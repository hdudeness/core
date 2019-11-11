using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed = false;
    public Shield shieldControl;
    private float timeSinceLastShot = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot > 0 && timeSinceLastShot < 0.2)
        {
            timeSinceLastShot += Time.deltaTime;
        }
        else
        {
            shieldControl.FireBullet();
            timeSinceLastShot = 0.1f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        timeSinceLastShot = 0;
    }
}
