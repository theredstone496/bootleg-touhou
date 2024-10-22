using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpWall2Controller : MonoBehaviour
{
    bool converting = false;
    public GameObject wallHalf;
    List<GameObject> walls;
    float angleReference = 0f;
    float length = 3.8f;
    public float scale = 0.5f;
    bool bulletBlocking = false;
    // Start is called before the first frame update
    void Start()
    {
        
        walls = new List<GameObject>();
        for (int i = 0; i < 3; i++){
            TrumpDespawner despawner = GetComponent<TrumpDespawner>();
            float angle = 120 * i;
            GameObject wallTop = Instantiate(wallHalf);

            wallTop.transform.SetParent(transform);
            wallTop.transform.localPosition = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * length * 0.5f;
            wallTop.transform.localEulerAngles = new Vector3(0, 0, 270 - angle);
            wallTop.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            TrumpDespawner topDespawner = wallTop.GetComponent<TrumpDespawner>();
            topDespawner.stage = despawner.stage;
            walls.Add(wallTop);
        }
        //ChangePosition();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++) {
            Debug.Log("bullet blocking" + bulletBlocking);
            walls[i].GetComponent<BulletBlockController>().blocking = bulletBlocking;
        }
        transform.localScale = new Vector3(1,1,1) * scale;
        if (angleReference >= 90) {
            converting = false;
            angleReference = 0;
        }
        if (converting) {
            if (angleReference <= 44.5) {
                length += (44.5f - angleReference) / 300f;
            }
            else {
                length -= (angleReference - 45) / 300f;
            } 
            for (int i = 0; i < 3; i++){
                walls[i].transform.localEulerAngles = new Vector3(0, 0, walls[i].transform.localEulerAngles[2]+0.5f);
            }
            angleReference += 0.5f;
        }
        for (int i = 0; i < 3; i++){
            float angle = 120 * i;
            walls[i].transform.localPosition = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad)) * length * 0.5f;
            walls[i].transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
        }
    }
    public void ChangePosition() {
        converting = true;

    }
    public void SetScale(float sca) {
        scale = sca;
    }

    public void SetBulletBlocking(bool block = false) {
        Debug.Log("set bullet block");
        bulletBlocking = block;
    }
       
}
