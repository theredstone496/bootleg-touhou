using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingBulletController : MonoBehaviour
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
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
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
            if (pos[1] > 11 || pos[1] < -11 || pos[0] > 9.7 || pos[0] < -9.7) {
                Destroy(gameObject);
            }
            if (player != null) {
                float playerx = player.transform.position[0]; 
                float playery = player.transform.position[1];
                float targetangle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
                if (targetangle > angle) {
                    angle += homingrate * Time.deltaTime;
                }
                if (targetangle < angle) {
                    angle -= homingrate * Time.deltaTime;
                }
            }
            speed += acceleration * Time.deltaTime;
            if (speed < 0) {speed = 0;}
            hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
            vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
            transform.localPosition += new Vector3(hspeed, vspeed, 0) * Time.deltaTime;
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
}
