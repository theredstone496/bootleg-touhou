using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMoneyRain1A : Attack
{
    public ReverseMoneyRain1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        int bulletcount = 25;
        System.Random rand = new System.Random();
        int empty = rand.Next(1, bulletcount + 1);
        for (int i = 0; i < bulletcount; i++) {
            int coin = rand.Next(1, 3);
            GameObject bullet;
            if (coin == 1) {
                bullet = SpawnBullet(bullets[0]);
            }
            else {
                bullet = SpawnBullet(bullets[1]);
            }
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 1;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = new Vector3(-9.5f + 19f / (bulletcount - 1) * i, -10.8f, 0);
            controller1.UpdateSpeed(3.5f, 90);
            if (empty - 1 == i) {
                GameObject.Destroy(bullet);
            }
        }
    }
}
