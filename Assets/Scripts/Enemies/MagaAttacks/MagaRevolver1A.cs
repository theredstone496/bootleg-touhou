using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaRevolver1A : Attack {
    public MagaRevolver1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {

    }
    public override void ActivateAttack(int spellTime) {
        GameObject bullet = SpawnBullet(bullets[0]);
        float angle = Mathf.Atan2(player.transform.position[1] - enemy.transform.position[1], player.transform.position[0] - enemy.transform.position[0]) * Mathf.Rad2Deg;
        SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
        controller1.UpdateSpeed(7f,angle);
        bullet.transform.localScale = new Vector3(2.2f,2.2f,1);
    }
}
