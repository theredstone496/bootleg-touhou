using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoreController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    public GameObject algoreBullet1Obj;
    public GameObject algoreBullet2Obj;
    int spellTime;
    /*and so on...*/
    // Start is called before the first frame update
    void AlgoreShoot() {
        for (int i = 0; i < 12; i++) {
            GameObject bullet1 = Instantiate(algoreBullet1Obj);
            SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position + new Vector3(9.0f * Mathf.Cos((360 / 12 * i) * Mathf.Deg2Rad), 9.0f * Mathf.Sin((360 / 12 * i) * Mathf.Deg2Rad), 0) * 0.05f;
            controller1.UpdateSpeed(9.0f, 360 / 12 * i);
        }
        for (int j = 0; j < 6; j++) {
            GameObject bullet1 = Instantiate(algoreBullet2Obj);
            WallBouncingBulletController controller1 = bullet1.GetComponent<WallBouncingBulletController>();
            controller1.transform.position = transform.position + new Vector3(14.0f * Mathf.Cos((360 / 12 * j) * Mathf.Deg2Rad), 9.0f * Mathf.Sin((360 / 12 * j) * Mathf.Deg2Rad), 0) * 0.05f;;
            controller1.UpdateSpeed(14.0f, 360 / 6 * j + 90);
        }
    }
    void AlgoreMove() {
        float goalx = player.transform.position[0];
        xspeed = (goalx - transform.position[0]) / 50;
    }
    void AlgoreStop() {
        xspeed = 0;
    }
    void Start()
    {
        Application.targetFrameRate = 120;
        spellTime = 200;
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
            spellTime--;
            /*and so on*/
            if (spellTime >= 120 && spellTime <= 210 && spellTime % 2 == 0) {
                if (Mathf.Abs(transform.position[0]) < 9.7 && Mathf.Abs(transform.position[1]) < 11) {
                    AlgoreShoot();
                    }
            }
            if (spellTime == 50) {
                AlgoreMove();
            }
            if (spellTime == 0) {
                spellTime = 300;
                AlgoreStop();
            }
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
