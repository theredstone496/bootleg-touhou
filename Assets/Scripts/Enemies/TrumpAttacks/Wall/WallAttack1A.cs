using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAttack1A : Attack
{
    float distance;
    public WallAttack1A(GameObject[] bullets, GameObject player, GameObject wall, float distance): base(bullets, player, wall) {
        this.distance = distance;
    }
    public override void ActivateAttack(int spellTime) {
        float angle = enemy.transform.eulerAngles[2] + 90;
        int[] angleOffsets = new int[]{-15,15,165,195};
        for (int i = 0; i < angleOffsets.Length; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 3;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = enemy.transform.position + distance * new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);
            controller1.UpdateSpeed(6f + (i % 2) * 0.3f, angle + 90 + angleOffsets[i]);
        }

    }
}
