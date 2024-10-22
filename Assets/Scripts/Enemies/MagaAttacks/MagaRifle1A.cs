using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaRifle1A : Attack
{
    public MagaRifle1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        GameObject bullet = SpawnBullet(bullets[0]);
        float angle = Mathf.Atan2(player.transform.position[1] - enemy.transform.position[1], player.transform.position[0] - enemy.transform.position[0]) * Mathf.Rad2Deg;
        SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
        controller1.UpdateSpeed(16f,angle);
    }
}
