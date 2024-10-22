using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnController : MonoBehaviour
{
    public bool exiting;
    public int lifespan;
    int time;
    public bool created;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (created) {time++;}
        if (time >= lifespan) {
            exiting = true;
            HealthController healthController = this.GetComponent<HealthController>();
            if (healthController != null) {
                healthController.destroyed = true;
            }
        }
        if (transform.position[0] > 20 || transform.position[0] < -20) {
            Destroy(gameObject);
        }
        if (transform.position[1] > 18 || transform.position[1] < -18) {
            Destroy(gameObject);
        }
    }
}
