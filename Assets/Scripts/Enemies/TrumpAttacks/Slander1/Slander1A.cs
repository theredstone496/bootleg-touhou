

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slander1A : Attack
{
    public Slander1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        int bulletcount = 5;
        System.Random rand = new System.Random();
        int angleOff = rand.Next(-45, 46);
        for (int i = 0; i < bulletcount; i++) {
            int bulletNo = rand.Next(0, 28);
            GameObject bullet = SpawnBullet(bullets[bulletNo]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = enemy.GetComponent<TrumpController>().stage;
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(enemy.transform.position[1] - playery, enemy.transform.position[0] - playerx) * Mathf.Rad2Deg + angleOff + (i - (bulletcount - 1) / 2) * 30 + rand.Next(-2, 3);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.UpdateSpeed(6.0f, angle, false);
            controller1.UpdateAcceleration(9.0f, Mathf.Atan2(playery - enemy.transform.position[1], playerx - enemy.transform.position[0]) * Mathf.Rad2Deg);
            controller1.reverse = true;
            controller1.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }
}
