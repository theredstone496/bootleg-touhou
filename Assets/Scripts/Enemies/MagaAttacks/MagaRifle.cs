using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagaRifle : AttackPattern
{
    
    public MagaRifle(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 500) {

        activationTimes = new int[1][];
        int offset = (int) Random.Range(0,200);
        activationTimes[0] = Enumerable.Range(0, 30).Select(x => 5 * x + offset).ToArray();
        patterns = new Attack[]{new MagaRifle1A(bullets,player,enemy)};
    }
}
