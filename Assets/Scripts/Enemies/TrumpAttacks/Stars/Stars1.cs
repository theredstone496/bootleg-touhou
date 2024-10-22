using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars1 : AttackPattern
{
    public Stars1(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 1500) {

        activationTimes = new int[1][];
        activationTimes[0] = new int[]{0,300,600,900,1200};
        patterns = new Attack[]{new Stars1A(bulletList,player,enemy)};
    }
}
