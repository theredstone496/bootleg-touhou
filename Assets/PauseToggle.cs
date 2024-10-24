using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MonoBehaviour[] objectsToPause = (MonoBehaviour[]) GameObject.FindObjectsOfType(typeof(MonoBehaviour));
            if (Time.timeScale == 0) {
                Debug.Log("unpaused");
                Time.timeScale = 1;
                foreach(MonoBehaviour script in objectsToPause) {
                    if (script != this && !script.GetType().IsSubclassOf(typeof(TMP_Text)) && !(script is FullScreenToggle) && !(script is BackController)) {
                        script.enabled = true;
                    }
                    
                }
                GameObject.Find("PauseBackText").GetComponent<TMP_Text>().enabled = false;
                GameObject.Find("PauseText").GetComponent<TMP_Text>().enabled = false;
                GameObject.Find("PauseBackButton").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("pausebackground").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("PauseBackButton").GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (Time.timeScale == 1) {
                Debug.Log("paused");
                Time.timeScale = 0;
                foreach(MonoBehaviour script in objectsToPause) {
                    if (script != this && !script.GetType().IsSubclassOf(typeof(TMP_Text)) && !(script is FullScreenToggle) && !(script is BackController)) {
                        script.enabled = false;
                    }
                }
                GameObject.Find("PauseBackText").GetComponent<TMP_Text>().enabled = true;
                GameObject.Find("PauseText").GetComponent<TMP_Text>().enabled = true;
                GameObject.Find("PauseBackButton").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("pausebackground").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("PauseBackButton").GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
