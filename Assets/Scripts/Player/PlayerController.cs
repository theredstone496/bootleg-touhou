using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using TMPro;
[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public float speed;
    private float movespeed;
    float speedup;
    float speeddown;
    float speedleft;
    float speedright;
    private Controls m_Controls;
    private Rigidbody2D body;  
    public GameObject playerBulletObj;
    public GameObject bloodExplosionObj;
    public GameObject playerBombObj;
    public GameObject playerSuicideBulletObj;
    SpriteRenderer spriteRenderer;
    CircleCollider2D collider;
    private bool firing;
    public bool ghosting;
    private bool suiciding;
    private float suicideAngle;
    public int maxLives;
    int lives;
    public int maxBombs;
    int suicideTime;
    int bombs;
    bool suicideEnabled;
    // Start is called before the first frame update
    public void Awake()
    {
        m_Controls = new Controls();
        m_Controls.Default.Up.started +=
            ctx =>
        {
            speedup = movespeed;
        };
        m_Controls.Default.Up.canceled +=
            ctx =>
        {
            speedup = 0;
        };
        m_Controls.Default.Down.started +=
            ctx =>
        {
            speeddown = movespeed;
        };
        m_Controls.Default.Down.canceled +=
            ctx =>
        {
            speeddown = 0;
        };
        m_Controls.Default.Left.started +=
            ctx =>
        {
            speedleft = movespeed;
        };
        m_Controls.Default.Left.canceled +=
            ctx =>
        {
            speedleft = 0;
        };
        m_Controls.Default.Right.started +=
            ctx =>
        {
            speedright = movespeed;
        };
        m_Controls.Default.Right.canceled +=
            ctx =>
        {
            speedright = 0;
        };
        m_Controls.Default.Slow.started +=
            ctx =>
        {
            movespeed = speed * 0.33f;
            if (speedleft != 0) {
                speedleft = speed * 0.33f;
            }
            if (speedup != 0) {
                speedup = speed * 0.33f;
            }
            if (speedright != 0) {
                speedright = speed * 0.33f;
            }
            if (speeddown != 0) {
                speeddown = speed * 0.33f;
            }
        };
        m_Controls.Default.Slow.canceled +=
            ctx =>
        {
            movespeed = speed;
            if (speedleft != 0) {
                speedleft = speed;
            }
            if (speedup != 0) {
                speedup = speed;
            }
            if (speedright != 0) {
                speedright = speed;
            }
            if (speeddown != 0) {
                speeddown = speed;
            }
        };
        m_Controls.Default.Shoot.started +=
            ctx =>
            {
                firing = true;
            };
        m_Controls.Default.Shoot.canceled +=
            ctx =>
            {
                firing = false;
            };
        m_Controls.Default.Bomb.started +=
            ctx =>
            {
                if (playerBombObj != null && bombs > 0) {GameObject bomb = Instantiate(playerBombObj);
                bomb.transform.position = this.transform.position;
                RemoveBomb();}
            };
        m_Controls.Default.SuicideBomb.started +=
            ctx =>
            {
                if (!ghosting && suicideEnabled) {RemoveLives(1);
                RemoveBomb();
                suiciding = true;
                Invoke("StopSuiciding", 1.5f);}
            };
        
    }
    public void OnEnable()
    {
        m_Controls.Enable();
    }

    public void OnDisable()
    {
        m_Controls.Disable();
    }
    void Start()
    {
        //playerbulletobj = Resources.Load("prefabs/");
        firing = false;
        ghosting = false;
        movespeed = speed;
        speedup = 0;
        speeddown = 0;
        speedleft = 0;
        speedright = 0;
        body = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<CircleCollider2D>();
        bombs = maxBombs;
        lives = maxLives;
        int suicideValue = PlayerPrefs.GetInt("suicide", 0);
        if (suicideValue == 0) {
            suicideEnabled = false;
        }
        else if (suicideValue == 1) {
            suicideEnabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(collider.IsTouchingLayers(Physics2D.AllLayers));
        //body.velocity = new Vector2(speedright - speedleft,speedup - speeddown);
        transform.position += new Vector3(speedright - speedleft,speedup - speeddown, 0) * 1f / 60f;
        if (transform.position.x < -9.577) {
            transform.position= new Vector3(-9.577f, transform.position.y, 0);
        }
        if (transform.position.x > 9.577) {
            transform.position= new Vector3(9.577f, transform.position.y, 0);
        }
        if (transform.position.y < -10.912) {
            transform.position= new Vector3(transform.position.x, -10.912f, 0);
        }
        if (transform.position.y > 10.912) {
            transform.position= new Vector3(transform.position.x, 10.912f, 0);
        }
        if (m_Controls.Default.Shoot.ReadValue<float>() == 1 && playerBulletObj != null && lives >= 0) {
            PlayerShoot();
        }
        if (suiciding) {
            suicideTime++;
            if (suicideTime % 1 == 0) {SuicideBomb();}
        }
        
    }
    void PlayerShoot()
    {
        GameObject playerBullet = Instantiate(playerBulletObj);
            SimpleHomingBulletController controller = playerBullet.GetComponent<SimpleHomingBulletController>();
            controller.UpdateSpeed(48f,90);
            controller.UpdateHomingRate(0f);
            controller.transform.position = transform.position - new Vector3(0.08f,0.0f,0);
    }
    public void RemoveLives(int livesToRemove) {
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f,0.35f);
        /*collider.enabled = false;*/
        ghosting = true;
        lives -= livesToRemove;
        if (lives >= 0) {
            Invoke("StopGhosting", 2.0f);
        }
        LifeRenderer lifeRenderer = GameObject.Find("lives").GetComponent<LifeRenderer>();
        lifeRenderer.RemoveLives(livesToRemove);
        GameObject bloodExplosion = Instantiate(bloodExplosionObj);
        BloodExplosionController controller = bloodExplosion.GetComponent<BloodExplosionController>();
        bloodExplosion.transform.SetParent(this.transform);
        bloodExplosion.transform.localPosition = new Vector3(0,0);
        controller.Explode(30, 0.3f, 4.0f, 0.7f, 0.0f);
        //RestoreBombs(livesToRemove);
    }
    public void RemoveBomb() {
        bombs --;
        BombDisplayer bombRenderer = GameObject.Find("bombs").GetComponent<BombDisplayer>();
        bombRenderer.RemoveBomb();
    }
    public void RestoreBombs(int number) {
        bombs += number;
        BombDisplayer bombRenderer = GameObject.Find("bombs").GetComponent<BombDisplayer>();
        bombRenderer.RestoreBombs(number);
    }
    public void StopGhosting() {
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f,1.0f);
        collider.enabled = true;
        ghosting = false;
    }
    public void StopSuiciding() {
        suiciding = false;
        suicideTime = 0;
    }
    void SuicideBomb() {
        suicideAngle += 7.3f;
        GameObject playerBullet = Instantiate(playerSuicideBulletObj);
        WallBouncingBulletController controller = playerBullet.GetComponent<WallBouncingBulletController>();
        controller.UpdateSpeed(30f,suicideAngle);
        controller.transform.position = transform.position - new Vector3(0.08f,0.0f,0);
        playerBullet = Instantiate(playerSuicideBulletObj);
        controller = playerBullet.GetComponent<WallBouncingBulletController>();
        controller.UpdateSpeed(30f,-suicideAngle);
        controller.transform.position = transform.position - new Vector3(0.08f,0.0f,0);
        playerBullet = Instantiate(playerSuicideBulletObj);
        controller = playerBullet.GetComponent<WallBouncingBulletController>();
        controller.UpdateSpeed(30f,180 - suicideAngle);
        controller.transform.position = transform.position - new Vector3(0.08f,0.0f,0);
        playerBullet = Instantiate(playerSuicideBulletObj);
        controller = playerBullet.GetComponent<WallBouncingBulletController>();
        controller.UpdateSpeed(30f,suicideAngle + 180);
        controller.transform.position = transform.position - new Vector3(0.08f,0.0f,0);
    }
    public void Win() {
        if (lives >= 0) {
            if (!suicideEnabled) {
                GameObject.Find("SuicideText").GetComponent<TMP_Text>().enabled = true;
            }
            GameObject.Find("WinText").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("BackText").GetComponent<TMP_Text>().enabled = true;
            GameObject.Find("BackButton").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("BackButton").GetComponent<SpriteRenderer>().enabled = true;
            PlayerPrefs.SetInt("suicide", 1);
            PlayerPrefs.Save();
        }
    }
}
