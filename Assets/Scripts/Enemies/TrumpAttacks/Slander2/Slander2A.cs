using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slander2A : Attack
{
    public Slander2A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        float offset = 0;
        if (spellTime > 30) {
            offset = Mathf.Pow((spellTime - 30) / 2, 1.5f);
        }
        System.Random rand = new System.Random();
        int bulletcount = 3;
        for (int i = 0; i < bulletcount; i++) {
            int bulletNo = rand.Next(0, 28);
            GameObject bullet = SpawnBullet(bullets[bulletNo]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 2;
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(playery - enemy.transform.position[1], playerx - enemy.transform.position[0]) * Mathf.Rad2Deg;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = controller1.transform.position + (i - ((bulletcount - 1) / 2)) * new Vector3(1f, 0, 0);
            controller1.UpdateSpeed(16.0f, angle + offset * (i - (bulletcount - 1) / 2), false);
        }
        for (int i = 0; i < bulletcount; i++) {
            int bulletNo = rand.Next(0, 28);
            GameObject bullet = SpawnBullet(bullets[bulletNo]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 2;
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(playery - enemy.transform.position[1], playerx - enemy.transform.position[0]) * Mathf.Rad2Deg;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = controller1.transform.position + (i - ((bulletcount - 1) / 2)) * new Vector3(0, 1f, 0);
            controller1.UpdateSpeed(10.0f, angle + offset * (i - (bulletcount - 1) / 2), false);
        }
    }
}
