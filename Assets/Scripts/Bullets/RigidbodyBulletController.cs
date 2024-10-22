using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyBulletController : MonoBehaviour
{
    public float speed;
    public float haccel;
    public float vaccel;
    private float originalhspeed;
    private float originalvspeed;
    private float originalhaccel;
    private float originalvaccel;
    //angle counterclockwise from positive x axis in degrees
    public float angle;
    public float moveAngle;
    public float rotationSpeed;
    /*public float turningSpeed;*/
    public int timeMin;
    public int timeMax;
    int time;
    bool activated;
    public bool reverse;
    public string range = "short";
    bool updateAngle = true;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        /*speed = 0;
        vspeed = 0;
        hspeed = 0;
        angle = 0;*/
        /*if (speed != 0) {
            hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
            vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        }*/
    }
    public void UpdateRigidbody() {
        body = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        BoxCollider2D box = this.GetComponent<BoxCollider2D>();
        if (time <= timeMax) {time++;}
        if (time >= timeMin && (time <= timeMax || timeMax == 0)) {
            activated = true;
        }
        else {
            activated = false;
        }
        if (activated) {
            Vector3 pos = transform.position;
            if ((haccel == 0 && vaccel == 0) || range == "short") {
                if (pos[1] > 12.5 || pos[1] < -12.5 || pos[0] > 10.5 || pos[0] < -10.5) {
                    Destroy(gameObject);
                }
            }
            else if (range != "long") {
                if (pos[1] > 25 || pos[1] < -25 || pos[0] > 23 || pos[0] < -23) {
                    Destroy(gameObject);
                }
            }
            else {
                if (pos[1] > 40 || pos[1] < -40 || pos[0] > 34 || pos[0] < -34) {
                    Destroy(gameObject);
                }
            }
            if (!reverse && Mathf.Abs(originalhspeed) / originalhspeed != Mathf.Abs(originalhaccel) / originalhaccel && Mathf.Abs(originalvspeed) / originalvspeed != Mathf.Abs(originalvaccel) / originalvaccel) {
                if (Mathf.Abs(body.velocity.x) <= Mathf.Abs(haccel * 1f / 60f)) {
                    body.velocity = new Vector2(0, body.velocity.y);
                }
                else {
                    body.velocity = new Vector2(body.velocity.x + haccel * 1f / 60f, body.velocity.y);
                }
                if (Mathf.Abs(body.velocity.y) <= Mathf.Abs(vaccel * 1f / 60f)) {
                    body.velocity = new Vector2(body.velocity.x, 0);
                }
                else {
                    body.velocity = new Vector2(body.velocity.x, body.velocity.y + vaccel * 1f / 60f);
                }
            }
            else {
                body.velocity = new Vector2(body.velocity.x + haccel * 1f / 60f, body.velocity.y + vaccel * 1f / 60f);
            }


            speed = body.velocity.magnitude;
            moveAngle = Mathf.Atan2(body.velocity.y, body.velocity.x);
            /*speed += acceleration * 1f / 60f; */

            /*moveAngle += turningSpeed * 1f / 60f;*/
        }


    }
    
    public void UpdateSpeed(float speed, float newangle, bool updateAngle = true) {
        
        moveAngle = newangle;
        body.velocity = new Vector2(speed * Mathf.Cos(newangle * Mathf.Deg2Rad), speed * Mathf.Sin(newangle * Mathf.Deg2Rad));
        originalhspeed = speed * Mathf.Cos(newangle * Mathf.Deg2Rad);
        originalvspeed = speed * Mathf.Sin(newangle * Mathf.Deg2Rad);
        if (updateAngle) {body.rotation = newangle - 90;}
        this.updateAngle = updateAngle;
    }
    public void UpdateAcceleration(float newaccel, float newangle) {
        haccel = newaccel * Mathf.Cos(newangle * Mathf.Deg2Rad);
        vaccel = newaccel * Mathf.Sin(newangle * Mathf.Deg2Rad);
        originalhaccel = haccel;
        originalvaccel = vaccel;
    }
    public void UpdateRotationSpeed(float newRotationSpeed) {
        rotationSpeed = newRotationSpeed;
    }
    public void UpdateActivationTime(int start, int end) {
        timeMin = start;
        timeMax = end;
    }
}
