using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreeneController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    public GameObject greeneBulletObj;
    int spellTime;
    Vector3 originalPosition;
    float shootAngle;
    bool leftOfPlayer;
    /*and so on...*/
    // Start is called before the first frame update
    void GreeneTeleport() {
        float distx = transform.position[0] - player.transform.position[0];
        float disty = transform.position[1] - player.transform.position[1];
        float angle = (90 + (Mathf.Atan2(disty, distx) * Mathf.Rad2Deg - 90) * 2) * Mathf.Deg2Rad;
        originalPosition = transform.position;
        transform.position = new Vector3(player.transform.position[0] + 3.0f * Mathf.Cos(angle), player.transform.position[1] + 3.0f * Mathf.Sin(angle));
        if (distx < 0) {leftOfPlayer = true;}
        else {leftOfPlayer = false;}
    }
    void GreeneReturn() {
        transform.position = originalPosition;
        shootAngle = 270;
    }
    void GreeneShoot() {
        GameObject bullet1 = Instantiate(greeneBulletObj);
        SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = transform.position;
        controller1.UpdateSpeed(7.0f, shootAngle);
        GameObject bullet2 = Instantiate(greeneBulletObj);
        SimpleBulletController controller2 = bullet2.GetComponent<SimpleBulletController>();
        controller2.transform.position = transform.position;
        controller2.UpdateSpeed(7.0f, shootAngle + 180);
        if (leftOfPlayer) {shootAngle += 15;}
        else {shootAngle -= 15;}
    }
    void Start()
    {
        spellTime = 120;
        shootAngle = 270f;
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
            if (spellTime == 100) {
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.4f);
            }
            if (spellTime == 60) {
                GreeneTeleport();
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            if (spellTime >= 10 && spellTime <= 40 && spellTime % 2 == 0) {
                GreeneShoot();
            }
            if (spellTime == 0) {
                GreeneReturn();
                spellTime = 300;
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
