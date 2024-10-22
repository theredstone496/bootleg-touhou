using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackPattern
{
    int time = 0;
    public int interval;
    public int[][] activationTimes;
    public GameObject[] bulletList;
    public Attack[] patterns;
    public GameObject player;
    public GameObject enemy;
    public AttackPattern(GameObject[] bulletList, GameObject enemy, int[][] activationTimes, int interval) {
        this.bulletList = bulletList;
        this.player = GameObject.Find("player");;
        this.enemy = enemy;
        this.activationTimes = activationTimes;
        this.interval = interval;
        
    }
    public void Update() {

        if (time >= interval) {
            time = 0;
        }
        for (int i = 0; i < activationTimes.Length;i++) {
            if (Array.Exists(activationTimes[i], element => element == time)) {
                patterns[i].ActivateAttack(time);
            }
        }
        time++;
    }
}
