using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObamaBombController : MonoBehaviour, BombController
{
    float imageAlpha;
    SpriteRenderer spriteRenderer;
    public float damage;
    public float scaleConstant;
    public float scaleMax;
    public float startScale;
    public int curveConstant;
    public float movementConstant; 
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        imageAlpha = 1f;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale[0] < startScale) {transform.localScale = new Vector3(startScale, startScale, 0);}
        transform.localScale += Mathf.Pow(((scaleMax - transform.localScale[0]) / scaleMax), curveConstant) * new Vector3(scaleConstant, scaleConstant, 0);
        transform.position += new Vector3(0, transform.localScale[0] * movementConstant, 0); 
        if (imageAlpha <= 0.01) {Destroy(gameObject);}
        spriteRenderer.color = new Color(1.0f,1.0f,1.0f,imageAlpha);
        imageAlpha -= 1 / duration;
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Enemy") {
            HealthController enemyHealthController = hitInfo.gameObject.GetComponent<HealthController>();
            enemyHealthController.RemoveHealth(damage);
           
        }
        
    }
    public bool IsInBomb(Vector3 pos) {
        float dist = Vector3.Distance(pos, this.transform.position);
        return dist < this.transform.localScale[0] * 0.43;
    }
}
