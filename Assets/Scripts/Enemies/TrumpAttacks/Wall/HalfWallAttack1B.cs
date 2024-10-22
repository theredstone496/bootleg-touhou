using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfWallAttack1B : Attack
{
    float distance;
    public HalfWallAttack1B(GameObject[] bullets, GameObject player, GameObject wall, float distance): base(bullets, player, wall) {
        this.distance = distance;
    }
    public override void ActivateAttack(int spellTime) {
        float angle = enemy.transform.eulerAngles[2] + 90;
        int[] angleOffsets = new int[]{0, 180};
        for (int i = 0; i < angleOffsets.Length; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 3;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = enemy.transform.position + distance * new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            controller1.UpdateSpeed(7f, angle+ angleOffsets[i]);
        }
    }
}

