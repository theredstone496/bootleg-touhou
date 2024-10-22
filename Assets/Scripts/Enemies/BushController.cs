using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    public GameObject bushBulletObj;
    public GameObject parentObj;
    int chargeTime;
    int shootTime;
    /*and so on...*/
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        created = false;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController =  this.GetComponent<DespawnController>();
        chargeTime = 200;
        shootTime = 140;
    }
    void BushShoot1() {
        for (int i = 0; i < 8; i++) {
            GameObject parent1 = Instantiate(parentObj);
            SimpleBulletController parentController = parent1.GetComponent<SimpleBulletController>();
            parentController.UpdateSpeed(6.0f, 45 * i);
            GameObject bullet1 = Instantiate(bushBulletObj);
            SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.SetParent(parent1.transform);
            controller1.transform.localPosition = new Vector3(0.25f, 1.125f, 0);
            controller1.UpdateSpeed(0f,90f);
            bullet1 = Instantiate(bushBulletObj);
            controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.SetParent(parent1.transform);
            controller1.transform.localPosition = new Vector3(-0.25f, 1.125f, 0);
            controller1.UpdateSpeed(0f,90f);
            parent1.transform.position = new Vector3(transform.position[0], transform.position[1], 0);
        }
    }
    void BushShoot2() {
        for (int i = 0; i < 8; i++) {
            GameObject parent1 = Instantiate(parentObj);
            SimpleBulletController parentController = parent1.GetComponent<SimpleBulletController>();
            parentController.UpdateSpeed(7.0f, 45 * i + 22.5f);
            GameObject bullet1 = Instantiate(bushBulletObj);
            SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.SetParent(parent1.transform);
            controller1.transform.localPosition = new Vector3(0.25f, 1.125f, 0);
            controller1.UpdateSpeed(0f,90f);
            bullet1 = Instantiate(bushBulletObj);
            controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.SetParent(parent1.transform);
            controller1.transform.localPosition = new Vector3(-0.25f, 1.125f, 0);
            controller1.UpdateSpeed(0f,90f);
            parent1.transform.position = new Vector3(transform.position[0], transform.position[1], 0);
        }
    }
    void BushShoot3() {
        float playerx = player.transform.position[0]; 
        float playery = player.transform.position[1];
        float targetAngle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
        GameObject parent1 = Instantiate(parentObj);
        SimpleBulletController parentController = parent1.GetComponent<SimpleBulletController>();
        parentController.UpdateSpeed(10.0f, targetAngle);
        GameObject bullet1 = Instantiate(bushBulletObj);
        SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.SetParent(parent1.transform);
        controller1.transform.localPosition = new Vector3(0.25f, 1.125f, 0);
        controller1.UpdateSpeed(0f,90f);
        bullet1 = Instantiate(bushBulletObj);
        controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.SetParent(parent1.transform);
        controller1.transform.localPosition = new Vector3(-0.25f, 1.125f, 0);
        controller1.UpdateSpeed(0f,90f);
        parent1.transform.position = new Vector3(transform.position[0], transform.position[1], 0);
    }
    void BushMove() {
        if (chargeTime > 30) {
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
            xspeed = 0.011f * Mathf.Cos(angle * Mathf.Deg2Rad);
            yspeed = 0.011f * Mathf.Sin(angle * Mathf.Deg2Rad);
        }
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (created) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
                BushMove();
            }
            chargeTime--;
            shootTime--;
            /*and so on*/
        }
        
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        
        /*if spawn out */
        if (created && !exiting) {
            if (despawnController.exiting) {exiting = true;
                SpawnOutController spawnOut = this.GetComponent<SpawnOutController>();
                spawnOut.exiting = true;
            }
            
        }
        if (chargeTime == 30) {
            xspeed = 4 * xspeed;
            yspeed = 4 * yspeed;
        }
        if (chargeTime == 0) {chargeTime = 200;}
        if (shootTime == 45) {BushShoot1();}
        if (shootTime == 25) {BushShoot2();}
        if (shootTime <= 5) {BushShoot3();}
        if (shootTime == 0) {shootTime = 200;}
    }
}
