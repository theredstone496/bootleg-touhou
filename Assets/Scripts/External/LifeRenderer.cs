using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LifeRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    int lives;
    List<GameObject> lifeObjects;
    public GameObject lifeObject;
    void Start()
    {
        lifeObjects = new List<GameObject>();
        lives = GameObject.Find("player").GetComponent<PlayerController>().maxLives;
        for (int i = 0; i < lives; i++) {
            GameObject newLife = Instantiate(lifeObject);
            newLife.transform.SetParent(transform);
            newLife.transform.localPosition = new Vector3(1.75f * (i % 5), ((int) i / 5) * -1.75f, 0);
            lifeObjects.Add(newLife);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RemoveLives(int livesToRemove) {
        for (int i = 0; i < livesToRemove; i++) {
            if (lifeObjects.Count > 0) {
                Destroy(lifeObjects[lifeObjects.Count - 1]);
                lifeObjects.RemoveAt(lifeObjects.Count - 1);
            }
            else {
                GameObject.Find("LoseText").GetComponent<TMP_Text>().enabled = true;
                GameObject.Find("BackText").GetComponent<TMP_Text>().enabled = true;
                GameObject.Find("BackButton").GetComponent<BoxCollider2D>().enabled = true;
                GameObject.Find("BackButton").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
