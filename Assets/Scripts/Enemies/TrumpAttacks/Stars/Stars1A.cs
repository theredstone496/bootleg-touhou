

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars1A : Attack
{
    public Stars1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        for (int i = 0; i < 5; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = enemy.GetComponent<TrumpController>().stage;
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(enemy.transform.position[1] - playery, enemy.transform.position[0] - playerx) * Mathf.Rad2Deg + 180;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.UpdateSpeed((21.0f - 2 * i) / 1.5f, angle - 65 - 8 * i);
            controller1.reverse = true;
            controller1.UpdateAcceleration((17.0f - 3 * i) / 1.5f, angle + 80 - 5 * i);
        }
        for (int i = 0; i < 5; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = enemy.GetComponent<TrumpController>().stage;
            float playerx = player.transform.position[0]; 
            float playery = player.transform.position[1];
            float angle = Mathf.Atan2(enemy.transform.position[1] - playery, enemy.transform.position[0] - playerx) * Mathf.Rad2Deg + 180;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.UpdateSpeed((21.0f - 2 * i) / 1.5f, angle + 65 + 8 * i);
            controller1.reverse = true;
            controller1.UpdateAcceleration((17.0f - 3 * i) / 1.5f, angle - 80 + 5 * i);
        }
    }
}
