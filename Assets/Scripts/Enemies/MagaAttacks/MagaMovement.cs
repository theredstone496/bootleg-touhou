using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaMovement : AttackPattern
{
    public MagaMovement(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 30) {
        activationTimes = new int[1][];
        activationTimes[0] = new int[]{(int) Random.Range(0,30)};
        patterns = new Attack[]{new MagaMovement1A(bullets, player, enemy)};
    }
}
