using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public int halos;
    public bool invincibility;
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start () {
        invincibility = false;
     }

    // Update is called once per frame
    void Update () {

    }

    void OnCollisionEnter2D (Collision2D collision) {
        Debug.Log ("Collision Detected");
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Explosion" || collision.gameObject.tag == "Trail") && !invincibility) {
            health--;
            hitSound.Play(0);
            StartCoroutine (Invincibility ());
        }
        if (health <= 0)
            SceneManager.LoadScene (2);
    }

    IEnumerator Invincibility () {
        int BLINK_COUNT = 20;
        //GetComponent<BoxCollider2D> ().enabled = false;
        invincibility = true;
        SpriteRenderer sprite = GetComponent<SpriteRenderer> ();

        for (int i = 0; i < BLINK_COUNT; i++) {
            // print("blink" + i);
            sprite.color = new Color (0, 0, 0, 0.5f);
            yield return new WaitForSeconds (2f / BLINK_COUNT / 2);
            sprite.color = new Color (1, 1, 1, 1f);
            yield return new WaitForSeconds (2f / BLINK_COUNT / 2);
        }
        invincibility = false;
        // yield return new WaitForSeconds(2f);
        //GetComponent<BoxCollider2D> ().enabled = true;

    }
}