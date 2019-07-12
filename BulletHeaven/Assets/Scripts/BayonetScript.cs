using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayonetScript : MonoBehaviour
{
    public float speedRotate;
    public float time;

    public AudioSource slash;

    //public Quaternion initalRotation;
    //private bool inital;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
        //initalRotation = transform.rotation;
        //inital = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").GetComponent<Transform>().position;
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        
        //Debug.Log(transform.rotation.z);
        //if(transform.rotation.z <= 0f)
           // Destroy(gameObject);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        slash.Play(0);
    }
}
