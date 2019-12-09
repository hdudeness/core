using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretItem : MonoBehaviour
{
    public GameObject turretHead;
    public Transform turretRange;
    public Transform turretGun;
    public float fireRate;
    public float lineWidth;
    public float lineDuration;
    public int turretDamage;
    private float min;
    private float max;
    private float fireTimer;
    public GameObject laser;
    public int itemDuration;

    private GameObject FindClosestEnemy(float min, float max)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = turretGun.position;

        // calculate squared distances
        min = min * min;
        max = max * max;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

   private float CalculateRangeMax()
    {
        Vector3 center = turretHead.transform.position;
        Vector3 edge = turretRange.position;
        Vector3 diff = center - edge;
        return diff.magnitude;
    }

    private float CalculateRangeMin()
    {
        Vector3 center = turretHead.transform.position;
        Vector3 edge = turretGun.position;
        Vector3 diff = center - edge;
        return diff.magnitude;
    }

    IEnumerator DrawLine(Vector3 start, Vector3 end, Color color, float width, float duration)
    {
        laser.GetComponent<LineRenderer>().enabled = true;
        laser.transform.position = start;
        LineRenderer lr = laser.GetComponent<LineRenderer>();
        lr.startWidth = width;
        lr.endWidth = width;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        yield return new WaitForSeconds(duration);
        laser.GetComponent<LineRenderer>().enabled = false;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(itemDuration);

        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        min = 0;
        max = CalculateRangeMax();
        fireTimer = fireRate;
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if(fireTimer >= fireRate)
        {
            GameObject target = FindClosestEnemy(min, max);
            if (target != null)
            {
                Vector3 dir = target.transform.position - turretHead.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                turretHead.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                StartCoroutine(DrawLine(turretGun.position, target.transform.position, Color.red, lineWidth, lineDuration));
                target.SendMessage("Hit", turretDamage);
                fireTimer = 0;
            }
        }
    }
}
