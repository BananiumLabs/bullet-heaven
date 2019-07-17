using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealSpawner : MonoBehaviour
{
    public GameObject Reveal;
    private AudioSource RevealSource;
    public float nextReveal, timeBtwnReveals;
    
    // Start is called before the first frame update
    void Start()
    {
        RevealSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerHealth>().halos > 0) {
            if(Input.GetKey(KeyCode.L) || Input.GetKey("joystick button 3"))
            {
                if (Time.time > nextReveal)
                {
                    nextReveal = Time.time + timeBtwnReveals;
                    GameObject reav = Instantiate(Reveal, transform.position, transform.rotation) as GameObject;
                    //BayonetSource.Play();
                    GameObject.Find("Player").GetComponent<PlayerHealth>().halos--;
                    //Debug.Log("HEY FUCKO" + GameObject.Find("Player").GetComponent<PlayerHealth>().halos);
                }

            }
        }
    }
}
