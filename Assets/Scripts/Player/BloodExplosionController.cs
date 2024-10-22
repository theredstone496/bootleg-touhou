using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodExplosionController : MonoBehaviour
{
    bool exploding;
    int time;
    float minDiameter;
    float maxDiameter;
    float minAlpha;
    float maxAlpha;
    float diameter;
    float alpha;
    SpriteRenderer spriteRenderer;
    int currentTime;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (exploding) {
            currentTime++;
            diameter += (maxDiameter - minDiameter) / time;
            alpha += (maxAlpha - minAlpha) / time;
            spriteRenderer.color = new Color(1.0f,1.0f,1.0f,alpha);
            transform.localScale = new Vector3(diameter, diameter, 1f);
            if (currentTime >= time) {
                Destroy(gameObject);
            }
        }
    }
    public void Explode(int time, float minDiameter, float maxDiameter, float minAlpha, float maxAlpha) {
        this.time = time;
        this.minDiameter = minDiameter;
        this.diameter = minDiameter;
        this.maxDiameter = maxDiameter;
        this.minAlpha = minAlpha;
        this.alpha = minAlpha;
        this.maxAlpha = maxAlpha;
        exploding = true;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f,minAlpha);
        transform.localScale = new Vector3(minDiameter, minDiameter, 1f);
    }
}
