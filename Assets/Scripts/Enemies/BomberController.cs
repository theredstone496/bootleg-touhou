using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    public GameObject bombBullet;
    public int direction; //anything nonnegative for right, anything negative for left
    int bomberTime;
    /*and so on...*/
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        created = false;
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
            bomberTime++;
            if (bomberTime >= 25) {
                bomberTime = 0;
                GameObject bomb = Instantiate(bombBullet);
                bomb.transform.position = transform.position;
                SimpleBulletController controller1 = bomb.GetComponent<SimpleBulletController>();
                if (direction >= 0) {
                    controller1.UpdateSpeed(9f, 300);
                }
                else {
                    controller1.UpdateSpeed(9f, 240);
                }
            }
            /*and so on*/
        }
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        if (!exiting) {if (despawnController.exiting) {exiting = true;}}




        /*if spawn out */
        if (created && !exiting) {
            if (despawnController.exiting) {exiting = true;
                SpawnOutController spawnOut = this.GetComponent<SpawnOutController>();
                spawnOut.exiting = true;
            }
            
        }
    }
}
