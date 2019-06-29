using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LurkerScript : MonoBehaviour
{
    public float timeBtwnTrail;
    private float nextTrail;
    public GameObject lurkerTrail;
    // Start is called before the first frame update
    void Start()
    {
        nextTrail = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTrail)
        {
            nextTrail = Time.time + timeBtwnTrail;
            GameObject halo = Instantiate(lurkerTrail, transform.position, transform.rotation) as GameObject;
        }
    }
}
