using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpDespawner : MonoBehaviour
{
    public GameObject trump;
    public int stage;
    // Start is called before the first frame update
    void Start()
    {
        trump = GameObject.Find("enemytrump(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (trump == null || trump.GetComponent<TrumpController>().stage != stage) {
            Destroy(gameObject);
        }
    }
}
