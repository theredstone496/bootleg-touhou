using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageAdvancer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies;
    public bool active;
    public int stageNumber;
    public int enemyCount;
    public int timeToNext;
    private int time;
    void Start()
    {
        if (stageNumber != 1) {active = false;}
        else {active = true;}
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            time++;
            if (enemies.Count >= enemyCount) {
                bool dead = true;
                for (int i = 0; i < enemies.Count; i++) {
                    if (enemies[i] != null && !enemies[i].GetComponent<HealthController>().destroyed) {
                        dead = false;
                        break;
                    }
                } 
                if (dead) {
                    EndSpawn();
                }
            }
            if (time >= timeToNext) {
                EndSpawn();
            }
        }
    }
    public void StartSpawn() {
        active = true;
    }
    public void EndSpawn() {
        GameObject stageCounter = GameObject.Find("stagecounter");
        GameObject nextStage = GameObject.Find("stage" + (stageNumber + 1).ToString());
        if (nextStage != null) {
            nextStage.GetComponent<StageAdvancer>().StartSpawn();
            if (stageCounter != null) {(stageCounter.GetComponent<TextMeshProUGUI>()).text = (stageNumber + 1).ToString();}
        }
        else {
            GameObject.Find("player").GetComponent<PlayerController>().Win();
        }
        this.enabled = false;
        active = false;
    }
}
