using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall3B : Attack
{
    GameObject[] walls;
    GameObject wallObj;
    bool bulletBlock;
    int wallCount;
    public Wall3B(GameObject enemy, GameObject player, GameObject wallObj, bool bulletBlock = true): base(null, player, enemy) {
        wallCount = 7;
        walls = new GameObject[7];
        this.wallObj = wallObj;
        this.bulletBlock = bulletBlock;
    }
    public override void ActivateAttack(int spellTime) {
        
        for (int i = 0; i < wallCount; i++) {
if (walls[i] == null) {
                walls[i] = SpawnBullet(wallObj);
                TrumpWall2Controller wallcontroller0 = walls[i].GetComponent<TrumpWall2Controller>();
                TrumpDespawner despawner = walls[i].GetComponent<TrumpDespawner>();
                despawner.stage = 4;
                wallcontroller0.SetScale(0.4f);
                SimpleBulletController controller0 = walls[i].GetComponent<SimpleBulletController>();
                walls[i].transform.position = new Vector3(Random.Range(-12f,0f),10,0);
                controller0.UpdateSpeed(4, 270);
                controller0.reverse = true;
                controller0.range = "long";
            }
            TrumpWall2Controller wallcontroller = walls[i].GetComponent<TrumpWall2Controller>();
            if (bulletBlock) {
                wallcontroller.SetBulletBlocking(bulletBlock);
            }
            if (spellTime == 180) {
                SimpleBulletController controller0 = walls[i].GetComponent<SimpleBulletController>();
                controller0.UpdateSpeed(Random.Range(2.4f, 3f) - Mathf.Sqrt(Mathf.Abs(walls[i].transform.position[0])) / 2.5f, Random.Range(250f, 290f));
                controller0.reverse = true;
                controller0.range = "long";
            }
            if (spellTime > 180) {
                SimpleBulletController controller1 = walls[i].GetComponent<SimpleBulletController>();
                Vector2 speedChange = 40 * (new Vector2(4, -3) - new Vector2(walls[i].transform.position.x, walls[i].transform.position.y)) / Mathf.Pow((new Vector2(4, -3) - new Vector2(walls[i].transform.position.x, walls[i].transform.position.y)).magnitude, 3);
                controller1.haccel = speedChange[0];
                controller1.vaccel = speedChange[1];
                if (spellTime % 300 == 0) {
                    wallcontroller.ChangePosition();
                }
            }
        }
        

    }
}
