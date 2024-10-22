using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    int timeCount1;
    int timeCount2;
    int TimeCount3;
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
            timeCount1--;
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
