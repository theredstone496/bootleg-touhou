using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BernieController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    public GameObject bernieBulletObj;
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
        shootTime = 30;
    }
    void BernieShoot() {
        float angle = Mathf.Atan2(player.transform.position[1] - transform.position[1], player.transform.position[0] - transform.position[0]);
        GameObject bullet1 = Instantiate(bernieBulletObj);
        SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(5.5f, angle * Mathf.Rad2Deg - 10);
        bullet1 = Instantiate(bernieBulletObj);
        controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(5.5f, angle * Mathf.Rad2Deg - 20);
        bullet1 = Instantiate(bernieBulletObj);
        controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(5.5f, angle * Mathf.Rad2Deg);
        bullet1 = Instantiate(bernieBulletObj);
        controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(5.5f, angle * Mathf.Rad2Deg + 10);
        bullet1 = Instantiate(bernieBulletObj);
        controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(5.5f, angle * Mathf.Rad2Deg + 20);
    }
    // Update is called once per frame  
    void Update()
    {
        if (created) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
            }
            shootTime--;
            /*and so on*/
        }
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        if (!exiting) {if (despawnController.exiting) {exiting = true;}}
        if (shootTime == 0) {
            shootTime = 200;
            BernieShoot();
        }



        /*if spawn out */
        if (created && !exiting) {
            if (despawnController.exiting) {exiting = true;
                SpawnOutController spawnOut = this.GetComponent<SpawnOutController>();
                spawnOut.exiting = true;
            }
            
        }
    }
}
