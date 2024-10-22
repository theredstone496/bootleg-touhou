using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartController : MonoBehaviour
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
        GameObject.Find("StartText").GetComponent<TMP_Text>().color = new Color32(200, 200, 200, 255);
    }
    private void OnMouseOver() 
    {
        if (Input.GetMouseButton(0)) 
        {
            Debug.Log("START GAME");
            SceneManager.LoadScene (sceneName:"SampleScene");
        }
    }
    private void OnMouseExit()
    {
        GameObject.Find("StartText").GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
    }
}
