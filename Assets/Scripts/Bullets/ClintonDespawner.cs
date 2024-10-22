using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClintonDespawner : MonoBehaviour
{
    public GameObject clinton;
    public int stage;
    // Start is called before the first frame update
    void Start()
    {
        clinton = GameObject.Find("enemyclinton(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (clinton == null || clinton.GetComponent<ClintonController>().stage != stage) {
            Destroy(gameObject);
        }
    }
}
