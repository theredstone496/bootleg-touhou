using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonBullet2Controller : MonoBehaviour
{
    SimpleBulletController controller;
    float angle;
    public float spawnTime;
    public GameObject bullet2SpawnObj;
    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<SimpleBulletController>();
        angle = controller.angle; 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime--;
        if (spawnTime <= 0) {
            spawnTime = 20;
            BulletSpawn();
        } 
    }
    void BulletSpawn() {
            GameObject bullet = Instantiate(bullet2SpawnObj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(3.0f,angle + 90);
            GameObject bullet2 = Instantiate(bullet2SpawnObj);
            SimpleBulletController controller2 = bullet2.GetComponent<SimpleBulletController>();
            controller2.transform.position = transform.position;
            controller2.UpdateSpeed(3.0f,angle - 90);
    }
}
