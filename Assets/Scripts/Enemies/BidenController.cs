using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidenController : MonoBehaviour
{
    float spellTime;
    float hp;
    float yspeed;
    float xspeed;
    bool created;
    bool exiting;
    float imageAlpha;
    float spellOffset;
    GameObject player;
    public GameObject bidenBulletObj;
    public float forgetChance;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    // Start is called before the first frame update
    void BidenShoot(float offset) {
        float playerx = player.transform.position[0]; 
        float playery = player.transform.position[1];
        float angle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]);
        float targetx = playerx + offset * -Mathf.Sin(angle);
        float targety = playery + offset * Mathf.Cos(angle);
        float targetAngle = Mathf.Atan2(targety - transform.position[1], targetx - transform.position[0]);
        float targetAngle2 = angle + (angle - targetAngle);
        targetAngle = targetAngle * Mathf.Rad2Deg;
        targetAngle2 = targetAngle2 * Mathf.Rad2Deg;
        if (Random.Range(0f,1f) > forgetChance) {
            GameObject bullet1 = Instantiate(bidenBulletObj);
            SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(7.0f, targetAngle);
        }
        if (Random.Range(0f,1f) > forgetChance) {
            GameObject bullet2 = Instantiate(bidenBulletObj);
            SimpleBulletController controller2 = bullet2.GetComponent<SimpleBulletController>();
            controller2.transform.position = transform.position;
            controller2.UpdateSpeed(9.0f, targetAngle);
        }
        if (Random.Range(0f,1f) > forgetChance) {
            GameObject bullet3 = Instantiate(bidenBulletObj);
            SimpleBulletController controller3 = bullet3.GetComponent<SimpleBulletController>();
            controller3.transform.position = transform.position;
            controller3.UpdateSpeed(7.0f, targetAngle2);
        }
        if (Random.Range(0f,1f) > forgetChance) {
            GameObject bullet4 = Instantiate(bidenBulletObj);
            SimpleBulletController controller4 = bullet4.GetComponent<SimpleBulletController>();
            controller4.transform.position = transform.position;
            controller4.UpdateSpeed(9.0f, targetAngle2);
        }


        
    }
    void BidenMove() {
        if (!exiting) {
            float goalx = -transform.position[0] + Random.Range(-0.6f, 0.6f);
            float goaly = transform.position[1] - Random.Range(1.2f,1.5f);
            if (goalx > 9) {goalx = 18 - goalx;}
            if (goalx < -9) {goalx = -18 - goalx;}
            xspeed = (goalx - transform.position[0]) / 100;
            yspeed = (goaly - transform.position[1]) / 100;
        }
        else {
            if (transform.position[0] >= 0) {xspeed = -0.15f;}
            if (transform.position[0] < 0) {xspeed = 0.15f;}
        }
    }
    void BidenStop() {
        if (!exiting) {xspeed = 0;
            yspeed = 0;
            spellTime = 150;
            spellOffset = Random.Range(0.26f,0.30f);
        }
    }
    void Start()
    {
        spellOffset = Random.Range(0.26f,0.30f);
        player = GameObject.Find("player");
        spellTime = 160;
        hp = 20;
        yspeed = 0;
        xspeed = 0;
        created = false;
        imageAlpha = 0;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController =  this.GetComponent<DespawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (created) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
            }
            spellTime--;
        }
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        if (!exiting) {if (despawnController.exiting) {exiting = true;}}
        
        if (spellTime == 130 || spellTime == 115) {
            BidenShoot(spellOffset);
        }
        if (spellTime == 100) {
            if (Random.Range(0f,1f) > forgetChance || exiting) {
                BidenMove();
            }

        }
        if (spellTime == 0) {
            BidenStop();
        }
        if (transform.position[1] < -11) {
            transform.position += new Vector3(0,22,0); 
        }

    }
}
