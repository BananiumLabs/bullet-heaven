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

        if(GameObject.Find("Player").GetComponent<PlayerHealth>().halos > 0) {
            if(Input.GetKey(KeyCode.L) || Input.GetKey("joystick button 3")|| Input.GetKey("joystick button 0"))
            {
                if (Time.time > nextBayonet)
                {
                    nextBayonet = Time.time + timeBtwnBayonets;
                    GameObject halo = Instantiate(Bayonet, transform.position, transform.rotation) as GameObject;
                    BayonetSource.Play();
                    GameObject.Find("Player").GetComponent<PlayerHealth>().halos--;
                }

            }
        }
    }
}
