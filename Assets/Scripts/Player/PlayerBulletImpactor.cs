using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletImpactor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 11) {
            GameObject.Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Enemy") {
            HealthController enemyHealthController = hitInfo.gameObject.GetComponent<HealthController>();
            enemyHealthController.RemoveHealth(1);
            Destroy(gameObject);
            
        }
        
    }
}
