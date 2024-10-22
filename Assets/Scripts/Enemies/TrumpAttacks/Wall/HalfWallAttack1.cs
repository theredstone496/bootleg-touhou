using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HalfWallAttack1 : AttackPattern
{
    float distance;
    public HalfWallAttack1(GameObject[] bullets, GameObject wall, float distance): base(bullets, wall, null, 360) {
        activationTimes = new int[3][];
        this.distance = distance;
        activationTimes[0] = Enumerable.Range(0, 15).Select(x => 24 * x).ToArray();
        activationTimes[1] = Enumerable.Range(0,15).Select(x => 18 * x).ToArray();
        activationTimes[2] = Enumerable.Range(0,30).Select(x => 12 * x).ToArray();
        patterns = new Attack[]{new HalfWallAttack1A(new GameObject[]{bullets[0]}, player, wall, distance / 5), new HalfWallAttack1A(new GameObject[]{bullets[1]}, player, wall, distance / 2),
        new HalfWallAttack1B(new GameObject[]{bullets[2]}, player, wall, distance)};
    }
}
