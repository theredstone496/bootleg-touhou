using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    int bombs;
    List<GameObject> bombObjects;
    public GameObject bombObject;
    void Start()
    {
        bombObjects = new List<GameObject>();
        bombs = GameObject.Find("player").GetComponent<PlayerController>().maxBombs;
        for (int i = 0; i < bombs; i++) {
            GameObject newBomb = Instantiate(bombObject);
            newBomb.transform.SetParent(transform);
            newBomb.transform.localPosition = new Vector3(1.75f * (i % 5), ((int) i / 5) * -1.75f, 0);
            bombObjects.Add(newBomb);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemoveBomb() {
        if (bombObjects.Count > 0) {
            Destroy(bombObjects[bombObjects.Count - 1]);
            bombObjects.RemoveAt(bombObjects.Count - 1);
        }
        
    }
    public void RestoreBombs(int amount) {
        for (int i = 0; i< amount; i++) {
            GameObject newBomb = Instantiate(bombObject);
            newBomb.transform.SetParent(transform);
            newBomb.transform.localPosition = new Vector3(1.75f * (bombObjects.Count % 5), ((int) bombObjects.Count / 5) * -1.75f, 0);
            bombObjects.Add(newBomb);
        }
    }
}
