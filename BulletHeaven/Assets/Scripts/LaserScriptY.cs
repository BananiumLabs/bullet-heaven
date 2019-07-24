using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScriptY : MonoBehaviour
{

    public float speedIncrease;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0, speedIncrease, 0);
    }
}
