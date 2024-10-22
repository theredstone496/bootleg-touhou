using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpWall1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trumpWall1Bullet;
    public GameObject wallTopHalf;
    public GameObject wallBottomHalf;
    SimpleBulletController[] simpleBulletControllers;
    WallAttack1[] wallAttacks;
    int time;
    int maxTime;
    public int fragmentDelay;
    void Start()
    {
        wallAttacks = new WallAttack1[9];
        for (int i = 0; i < wallAttacks.Length; i++) {
            wallAttacks[i] = new WallAttack1(new GameObject[]{trumpWall1Bullet}, gameObject, (i - (wallAttacks.Length-1) / 2) * 3f);
        }
        simpleBulletControllers = GetComponents<SimpleBulletController>();
        time = 0;
        foreach (SimpleBulletController controller in simpleBulletControllers) {
            if (maxTime < controller.timeMax) {
                maxTime = controller.timeMax;
            }
        }
        maxTime = maxTime + fragmentDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > maxTime) {
        //if (true) {
            TrumpDespawner despawner = GetComponent<TrumpDespawner>();
            float length = GetComponent<BoxCollider2D>().size[1];
            float angle = transform.eulerAngles[2] * Mathf.Deg2Rad;
            GameObject wallTop = Instantiate(wallTopHalf);
            wallTop.transform.position = this.transform.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * length / 8;
            TrumpDespawner topDespawner = wallTop.GetComponent<TrumpDespawner>();
            topDespawner.stage = despawner.stage;
            GameObject wallBottom = Instantiate(wallBottomHalf);
            wallBottom.transform.position = this.transform.position - new Vector3(Mathf.Sin(angle), Mathf.Cos(angle)) * length / 8;
            TrumpDespawner bottomDespawner = wallBottom.GetComponent<TrumpDespawner>();
            bottomDespawner.stage = despawner.stage;
            Destroy(gameObject);
        }
        for (int i = 0; i < wallAttacks.Length; i++) {
            wallAttacks[i].Update();
        }
        time++;
    }
}
