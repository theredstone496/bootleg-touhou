using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterController : MonoBehaviour
{
    //0 - Biden
    //1 - Osama
    //2 - Bush
    public List<int> stage1;
    public List<int> stage2;
    public List<int> stage3;
    public List<int> stage4;
    public List<int> stage5;
    public List<int> stage6;
    public List<int> stage7;
    public List<int> stage8;
    public List<int> enemykilled;
    public List<GameObject> enemySpawners;
    List<List<int>> stageCounts;
    public int enemyCount;
    public int currentStage;
    // Start is called before the first frame update
    void Start()
    {
        stageCounts.Add(stage1);
        stageCounts.Add(stage2);
        stageCounts.Add(stage3);
        stageCounts.Add(stage4);
        stageCounts.Add(stage5);
        stageCounts.Add(stage6);
        stageCounts.Add(stage7);
        stageCounts.Add(stage8);
    }

    // Update is called once per frame
    void Update()
    {
        bool advancing = true;
        for (int i = 0; i < enemyCount; i++) {
            
        }
        
    }
}
