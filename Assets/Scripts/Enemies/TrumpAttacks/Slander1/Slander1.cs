using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slander1 : AttackPattern
{
    public Slander1(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 6) {

        activationTimes = new int[1][];
        activationTimes[0] = new int[1]{0};
        patterns = new Attack[]{new Slander1A(bulletList,player,enemy)};
    }
}
