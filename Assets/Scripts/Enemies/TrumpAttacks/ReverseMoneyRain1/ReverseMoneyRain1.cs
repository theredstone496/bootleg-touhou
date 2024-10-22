using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMoneyRain1 : AttackPattern
{
    public ReverseMoneyRain1(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 100) {

        activationTimes = new int[1][];
        activationTimes[0] = new int[1]{0};
        patterns = new Attack[]{new ReverseMoneyRain1A(bulletList,player,enemy)};
    }
}
