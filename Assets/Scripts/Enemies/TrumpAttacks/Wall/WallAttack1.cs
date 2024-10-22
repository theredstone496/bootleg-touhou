using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAttack1 : AttackPattern
{
    float distance;
    public WallAttack1(GameObject[] bullets, GameObject wall, float distance): base(bullets, wall, null, 300) {
        activationTimes = new int[1][];
        this.distance = distance;
        activationTimes[0] = new int[1]{0};
        patterns = new Attack[]{new WallAttack1A(bullets, player, wall, distance)};
    }
}
