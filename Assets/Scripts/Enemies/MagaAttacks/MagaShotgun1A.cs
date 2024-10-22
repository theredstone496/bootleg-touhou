using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaShotgun1A : Attack
{
    public MagaShotgun1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
    }
    public override void ActivateAttack(int spellTime) {
        for (int i = 0; i < 10; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            float angle = Mathf.Atan2(player.transform.position[1] - enemy.transform.position[1], player.transform.position[0] - enemy.transform.position[0]) * Mathf.Rad2Deg + Random.Range(-30, 30);
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.UpdateSpeed(10f + Random.Range(-0.7f,0.7f),angle);
            bullet.transform.localScale = new Vector3(0.4f,0.4f,1);
        }

    }
}
