using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    //private int rand;
    public GameObject player, Vorpal, Shell, Lurker, Wraith, Fracture;

    public Sprite vorpalSprite, shellSprite, lurkerSprite, wraithSprite, fractureSprite;

    //public float nextSpawn;
    //public float spawnRate;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        /*if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            rand = Random.Range(1,3);
            if(rand == 1){
                GameObject Vorp = Instantiate(Vorpal, transform.position, transform.rotation) as GameObject;
                Vorp.GetComponent<EnemyTracking>().target = GameObject.Find("Player");
            }
            if(rand == 2){
                GameObject Shel = Instantiate(Shell, transform.position, transform.rotation) as GameObject;
                Shel.GetComponent<EnemyTracking>().target = GameObject.Find("Player");
            }
            if(rand == 3){
                GameObject Lurk = Instantiate(Lurker, transform.position, transform.rotation) as GameObject;
                Lurk.GetComponent<EnemyTracking>().target = GameObject.Find("Player");
            }
        }*/
    }

    public void Spawn (int enemy) {
        if (enemy == (int) MasterSpawner.Enemies.Vorpal) {
            GameObject Vorp = Instantiate (Vorpal, transform.position, transform.rotation) as GameObject;
            StartCoroutine (Blink (1, Vorp, vorpalSprite));
        }
        if (enemy == (int) MasterSpawner.Enemies.Shell) {
            GameObject Shel = Instantiate (Shell, transform.position, transform.rotation) as GameObject;
            StartCoroutine (Blink (1, Shel, shellSprite));
        }
        if (enemy == (int) MasterSpawner.Enemies.Lurker) {
            GameObject Lurk = Instantiate (Lurker, transform.position, transform.rotation) as GameObject;
            StartCoroutine (Blink (1, Lurk, lurkerSprite));
        }
        if (enemy == (int) MasterSpawner.Enemies.Wraith) {
            GameObject Wrai = Instantiate (Wraith, transform.position, transform.rotation) as GameObject;
            StartCoroutine (Blink (1, Wrai, wraithSprite));
        }
        if (enemy == (int) MasterSpawner.Enemies.Fracture) {
            GameObject Frac = Instantiate (Fracture, transform.position, transform.rotation) as GameObject;
            StartCoroutine (Blink (1, Frac, fractureSprite));
        }
    }

    IEnumerator Blink (float seconds, GameObject obj, Sprite spawnSprite) {
        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer> ();
        Sprite currSprite = renderer.sprite;

        obj.GetComponent<BoxCollider2D> ().enabled = false;

        try {
            obj.GetComponent<LurkerScript> ().enabled = false;
        } catch { }
        try {
            obj.GetComponent<ShellScript> ().enabled = false;
        } catch { }

        obj.GetComponent<EnemyTracking> ().enabled = false;

        for (int i = 0; i < seconds * 5; i++) {
            renderer.sprite = spawnSprite;
            yield return new WaitForSeconds (seconds / 5 / 2);
            renderer.sprite = currSprite;
            yield return new WaitForSeconds (seconds / 5 / 2);
        }

        try {
            obj.GetComponent<LurkerScript> ().enabled = true;
        } catch { }
        try {
            obj.GetComponent<ShellScript> ().enabled = true;
        } catch { }

        obj.GetComponent<EnemyTracking> ().enabled = true;
        obj.GetComponent<BoxCollider2D> ().enabled = true;
        obj.GetComponent<EnemyTracking> ().target = GameObject.Find ("Player");
    }
}