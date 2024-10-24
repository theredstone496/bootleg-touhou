using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsamaController : MonoBehaviour
{
    // Start is called before the first frame update
    float moveTime;
    float shootTime;
    float imageAlpha;
    float hp;
    int yspeed;
    float directionOffset;
    float shootOffset;
    int direction;
    float xspeed;
    bool created;
    bool exiting;
    SpriteRenderer spriteRenderer;
    public GameObject osamaBulletObj;
    Rigidbody2D body;
    SpawnInController spawnInController;
    DespawnController despawnController;
    float shootx;
    float shooty;
    void Start()
    {
        exiting = false;
        moveTime = 0;
        shootTime = Random.Range(90,211);
        imageAlpha = 0;
        hp = 15;
        /*HealthController healthController = gameObject.GetComponent<HealthController>();
        healthController.hp = hp;*/
        yspeed = 0;
        directionOffset = Random.Range(50,71);
        direction = Mathf.FloorToInt(Random.Range(0,2));
        if (direction == 0) {
            xspeed = 3f;
            transform.localScale = new Vector3(1,1,1);
        }
        else {
            xspeed = -3f;
            transform.localScale = new Vector3(-1,1,1);
        }
        created = false;
        body = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController = this.GetComponent<DespawnController>();
        
    }
    void OsamaSpell1() {
        GameObject bullet1 = Instantiate(osamaBulletObj);
        SimpleBulletController controller1 = bullet1.GetComponent<SimpleBulletController>();
        controller1.transform.position = new Vector3(shootx, shooty, 0);
        controller1.UpdateSpeed(4.5f, 240);
        GameObject bullet2 = Instantiate(osamaBulletObj);
        SimpleBulletController controller2 = bullet2.GetComponent<SimpleBulletController>();
        controller2.transform.position = new Vector3(shootx, shooty, 0);
        controller2.UpdateSpeed(4.5f, 260);
        GameObject bullet3 = Instantiate(osamaBulletObj);
        SimpleBulletController controller3 = bullet3.GetComponent<SimpleBulletController>();
        controller3.transform.position = new Vector3(shootx, shooty, 0);
        controller3.UpdateSpeed(4.5f, 280);
        GameObject bullet4 = Instantiate(osamaBulletObj);
        SimpleBulletController controller4 = bullet4.GetComponent<SimpleBulletController>();
        controller4.transform.position = new Vector3(shootx, shooty, 0);
        controller4.UpdateSpeed(4.5f, 300);
    }
    // Update is called once per frame
    void Update()
    {
        if (created) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0) * 1f / 60f;
            }
            moveTime++;
            shootTime--;
        }
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        
        if (created && !exiting) {
            if (despawnController.exiting) {exiting = true;
                SpawnOutController spawnOut = this.GetComponent<SpawnOutController>();
                spawnOut.exiting = true;
            }
            
        }
        if (moveTime == directionOffset) {
            moveTime = directionOffset - 70f;
            if (direction == 0) {
                xspeed = -3f;
                direction = 1;
                transform.localScale = new Vector3(-1,1,1);
            }
            else {
                xspeed = 3f;
                direction = 0;
                transform.localScale = new Vector3(1,1,1);
            }
        }
        if (shootTime == 0) {
            shootTime = Random.Range(190,210);
            OsamaSpell1();
        }
        if (shootTime == 18) {
            shootx = transform.position[0];
            shooty = transform.position[1];
            OsamaSpell1();
        }
        if (shootTime == 6 || shootTime == 12) {
            OsamaSpell1();
        }
        if (transform.position[0] < -9) {
            direction = 0;
            moveTime = directionOffset - 50;
            xspeed = 3f;
            transform.localScale = new Vector3(1,1,1);
        }
        if (transform.position[0] > 9) {
            direction = 1;
            moveTime = directionOffset - 50;
            xspeed = -3f;
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
