using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOutController : MonoBehaviour
{
    float xpos;
    float ypos;
    public float xspeed;
    public float yspeed;
    public int time;
    public float alpha;
    public bool exiting;
    int timeProg;
    SpriteRenderer spriteRenderer;
    DespawnController despawnController;
    float r;
    float g;
    float b;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        despawnController = this.GetComponent<DespawnController>();
        Color color = spriteRenderer.color;
        r = color[0];
        g = color[1];
        b = color[2]; 
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnController.exiting) {
            xpos = transform.position[0];
            ypos = transform.position[1];
            if (timeProg >= time) {
                Destroy(gameObject);
            }
            else {
                timeProg += 1;
                transform.position = new Vector3(xpos, ypos, 0);
                xpos += xspeed * Time.deltaTime;
                ypos += yspeed * Time.deltaTime;
                spriteRenderer.color = new Color(r,g,b,alpha);
                alpha = 1.0f + (0.0f - 1.0f) / time * timeProg;
            }
        }
    }
}
