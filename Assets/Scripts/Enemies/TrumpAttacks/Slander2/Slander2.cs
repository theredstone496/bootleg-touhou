using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Slander2 : AttackPattern
{
    public Slander2(GameObject[] bullets, GameObject enemy): base(bullets, enemy, null, 360) {
        int movementStart = 190;
        int movementDura = 60;
        activationTimes = new int[3][];
        activationTimes[0] = new int[]{0,8,16,24,32,40,46,52,58,64,70,76,82,88};
        activationTimes[1] = Enumerable.Range(0, movementDura / 15 + 1).Select(x => movementStart + 15 * x).ToArray();
        activationTimes[2] = Enumerable.Range(movementStart, movementDura + 1).ToArray();
        Slander2Movement movement = new Slander2Movement(bulletList,player,enemy, movementStart, movementStart + movementDura);
        patterns = new Attack[]{new Slander2A(bulletList,player,enemy), 
        new Slander2B(bulletList,player,enemy,movementStart, movement), movement};
    }
}
