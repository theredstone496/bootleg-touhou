using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRain1A : Attack
{
    private int spellAngle = 0;
    public MoneyRain1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        
    }
    public override void ActivateAttack(int spellTime) {
        spellAngle += 5;
        spellAngle = spellAngle % 360; 
        for (int i = 0; i < 40; i++) {
            GameObject bullet = SpawnBullet(bullets[0]);
            TrumpDespawner despawner = bullet.GetComponent<TrumpDespawner>();
            despawner.stage = enemy.GetComponent<TrumpController>().stage;
            SimpleBulletController controller1 = bullet.GetComponent<SimpleBulletController>();
            controller1.transform.position = controller1.transform.position + new Vector3(6f * Mathf.Cos((spellAngle + i * 9f) * Mathf.Deg2Rad), 6f * Mathf.Sin((spellAngle + i * 9f) * Mathf.Deg2Rad), 0) * 0.1f;;
            controller1.UpdateSpeed(8f,spellAngle + i * 9f);
        }
    }
}
