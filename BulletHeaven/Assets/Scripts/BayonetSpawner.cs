using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayonetSpawner : MonoBehaviour
{
    public GameObject Bayonet;
    private AudioSource BayonetSource;
    public float nextBayonet, timeBtwnBayonets;
    
    // Start is called before the first frame update
    void Start()
    {
        BayonetSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.K) || Input.GetKey("joystick button 0"))
        {
            if (Time.time > nextBayonet)
            {
                nextBayonet = Time.time + timeBtwnBayonets;
                GameObject bayo = Instantiate(Bayonet, transform.position, transform.rotation) as GameObject;
                //BayonetSource.Play();
                //GameObject.Find("Player").GetComponent<PlayerHealth>().halos--;
                //Debug.Log("HEY FUCKO" + GameObject.Find("Player").GetComponent<PlayerHealth>().halos);
            }

        }
    }
}
