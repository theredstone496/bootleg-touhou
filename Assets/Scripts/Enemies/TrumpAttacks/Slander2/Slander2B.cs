using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slander2B : Attack
{
    int startTime = 0;
    Slander2Movement movementScript;
    public Slander2B(GameObject[] bullets, GameObject player, GameObject enemy, int startTime, Slander2Movement movement): base(bullets, player, enemy) {
        movementScript = movement;
        this.startTime = startTime;
    }
    public override void ActivateAttack(int spellTime) {
        Vector3 path = movementScript.slander2Dest - movementScript.slander2Start;
        float frontAngle = Mathf.Atan2(path.y,path.x) * Mathf.Rad2Deg;
        float leftAngle = frontAngle + 40;
        float rightAngle = frontAngle - 40;
        int bulletcount1 = 2;
        int bulletcount = 3;
        System.Random rand = new System.Random();
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < bulletcount1; j++) {
                int bulletNo = rand.Next(0, 28);
                GameObject bullet = SpawnBullet(bullets[bulletNo]);
                SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                
                TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
                despawner.stage = 2;
                controller1.UpdateSpeed(8.0f, frontAngle + i * 90 + (j-(bulletcount1-1)/2) * 10);
                controller1.transform.localScale = new Vector3(0.6f,0.6f,1);
            }
        }
        for (int i = 0; i < bulletcount; i++) {
            int bulletNo = rand.Next(0, 28);
            GameObject bullet = SpawnBullet(bullets[bulletNo]);  
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 2;
            controller1.UpdateSpeed(10.0f, leftAngle + (i-(bulletcount-1)/2) * 5);
            controller1.transform.localScale = new Vector3(0.6f,0.6f,1);
        }
        for (int i = 0; i < bulletcount; i++) {
            int bulletNo = rand.Next(0, 28);
            GameObject bullet = SpawnBullet(bullets[bulletNo]);  
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 2;
            controller1.UpdateSpeed(10.0f, rightAngle + (i-(bulletcount-1)/2) * 5);
            controller1.transform.localScale = new Vector3(0.6f,0.6f,1);
        }
    }
}
