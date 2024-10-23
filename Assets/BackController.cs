using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BackController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        GameObject.Find("BackText").GetComponent<TMP_Text>().color = new Color32(200, 200, 200, 255);
        GameObject.Find("PauseBackText").GetComponent<TMP_Text>().color = new Color32(200, 200, 200, 255);
    }
    private void OnMouseOver() 
    {
        if (Input.GetMouseButton(0)) 
        {
            Debug.Log("BACK HOME");
            if (Time.timeScale == 0) {
                Debug.Log("unpaused");
                Time.timeScale = 1;
            }
            SceneManager.LoadScene(sceneName:"StartScreen");
        }
    }
    private void OnMouseExit()
    {
        GameObject.Find("BackText").GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
        GameObject.Find("PauseBackText").GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
    }
}
