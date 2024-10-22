using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletController : MonoBehaviour
{
    public float speed; 
    public float haccel;
    public float vaccel;
    public float hspeed;
    public float vspeed;
    private float originalhspeed;
    private float originalvspeed;
    private float originalhaccel;
    private float originalvaccel;
    //angle counterclockwise from positive x axis in degrees
    public float angle;
    public float moveAngle;
    public float rotationSpeed;
    public float Aaccel;
    /*public float turningSpeed;*/
    public int timeMin;
    public int timeMax; //exclusive
    int time;
    bool activated;
    public bool reverse;
    public string range = "short";
    //when another controller's time runs out, update these values accordingly
    public bool inheritRotation = false;
    public bool inheritRotationSpeed = false;
    bool updateAngle = true;

    // Start is called before the first frame update
    void Start()
    {
        /*speed = 0;
        vspeed = 0;
        hspeed = 0;
        angle = 0;*/
        /*if (speed != 0) {
            hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
            vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if ((time == timeMax-1 || time == timeMax-2) && timeMax != 0) {
            SimpleBulletController[] controllers = GetComponents<SimpleBulletController>();
            foreach (SimpleBulletController controller in controllers) {
                if (controller.inheritRotation) {
                    controller.angle = angle;
                }
                if (controller.inheritRotationSpeed) {
                    controller.rotationSpeed = rotationSpeed;
                }
            }
        }
        if (time <= timeMax) {time++;}
        if (time >= timeMin && (time < timeMax || timeMax == 0)) {
            activated = true;
        }
        else {

            activated = false;
        }
        if (activated) {
            Vector3 pos = transform.position;
            if (range == "short") {
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
                if (Mathf.Abs(hspeed) <= Mathf.Abs(haccel * 1f / 60f)) {
                    hspeed = 0;
                }
                else {
                    hspeed = hspeed + haccel * 1f / 60f;
                }
                if (Mathf.Abs(vspeed) <= Mathf.Abs(vaccel * 1f / 60f)) {
                    vspeed = 0;
                }
                else {
                    vspeed = vspeed + vaccel * 1f / 60f;
                }
            }
            else {
                hspeed = hspeed + haccel * 1f / 60f;
            
                vspeed = vspeed + vaccel * 1f / 60f;
            }


            speed = Mathf.Sqrt(Mathf.Pow(hspeed, 2) + Mathf.Pow(vspeed, 2));
            moveAngle = Mathf.Atan2(vspeed, hspeed);
            /*speed += acceleration * 1f / 60f; */
            if (speed < 0 && reverse) {speed = 0;}

            transform.localPosition += new Vector3(hspeed, vspeed, 0) * 1f / 60f;
            /*moveAngle += turningSpeed * 1f / 60f;*/
            angle += rotationSpeed * 1f / 60f;
            rotationSpeed += Aaccel * 1f / 60f;
            if (updateAngle) {transform.localEulerAngles = new Vector3(0, 0, angle - 90);}
        }


    }
    
    public void UpdateSpeed(float newspeed, float newangle, bool updateAngle = true) {
        speed = newspeed;
        
        moveAngle = newangle;
        angle = newangle;
        hspeed = speed * Mathf.Cos(newangle * Mathf.Deg2Rad);
        vspeed = speed * Mathf.Sin(newangle * Mathf.Deg2Rad);
        originalhspeed = hspeed;
        originalvspeed = vspeed;
        if (updateAngle) {transform.localEulerAngles = new Vector3(0, 0, angle - 90);}
        this.updateAngle = updateAngle;
    }
    public void UpdatePos(int frames) {
        this.transform.position = this.transform.position + new Vector3(hspeed,vspeed,0) / 60f * frames;
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
