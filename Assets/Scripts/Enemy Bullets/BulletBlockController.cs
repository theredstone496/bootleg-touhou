using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlockController : MonoBehaviour
{
    public bool blocking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (blocking) {
            Debug.Log("delete bulet");
            if (hitInfo.gameObject.tag == "Bullet") {
                Destroy(hitInfo.gameObject);
            }
        }

    }
}
