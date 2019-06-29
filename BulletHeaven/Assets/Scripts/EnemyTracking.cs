using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTracking : MonoBehaviour
{
    public  GameObject target;
    public float speed;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (target.transform.position - transform.position).normalized;
        transform.position += moveDir * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Collision Detected");
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Explosion")
            health--;
        if(health == 0){
            ScoreCounter.Score+=(ScoreCounter.Bounty * 100);
            ScoreCounter.EnemiesKilled++;
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Trigger Detected");
        if(other.gameObject.tag == "Halo")
            health--;
        if(health == 0){
            ScoreCounter.Score+=(ScoreCounter.Bounty * 100);
            ScoreCounter.EnemiesKilled++;
            Destroy(gameObject);
            //ScoreCounter.Score+=100;
        }
        
    }

}
