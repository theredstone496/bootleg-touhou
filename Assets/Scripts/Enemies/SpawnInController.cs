using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInController : MonoBehaviour
{
    public float startxpos;
    public float startypos;
    float xpos;
    float ypos;
    public float xspeed;
    public float yspeed;
    public int time;
    public float startAlpha;
    float alpha;
    int timeProg;
    public bool spawned;
    public bool moving;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        xpos = startxpos;
        ypos = startypos;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeProg >= time) {
            spawned = true;
        }
        else {
            timeProg += 1;
            if (startxpos != 0 && startypos != 0) {
                transform.position = new Vector3(xpos, ypos, 0);
            }
            xpos += xspeed * Time.deltaTime;
            ypos += yspeed * Time.deltaTime;
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,alpha);
            alpha = startAlpha + (1.0f - startAlpha) / time * timeProg;
            if (time == 0) {alpha = 1;}
        }
    }
}
