using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRain2 : AttackPattern
{
    public MoneyRain2(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 400) {

        activationTimes = new int[1][];
        activationTimes[0] = new int[1]{0};
        patterns = new Attack[]{new MoneyRain2A(bulletList,player,enemy)};
    }
}
