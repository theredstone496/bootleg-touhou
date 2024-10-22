using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2A : Attack
{
    GameObject wall;
    GameObject wallObj;
    bool bulletBlock;
    public Wall2A(GameObject enemy, GameObject player, GameObject wallObj, bool bulletBlock = false): base(null, player, enemy) {
        wall = null;
        this.wallObj = wallObj;
        this.bulletBlock = bulletBlock;
    }
    public override void ActivateAttack(int spellTime) {
        if (wall == null) {
            wall = SpawnBullet(wallObj);
            float y = 0f;
            if (player.transform.position[1] < 0) {
                y = player.transform.position[1];
            }
            wall.transform.position = new Vector3(0, y, 0);
            TrumpWall2Controller wallcontroller = wall.GetComponent<TrumpWall2Controller>();
            if (bulletBlock) {
                wallcontroller.SetBulletBlocking(bulletBlock);
            }
            wallcontroller.SetScale(8f);
        }
        TrumpWall2Controller controller2 = wall.GetComponent<TrumpWall2Controller>();
        if (controller2.scale > 2.3f) {
            Debug.Log("Reducing scale");
            controller2.SetScale(controller2.scale-0.04f);
            if (controller2.scale <= 2.3f) {
                controller2.SetScale(2.3f);
                SimpleBulletController controller1 = wall.GetComponent<SimpleBulletController>();
                if (Random.Range(0, 1) > 0.5f) {
                    controller1.rotationSpeed = -40f;
                }
                else {
                    controller1.rotationSpeed = 40f;
                }
                if (Random.Range(0, 1) > 0.5f) {
                    controller1.hspeed = -2f;
                }
                else {
                    controller1.hspeed = 2f;
                }
            }
        }
        else {
            SimpleBulletController controller1 = wall.GetComponent<SimpleBulletController>();
            controller1.haccel = -wall.transform.position[0] / 4f;
            if (wall.transform.position[1] > player.transform.position[1] + 2.4f) {
                controller1.vspeed = -1f;
            }
            else if (wall.transform.position[1] < player.transform.position[1] - 2.4f) {
                controller1.vspeed = 1f;
            }
            else {
                controller1.vspeed = 0;
            }
            controller1.reverse = true;
            if (spellTime == 799) {
                controller2.ChangePosition();
            }
        }

    }
    public void DestroyWall() {
        GameObject.Destroy(wall);
    }
}
