using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvincibleBulletImpactor : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collider1;
    GameObject player;
    public bool disableCollider = true;
    void Start()
    {
        collider1 = (Collider2D) this.GetComponent(typeof(Collider2D));
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist > 1 && disableCollider) {
            if (collider1 != null) {collider1.enabled = false;}
        }
        else {
            if (collider1 != null) {collider1.enabled = true;}
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player") {
            PlayerController playerController = hitInfo.gameObject.GetComponent<PlayerController>();
            if (!playerController.ghosting) {
                playerController.RemoveLives(1);
            }
            
        }
        if (hitInfo.gameObject.tag == "Bomb") {
                      
        }
        
    }
}
