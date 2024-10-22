using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wall2 : AttackPattern
{
    public Wall2(GameObject enemy, GameObject wallObj, bool bulletBlock = false): base(null, enemy, null, 300) {
        activationTimes = new int[1][];
        activationTimes[0] = Enumerable.Range(0,800).ToArray();
        patterns = new Attack[]{new Wall2A(enemy, player, wallObj, bulletBlock)};
    }
    public void DestroyWall() {
        ((Wall2A) patterns[0]).DestroyWall();
    }
}
