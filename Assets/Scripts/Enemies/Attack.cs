using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public GameObject[] bullets;
    public GameObject player;
    public GameObject enemy;
    public Attack(GameObject[] bullets, GameObject player, GameObject enemy) {
        this.bullets = bullets;
        this.player = player;
        this.enemy = enemy;
    }
    abstract public void ActivateAttack(int spellTime);
    public virtual GameObject SpawnBullet(GameObject bullet1) {
        GameObject thing = GameObject.Instantiate(bullet1);
        thing.transform.position = enemy.transform.position;
        return thing;
    }
}
