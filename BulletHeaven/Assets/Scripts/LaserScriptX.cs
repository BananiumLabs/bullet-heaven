using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptX : MonoBehaviour
{
    // Start is called before the first frame updat
    public float speedIncrease;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(speedIncrease, 0, 0);
    }
}
