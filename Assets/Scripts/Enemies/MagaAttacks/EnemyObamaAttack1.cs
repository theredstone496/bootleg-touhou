using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObamaAttack1 : Attack {
    public EnemyObamaAttack1(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {

    }
    public override void ActivateAttack(int spellTime) {
        GameObject bullet = SpawnBullet(bullets[0]);
        float angle = Mathf.Atan2(player.transform.position[1] - enemy.transform.position[1], player.transform.position[0] - enemy.transform.position[0]) * Mathf.Rad2Deg;
        SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
        controller1.UpdateSpeed(5f,angle);
        controller1.UpdateAcceleration(5f, angle);
    }
}
