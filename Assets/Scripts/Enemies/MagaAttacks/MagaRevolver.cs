using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagaRevolver : AttackPattern
{
    public MagaRevolver(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 400) {
        activationTimes = new int[1][];
        int offset = (int) Random.Range(0,90);
        activationTimes[0] = Enumerable.Range(0,6).Select(x => 60 * x + offset).ToArray();
        patterns = new Attack[]{new MagaRevolver1A(bullets,player,enemy)};
    }
}
