using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    private GameObject target;
    public GameObject shellExplosion;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.GetComponent<Transform>().position ) <= 1){
            Instantiate(shellExplosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Bullet"){
            Instantiate(shellExplosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
