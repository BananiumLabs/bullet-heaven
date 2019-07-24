using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithScript : MonoBehaviour {
    private GameObject target;

    private bool isGhost = false;

    /// How close the player must be in order to attack
    public float attackRange = 5f;

    // Start is called before the first frame update
    void Start () {
        target = GameObject.Find ("Player");
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Vector2.Distance (transform.position, target.GetComponent<Transform> ().position) <= attackRange && isGhost) {
            GetComponent<BoxCollider2D> ().enabled = true;
            GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
            isGhost = false;
        } else if (Vector2.Distance (transform.position, target.GetComponent<Transform> ().position) > attackRange && !isGhost) {
            GetComponent<BoxCollider2D> ().enabled = false;
            GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
            isGhost = true;
        }
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Bullet" && !isGhost) {
            gameObject.SetActive (false);
        }
    }
}