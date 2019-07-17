using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureScript : MonoBehaviour {
    private GameObject target;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start () {
        target = GameObject.Find ("Player");
    }

    // Update is called once per frame
    void Update () {
        if (Vector2.Distance (transform.position, target.GetComponent<Transform> ().position) <= 1) {
            Die ();
        }
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            Die ();
        }
    }

    void Die () {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90f));
        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 180f));
        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 270f));
    gameObject.SetActive (false);
}
}