using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    HealthController healthController;
    GameObject player;
    public GameObject clintonBullet1Obj;
    public GameObject clintonBullet2Obj;
    public GameObject clintonBullet3Obj;
    public GameObject clintonBullet4Obj;
    public GameObject clintonBullet5Obj;
    public GameObject healthBar1Obj;
    public GameObject healthBar2Obj;
    public GameObject healthBar3Obj;
    GameObject healthBar1;
    GameObject healthBar2;
    GameObject healthBar3;
    int spellTime;
    int timeAlive;
    public int stage;
    int spell1Angle;
    float p2health;
    float p3health;
    bool bombs = false;
    /*and so on...*/
    // Start is calle before the first frame update
    void ClintonSpell1() {
        spell1Angle += 131;
        spell1Angle = spell1Angle % 360; 
        for(int i = 0; i < 80; i++) {
            int bulletPosition = Mathf.Abs(i % 16 - 8);
            float bulletSpeed = 5f + bulletPosition / 2;
            GameObject bullet = Instantiate(clintonBullet1Obj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position + new Vector3(bulletSpeed * Mathf.Cos((spell1Angle + i * 4.5f) * Mathf.Deg2Rad), bulletSpeed * Mathf.Sin((spell1Angle + i * 4.5f) * Mathf.Deg2Rad), 0) * 0.1f;
            controller1.UpdateSpeed(bulletSpeed,spell1Angle + i * 4.5f);
            controller1.UpdateRotationSpeed(50f);
        }
    }
    void ClintonSpell2() {
        float playerx = player.transform.position[0]; 
        float playery = player.transform.position[1];
        float angle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
        for (int i = 0; i < 3; i++) {
            GameObject bullet = Instantiate(clintonBullet2Obj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = transform.position;
            controller1.UpdateSpeed(7.0f,angle + (i - 1) * 30f);
        }
    }
    void ClintonSpell3() {
        float playerx = player.transform.position[0]; 
        float playery = player.transform.position[1];
        float angle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
        float distance = Vector3.Distance(transform.position, player.transform.position);
        for (int i = 0; i < 4; i++) {
            GameObject bullet = Instantiate(clintonBullet3Obj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            ClintonBullet3Controller controller2 = bullet.GetComponent<ClintonBullet3Controller>();
            controller1.transform.position = transform.position;
            controller2.deathTime = 180f;
            controller1.UpdateSpeed(8.0f,angle + (i - 1.5f) * 20f);
            controller1.UpdateAcceleration(-1.3f, angle + (i - 1.5f) * 20f);
        }
    }
    void ClintonSpell4() {
        GameObject bullet = Instantiate(clintonBullet4Obj);
        SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
        ClintonBullet4Controller controller2 = bullet.GetComponent<ClintonBullet4Controller>();
        controller1.transform.position = transform.position;
        controller2.deathTime = 60f;
        controller1.UpdateSpeed(6.0f,270);
        controller1.UpdateAcceleration(-2.0f, 270);
    }
    void ClintonSpell4A() {
        for (int i = 0; i < 2; i++) {
            GameObject bullet = Instantiate(clintonBullet4Obj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            ClintonBullet4Controller controller2 = bullet.GetComponent<ClintonBullet4Controller>();
            controller1.transform.position = transform.position;
            controller2.deathTime = 60f;
            controller1.UpdateSpeed(6.0f,235 + 70 * i);
            controller1.UpdateAcceleration(-2.0f, 235 + 70 * i);
        }
    }
    void ClintonSpell4B() {
        for (int i = 0; i < 2; i++) {
            GameObject bullet = Instantiate(clintonBullet4Obj);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            ClintonBullet4Controller controller2 = bullet.GetComponent<ClintonBullet4Controller>();
            controller1.transform.position = transform.position;
            controller2.deathTime = 60f;
            controller1.UpdateSpeed(6.0f,200 + 140 * i);
            controller1.UpdateAcceleration(-2.0f, 200 + 140 * i);
        }
    }
    void ClintonSpell5() {
        float playerx = player.transform.position[0]; 
        float playery = player.transform.position[1];
        float playerangle = Mathf.Atan2(playery - transform.position[1], playerx - transform.position[0]) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(clintonBullet5Obj);
        SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
        ClintonBullet5Controller controller2 = bullet.GetComponent<ClintonBullet5Controller>();
        controller1.transform.position = transform.position;
        controller2.deathTime = 500f;
        controller1.UpdateSpeed(3.0f, playerangle);
        controller1.UpdateAcceleration(-1.0f, playerangle);
        controller1.UpdateRotationSpeed(200f);
        
    }
    void Start()
    {   
        healthBar1 = Instantiate(healthBar1Obj);
        healthBar2 = Instantiate(healthBar2Obj);
        healthBar3 = Instantiate(healthBar3Obj);
        stage = 1;
        player = GameObject.Find("player");
        created = false;
        spellTime = 50;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController =  this.GetComponent<DespawnController>();
        healthController = this.GetComponent<HealthController>();
    }

    // Update is called once per frame  
    void Update()
    {
        if (spawnInController.spawned) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
            }
            spellTime--;
            timeAlive++;
            if ((timeAlive >= despawnController.lifespan / 3 || healthController.hp <= 2 * healthController.maxhp / 3) && stage == 1) {
                stage = 2;
                spellTime = 200;
                p2health = healthController.hp / healthController.maxhp;
                Destroy(healthBar1);
            }
            if ((timeAlive >= 2 * despawnController.lifespan / 3 || healthController.hp <= healthController.maxhp / 3) && stage == 2) {
                stage = 3;
                spellTime = 200;
                p3health = healthController.hp / healthController.maxhp;
                Destroy(healthBar2);
            }
            if ((timeAlive >= despawnController.lifespan || healthController.hp <= 0) && !bombs) {
                bombs = true; //i dont want obama to get infinite bombs
                Destroy(healthBar3);
                player.GetComponent<PlayerController>().RestoreBombs((int) Mathf.Ceil(player.GetComponent<PlayerController>().maxBombs / 2f));
            }
            float percentHealth = healthController.hp / healthController.maxhp;
            if (stage == 1) {
                healthBar1.transform.localScale = new Vector3((percentHealth - 2f/3f) / (1f/3f) * 500, 50, 1);
                healthBar1.transform.position = new Vector3(- (1 - percentHealth) * 7.5f + 5f, 10.5f, 0);    
            }
            if (stage == 2) {
                healthBar2.transform.localScale = new Vector3((percentHealth - 1f/3f) / (1f/3f) * 500, 50, 1);
                healthBar2.transform.position = new Vector3(- (p2health - percentHealth) * 7.5f, 10.5f, 0);
            }
            if (stage == 3 && !despawnController.exiting) {
                healthBar3.transform.localScale = new Vector3((percentHealth / p3health) * 500, 50, 1);
                healthBar3.transform.position = new Vector3(- (p3health - percentHealth) * 7.5f - 5f, 10.5f, 0);
            }
            /*and so on*/
            
        }
        if (!created) {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        if (!exiting) {if (despawnController.exiting) {exiting = true;}}
        if (stage == 1 && spellTime == 0) {
            spellTime = 50;
            ClintonSpell1();
        }
        if (stage == 2 && spellTime == 0) {
            spellTime = 200;
            ClintonSpell2();
        }
        if (stage == 2 && spellTime == 50) {
            ClintonSpell3();
        }
        if (stage == 3 && spellTime == 0) {
            spellTime = 200;
            ClintonSpell4();
            Invoke("ClintonSpell4A", 0.2f);
            Invoke("ClintonSpell4B", 0.4f);
        }
        if (stage == 3 && spellTime == 100) {
            ClintonSpell5();
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
