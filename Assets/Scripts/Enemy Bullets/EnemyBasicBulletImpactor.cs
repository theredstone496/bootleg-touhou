using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicBulletImpactor : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D collider;
    GameObject player;
    public bool disableCollider = true;
    void Start()
    {
        collider = (Collider2D) this.GetComponent(typeof(Collider2D));
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist > 1 && disableCollider) {
            if (collider != null) {collider.enabled = false;}
        }
        else {
            if (collider != null) {collider.enabled = true;}
        }
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        if (bombs != null) {
            for (int i = 0; i < bombs.Length; i++) {
                if (((BombController) bombs[i].GetComponent(typeof(BombController))).IsInBomb(this.transform.position)) {
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player") {
            PlayerController playerController = hitInfo.gameObject.GetComponent<PlayerController>();
            if (!playerController.ghosting) {
                playerController.RemoveLives(1);
                Destroy(gameObject);
            }
            
        }
        if (hitInfo.gameObject.tag == "Bomb") {
                      
            Destroy(gameObject);
                       
        }
        
    }
}
