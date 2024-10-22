using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpMoneyRain1 : AttackPattern
{
    
    public TrumpMoneyRain1(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 200) {

        activationTimes = new int[2][];
        activationTimes[0] = new int[5]{60,80,100,120,140};
        activationTimes[1] = new int[1]{199};
        patterns = new Attack[]{new MoneyRain1A(new GameObject[1]{bulletList[0]},player,enemy),
                                new MoneyRain1B(new GameObject[1]{bulletList[1]}, player, enemy)};
    }
}
