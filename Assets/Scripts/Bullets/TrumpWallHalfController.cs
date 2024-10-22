using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpWallHalfController : MonoBehaviour
{
    [SerializeField] public GameObject[] wallHalfBullets;
    HalfWallAttack1 halfWallAttack;
    HalfWallAttack1 halfWallAttack2;
    public int time;
    public int maxTime;
    // Start is called before the first frame update
    void Start()
    {
        halfWallAttack = new HalfWallAttack1(wallHalfBullets, gameObject, 5);
        halfWallAttack2 = new HalfWallAttack1(wallHalfBullets, gameObject, -5);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= maxTime) {
            halfWallAttack.Update();
            halfWallAttack2.Update();
        }

        time++;
    }
}
