using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLinePath : MonoBehaviour, IPath
{
    float xStart;
    float yStart;
    float angle;
    float speed;
    float distance;
    int time;
    int timeProg;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 15, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timeProg++;
    }
    public void SetPathParams(List<float> pathParams) {
        xStart = pathParams[0];
        yStart = pathParams[1];
        angle = pathParams[2];
        speed = pathParams[3];
        distance = pathParams[4];
        time =  (int) (distance / speed * 60);
    }
    public void Move() {
        transform.position = new Vector3(xStart + speed / 60 * timeProg * Mathf.Cos(angle * Mathf.Deg2Rad), yStart + speed / 60 * timeProg * Mathf.Sin(angle * Mathf.Deg2Rad), 0);
        if (timeProg > time) {Destroy(gameObject);}
        if (Mathf.Abs(transform.position[0]) > 40 || Mathf.Abs(transform.position[1]) > 40) {
            Destroy(gameObject);
        }
    }
}
