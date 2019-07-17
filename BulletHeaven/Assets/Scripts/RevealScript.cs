using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;
    }   
}
