using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MagaShotgun : AttackPattern
{
    
    public MagaShotgun(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 600) {

        activationTimes = new int[1][];
        int offset = (int) Random.Range(0,200);
        activationTimes[0] = Enumerable.Range(0, 4).Select(x => 120 * x + offset).ToArray();
        patterns = new Attack[]{new MagaShotgun1A(bullets,player,enemy)};
    }
}
