using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slander2Movement : Attack {
    int startTime = 0;
    int endTime = 0;
    public Vector3 slander2Dest;
    public Vector3 slander2Start;
    Rigidbody2D body;
    public Slander2Movement(GameObject[] bullets, GameObject player, GameObject enemy, int startTime, int endTime): base(bullets, player, enemy) {
        this.startTime = startTime;
        this.endTime = endTime;
        body = enemy.GetComponent<Rigidbody2D>();
    }
    public override void ActivateAttack(int spellTime) {
        if (spellTime == startTime) {
            this.slander2Dest = player.transform.position;
            this.slander2Start = enemy.transform.position;
        }
        else {
            float velocity = Mathf.Pow(Mathf.Pow(spellTime - startTime, 2) * Mathf.Pow(spellTime - endTime, 2), 0.5f) / 36000;
            Vector3 balls = slander2Dest - slander2Start;
            if (Vector3.Distance(enemy.transform.position, slander2Dest) >= 0.2) {body.velocity = new Vector2(balls.x,balls.y) * velocity * 60f;}
            else {body.velocity = new Vector2(0,0);}
        }
    }
}
