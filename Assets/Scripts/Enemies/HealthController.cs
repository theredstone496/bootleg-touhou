using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxhp;
    public float hp;
    public bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp;
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void RemoveHealth(float damage) {
        hp -= damage;
        if (hp < 0) {
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
