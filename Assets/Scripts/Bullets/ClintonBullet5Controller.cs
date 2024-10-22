using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonBullet5Controller : MonoBehaviour
{
    SimpleBulletController controller;
    float angle;
    public float deathTime;
    public float spawnTime;
    public GameObject bullet5SpawnObj;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<SimpleBulletController>();
        angle = controller.angle; 
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        deathTime--;
        spawnTime--;
        if (spawnTime <= 0) {
            spawnTime = 13;
            BulletSpawn();
        } 
        if (deathTime <= 0) {
            Destroy(gameObject);
        }
    }
    void BulletSpawn() {
        angle = controller.angle;
        for (int i = 0; i < 4; i++) {
            GameObject bullet = Instantiate(bullet5SpawnObj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(4.0f,angle + 90 * i);
        }
    }
}
