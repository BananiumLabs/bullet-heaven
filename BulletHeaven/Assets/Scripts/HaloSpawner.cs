using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloSpawner : MonoBehaviour
{
    public GameObject Halo;
    private AudioSource HaloSource;
    public float nextHalo, timeBtwnHalos;
    // Start is called before the first frame update
    void Start()
    {
        HaloSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerHealth>().halos > 0) {
            if(Input.GetKey(KeyCode.L) || Input.GetKey("joystick button 3")|| Input.GetKey("joystick button 0"))
            {
                if (Time.time > nextHalo)
                {
                    nextHalo = Time.time + timeBtwnHalos;
                    GameObject halo = Instantiate(Halo, transform.position, transform.rotation) as GameObject;
                    HaloSource.Play();
                    GameObject.Find("Player").GetComponent<PlayerHealth>().halos--;
                }

            }
        }
    }
}
