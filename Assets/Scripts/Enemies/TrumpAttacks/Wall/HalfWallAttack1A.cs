using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfWallAttack1A : Attack
{
    float distance;
    public HalfWallAttack1A(GameObject[] bullets, GameObject player, GameObject wall, float distance): base(bullets, player, wall) {
        this.distance = distance;
    }
    public override void ActivateAttack(int spellTime) {
        Debug.Log(enemy);
        float angle = enemy.transform.eulerAngles[2] + 90;
        int[] angleOffsets = new int[]{0, 180};
        for (int i = 0; i < angleOffsets.Length; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 3;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            if (controller1 == null) {
                SimpleHomingBulletController controller2 = bullet.GetComponent<SimpleHomingBulletController>();
                controller2.transform.position = enemy.transform.position + distance * new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
                controller2.UpdateSpeed(7f, angle + 90 + angleOffsets[i]);
            }
            else {
            controller1.transform.position = enemy.transform.position + distance * new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            controller1.UpdateSpeed(5f, angle + 90 + angleOffsets[i]);
            }
        }
    }
}
