using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRain1B : Attack
{
    private int spellAngle = 0;
    public MoneyRain1B(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        spellAngle += 45;
        spellAngle = spellAngle % 360;
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 8; j++) {
                for (int k = 0; k <= j; k++) {
                    GameObject bullet = SpawnBullet(bullets[0]);
                    TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
                    despawner.stage = enemy.GetComponent<TrumpController>().stage;
                    SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
                    float spellAngle1 = 0;
                    if (j == 0) {
                        spellAngle1 = 90 * i + spellAngle;
                    }
                    else {
                        spellAngle1 = 90 * i + spellAngle + 60f / (float) (j) * ((float) (k) - (float)(j) / 2f);
                    }
                    controller1.transform.position = controller1.transform.position + new Vector3(2f * (i - 1) - 4f * (i==3 ? 1 : 0), 2f * (i - 2) + 4f * (i==0 ? 1 : 0), 0);
                    controller1.UpdateSpeed(j + 4, spellAngle1);
                }   
            }
        }
    }
}
