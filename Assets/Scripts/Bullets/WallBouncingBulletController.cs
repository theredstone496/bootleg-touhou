using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBouncingBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; 
    public float hspeed;
    public float vspeed;
    public int timeMin;
    public int timeMax; //exclusive
    int time;
    bool activated;
    //angle counterclockwise from positive x axis in degrees
    public float angle;
    public float sideBounceConstant;
    public float vertBounceConstant;
    public bool sideBounce = true;
    public bool vertBounce = true;

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
        if (time <= timeMax) {time++;}
        if (time >= timeMin && (time < timeMax || timeMax == 0)) {
            activated = true;
        }
        else {

            activated = false;
        }
        if (activated) {
            Vector3 pos = transform.position;
            if (vertBounce) {
                if (pos[1] > 11) {float posy = 11f - (transform.position[1] - 11f) * sideBounceConstant;
                transform.position = new Vector3(transform.position[0], posy, 0);}
                if (pos[1] < -11) {float posy = -11f - (transform.position[1] - -11f) * sideBounceConstant;
                transform.position = new Vector3(transform.position[0], posy, 0);}
                if (pos[1] > 11 || pos[1] < -11) {
                    vspeed = -vspeed * vertBounceConstant;
                    hspeed = hspeed * sideBounceConstant;
                }
            }
            
            if (sideBounce) {
                if (pos[0] > 9.7) {float posx = 9.7f - (transform.position[0] - 9.7f) * sideBounceConstant;
                transform.position = new Vector3(posx, transform.position[1], 0);}
                if (pos[0] < -9.7) {float posx = -9.7f - (transform.position[0] - -9.7f) * sideBounceConstant;
                transform.position = new Vector3(posx, transform.position[1], 0);}
                if (pos[0] > 9.7 || pos[0] < -9.7) {
                    hspeed =  -hspeed * sideBounceConstant;
                    vspeed = vspeed * vertBounceConstant;
                }
            }
            
            transform.localPosition += new Vector3(hspeed, vspeed, 0) * 1f / 60f;
            float moveAngle = Mathf.Atan2(vspeed, hspeed) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, moveAngle - 90);
        }
        else {
            transform.localPosition += new Vector3(hspeed, vspeed, 0) * 1f / 60f;
            float moveAngle = Mathf.Atan2(vspeed, hspeed) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, moveAngle - 90);
        }

    }
    public void UpdateSpeed(float newspeed, float newangle) {
        
        speed = newspeed;
        
        angle = newangle;
        hspeed = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
        vspeed = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        
        transform.localEulerAngles = new Vector3(0, 0, angle - 90);
    }
}
