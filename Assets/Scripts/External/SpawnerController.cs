using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<int> spawnTimes;
    public List<float> spawnX;
    public List<float> spawnXoffset;
    public List<float> spawnYoffset;
    public List<float> spawnY; 
    public List<float> spawnV;
    public List<float> spawnVoffset;
    public List<float> spawnAngles;
    public List<float> spawnAngleOffset;
    public List<float> startAlpha;
    public List<int> durations;
    public List<int> lifespans;
    public GameObject spawnObject;
    public GameObject pathObject;
    public List<float> pathParams;
    private int time;
    public int startTime;
    public float baseX;
    public float baseY;
    public float baseV;
    public float baseAngle;
    public int baseDuration;
    public int baseLifespan;
    public float baseAlpha;
    public int timeDiff;
    public bool active;
    StageAdvancer stageAdvancer;
    // Start is called before the first frame update
    void Start()
    {
        stageAdvancer = this.GetComponent<StageAdvancer>();
        time = -50;
        if (stageAdvancer.stageNumber != 1) {active = false;}
    }

    // Update is called once per frame
    void Update()
    {
        if (stageAdvancer.active && time >= startTime) {
            for (int i = 0; i < spawnTimes.Count; i++) {
                int spawnTime = startTime + spawnTimes[i] + timeDiff * i + 2;
                if (time == spawnTime) {
                    float X = spawnX[i] + Random.Range(-spawnXoffset[i], spawnXoffset[i]) + baseX;
                    float Y = spawnY[i] + Random.Range(-spawnYoffset[i], spawnYoffset[i]) + baseY;
                    float V = spawnV[i] + Random.Range(-spawnVoffset[i], spawnVoffset[i]) + baseV;
                    float angle = spawnAngles[i] + Random.Range(-spawnAngleOffset[i], spawnAngleOffset[i]) + baseAngle;
                    GameObject spawnedObject = Instantiate(spawnObject);
                    spawnedObject.transform.position = new Vector3(X, Y, 0);
                    SpawnInController spawnInController = spawnedObject.GetComponent<SpawnInController>();
                    DespawnController despawnController = spawnedObject.GetComponent<DespawnController>();
                    spawnInController.startxpos = X;
                    spawnInController.startypos = Y;
                    spawnInController.xspeed = V * Mathf.Cos(angle * Mathf.Deg2Rad);
                    spawnInController.yspeed = V * Mathf.Sin(angle * Mathf.Deg2Rad);
                    spawnInController.time = durations[i] + baseDuration;
                    spawnInController.startAlpha = startAlpha[i] + baseAlpha;
                    despawnController.lifespan = lifespans[i] + baseLifespan;
                    if (pathObject != null) {
                        GameObject path = Instantiate(pathObject);
                        spawnedObject.transform.SetParent(path.transform);
                        spawnedObject.transform.localPosition = new Vector3(0,0,0);
                        path.transform.position = new Vector3(X, Y, 0);
                        IPath pathController = (IPath) path.GetComponent<IPath>();
                        pathController.SetPathParams(pathParams);
                        spawnInController.moving = false;
                    }
                    stageAdvancer.enemies.Add(spawnedObject);

                }
                if (time < spawnTime) {
                    break;
                }
                if (i == spawnTimes.Count - 1 && time > spawnTime) {
                    this.enabled = false;
                    active = false;
                    break;
                }
            }
        }
        if (stageAdvancer.active) {time++;}
    }
    public void StartSpawn() {
        Debug.Log("started");
        active = true;
    }
}
