using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHomingBulletController : MonoBehaviour
{
    public float speed; 
    public float acceleration;
    public float hspeed;
    public float vspeed;
    //angle counterclockwise from positive x axis in degrees
    public float angle;
    public float homingrate;
    public int timeMin;
    public int timeMax;
    int time;
    bool activated;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= timeMax || time <= timeMin) {time++;}
        if (time >= timeMin && (time <= timeMax || timeMax == 0)) {
            activated = true;
        }
        else {
            activated = false;
        }
        if (activated) {
            Vector3 pos = transform.position;
            if (pos[1] > 13 || pos[1] < -13 || pos[0] > 10 || pos[0] < -10) {
                Destroy(gameObject);
            }
            if (enemy != null) {
                float enemyx = enemy.transform.position[0]; 
                float enemyy = enemy.transform.position[1];
                float targetangle = Mathf.Atan2(enemyy - transform.position[1], enemyx - transform.position[0]) * Mathf.Rad2Deg;
                if (targetangle > angle) {
                    angle += homingrate * 1f / 60f;
                }
                if (targetangle < angle) {
                    angle -= homingrate * 1f / 60f;
                }
            }
            speed += acceleration * 1f / 60f;
            if (speed < 0) {speed = 0;}
            hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
            vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
            transform.localPosition += new Vector3(hspeed, vspeed, 0) * 1f / 60f;
            transform.localEulerAngles = new Vector3(0, 0, angle - 90);
        }
    }
    public void UpdateSpeed(float newspeed, float newangle) {
        
        speed = newspeed;
        
        angle = newangle;
        hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
        vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        
        transform.localEulerAngles = new Vector3(0, 0, angle - 90);
    }
    public void UpdateHomingRate(float newhomingrate) {
        homingrate = newhomingrate;
    } 
    public void UpdateActivationTime(int start, int end) {
        timeMin = start;
        timeMax = end;
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
