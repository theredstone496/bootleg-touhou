using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonBullet4Controller : MonoBehaviour
{
    SimpleBulletController controller;
    float angle;
    public float deathTime;
    public GameObject bullet4SpawnObj;
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
        if (deathTime <= 0) {
            for (int i = 0; i < 8; i++) {
            GameObject bullet = Instantiate(bullet4SpawnObj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(4.0f,angle + 30 + i * 60);
            controller1.UpdateAcceleration(-8.0f, angle + 30 + i * 60);
            EnemyHomingBulletController controller2 = bullet.GetComponent<EnemyHomingBulletController>();
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float playerangle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
            controller2.UpdateSpeed(5.0f, playerangle);
            }
            Destroy(gameObject);
        }
    }
}
