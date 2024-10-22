using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaMovement1A : Attack{
    Rigidbody2D body;
    public MagaMovement1A(GameObject[] bullets, GameObject player, GameObject enemy): base(bullets, player, enemy) {
        body = enemy.GetComponent<Rigidbody2D>();
    }
    public override void ActivateAttack(int spellTime) {
        float x = enemy.transform.position[0] / 24f;
        float y = (enemy.transform.position[1] - 6.5f) / 7.5f;
        body.velocity = new Vector2(Random.Range(-3 - x, 3 - x), Random.Range(-3 - y, 3 - y));
    }
}
