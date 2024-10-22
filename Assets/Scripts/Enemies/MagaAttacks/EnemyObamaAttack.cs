using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObamaAttack : AttackPattern
{
    public EnemyObamaAttack(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 4) {
        activationTimes = new int[1][];
        int offset = (int) Random.Range(0,90);
        activationTimes[0] = new int[]{0};
        patterns = new Attack[]{new EnemyObamaAttack1(bullets,player,enemy)};
    }
}

