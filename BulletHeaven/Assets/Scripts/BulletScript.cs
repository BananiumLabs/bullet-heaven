using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Transform trans;
    private Rigidbody2D rb;
    private bool collided;
    public float thrust;
    public AudioSource BulletDie;
    public AnimationClip anim;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!collided)
            rb.AddForce(trans.up * thrust);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Collision Detected");
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy") {
            collided=true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
            StartCoroutine(Die());
            //GetComponent<Animator>().enabled = true;
            //Destroy(gameObject);
        }
    }

    private IEnumerator Die(){
        GetComponent<Animator>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
        BulletDie.Play(0);
        //GetComponent<Rigidbody2D>().Sleep();
        yield return new WaitForSeconds(anim.length);
        Destroy(gameObject);
    }
}
