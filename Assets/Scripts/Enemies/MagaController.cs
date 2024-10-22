using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagaController : MonoBehaviour
{
    bool created;
    bool exiting;
    float xspeed;
    float yspeed;
    SpriteRenderer spriteRenderer;
    SpawnInController spawnInController;
    DespawnController despawnController;
    GameObject player;
    AttackPattern attackPattern;
    AttackPattern movementPattern;
    public string attack;
    public GameObject usaBullet;
    Dictionary<string, AttackPattern> possibleAttacks;
    /*and so on...*/
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        created = false;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spawnInController = this.GetComponent<SpawnInController>();
        despawnController =  this.GetComponent<DespawnController>();
        possibleAttacks = new Dictionary<string, AttackPattern>();
        possibleAttacks.Add("revolver", new MagaRevolver(new GameObject[]{usaBullet}, gameObject));
        possibleAttacks.Add("shotgun", new MagaShotgun(new GameObject[]{usaBullet}, gameObject));
        possibleAttacks.Add("rifle", new MagaRifle(new GameObject[]{usaBullet}, gameObject));
        attackPattern = possibleAttacks[attack];
        movementPattern = new MagaMovement(new GameObject[]{}, gameObject);
    }

    // Update is called once per frame  
    void Update()
    {
        if (created) {
            if (spawnInController.moving) {
                transform.position += new Vector3(xspeed,yspeed, 0);
            }
            attackPattern.Update();
            movementPattern.Update();
            /*and so on*/
        }
        else {
            if (spawnInController.spawned) {
                created = true;
                despawnController.created = true;
            }
        }
        if (!exiting) {if (despawnController.exiting) {exiting = true;}}




        /*if spawn out */
        if (created && !exiting) {
            if (despawnController.exiting) {exiting = true;
                SpawnOutController spawnOut = this.GetComponent<SpawnOutController>();
                spawnOut.exiting = true;
            }
            
        }
    }
}
