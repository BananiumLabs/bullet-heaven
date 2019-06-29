using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloScript : MonoBehaviour
{
    public float enlargeRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(enlargeRate, enlargeRate, enlargeRate);
        if(transform.localScale.x >= 0.6)
        {
            Destroy(gameObject);
        }
    }
}
