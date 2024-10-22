using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wall3 : AttackPattern
{
    public Wall3(GameObject enemy, GameObject wallObj, bool bulletBlock = true): base(null, enemy, null, 3000) {
        activationTimes = new int[2][];
        activationTimes[0] = Enumerable.Range(0,3000).ToArray();
        activationTimes[1] = Enumerable.Range(0,3000).ToArray();
        patterns = new Attack[]{new Wall3A(enemy, player, wallObj, bulletBlock),new Wall3B(enemy, player, wallObj, bulletBlock)};
    }
}
