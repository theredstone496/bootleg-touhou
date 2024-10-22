using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRain2A : Attack
{
    public MoneyRain2A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 47; j++) {
                float angle = (j + 0.5f) * 360f / 47;
                float speed =  70f / (i * 6 + 10);
                GameObject bullet = SpawnBullet(bullets[2]);
                SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                controller1.UpdateSpeed(speed, angle);
                controller1.UpdatePos(10);
            }
            for (int j = 0; j < 62; j++) {
                float angle = (j + 0.5f) * 360f / 62;
                float speed = 70f / (i * 6 + 8);
                GameObject bullet = SpawnBullet(bullets[1]);
                SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                controller1.UpdateSpeed(speed, angle);
                controller1.UpdatePos(10);
            }
            for (int j = 0; j < 73; j++) {
                float angle = (j + 0.5f) * 360f / 73;
                float speed = 70f / (i * 6 + 6);
                GameObject bullet = SpawnBullet(bullets[0]);
                SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                controller1.UpdateSpeed(speed, angle);
                controller1.UpdatePos(10);
            }
        }
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 10; j++) {
                float angle1 = i * 360f / 6 + (j + 0.5f) * 60f / 10;
                float angle2 = i * 360f / 6 - (j + 0.5f) * 60f / 10;
                float speed = (j + 4) * 0.8f;
                GameObject bullet = SpawnBullet(bullets[3]);
                SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                controller1.UpdateSpeed(speed, angle1);
                controller1.UpdatePos(10);
                bullet = SpawnBullet(bullets[3]);
                controller1 = bullet.GetComponent<SimpleBulletController>();
                controller1.UpdateSpeed(speed, angle2);
                controller1.UpdatePos(10);
            }
        }
    }
    public override GameObject SpawnBullet(GameObject obj) {
        GameObject bullet = GameObject.Instantiate(obj);
        TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
        despawner.stage = 2;
        bullet.transform.position = enemy.transform.position;
        return bullet;
    }
}
