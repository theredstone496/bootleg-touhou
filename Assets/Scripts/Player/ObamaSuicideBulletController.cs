using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObamaSuicideBulletController : MonoBehaviour
{
    DespawnController despawnController;
    public GameObject bombObject;
    // Start is called before the first frame update
    void Start()
    {
        despawnController = this.GetComponent<DespawnController>();
    }

    // Update is called once per frame
    void Update()
    {
        despawnController.created = true;
        if (despawnController.exiting) {
            Bomb();
        }
    }
    void Bomb() {
        if (bombObject != null) {GameObject bomb = Instantiate(bombObject);
            bomb.transform.position = this.transform.position;
            ObamaBombController bombController = bomb.GetComponent<ObamaBombController>();
            bombController.movementConstant = 0f;
            bombController.scaleConstant = 0f;
            bombController.curveConstant = 0;
            bombController.startScale = 5f;
            bombController.scaleMax = 5f;
            bombController.duration = 20;
            bombController.damage = 10f;
        }
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Bullet") {
            Bomb();
        }
        
    }

}
