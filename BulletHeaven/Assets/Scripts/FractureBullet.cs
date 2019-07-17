using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureBullet : MonoBehaviour
{

    private Transform trans;
    private Rigidbody2D rb;
    private bool collided;
    public float thrust;
    public AudioSource BulletDie;
    public AnimationClip anim;
    public int durability;
    public int hitCount;
    public bool wallTilDead;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collided = false;
        hitCount = 0;
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
        if(!wallTilDead)
        {
            hitCount++;
            if((collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player") && (durability <= hitCount)) {
                collided=true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0f;
                StartCoroutine(Die());
                //GetComponent<Animator>().enabled = true;
                //Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Wall")
        {
            collided=true;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<Rigidbody2D>().angularVelocity = 0f;
                StartCoroutine(Die());
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
