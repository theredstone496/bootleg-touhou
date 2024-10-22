

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMoneyRain2A : Attack
{
    int reverseAngle = 0;
    public ReverseMoneyRain2A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        int bulletcount = 43;
        reverseAngle += 29;
        for (int i = 0; i < bulletcount; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = 1;
            float spellAngle = (360 + reverseAngle) / (bulletcount - 1) * i;
            float speed = Mathf.Abs(4 * Mathf.Sin((180 + spellAngle) * Mathf.Deg2Rad)) +1.5f +  Mathf.Abs(1.5f * Mathf.Cos((180 + spellAngle) * Mathf.Deg2Rad));
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.UpdateSpeed(speed, spellAngle);
            controller1.UpdateAcceleration(-0.14f * speed, spellAngle);
            controller1.reverse = true;
            controller1.range = "long";
            controller1.timeMin = i;
            controller1.timeMax = 10000 * i;
        }
    }
}
