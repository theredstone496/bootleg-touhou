using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrumpController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    HealthController healthController;
    Rigidbody2D body;
    public GameObject trumpPennyBulletObj;
    public GameObject trumpNickelBulletObj;
    public GameObject trumpDimeBulletObj;
    public GameObject trump1DollarObj;
    public GameObject trump10DollarObj;
    public GameObject trump100DollarObj;
    public List<GameObject> trumpAlphabetBullets;
    public GameObject trumpWall1Obj;
    public GameObject trumpWall2Obj;
    public List<GameObject> trumpAlphabetRigidbody;
    public GameObject redStripeObj;
    public GameObject whiteStripeObj;
    public GameObject trumpStarBulletObj;
    public GameObject healthBar1Obj;
    public GameObject healthBar2Obj;
    public GameObject healthBar3Obj;
    public GameObject healthBar4Obj;
    GameObject player;
    GameObject healthBar1;
    GameObject healthBar2;
    GameObject healthBar3;
    GameObject healthBar4;
    int spellTime;
    int timeAlive;
    int spell1aAngle;
    int spell1bAngle;
    int reverse1bAngle;
    float stripeAngle;
    Vector3 slander2Dest;
    Vector3 slander2Start;
    public int stage;
    public Vector3 originalPosition;
    float p2health;
    float p3health;
    float p4health;
    bool escaping = false;
    float escapingTime = 0;
    bool returning = false;
    float returningTime = 0;
    public List<GameObject> minions;
    public GameObject circlingObama;
    public GameObject bomberObj;
    public GameObject straightLinePath;
    List<GameObject> aliveMinions;
    TrumpMoneyRain1 moneyRain1;
    ReverseMoneyRain1 reverseMoneyRain1;
    ReverseMoneyRain2 reverseMoneyRain2;
    Slander1 slander1;
    Slander2 slander2;
    MoneyRain2 moneyRain2;
    Wall2 wall2;
    Wall3 wall3;
    Stars1 stars;
    /*and so on...*/
    // Start is called before the first frame update
    GameObject SpawnBullet(GameObject obj, int stage) {
        GameObject bullet = Instantiate(obj);
        TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
        despawner.stage = stage;
        return bullet;
    }
    GameObject SpawnMinion(GameObject obj, Vector3 pos) {
        GameObject minion = Instantiate(obj);
        minion.transform.position = pos;
        SpawnInController spawnInController = minion.GetComponent<SpawnInController>();
        DespawnController despawnController = minion.GetComponent<DespawnController>();
        spawnInController.startxpos = pos[0];
        spawnInController.startypos = pos[1];
        spawnInController.time = 40;
        spawnInController.startAlpha = 0;
        despawnController.lifespan = 10000;
        aliveMinions.Add(minion);
        return minion;
    }
    void SpawnObamas() {
        for (int i = 0; i < 4; i++) {
            GameObject obama = Instantiate(circlingObama);
            obama.transform.SetParent(transform);
            obama.transform.localPosition = new Vector3(0,0,0);
            obama.GetComponent<EnemyObamaController>().angle = 90 * i;
        }
    }
    void Start()
    {
        aliveMinions = new List<GameObject>();
        GameObject[] moneyRainBullets = new GameObject[2];
        moneyRainBullets[0]= trumpPennyBulletObj;
        moneyRainBullets[1] = trumpDimeBulletObj;
        moneyRain1 = new TrumpMoneyRain1(moneyRainBullets,gameObject);
        reverseMoneyRain1 = new ReverseMoneyRain1(new GameObject[2]{trumpPennyBulletObj, trumpNickelBulletObj}, gameObject);
        reverseMoneyRain2 = new ReverseMoneyRain2(new GameObject[1]{trumpDimeBulletObj}, gameObject);
        slander1 = new Slander1(trumpAlphabetBullets.ToArray(), gameObject);
        slander2 = new Slander2(trumpAlphabetBullets.ToArray(), gameObject);
        moneyRain2 = new MoneyRain2(new GameObject[4]{trumpPennyBulletObj, trumpNickelBulletObj, trumpDimeBulletObj, trump1DollarObj}, gameObject);
        wall2 = new Wall2(gameObject, trumpWall2Obj);
        wall3 = new Wall3(gameObject, trumpWall2Obj);
        stars = new Stars1(new GameObject[1]{trumpStarBulletObj}, gameObject);
        body = this.GetComponent<Rigidbody2D>();
        healthBar1 = Instantiate(healthBar1Obj);
        healthBar2 = Instantiate(healthBar2Obj);
        healthBar3 = Instantiate(healthBar3Obj);
        healthBar4 = Instantiate(healthBar4Obj);
        stage = 1;
        player = GameObject.Find("player");
        created = false;
        spellTime = -1;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController =  this.GetComponent<DespawnController>();
        healthController = this.GetComponent<HealthController>();
        healthBar1.transform.localScale = new Vector3(400f, 50f, 1f); 
        healthBar2.transform.localScale = new Vector3(400f, 50f, 1f); 
        healthBar3.transform.localScale = new Vector3(400f, 50f, 1f); 
        healthBar4.transform.localScale = new Vector3(400f, 50f, 1f);    
        healthBar2.transform.position = new Vector3(2f, 10.5f, 0);    
        healthBar3.transform.position = new Vector3(-2f, 10.5f, 0);    
        healthBar4.transform.position = new Vector3(-6f, 10.5f, 0);    
        healthBar1.transform.position = new Vector3(6f, 10.5f, 0);    
    }
    void SpawnWall1() {
        GameObject bullet = Instantiate(trumpWall1Obj);
        bullet.transform.position = transform.position;
        TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
        despawner.stage = 3;
    }
    void RedStripes() {
        for (int i = 0; i < 7; i++) {
            GameObject bullet = Instantiate(redStripeObj);
            bullet.transform.position = transform.position;
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = stage;
            WallBouncingBulletController controller1 = bullet.GetComponent<WallBouncingBulletController>();
            controller1.UpdateSpeed(12.0f, stripeAngle + 20 * (i-3));
        }
    }
    void WhiteStripes() {
        GameObject bullet = Instantiate(whiteStripeObj);
        bullet.transform.position = transform.position;
        TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
        despawner.stage = stage;
        WallBouncingBulletController controller1 = bullet.GetComponent<WallBouncingBulletController>();
        controller1.UpdateSpeed(10.0f, stripeAngle);
    }
    void SpawnPlane() {
        GameObject plane = Instantiate(bomberObj);
        GameObject path = Instantiate(straightLinePath);
        SpawnInController spawnInController = plane.GetComponent<SpawnInController>();
        plane.transform.SetParent(path.transform);
        plane.transform.localPosition = new Vector3(0,0,0);
        IPath pathController = (IPath) path.GetComponent<IPath>();
        float y = Random.Range(6f,8f);
        float v = Random.Range(8f,10f);
        plane.transform.localScale = new Vector3(-1,1,1);
        float x = Random.Range(-20f,-19f);
        float angle = Random.Range(0f,5f);
        path.transform.position = new Vector3(x, y, 0);
        pathController.SetPathParams(new List<float>{x,y,angle,v,40});
        spawnInController.moving = false;
    }
    // Update is called once per frame  
    void Update()
    {
        if (created) {
            Debug.Log(aliveMinions.Count);
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
            }
            if (escapingTime == 0 && returningTime == 0) {
                spellTime++;
            }
            timeAlive++;
            if (escapingTime > 0 && escaping) {
                escapingTime--;
            }
            else {
                escaping = false;
            }
            if (returningTime > 0 && returning) {
                returningTime--;
            }
            else {
                returning = false;
            }
            if (escaping && !returning) {
                body.velocity = new Vector2(0,8);
            }
            else if (returning && !escaping) {
                body.velocity = new Vector2(0,-8);
            }
            else {
                body.velocity = new Vector2(0,0);
            }
            if ((timeAlive >= despawnController.lifespan / 4 || healthController.hp <= 3 * healthController.maxhp / 4) && stage == 1) {
                stage = 2;
                spellTime = 0;
                p2health = healthController.hp / healthController.maxhp;
                Destroy(healthBar1);
            }
            if ((timeAlive >= 2 * despawnController.lifespan / 4 || healthController.hp <= 2 * healthController.maxhp / 4) && stage == 2) {
                stage = 3;
                spellTime = 0;
                escaping = true;
                escapingTime = 60;
                returningTime = 60;
                returning = false;
                SpawnMinion(minions[0], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[1], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[0], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[1], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                p3health = healthController.hp / healthController.maxhp;
                Destroy(healthBar2);
            }
            if ((timeAlive >= 3 * despawnController.lifespan / 4 || healthController.hp <= healthController.maxhp / 4) && stage == 3) {
                stage = 4;
                spellTime = 0;
                escaping = true;
                escapingTime = 60;
                returningTime = 60;
                returning = false;
                SpawnMinion(minions[0], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[1], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[1], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[2], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                SpawnMinion(minions[3], new Vector3(Random.Range(-6,6),Random.Range(5,9)));
                p4health = healthController.hp / healthController.maxhp;
                Destroy(healthBar3);
            }
            if (timeAlive >= despawnController.lifespan || healthController.hp <= 0) {
                Destroy(healthBar3);
            }
            float percentHealth = healthController.hp / healthController.maxhp;
            if (stage == 1) {
                healthBar1.transform.localScale = new Vector3((percentHealth - 3f/4f) / (1f/4f) * 400, 50, 1);
                healthBar1.transform.position = new Vector3(- (1 - percentHealth) * 8f + 6f, 10.5f, 0);    
            }
            if (stage == 2) {
                healthBar2.transform.localScale = new Vector3((percentHealth - 2f/4f) / (1f/4f) * 400, 50, 1);
                healthBar2.transform.position = new Vector3(- (p2health - percentHealth) * 8f + 2f, 10.5f, 0);
            }
            if (stage == 3) {
                healthBar3.transform.localScale = new Vector3((percentHealth - 1f/4f) / (1f/4f) * 400, 50, 1);
                healthBar3.transform.position = new Vector3(- (p3health - percentHealth) * 8f - 2f, 10.5f, 0);
            }
            if (stage == 4) {
                healthBar4.transform.localScale = new Vector3((percentHealth) / (1f/4f) * 400, 50, 1);
                healthBar4.transform.position = new Vector3(- (p4health - percentHealth) * 8f - 6f, 10.5f, 0);
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
        
        if (stage == 1) {
            if (spellTime % 5000 <= 1500) {
                moneyRain1.Update();
            }
            if ((spellTime % 5000 >= 1600 && spellTime % 5000 < 2200)) {
                reverseMoneyRain1.Update();
            }
            if (spellTime % 5000 >= 2400 && spellTime % 5000 < 3300) {
                reverseMoneyRain2.Update();
            }
        }
        if (stage == 2) {
            if (spellTime % 5000 < 1000) {
                slander1.Update();
            }
            if (spellTime % 5000 >= 1200 && spellTime % 5000 < 2800) {
                slander2.Update();
            }
            if (spellTime % 5000 == 2900) {
                    slander2Dest = originalPosition;
                    slander2Start = transform.position;
            }
            if (spellTime % 5000 >= 2900 && spellTime % 5000 <= 2960) {
                float velocity = Mathf.Pow(Mathf.Pow(spellTime % 5000 - 2900, 2) * Mathf.Pow(spellTime % 5000 - 2960, 2), 0.5f) / 36000;
                Vector3 balls = slander2Dest - slander2Start;
                if (Vector3.Distance(transform.position, slander2Dest) >= 0.2) {body.velocity = new Vector2(balls.x,balls.y) * velocity * 60f;}
                else {body.velocity = new Vector2(0,0);}
            }
            if (spellTime % 5000 >= 3000 && spellTime % 5000 < 4500) {
                moneyRain2.Update();
            }
        }
        if (stage == 3) {
            slander1.interval = 20;
            if (spellTime % 5000 == 1) {
                SpawnWall1();
            }
            if (spellTime % 5000 >= 3601 && spellTime % 5000 <= 4600) {
                wall2.Update();
            }
            if (spellTime % 5000 >= 3800 && spellTime % 5000 <= 4600) {
                slander1.Update();
            }
            if (spellTime % 5000 == 4800) {
                wall2.DestroyWall();
            }
        }
        if (stage == 4) {
            
            if (spellTime % 7500 >= 100 && spellTime % 7500 < 1500) {
                stars.Update();
            }
            if (spellTime % 7500 == 1) {
                stripeAngle = Mathf.Atan2(transform.position[1] - player.transform.position[1], transform.position[0] - player.transform.position[0]) * Mathf.Rad2Deg + 180;
            }
            if (spellTime % 7500 < 40 && (spellTime % 4 - 1 == 0)) {
                RedStripes();
            }
            if (spellTime % 7500 == 500) {
                stripeAngle = Mathf.Atan2(transform.position[1] - player.transform.position[1], transform.position[0] - player.transform.position[0]) * Mathf.Rad2Deg + 180 - 75;
            }
            if (spellTime % 7500 > 500 && spellTime % 7500 < 800 && spellTime % 50 == 0) {
                stripeAngle += 30;
            }
            if (spellTime % 7500 > 500 && spellTime % 7500 < 800 && (spellTime % 50 < 32 && (spellTime % 4 - 1 == 0))) {
                WhiteStripes();
            }
            if (spellTime % 7500 >= 1901 && spellTime % 7500 <= 4700) {
                wall3.Update();
            }
            if (spellTime % 7500 >= 2301 && spellTime % 7500 <= 4700) {
                moneyRain1.Update();
            }
            if (spellTime % 7500 == 5001) {
                SpawnObamas();
            }
            if (spellTime % 7500 >= 5000 && spellTime % 7500 < 7000) {
                if (spellTime % 50 == 0) {
                    SpawnPlane();
                }
                if (spellTime % 500 < 63 || spellTime % 500 >= 438) {
                    transform.position = new Vector3(((spellTime + 62) % 500 - 62f) * 7.7f / 62.5f, 8.3f, 0);
                }
                else if(spellTime % 500 >= 63 && spellTime % 500 < 188) {
                    transform.position = new Vector3(7.7f, (125f - spellTime % 500) * 8.3f / 62.5f, 0);
                }
                else if(spellTime % 500 >= 188 && spellTime % 500 < 313) {
                    transform.position = new Vector3((250f - spellTime % 500) * 7.7f / 62.5f, -8.3f, 0);
                }
                else if(spellTime % 500 >= 313 && spellTime % 500 < 438) {
                    transform.position = new Vector3(-7.7f, (spellTime % 500 - 375f) * 8.3f / 62.5f, 0);
                }
            }
            if (spellTime % 7500 == 7000) {
                transform.position = new Vector3(0, 6.9f, 0);
            }
        }
        if (aliveMinions.Count >= 1) {
            for (int i = aliveMinions.Count-1; i >=0; i--) {
                if (aliveMinions[i] == null || aliveMinions[i].GetComponent<HealthController>().destroyed) {
                    aliveMinions.RemoveAt(i);
                }
            } 
        }
        else {
            returning = true;
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
