using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonBullet3Controller : MonoBehaviour
{
    SimpleBulletController controller;
    float angle;
    public float deathTime;
    public GameObject bullet3SpawnObj;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<SimpleBulletController>();
        angle = controller.angle; 
    }

    // Update is called once per frame
    void Update()
    {
        deathTime--;
        if (deathTime <= 0) {
            for (int i = 0; i < 6; i++) {
            GameObject bullet = Instantiate(bullet3SpawnObj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(5.0f,angle + 30 + i * 60);
            }
            Destroy(gameObject);
        }
    }
}
